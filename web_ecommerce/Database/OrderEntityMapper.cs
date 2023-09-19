using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using web_ecommerce.Entities;

namespace web_ecommerce.Database;

public class OrderEntityMapper : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(order=>order.User)
            .WithMany(user => user.Orders)
            .HasForeignKey(x=>x.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}