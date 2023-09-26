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
        model?.Initialize(model.OrderId);
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

    [HttpDelete("{id:guid}")]
    public async Task Delete([FromRoute] Guid id)
    {
        await _business.DeleteOrderInstance(id);
    }

    [HttpGet("approvedInstances/{userId:guid}")]
    public async Task<IEnumerable> WaitingForApproval([FromRoute]Guid userId)
    {
        return await _business.WaitingForApproval(userId);
    }

    [HttpPut]
    public async Task OrderInstanceSellerResponse(OrderInstanceInProcessModel model)
    {
        await _business.OrderInstanceSellerResponse(model);
    }

    [HttpPut("returnOrderInstance")]
    public async Task ReturnOrderInstance(ReturnOrderInstanceModel model)
    {
        await _business.ReturnOrderInstance(model);
    }
    
}