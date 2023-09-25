using web_ecommerce.Database;
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

    public IEnumerable<UserProductResponseModel> ViewUserProducts()
    {
        return _service.ViewUserProducts();
    }

    public async Task DeleteUserProduct(Guid id)
    {
        await _service.DeleteUserProduct(id);
    }

    public async Task UpdateUserProduct(UpdateUserProductRequestModel model)
    {
        await UpdateUserProductValidation(model);
        await _service.UpdateUserProduct(model);
    }


    public UserProductResponseModel GetCheapestUserProduct(Guid id)
    {
        return _service.GetCheapestUserProduct(id).MapToModel();
    }
}