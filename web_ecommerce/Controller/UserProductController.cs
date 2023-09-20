using Microsoft.AspNetCore.Mvc;
using web_ecommerce.Business;
using web_ecommerce.Entities;
using web_ecommerce.RequestModels.UserProduct;

namespace web_ecommerce.Controller;
[ApiController]
[Route("UserProducts")]
public class UserProductController
{
    private readonly IUserProductBusiness _business;

    public UserProductController(IUserProductBusiness business)
    {
        _business = business;
    }
    [HttpPost]
    public async Task<Guid> RegisterUserProduct(CreateUserProductRequestModel model)
    {
        if (model == null) throw new Exception("İstek boş olamaz");
        return await _business.RegisterUserProduct(model);
    }

    [HttpGet]
    public IEnumerable<UserProduct> ViewUserProducts()
    {
        return _business.ViewUserProducts();
    }

    [HttpDelete]
    public async Task DeleteUserProduct(Guid id)
    {
        await _business.DeleteUserProduct(id);
    }

    [HttpGet("ByAscending")]
    public IEnumerable<UserProduct> GetUserProductsByAscending(Guid productId)
    {
        return _business.GetUserProductsByAscending(productId);
    }
}