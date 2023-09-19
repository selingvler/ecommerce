namespace web_ecommerce.Entities;

public class Category : BaseEntity
{
    public string CategoryName { get; set; }
    public virtual IEnumerable<Product> Products { get; set; }
}