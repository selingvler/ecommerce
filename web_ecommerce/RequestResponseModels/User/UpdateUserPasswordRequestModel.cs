namespace web_ecommerce.RequestResponseModels.User;

public class UpdateUserPasswordRequestModel
{
    public Guid Id { get; set; }
    public string Password { get; set; }

    public void Initialize(Guid id)
    {
        Id = id;
    }
}