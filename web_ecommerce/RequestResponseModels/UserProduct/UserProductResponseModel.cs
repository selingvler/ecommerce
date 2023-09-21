namespace web_ecommerce.RequestResponseModels.UserProduct;

public class UserProductResponseModel
{
    public Guid Id { get; set; }
    public int Price { get; set; }
    public int Unit { get; set; }
    public Guid UserId { get; set; }
    public Guid ProductId { get; set; }
}