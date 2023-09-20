namespace web_ecommerce.RequestModels.User;

public class CreateUserRequestModel
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string UserType { get; set; }
}