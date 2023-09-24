namespace web_ecommerce.Entities;

public class Order : BaseEntity
{
    public Guid UserId { get; set; }
    public string OrderStatus { get; set; }
    public virtual User User { get; set; }
    public virtual IEnumerable<OrderInstance> OrderInstances { get; set; }
}