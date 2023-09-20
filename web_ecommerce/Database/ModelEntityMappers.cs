using web_ecommerce.Entities;
using web_ecommerce.RequestModels.Product;
using web_ecommerce.RequestModels.User;
using web_ecommerce.RequestModels.UserProduct;

namespace web_ecommerce.Database;

public static class ModelEntityMappers
{
    public static User MapToEntity(this CreateUserRequestModel model)
    {
        return new User
        {
            Id = Guid.NewGuid(),
            Email = model.Email,
            Password = model.Password,
            UserName = model.UserName,
            UserType = model.UserType
        };
    }

    public static Product MapToEntity(this CreateProductRequestModel model)
    {
        return new Product
        {
            Id = Guid.NewGuid(),
            CategoryId = model.CategoryId,
            ProductName = model.ProductName
        };
    }

    public static UserProduct MapToEntity(this CreateUserProductRequestModel model)
    {
        return new UserProduct
        {
            Id = Guid.NewGuid(),
            UserId = model.UserId,
            ProductId = model.ProductId,
            Price = model.Price,
            Unit = model.Unit
        };
    }
}