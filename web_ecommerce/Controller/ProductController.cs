using Microsoft.AspNetCore.Mvc;
using web_ecommerce.Business;
using web_ecommerce.Entities;
using web_ecommerce.RequestResponseModels.Product;

namespace web_ecommerce.Controller;
[ApiController]
[Route("Products")]
public class ProductController
{
    private readonly IProductBusiness _business;

    public ProductController(IProductBusiness business)
    {
        _business = business;
    }
    [HttpPost]
    public async Task RegisterProduct(CreateProductRequestModel model)
    {
        model?.InitializeUserId(model.UserId);
        model?.InitializeCategoryId(model.CategoryId);
        await _business.AddProduct(model);
    }

    [HttpDelete("{id:guid}")]
    public async Task DeleteProduct([FromRoute] Guid id)
    {
        await _business.DeleteProduct(id);
    }

    [HttpGet]
    public IEnumerable<Product> ViewProducts()
    {
        return _business.ViewProducts();
    }
}