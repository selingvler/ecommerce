namespace web_ecommerce.RequestResponseModels.OrderInstances;

public class OrderInstanceInProcessModel
{
    public Guid UserId { get; set; }
    public Guid OrderInstanceId { get; set; }
    public string SellerResponse { get; set; }
}