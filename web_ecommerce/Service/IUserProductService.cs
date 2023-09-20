using web_ecommerce.Entities;
using web_ecommerce.RequestModels.UserProduct;

namespace web_ecommerce.Service;

public interface IUserProductService
{
    public Task<Guid> RegisterUserProduct(CreateUserProductRequestModel model);
    public IEnumerable<UserProduct> ViewUserProducts();
    
    public IEnumerable<UserProduct> GetUserProductsByAscending(Guid productId);
}