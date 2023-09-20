﻿using web_ecommerce.Entities;
using web_ecommerce.RequestModels.UserProduct;

namespace web_ecommerce.Business;

public interface IUserProductBusiness
{
    public Task<Guid> RegisterUserProduct(CreateUserProductRequestModel model);
    public IEnumerable<UserProduct> ViewUserProducts();
    public Task DeleteUserProduct(Guid id);
    public IEnumerable<UserProduct> GetUserProductsByAscending(Guid productId);
}