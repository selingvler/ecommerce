namespace web_ecommerce.Entities;

public class Product : BaseEntity
{
    public Guid CategoryId { get; set; }
    public string ProductName { get; set; }
    public virtual Category Category { get; set; }
    public IEnumerable<UserProduct> UserProducts { get; set; }
}