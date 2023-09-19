using Microsoft.EntityFrameworkCore;
using web_ecommerce.Entities;

namespace web_ecommerce.Database;

public class WebDbContext  : DbContext
{
    public WebDbContext(DbContextOptions options) :
        base(options)
    {
        ChangeTracker.LazyLoadingEnabled = false;
        ChangeTracker.AutoDetectChangesEnabled = false;
    }
    
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderInstance> OrderInstances { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserProduct> UserProducts { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("dbo");
        var mapperFactory = new EntitySqlMapper(modelBuilder);
        base.OnModelCreating(mapperFactory.Initialize());
    }
}