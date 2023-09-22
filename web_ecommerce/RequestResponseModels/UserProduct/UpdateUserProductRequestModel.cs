namespace web_ecommerce.RequestResponseModels.UserProduct;

public class UpdateUserProductRequestModel 
{
    public Guid Id { get; set; }
    public int Price { get; set; }
    public int Unit { get; set; }
    public Guid UserId { get; set; }

    public void Initialize(Guid id)
    {
        Id = id;
    }
}