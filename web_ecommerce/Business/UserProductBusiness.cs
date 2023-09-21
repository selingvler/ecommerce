using web_ecommerce.Entities;
using web_ecommerce.RequestResponseModels.UserProduct;
using web_ecommerce.Service;

namespace web_ecommerce.Business;

public partial class UserProductBusiness : IUserProductBusiness
{
    private readonly IUserProductService _service;
    private readonly IUserBusiness _userValidation;

    public UserProductBusiness(IUserProductService service,IUserBusiness userValidation)
    {
        _service = service;
        _userValidation = userValidation;
    }
    
    public async Task<Guid> RegisterUserProduct(CreateUserProductRequestModel model)
    {
        await AddUserProductValidation(model);
        return await _service.RegisterUserProduct(model);
    }

    public IEnumerable<UserProduct> ViewUserProducts()
    {
        return _service.ViewUserProducts();
    }

    public async Task DeleteUserProduct(Guid id)
    {
        await _service.DeleteUserProduct(id);
    }

    public IEnumerable<UserProduct> GetUserProductsByAscending(Guid productId)
    {
        return _service.GetUserProductsByAscending(productId);
    }
}