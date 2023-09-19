namespace web_ecommerce.Entities;

public class Order : BaseEntity
{
    public Guid UserId { get; set; }
    public virtual User User { get; set; }
    public virtual OrderInstance OrderInstance { get; set; }
}