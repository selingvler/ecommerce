using web_ecommerce.Entities;
using web_ecommerce.RequestResponseModels.Category;

namespace web_ecommerce.Service;

public interface ICategoryService
{
    public Task<Guid> AddCategory(CreateCategoryRequestModel model);
    public Task DeleteCategory(Guid id);
    public IEnumerable<Category> ViewCategories();
}