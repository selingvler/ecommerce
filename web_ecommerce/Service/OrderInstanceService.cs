using System.Collections;
using web_ecommerce.Database;
using web_ecommerce.Entities;
using web_ecommerce.RequestResponseModels.OrderInstances;

namespace web_ecommerce.Service;

public class OrderInstanceService : IOrderInstanceService
{
    private readonly IGenericRepository<OrderInstance> _repository;
    private readonly IGenericRepository<UserProduct> _userProductRepository;
    private readonly IUserProductService _userProductService;
    private readonly IGenericRepository<Order> _orderRepository;
    private readonly IProductService _productService;

    public OrderInstanceService(IGenericRepository<OrderInstance> repository,IGenericRepository<UserProduct> userProductRepository, IGenericRepository<Order> orderRepository, IUserProductService userProductService, IProductService productService)
    {
        _repository = repository;
        _userProductRepository = userProductRepository;
        _orderRepository = orderRepository;
        _userProductService = userProductService;
        _productService = productService;
    }

    public async Task<Guid> CreateOrderInstance(CreateOrderInstanceRequestModel model)
    {
        var order = await _orderRepository.Get(x => x.Id == model.OrderId) ??
                    throw new SlnException("İşlem yapmak istediğiniz kayıt bulunamadı");
        await _productService.CheckProduct(model.ProductId);
        var userProduct = _userProductService.GetCheapestUserProduct(model.ProductId);
        var orderInstanceId = await _repository.Add(MapToEntity(model, userProduct));
        await _repository.SaveChange();
        return orderInstanceId;
    }
    
    public async Task<IEnumerable> ViewOrderDetails(Guid orderId)
    {
        var order = await _orderRepository.Get(x => x.Id == orderId) ??
                    throw new SlnException("İşlem yapmak istediğiniz kayıt bulunamadı");
        return _repository.GetAll(x => x.OrderId == orderId).ToList().Select(x => x.MapToModel());
    }
    
    public IEnumerable<OrderInstanceResponseModel> View()
    {
        return _repository.GetAll(null).Select(x => x.MapToModel());
    }

    public async Task DeleteOrderInstance(Guid id)
    {
        var orderInstance = await _repository.Get(x => x.Id == id) ??
                            throw new SlnException("İşlem yapmak istediğiniz kayıt bulunamadı");
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

    public IEnumerable WaitingForApproval(Guid userId)
    {
        var productList = _userProductRepository.GetAll(x => x.UserId == userId).ToList();
        var approvedInstances = _repository.GetAll(x => x.Status == "approved").ToList();
        var result = new List<OrderInstance>();
        foreach (var userProduct in productList)
        {
            foreach (var instance in approvedInstances)
            {
                if (instance.UserProductId == userProduct.Id)
                {
                    result.Add(instance);
                }
            }
        }
        return result.Select(x=>x.MapToModel());
    }

    public async Task OrderInstanceSellerResponse(OrderInstanceInProcessModel model)
    {
        var orderInstance = await _repository.Get(x => x.Id == model.OrderInstanceId) ??
                            throw new SlnException("İşlem yapmak istediğiniz kayıt bulunamadı");
        var userProduct = await _userProductRepository.Get(x => x.Id == orderInstance.UserProductId) ??
                          throw new SlnException("Sipariş kaleminin içinde ürün bulunmamaktadır");
        if (orderInstance.Status != "approved")
        {
            throw new SlnException("Sipariş müşteri tarafından onaylanmadan işlem yapamazsınız");
        }
        if (userProduct.UserId != model.UserId)
        {
            throw new SlnException("Sadece kendi ürününüze onay verebilir ya da reddedebilirsiniz");
        }
        
        switch (model.SellerResponse)
        {
            case "in process":
                userProduct.Unit -= orderInstance.OrderUnit;
                await _userProductRepository.Update(userProduct);
                orderInstance.Status = "in process";
                await _repository.Update(orderInstance);
                await _repository.SaveChange();
                break;
            case "declined":
                await _repository.Delete(orderInstance);
                await _repository.SaveChange();
                break;
        }
        
        var order = await _orderRepository.Get(x=>x.Id == orderInstance.OrderId);
        var orderInstances = _repository.GetAll(x => x.OrderId == orderInstance.OrderId).ToList();
        var count = orderInstances.GroupBy(x => x.Status).Count();
        if (count==1)
        {
            order.OrderStatus = orderInstances[0].Status;
            await _orderRepository.Update(order);
            await _orderRepository.SaveChange();
        }
    }

    public async Task ReturnOrderInstance(ReturnOrderInstanceModel model)
    {
        var orderInstance = await _repository.Get(x => x.Id == model.OrderInstanceId) ??
                            throw new SlnException("İşlem yapmak istediğiniz kayıt bulunamadı");
        var userProduct = await _userProductRepository.Get(x => x.Id == orderInstance.UserProductId) ??
                          throw new SlnException("Sipariş kaleminin içinde ürün bulunmamaktadır");
        
        var order = await _orderRepository.Get(x => x.Id == orderInstance.OrderId);
        if (order.UserId != model.UserId)
        {
            throw new SlnException("Sadece kendinize ait siparişin ürününü iade edebilirsiniz");
        }
        
        orderInstance.Status = "returned";
        await _repository.Update(orderInstance);
        userProduct.Unit += orderInstance.OrderUnit;
        await _userProductRepository.Update(userProduct);
        await _repository.SaveChange();

        var orderInstances = _repository.GetAll(x => x.OrderId == order.Id).ToList();
        var count = orderInstances.GroupBy(x => x.Status).Count();
        if (count == 1)
        {
            order.OrderStatus = orderInstances[0].Status;
            await _orderRepository.Update(order);
            await _orderRepository.SaveChange();
        }
    }
}