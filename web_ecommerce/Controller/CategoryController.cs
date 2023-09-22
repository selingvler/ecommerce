using Microsoft.AspNetCore.Mvc;
using web_ecommerce.Business;
using web_ecommerce.Entities;
using web_ecommerce.RequestResponseModels.Category;

namespace web_ecommerce.Controller;

[ApiController]
[Route("Categories")]

public class CategoryController
{
    private readonly ICategoryBusiness _business;

    public CategoryController(ICategoryBusiness business)
    {
        _business = business;
    }

    [HttpPost]
    public async Task<Guid> AddCategory(CreateCategoryRequestModel model)
    {
        return await _business.AddCategory(model);
    }
    
    [HttpGet]
    public IEnumerable<CategoryResponseModel> ViewCategories()
    {
        return _business.ViewCategories();
    }

    [HttpDelete("{id:guid}")]
    public async Task DeleteCategory([FromRoute] Guid id)
    {
        await _business.DeleteCategory(id);
    }
}