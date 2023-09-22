namespace web_ecommerce.Service;

public interface IOrderService
{
    public Task<Guid> AddOrder(Guid userId);
}