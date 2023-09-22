namespace web_ecommerce.RequestResponseModels.OrderInstances;

public class OrderInstanceResponseModel
{
    public Guid OrderId { get; set; }
    public Guid UserProductId { get; set; }
    public int OrderPrice { get; set; }
    public int OrderUnit { get; set; }
}