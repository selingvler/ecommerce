using System.Collections;
using web_ecommerce.Entities;
using web_ecommerce.RequestResponseModels.OrderInstances;

namespace web_ecommerce.Service;

public interface IOrderInstanceService
{
    public Task<Guid> CreateOrderInstance(CreateOrderInstanceRequestModel model);
    public Task<IEnumerable> ViewOrderDetails(Guid orderId);
    public IEnumerable<OrderInstanceResponseModel> View();
    public Task DeleteOrderInstance(Guid id);
    public IEnumerable WaitingForApproval(Guid userId);
    public Task OrderInstanceSellerResponse(OrderInstanceInProcessModel model);
}