using web_ecommerce.RequestModels.Product;

namespace web_ecommerce.Service;

public interface IProductService
{
    public Task<Guid> AddProduct(CreateProductRequestModel model);
    public Task DeleteProduct(Guid id);
}