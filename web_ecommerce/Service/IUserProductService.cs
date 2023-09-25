using web_ecommerce.Entities;
using web_ecommerce.RequestResponseModels.UserProduct;

namespace web_ecommerce.Service;

public interface IUserProductService
{
    public Task<Guid> RegisterUserProduct(CreateUserProductRequestModel model);
    public IEnumerable<UserProductResponseModel> ViewUserProducts();
    public Task DeleteUserProduct(Guid id);
    public Task UpdateUserProduct(UpdateUserProductRequestModel model);
    public UserProduct GetCheapestUserProduct(Guid id);
}