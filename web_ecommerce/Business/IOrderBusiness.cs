using web_ecommerce.RequestResponseModels.Orders;

namespace web_ecommerce.Business;

public interface IOrderBusiness
{
    public Task<Guid> CreateOrder(Guid userId);
    public Task DeleteOrder(Guid orderId);
    public IEnumerable<OrderResponseModel> ViewOrders();
}