using web_ecommerce.Database;
using web_ecommerce.Entities;
using web_ecommerce.RequestResponseModels.Orders;

namespace web_ecommerce.Service;

public class OrderService : IOrderService
{
    private readonly IGenericRepository<Order> _repository;

    public OrderService(IGenericRepository<Order> repository)
    {
        _repository = repository;
    }

    public async Task<Guid> AddOrder(Guid userId)
    {
        var id = await _repository.Add(userId.MapToEntity());
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
}