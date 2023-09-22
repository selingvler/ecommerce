using web_ecommerce.Entities;
using web_ecommerce.RequestResponseModels.OrderInstances;

namespace web_ecommerce.Business;

public interface IOrderInstanceBusiness
{
    public Task<Guid> CreateOrderInstance(CreateOrderInstanceRequestModel model);
    public Task<OrderInstanceResponseModel> ViewOrderDetails(Guid orderId);
    public IEnumerable<OrderInstanceResponseModel> View();
}