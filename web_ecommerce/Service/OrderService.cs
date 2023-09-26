using web_ecommerce.Database;
using web_ecommerce.Entities;
using web_ecommerce.RequestResponseModels.Orders;

namespace web_ecommerce.Service;

public class OrderService : IOrderService
{
    private readonly IGenericRepository<Order> _repository;
    private readonly IGenericRepository<OrderInstance> _orderInstanceRepository;

    public OrderService(IGenericRepository<Order> repository, IGenericRepository<OrderInstance> orderInstanceRepository)
    {
        _repository = repository;
        _orderInstanceRepository = orderInstanceRepository;
    }

    public async Task<Guid> AddOrder(CreateOrderRequestModel model)
    {
        var id = await _repository.Add(model.MapToEntity());
        await _repository.SaveChange();
        return id;
    }

    public async Task DeleteOrder(Guid orderId)
    {
        var order = await _repository.Get(x => x.Id == orderId) ??
                 throw new SlnException("İşlem yapmak istediğiniz kayıt bulunamadı");
        await _repository.Delete(order);
        await _repository.SaveChange();
    }

    public IEnumerable<OrderResponseModel> ViewOrders()
    {
        return _repository.GetAll(null).Select(x => x.MapToModel());
    }

    public async Task ChangeOrderStatus(ChangeOrderStatusRequestModel model)
    {
        var order = await _repository.Get(x => x.Id == model.OrderId) ??
                    throw new SlnException("İşlem yapmak istediğiniz kayıt bulunamadı");
        if (model.UserId != order.UserId)
        {
            throw new SlnException("Sadece kendi siparişiniz durumunu değiştirebilirsiniz");
        }
        
        order.OrderStatus = model.OrderStatus;
        await _repository.Update(order);
        await _repository.SaveChange();
        var list = _orderInstanceRepository.GetAll(x => x.OrderId == model.OrderId).ToList();
        foreach (var orderInstance in list.Where(orderInstance => orderInstance.Status != order.OrderStatus))
        {
            orderInstance.Status = order.OrderStatus;
            await _orderInstanceRepository.Update(orderInstance);
            await _orderInstanceRepository.SaveChange();
        }
    }

    public async Task CheckOrder(Guid id)
    {
        var order = await _repository.Get(x => x.Id == id) ??
            throw new SlnException("İşlem yapmak istediğiniz kayıt bulunmadı");
    }
}