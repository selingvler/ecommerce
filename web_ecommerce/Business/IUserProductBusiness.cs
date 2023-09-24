using web_ecommerce.RequestResponseModels.UserProduct;

namespace web_ecommerce.Business;

public interface IUserProductBusiness
{
    public Task<Guid> RegisterUserProduct(CreateUserProductRequestModel model);
    public IEnumerable<UserProductResponseModel> ViewUserProducts();
    public Task DeleteUserProduct(Guid id);
    public Task UpdateUserProduct(UpdateUserProductRequestModel model);
    public UserProductResponseModel GetCheapestUserProduct(Guid id);
}