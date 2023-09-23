using web_ecommerce.Database;
using web_ecommerce.Entities;
using web_ecommerce.RequestResponseModels.Product;

namespace web_ecommerce.Service;

public class ProductService : IProductService
{
    private readonly IGenericRepository<Product> _repository;
    private readonly ICategoryService _categoryService;

    public ProductService(IGenericRepository<Product> repository,ICategoryService categoryService)
    {
        _repository = repository;
        _categoryService = categoryService;
    }
    
    public async Task<Guid> AddProduct(CreateProductRequestModel model)
    {
        await _categoryService.CheckCategory(model.CategoryId);
        var id = await _repository.Add(model.MapToEntity());
        await _repository.SaveChange();
        return id;
    }

    public async Task DeleteProduct(Guid id)
    {
        var product = await _repository.Get(x => x.Id == id);
        if (product == null) throw new SlnException("İşlem yapmak istediğiniz kayıt bulunamadı");
        await _repository.Delete(product);
        await _repository.SaveChange();
    }

    public IEnumerable<ProductResponseModel> ViewProducts()
    {
        return _repository.GetAll(null).Select(x=>x.MapToModel()).ToList();
    }

    public async Task CheckProduct(Guid id)
    {
        var product = await _repository.Get(x => x.Id == id) ??
                throw new SlnException("İşlem yapmak istediğiniz kayıt bulunamadı");
    }
}