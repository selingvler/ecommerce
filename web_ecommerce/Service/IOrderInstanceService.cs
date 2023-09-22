using web_ecommerce.Entities;
using web_ecommerce.RequestResponseModels.OrderInstances;

namespace web_ecommerce.Service;

public interface IOrderInstanceService
{
    public Task<Guid> CreateOrderInstance(CreateOrderInstanceRequestModel model);
    public Task<OrderInstanceResponseModel> ViewOrderDetails(Guid orderId);
    public Task<UserProduct> GetUserProduct(Guid id);
    public IEnumerable<OrderInstanceResponseModel> View();
}