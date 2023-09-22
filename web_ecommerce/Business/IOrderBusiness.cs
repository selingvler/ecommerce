namespace web_ecommerce.Business;

public interface IOrderBusiness
{
    public Task<Guid> CreateOrder(Guid userId);
}