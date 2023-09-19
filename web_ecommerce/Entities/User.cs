namespace web_ecommerce.Entities;

public class User : BaseEntity
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string UserType { get; set; }
    public virtual IEnumerable<UserProduct> UserProducts { get; set; }
    public virtual IEnumerable<Order> Orders { get; set; }
}