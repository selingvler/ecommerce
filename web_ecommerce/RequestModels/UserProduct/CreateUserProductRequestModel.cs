namespace web_ecommerce.RequestModels.UserProduct;

public class CreateUserProductRequestModel
{
    public Guid UserId { get; set; }
    public Guid ProductId { get; set; }
    public int Price { get; set; }
    public int Unit { get; set; }
}