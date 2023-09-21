using web_ecommerce.Entities;
using web_ecommerce.RequestResponseModels.Product;

namespace web_ecommerce.Service;

public interface IProductService
{
    public Task<Guid> AddProduct(CreateProductRequestModel model);
    public Task DeleteProduct(Guid id);
    public IEnumerable<ProductResponseModel> ViewProducts();
}