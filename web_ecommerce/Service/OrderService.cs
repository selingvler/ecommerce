using web_ecommerce.Database;
using web_ecommerce.Entities;

namespace web_ecommerce.Service;

public class OrderService : IOrderService
{
    private readonly IGenericRepository<Order> _repository;

    public OrderService(IGenericRepository<Order> repository)
    {
        _repository = repository;
    }

    public async Task<Guid> AddOrder(Guid userId)
    {
        var id = await _repository.Add(userId.MapToEntity());
        await _repository.SaveChange();
        return id;
    }
}