using web_ecommerce.RequestResponseModels.Orders;
using web_ecommerce.Service;

namespace web_ecommerce.Business;

public partial class OrderBusiness : IOrderBusiness
{
    private readonly IOrderService _service;
    private readonly IUserService _userService;

    public OrderBusiness(IOrderService service,IUserService userService)
    {
        _service = service;
        _userService = userService;
    }

    public async Task<Guid> CreateOrder(Guid userId)
    {
        await CreateOrderValidation(userId);
        return await _service.AddOrder(userId);
    }

    public async Task DeleteOrder(Guid orderId)
    {
        await _service.DeleteOrder(orderId);
    }

    public IEnumerable<OrderResponseModel> ViewOrders()
    {
        return _service.ViewOrders();
    }
}