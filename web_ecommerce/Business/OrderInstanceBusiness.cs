using System.Collections;
using web_ecommerce.RequestResponseModels.OrderInstances;
using web_ecommerce.Service;

namespace web_ecommerce.Business;

public partial class OrderInstanceBusiness : IOrderInstanceBusiness
{
    private readonly IOrderInstanceService _service;
    private readonly IUserProductService _userProductService;

    public OrderInstanceBusiness(IOrderInstanceService service, IUserProductService userProductService)
    {
        _service = service;
        _userProductService = userProductService;
    }

    public async Task<Guid> CreateOrderInstance(CreateOrderInstanceRequestModel model)
    {
        CreateOrderInstanceValidation(model);
        return await _service.CreateOrderInstance(model);
    }

    public Task<IEnumerable> ViewOrderDetails(Guid orderId)
    {
        return _service.ViewOrderDetails(orderId);
    }

    public IEnumerable<OrderInstanceResponseModel> View()
    {
        return _service.View();
    }

    public async Task DeleteOrderInstance(Guid id)
    {
        await _service.DeleteOrderInstance(id);
    }
}