namespace web_ecommerce.RequestResponseModels.User;

public class CreateUserRequestModel
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string UserType { get; set; }
}