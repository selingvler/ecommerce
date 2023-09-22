using web_ecommerce.RequestResponseModels.OrderInstances;
using web_ecommerce.Service;

namespace web_ecommerce.Business;

public partial class OrderInstanceBusiness : IOrderInstanceBusiness
{
    private readonly IOrderInstanceService _service;

    public OrderInstanceBusiness(IOrderInstanceService service)
    {
        _service = service;
    }

    public async Task<Guid> CreateOrderInstance(CreateOrderInstanceRequestModel model)
    {
        await CreateOrderInstanceValidation(model);
        return await _service.CreateOrderInstance(model);
    }

    public Task<OrderInstanceResponseModel> ViewOrderDetails(Guid orderId)
    {
        return _service.ViewOrderDetails(orderId);
    }
}