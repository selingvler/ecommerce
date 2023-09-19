namespace web_ecommerce.Entities;

public class OrderInstance : BaseEntity
{
    public Guid OrderId { get; set; }
    public Guid UserProductId { get; set; }
    public int OrderPrice { get; set; }
    public int OrderUnit { get; set; }
    public virtual Order Order { get; set; }
    public virtual UserProduct UserProduct { get; set; }
}