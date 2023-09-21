namespace web_ecommerce.RequestResponseModels.UserProduct;

public class CreateUserProductRequestModel
{
    public Guid UserId { get; set; }
    public Guid ProductId { get; set; }
    public int Price { get; set; }
    public int Unit { get; set; }

    public void InitializeUserId(Guid id)
    {
        UserId = id;
    }

    public void InitializeProductId(Guid id)
    {
        ProductId = id;
    }
}