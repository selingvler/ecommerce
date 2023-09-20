using web_ecommerce.Database;
using web_ecommerce.Entities;
using web_ecommerce.RequestResponseModels.Category;

namespace web_ecommerce.Service;

public class CategoryService : ICategoryService
{
    private readonly IGenericRepository<Category> _repository;

    public CategoryService(IGenericRepository<Category> repository)
    {
        _repository = repository;
    }
    public async Task<Guid> AddCategory(CreateCategoryRequestModel model)
    {
        return await _repository.Add(model.MapToEntity());
    }

    public async Task DeleteCategory(Guid id)
    {
        var category = await _repository.Get(x => x.Id == id);
        if (category == null) throw new Exception("İşlem yapmak istediğiniz kayıt bulunamadı");
        await _repository.Delete(category);
    }

    public IEnumerable<Category> ViewCategories()
    {
        return _repository.GetAll(null).ToList();
    }
}