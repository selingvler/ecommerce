using System.Collections;
using web_ecommerce.Database;
using web_ecommerce.Entities;
using web_ecommerce.RequestResponseModels.OrderInstances;

namespace web_ecommerce.Service;

public class OrderInstanceService : IOrderInstanceService
{
    private readonly IGenericRepository<OrderInstance> _repository;
    private readonly IGenericRepository<UserProduct> _userProductRepository;
    private readonly IGenericRepository<Order> _orderRepository;
    private readonly IProductService _productService;

    public OrderInstanceService(IGenericRepository<OrderInstance> repository,IGenericRepository<UserProduct> userProductRepository, IGenericRepository<Order> orderRepository, IProductService productService)
    {
        _repository = repository;
        _userProductRepository = userProductRepository;
        _orderRepository = orderRepository;
        _productService = productService;
    }
    public async Task CreateOrderInstance(CreateOrderInstanceRequestModel model)
    {
        var order = await _orderRepository.Get(x => x.Id == model.OrderId) ??
                    throw new SlnException("İşlem yapmak istediğiniz kayıt bulunamadı");
        if (order.OrderStatus != "waiting")
        {
            throw new SlnException(
                "Durumu approved, returned, in process ve completed olan siparişlere ürün eklemesi yapılamaz");
        }
        await _productService.CheckProduct(model.ProductId);
        var count = _userProductRepository.GetAll(x => x.ProductId == model.ProductId).ToList().Count;
        var i = 0;
        var userProduct = _userProductRepository.GetAll(x => x.ProductId == model.ProductId).ToList()
            .OrderBy(x => x.Price).ElementAt(0);
        if (userProduct.Unit < model.OrderUnit)
        {
            var condition = false;
            var unit = model.OrderUnit;
            do
            {
                var product = _userProductRepository.GetAll(x => x.ProductId == model.ProductId).ToList()
                    .OrderBy(x => x.Price).ElementAt(i);
                if (model.OrderUnit > product.Unit) model.OrderUnit = product.Unit;
                await _repository.Add(MapToEntity(model, product));
                await _repository.SaveChange();
                model.OrderUnit = unit; 
                if (model.OrderUnit - product.Unit <= 0) condition = true; 
                if (condition == true) break;
                model.OrderUnit -= product.Unit; 
                unit = model.OrderUnit; 
                i++;
                if (i < count) continue;
                {
                    var list = _userProductRepository.GetAll(x => x.ProductId == model.ProductId).ToList();
                    var stock = list.Sum(item => item.Unit);
                    throw new SlnException("Stokta bu üründen " + stock + " adet bulunmaktadır. Sepetinize stok adedi kadar eklenmiştir.");
                }
            } while (condition == false);
        }
        else
        {
            await _repository.Add(MapToEntity(model, userProduct));
            await _repository.SaveChange();
        }
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
        var result = (from userProduct in productList from instance in approvedInstances where instance.UserProductId == userProduct.Id select instance).ToList();
        return result.Select(x=>x.MapToModel());
    }

    public async Task OrderInstanceSellerResponse(OrderInstanceInProcessModel model)
    {
        var orderInstance = await _repository.Get(x => x.Id == model.OrderInstanceId) ??
                            throw new SlnException("İşlem yapmak istediğiniz kayıt bulunamadı");
        var userProduct = await _userProductRepository.Get(x => x.Id == orderInstance.UserProductId) ??
                          throw new SlnException("Sipariş kaleminin içinde ürün bulunmamaktadır");
        if (orderInstance.Status != "approved")
            throw new SlnException("Sipariş müşteri tarafından onaylanmadan işlem yapamazsınız");
        
        if (userProduct.UserId != model.UserId)
            throw new SlnException("Sadece kendi ürününüze onay verebilir ya da reddedebilirsiniz");
        
        switch (model.SellerResponse)
        {
            case "in process":
                if (userProduct.Unit <= 0)
                {
                    await _repository.Delete(orderInstance);
                    await _repository.SaveChange();
                    throw new SlnException("Satın almak istediğiniz üründe stok kalmamıştır");
                }
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
            order!.OrderStatus = orderInstances[0].Status; //
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
        if (order!.UserId != model.UserId) //
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