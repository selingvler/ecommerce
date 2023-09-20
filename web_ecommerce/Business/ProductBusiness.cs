using web_ecommerce.Entities;
using web_ecommerce.RequestModels.Product;
using web_ecommerce.Service;

namespace web_ecommerce.Business;

public class ProductBusiness : IProductBusiness
{
    private readonly IProductService _service;
    private readonly IUserService _userService;
    public ProductBusiness(IProductService service, IUserService userService)
    {
        _service = service;
        _userService = userService;
    }
    
    public async Task<Guid> AddProduct(CreateProductRequestModel model)
    {
        _userService.CheckUserTypeForManager(model.UserId);
        return await _service.AddProduct(model);
    }

    public async Task DeleteProduct(Guid id)
    {
        await _service.DeleteProduct(id);
    }
}