using Microsoft.AspNetCore.Mvc;
using web_ecommerce.Business;
using web_ecommerce.Entities;
using web_ecommerce.RequestModels.Product;
using web_ecommerce.RequestModels.User;

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
        await _business.AddProduct(model);
    }

    [HttpDelete]
    public async Task DeleteProduct(Guid id)
    {
        await _business.DeleteProduct(id);
    }

    [HttpGet]
    public IEnumerable<Product> ViewProducts()
    {
        return _business.ViewProducts();
    }
}