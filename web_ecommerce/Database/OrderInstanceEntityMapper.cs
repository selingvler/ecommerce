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
            .WithOne(userproduct => userproduct.OrderInstance)
            .HasForeignKey<OrderInstance>(x => x.UserProductId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(orderinstance => orderinstance.Order)
            .WithOne(order => order.OrderInstance)
            .HasForeignKey<OrderInstance>(x => x.OrderId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}