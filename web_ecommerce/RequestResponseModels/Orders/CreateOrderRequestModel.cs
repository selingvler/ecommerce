namespace web_ecommerce.RequestResponseModels.Orders;

public class CreateOrderRequestModel
{
    public Guid UserId { get; set; }
    public string OrderStatus { get; set; } = "waiting";
}