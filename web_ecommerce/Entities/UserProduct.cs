namespace web_ecommerce.Entities;

public class UserProduct : BaseEntity
{
    public Guid UserId { get; set; }
    public Guid ProductId { get; set; }
    public int Price { get; set; }
    public int Unit { get; set; }
    public virtual User User { get; set; }
    public virtual Product Product { get; set; }
    public virtual OrderInstance OrderInstance { get; set; }
}