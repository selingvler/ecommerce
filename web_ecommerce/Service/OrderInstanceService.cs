using System.Collections;
using web_ecommerce.Database;
using web_ecommerce.Entities;
using web_ecommerce.RequestResponseModels.OrderInstances;

namespace web_ecommerce.Service;

public class OrderInstanceService : IOrderInstanceService
{
    private readonly IGenericRepository<OrderInstance> _repository;
    private readonly IGenericRepository<UserProduct> _userProductRepository;
    private IUserProductService _userProductService;
    private readonly IOrderService _orderService;

    public OrderInstanceService(IGenericRepository<OrderInstance> repository,IGenericRepository<UserProduct> userProductRepository, IOrderService orderService, IUserProductService userProductService)
    {
        _repository = repository;
        _userProductRepository = userProductRepository;
        _orderService = orderService;
        _userProductService = userProductService;
    }

    public async Task<Guid> CreateOrderInstance(CreateOrderInstanceRequestModel model)
    {
        await _orderService.CheckOrder(model.OrderId);
        var userProduct = _userProductService.GetCheapestUserProduct(model.ProductId);
        var orderInstanceId = await _repository.Add(MapToEntity(model, userProduct));
        if (model.OrderStatus != "approved") return orderInstanceId;
        userProduct.Unit = userProduct.Unit - 1;
        await _userProductRepository.Update(userProduct);
        await _repository.SaveChange();
        return orderInstanceId;
    }
    
    public async Task<IEnumerable> ViewOrderDetails(Guid orderId)
    {
        await _orderService.CheckOrder(orderId);
        return _repository.GetAll(x => x.OrderId == orderId).ToList().Select(x => x.MapToModel());
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
            UserProductId = userProduct.Id,
            OrderPrice = userProduct.Price,
            OrderUnit = model.OrderUnit
        };
    }
}