using System.Collections;
using web_ecommerce.Database;
using web_ecommerce.Entities;
using web_ecommerce.RequestResponseModels.OrderInstances;

namespace web_ecommerce.Service;

public class OrderInstanceService : IOrderInstanceService
{
    private readonly IGenericRepository<OrderInstance> _repository;
    private readonly IGenericRepository<UserProduct> _userProductRepository;
    private readonly IOrderService _orderService;

    public OrderInstanceService(IGenericRepository<OrderInstance> repository,IGenericRepository<UserProduct> userProductRepository, IOrderService orderService)
    {
        _repository = repository;
        _userProductRepository = userProductRepository;
        _orderService = orderService;
    }

    public async Task<IEnumerable> ViewOrderDetails(Guid orderId)
    {
        await _orderService.CheckOrder(orderId);
        return _repository.GetAll(x => x.OrderId == orderId).ToList().Select(x => x.MapToModel());
    }


    public async Task<Guid> CreateOrderInstance(CreateOrderInstanceRequestModel model)
    {
        await _orderService.CheckOrder(model.OrderId);
        var userProduct = await GetUserProduct(model.UserProductId);
        var orderInstanceId = await _repository.Add(MapToEntity(model, userProduct));
        userProduct.Unit = userProduct.Unit - 1;
        await _userProductRepository.Update(userProduct);
        await _repository.SaveChange();
        return orderInstanceId;
    }
    
    public IEnumerable<OrderInstanceResponseModel> View()
    {
        return _repository.GetAll(null).Select(x => x.MapToModel());
    }

    public async Task<UserProduct> GetUserProduct(Guid id)
    {
        return await _userProductRepository.Get(x => x.Id == id) ??
               throw new SlnException("İşlem yapmak istediğiniz ürün bulunamadı");
    }

    private static OrderInstance MapToEntity(CreateOrderInstanceRequestModel model,UserProduct userProduct)
    {
        return new OrderInstance
        {
            Id = Guid.NewGuid(),
            OrderId = model.OrderId,
            UserProductId = model.UserProductId,
            OrderPrice = userProduct.Price,
            OrderUnit = model.OrderUnit
        };
    }
}