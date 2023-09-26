namespace web_ecommerce.RequestResponseModels.OrderInstances;

public class CreateOrderInstanceRequestModel
{
    public Guid OrderId { get; set; }
    public Guid ProductId { get; set; }
    public int OrderUnit { get; set; }
    public string Status { get; set; } = "waiting";

    public void Initialize(Guid orderId)
    {
        OrderId = orderId;
    }
}