using web_ecommerce.RequestResponseModels.Orders;

namespace web_ecommerce.Business;

public interface IOrderBusiness
{
    public Task<Guid> CreateOrder(CreateOrderRequestModel model);
    public Task DeleteOrder(Guid orderId);
    public Task ChangeOrderStatus(ChangeOrderStatusRequestModel model);
    public IEnumerable<OrderResponseModel> ViewOrders();
}