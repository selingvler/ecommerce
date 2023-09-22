using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using web_ecommerce.Database;
using web_ecommerce.Entities;

namespace web_ecommerce;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly WebDbContext _dbContext;
    public GenericRepository(WebDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Guid> Add(T entity)
    {
        entity.Id = Guid.NewGuid();
        await _dbContext.Set<T>().AddAsync(entity);
        return entity.Id;
    }

    public async Task<T?> Get(Expression<Func<T, bool>> filter)
    {
        return await _dbContext.Set<T>().FirstOrDefaultAsync(filter);
    }

    public IQueryable<T> GetAll(Expression<Func<T, bool>>? filter)
    {
        return filter == null
            ? _dbContext.Set<T>()
            : _dbContext.Set<T>().Where(filter);
    }

    public Task Delete(T entity)
    {
        _dbContext.Remove(entity);
        return Task.CompletedTask;
    }

    public Task Update(T entity)
    {
        _dbContext.Set<T>().Entry(entity).State = EntityState.Modified;
        return Task.CompletedTask;
    }

    public async Task<int> SaveChange()
    {
        return await _dbContext.SaveChangesAsync();
    }
}