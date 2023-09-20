using web_ecommerce.Entities;
using web_ecommerce.RequestResponseModels.Category;

namespace web_ecommerce.Business;

public interface ICategoryBusiness
{
    public Task<Guid> AddCategory(CreateCategoryRequestModel model);
    public Task DeleteCategory(Guid id);
    public IEnumerable<Category> ViewCategories();
}