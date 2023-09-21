using web_ecommerce.Entities;
using web_ecommerce.RequestResponseModels.UserProduct;

namespace web_ecommerce.Service;

public interface IUserProductService
{
    public Task<Guid> RegisterUserProduct(CreateUserProductRequestModel model);
    public IEnumerable<UserProduct> ViewUserProducts();
    public Task DeleteUserProduct(Guid id);
    
    public IEnumerable<UserProduct> GetUserProductsByAscending(Guid productId);
}