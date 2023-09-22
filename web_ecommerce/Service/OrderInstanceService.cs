using System.Security;
using web_ecommerce.Database;
using web_ecommerce.Entities;
using web_ecommerce.RequestResponseModels.OrderInstances;

namespace web_ecommerce.Service;

public class OrderInstanceService : IOrderInstanceService
{
    private readonly IGenericRepository<OrderInstance> _repository;
    private readonly IGenericRepository<UserProduct> _userProductRepository;

    public OrderInstanceService(IGenericRepository<OrderInstance> repository,IGenericRepository<UserProduct> userProductRepository)
    {
        _repository = repository;
        _userProductRepository = userProductRepository;
    }

    public async Task<OrderInstanceResponseModel> ViewOrderDetails(Guid orderId)
    {
        var order = await _repository.Get(x => x.OrderId == orderId) ??
                    throw new SlnException("girdiğiniz id ile sipariş bulunamadı");
        return order.MapToModel();
    }


    public async Task<Guid> CreateOrderInstance(CreateOrderInstanceRequestModel model)
    {
        var userProduct = await GetUserProduct(model.UserProductId);
        var orderInstanceId = await _repository.Add(MapToEntity(model, userProduct));
        userProduct.Unit = userProduct.Unit - 1;
        await _userProductRepository.Update(userProduct);
        await _repository.SaveChange();
        return orderInstanceId;
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

    public IEnumerable<OrderInstanceResponseModel> View()
    {
        return _repository.GetAll(null).Select(x => x.MapToModel());
    }
}