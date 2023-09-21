namespace web_ecommerce.RequestResponseModels.Product;

public class CreateProductRequestModel
{
    public Guid CategoryId { get; set; }
    public string ProductName { get; set; }
    public Guid UserId { get; set; }

    public void InitializeCategoryId(Guid id)
    {
        CategoryId = id;
    }
    public void InitializeUserId(Guid id)
    {
        UserId = id;
    }
}