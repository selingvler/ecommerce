using Microsoft.EntityFrameworkCore;

namespace web_ecommerce.Database;
public sealed class EntitySqlMapper
{
    private readonly ModelBuilder _modelBuilder;
    public EntitySqlMapper(ModelBuilder modelBuilder)
    {
        _modelBuilder = modelBuilder;
    }
    public ModelBuilder Initialize()
    {
        _modelBuilder.ApplyConfiguration(new CategoryEntityMapper());
        _modelBuilder.ApplyConfiguration(new OrderEntityMapper());
        _modelBuilder.ApplyConfiguration(new OrderInstanceEntityMapper());
        _modelBuilder.ApplyConfiguration(new ProductEntityMapper());
        _modelBuilder.ApplyConfiguration(new UserEntityMapper());
        _modelBuilder.ApplyConfiguration(new UserProductEntityMapper());
        return _modelBuilder;
    }
}