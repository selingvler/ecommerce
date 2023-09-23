using web_ecommerce.RequestResponseModels.Orders;

namespace web_ecommerce.Service;

public interface IOrderService
{
    public Task<Guid> AddOrder(Guid userId);
    public Task DeleteOrder(Guid orderId);
    public IEnumerable<OrderResponseModel> ViewOrders();
    public Task CheckOrder(Guid id);
}