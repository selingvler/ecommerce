namespace web_ecommerce.RequestResponseModels.Orders;

public class ChangeOrderStatusRequestModel
{
    public Guid UserId { get; set; }
    public Guid OrderId { get; set; }
    public string OrderStatus { get; set; }
}