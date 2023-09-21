using web_ecommerce.Entities;
using web_ecommerce.RequestResponseModels.Product;
using web_ecommerce.Service;

namespace web_ecommerce.Business;

public partial class ProductBusiness : IProductBusiness
{
    private readonly IProductService _service;
    private readonly IUserBusiness _userValidation;
    public ProductBusiness(IProductService service, IUserBusiness userValidation)
    {
        _service = service;
        _userValidation = userValidation;
    }
    
    public async Task<Guid> AddProduct(CreateProductRequestModel model)
    {
        AddProductValidation(model);
        await _userValidation.CheckUserTypeForManager(model.UserId);
        return await _service.AddProduct(model);
    }

    public async Task DeleteProduct(Guid id)
    {
        await _service.DeleteProduct(id);
    }

    public IEnumerable<ProductResponseModel> ViewProducts()
    {
        return _service.ViewProducts();
    }
}