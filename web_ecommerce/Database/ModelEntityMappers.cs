using web_ecommerce.Entities;
using web_ecommerce.RequestResponseModels.Category;
using web_ecommerce.RequestResponseModels.OrderInstances;
using web_ecommerce.RequestResponseModels.Product;
using web_ecommerce.RequestResponseModels.User;
using web_ecommerce.RequestResponseModels.UserProduct;

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

    public static Category MapToEntity(this CreateCategoryRequestModel model)
    {
        return new Category
        {
            Id = Guid.NewGuid(),
            CategoryName = model.CategoryName
        };
    }

    public static CategoryResponseModel MapToModel(this Category category)
    {
        return new CategoryResponseModel
        {
            CategoryName = category.CategoryName,
            Id = category.Id
        };
    }

    public static UserResponseModel MapToModel(this User user)
    {
        return new UserResponseModel
        {
            Id = user.Id,
            Email = user.Email,
            UserType = user.UserType,
            UserName = user.UserName,
            Password = user.Password
        };
    }

    public static UserProductResponseModel MapToModel(this UserProduct userProduct)
    {
        return new UserProductResponseModel
        {
            Id = userProduct.Id,
            Price = userProduct.Price,
            Unit = userProduct.Unit,
            UserId = userProduct.UserId,
            ProductId = userProduct.ProductId
        };
    }

    public static ProductResponseModel MapToModel(this Product product)
    {
        return new ProductResponseModel
        {
            Id = product.Id,
            ProductName = product.ProductName,
            CategoryId = product.CategoryId
        };
    }

    public static UserProduct MapToEntity(this UpdateUserProductRequestModel model)
    {
        return new UserProduct
        {
            Id = model.Id,
            Price = model.Price,
            Unit = model.Unit
        };
    }

    public static User MapToEntity(this UpdateUserPasswordRequestModel model)
    {
        return new User
        {
            Id = model.Id,
            Password = model.Password
        };
    }

    public static Order MapToEntity(this Guid userId)
    {
        return new Order
        {
            Id = Guid.NewGuid(),
            UserId = userId
        };
    }
    
    public static OrderInstanceResponseModel MapToModel(this OrderInstance orderInstance)
    {
        return new OrderInstanceResponseModel
        {
            OrderId = orderInstance.OrderId,
            UserProductId = orderInstance.UserProductId,
            OrderPrice = orderInstance.OrderPrice,
            OrderUnit = orderInstance.OrderUnit
        };
    }
    
}