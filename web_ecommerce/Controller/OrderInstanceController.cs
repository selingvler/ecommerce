using Microsoft.AspNetCore.Mvc;
using web_ecommerce.Business;
using web_ecommerce.Entities;
using web_ecommerce.RequestResponseModels.OrderInstances;

namespace web_ecommerce.Controller;
[ApiController]
[Route("OrderInstances")]
public class OrderInstanceController
{
    private readonly IOrderInstanceBusiness _business;

    public OrderInstanceController(IOrderInstanceBusiness business)
    {
        _business = business;
    }

    [HttpPost]
    public async Task<Guid> OrderProduct(CreateOrderInstanceRequestModel model)
    {
        model?.Initialize(model.OrderId,model.UserProductId);
        return await _business.CreateOrderInstance(model);
    }

    [HttpGet("{id:guid}")]
    public async Task<OrderInstanceResponseModel> ViewOrderDetails([FromRoute] Guid id)
    {
        return await _business.ViewOrderDetails(id);
    }

    [HttpGet]
    public IEnumerable<OrderInstanceResponseModel> View()
    {
        return _business.View();
    }
}