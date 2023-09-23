using System.Collections;
using Microsoft.AspNetCore.Mvc;
using web_ecommerce.Business;
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

    [HttpGet("{orderId:guid}")]
    public async Task<IEnumerable> ViewOrderDetails([FromRoute] Guid orderId)
    {
        return await _business.ViewOrderDetails(orderId);
    }

    [HttpGet]
    public IEnumerable<OrderInstanceResponseModel> View()
    {
        return _business.View();
    }
}