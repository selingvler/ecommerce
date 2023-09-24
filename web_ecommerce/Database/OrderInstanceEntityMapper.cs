using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using web_ecommerce.Entities;

namespace web_ecommerce.Database;

public class OrderInstanceEntityMapper : IEntityTypeConfiguration<OrderInstance>
{
    public void Configure(EntityTypeBuilder<OrderInstance> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(orderinstance => orderinstance.UserProduct)
            .WithMany(userproduct => userproduct.OrderInstances)
            .HasForeignKey(x => x.UserProductId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(orderinstance => orderinstance.Order)
            .WithMany(order => order.OrderInstances)
            .HasForeignKey(x => x.OrderId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}