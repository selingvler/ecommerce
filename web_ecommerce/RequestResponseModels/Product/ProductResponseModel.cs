namespace web_ecommerce.RequestResponseModels.Product;

public class ProductResponseModel
{
    public Guid Id { get; set; }
    public string ProductName { get; set; }
    public Guid CategoryId { get; set; }
}