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
    private readonly IProductService _productService;

    public OrderInstanceService(IGenericRepository<OrderInstance> repository,IGenericRepository<UserProduct> userProductRepository, IOrderService orderService, IUserProductService userProductService, IProductService productService)
    {
        _repository = repository;
        _userProductRepository = userProductRepository;
        _orderService = orderService;
        _userProductService = userProductService;
        _productService = productService;
    }

    public async Task<Guid> CreateOrderInstance(CreateOrderInstanceRequestModel model)
    {
        await _orderService.CheckOrder(model.OrderId);
        await _productService.CheckProduct(model.ProductId);
        var userProduct = _userProductService.GetCheapestUserProduct(model.ProductId);
        var orderInstance = MapToEntity(model, userProduct);
        var orderInstanceId = await _repository.Add(orderInstance);
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

    public async Task DeleteOrderInstance(Guid id)
    {
        var orderInstance = await _repository.Get(x => x.Id == id);
        await _repository.Delete(orderInstance);
        await _repository.SaveChange();
    }
    private static OrderInstance MapToEntity(CreateOrderInstanceRequestModel model,UserProduct userProduct)
    {
        return new OrderInstance
        {
            Id = Guid.NewGuid(),
            OrderId = model.OrderId,
            UserProductId = userProduct.Id,
            OrderPrice = userProduct.Price,
            OrderUnit = model.OrderUnit,
            Status = "waiting"
        };
    }
}