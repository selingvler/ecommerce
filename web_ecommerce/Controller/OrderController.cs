using Microsoft.AspNetCore.Mvc;
using web_ecommerce.Business;
using web_ecommerce.RequestResponseModels.Orders;

namespace web_ecommerce.Controller;
[ApiController]
[Route("Orders")]
public class OrderController
{
    private readonly IOrderBusiness _business;

    public OrderController(IOrderBusiness business)
    {
        _business = business;
    }
    
    [HttpPost]
    public async Task<Guid> CreateOrder(CreateOrderRequestModel model)
    {
        return await _business.CreateOrder(model);
    }

    [HttpDelete("{id:guid}")]
    public async Task DeleteOrder([FromRoute] Guid id)
    {
        await _business.DeleteOrder(id);
    }

    [HttpGet]
    public IEnumerable<OrderResponseModel> ViewOrders()
    {
        return _business.ViewOrders();
    }

    [HttpPut]
    public async Task ChangeOrderStatus(ChangeOrderStatusRequestModel model)
    {
        await _business.ChangeOrderStatus(model);
    }
}