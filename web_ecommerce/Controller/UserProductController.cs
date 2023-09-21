using Microsoft.AspNetCore.Mvc;
using web_ecommerce.Business;
using web_ecommerce.RequestResponseModels.UserProduct;

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
        model?.InitializeUserId(model.UserId);
        model?.InitializeProductId(model.ProductId);
        return await _business.RegisterUserProduct(model);
    }

    [HttpGet]
    public IEnumerable<UserProductResponseModel> ViewUserProducts()
    {
        return _business.ViewUserProducts();
    }

    [HttpDelete("{id:guid}")]
    public async Task DeleteUserProduct([FromRoute] Guid id)
    {
        await _business.DeleteUserProduct(id);
    }

    [HttpGet("{id:guid}/ByAscending")]
    public IEnumerable<UserProductResponseModel> GetUserProductsByAscending(Guid id)
    {
        return _business.GetUserProductsByAscending(id);
    }
}