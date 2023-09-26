using web_ecommerce.RequestResponseModels.Orders;

namespace web_ecommerce.Business;

public interface IOrderBusiness
{
    public Task<Guid> CreateOrder(CreateOrderRequestModel model);
    public Task DeleteOrder(Guid orderId);
    public IEnumerable<OrderResponseModel> ViewOrders();
}