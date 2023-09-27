using System.Collections;
using web_ecommerce.RequestResponseModels.OrderInstances;

namespace web_ecommerce.Business;

public interface IOrderInstanceBusiness
{
    public Task<IEnumerable> ViewOrderDetails(Guid orderId);
    public IEnumerable<OrderInstanceResponseModel> View();
    public Task DeleteOrderInstance(Guid id);
    public Task<IEnumerable> WaitingForApproval(Guid userId);
    public Task OrderInstanceSellerResponse(OrderInstanceInProcessModel model);
    public Task ReturnOrderInstance(ReturnOrderInstanceModel model);
    public Task CreateOrderInstance(CreateOrderInstanceRequestModel model);
}