using Microsoft.AspNetCore.Mvc;
using web_ecommerce.Business;

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
    
    [HttpPost("{id:guid}")]
    public async Task<Guid> CreateOrder([FromRoute] Guid id)
    {
        return await _business.CreateOrder(id);
    }
}