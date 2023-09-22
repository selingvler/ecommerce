namespace web_ecommerce.RequestResponseModels.OrderInstances;

public class CreateOrderInstanceRequestModel
{
    public Guid OrderId { get; set; }
    public Guid UserProductId { get; set; }
    public int OrderUnit { get; set; }

    public void Initialize(Guid orderId, Guid userProductId)
    {
        OrderId = orderId;
        UserProductId = userProductId;
    }
}