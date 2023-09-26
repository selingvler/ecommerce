namespace web_ecommerce.RequestResponseModels.OrderInstances;

public class OrderInstanceResponseModel
{
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public Guid UserProductId { get; set; }
    public int OrderPrice { get; set; }
    public int OrderUnit { get; set; }
    public string Status { get; set; }
}