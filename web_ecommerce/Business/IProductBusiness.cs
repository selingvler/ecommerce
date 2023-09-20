using web_ecommerce.RequestModels.Product;

namespace web_ecommerce.Business;

public interface IProductBusiness
{
    public Task<Guid> AddProduct(CreateProductRequestModel model);
    public Task DeleteProduct(Guid id);
}