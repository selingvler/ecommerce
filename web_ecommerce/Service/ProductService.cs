using web_ecommerce.Database;
using web_ecommerce.Entities;
using web_ecommerce.RequestModels.Product;

namespace web_ecommerce.Service;

public class ProductService : IProductService
{
    private readonly IGenericRepository<Product> _repository;

    public ProductService(IGenericRepository<Product> repository)
    {
        _repository = repository;
    }
    
    public async Task<Guid> AddProduct(CreateProductRequestModel model)
    {
        return await _repository.Add(model.MapToEntity());
    }

    public async Task DeleteProduct(Guid id)
    {
        var product = await _repository.Get(x => x.Id == id);
        if (product == null) throw new Exception("İşlem yapmak istediğiniz kayıt bulunamadı");
        await _repository.Delete(product);
    }

    public IEnumerable<Product> ViewProducts()
    {
        return _repository.GetAll(null).ToList();
    }
}