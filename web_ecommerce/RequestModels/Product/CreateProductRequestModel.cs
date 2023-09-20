namespace web_ecommerce.RequestModels.Product;

public class CreateProductRequestModel
{
    public Guid CategoryId { get; set; }
    public string ProductName { get; set; }
    public Guid UserId { get; set; }
}