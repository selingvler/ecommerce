using web_ecommerce.Entities;
using web_ecommerce.RequestModels.UserProduct;
using web_ecommerce.Service;

namespace web_ecommerce.Business;

public class UserProductBusiness : IUserProductBusiness
{
    private readonly IUserProductService _service;
    private readonly IUserService _userService;

    public UserProductBusiness(IUserProductService service,IUserService userService)
    {
        _service = service;
        _userService = userService;
    }
    
    public async Task<Guid> RegisterUserProduct(CreateUserProductRequestModel model)
    {
        _userService.CheckUserTypeForSeller(model.UserId);
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