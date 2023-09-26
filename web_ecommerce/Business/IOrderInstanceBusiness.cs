using System.Collections;
using web_ecommerce.RequestResponseModels.OrderInstances;

namespace web_ecommerce.Business;

public interface IOrderInstanceBusiness
{
    public Task<Guid> CreateOrderInstance(CreateOrderInstanceRequestModel model);
    public Task<IEnumerable> ViewOrderDetails(Guid orderId);
    public IEnumerable<OrderInstanceResponseModel> View();
    public Task DeleteOrderInstance(Guid id);
}