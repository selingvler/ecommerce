using System.Linq.Expressions;
using web_ecommerce.Entities;

namespace web_ecommerce;

public interface IGenericRepository<T> where T : BaseEntity
{
    public Task<Guid> Add(T entity);
    public Task<T?> Get(Expression<Func<T, bool>> filter);
    public IQueryable<T> GetAll(Expression<Func<T, bool>>? filter);
    public Task Delete(T entity);
    public Task<int> SaveChange();
}