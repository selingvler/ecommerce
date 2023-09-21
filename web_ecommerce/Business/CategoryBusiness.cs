using web_ecommerce.Entities;
using web_ecommerce.RequestResponseModels.Category;
using web_ecommerce.Service;

namespace web_ecommerce.Business;

public partial class CategoryBusiness : ICategoryBusiness
{
    private readonly ICategoryService _service;
    public CategoryBusiness(ICategoryService service)
    {
        _service = service;
    }
    public async Task<Guid> AddCategory(CreateCategoryRequestModel model)
    {
        AddCategoryValidation(model);
        return await _service.AddCategory(model);
    }

    public async Task DeleteCategory(Guid id)
    {
        await _service.DeleteCategory(id);
    }

    public IEnumerable<CategoryResponseModel> ViewCategories()
    {
        return _service.ViewCategories();
    }
}