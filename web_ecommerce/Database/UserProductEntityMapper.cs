using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using web_ecommerce.Entities;

namespace web_ecommerce.Database;

public class UserProductEntityMapper : IEntityTypeConfiguration<UserProduct>
{
    public void Configure(EntityTypeBuilder<UserProduct> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(userproduct => userproduct.Product)
            .WithMany(product => product.UserProducts)
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(userproduct => userproduct.User)
            .WithMany(user => user.UserProducts)
            .HasForeignKey(x => x.UserId);
    }
}