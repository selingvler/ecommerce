using web_ecommerce.Database;
using web_ecommerce.Entities;
using web_ecommerce.RequestResponseModels.UserProduct;

namespace web_ecommerce.Service;

public class UserProductService : IUserProductService
{
    private readonly IGenericRepository<UserProduct> _repository;
    private readonly IProductService _productService;

    public UserProductService(IGenericRepository<UserProduct> repository, IProductService productService)
    {
        _repository = repository;
        _productService = productService;
    }
    public async Task<Guid> RegisterUserProduct(CreateUserProductRequestModel model)
    {
        await _productService.CheckProduct(model.ProductId);
        var id = await _repository.Add(model.MapToEntity());
        await _repository.SaveChange();
        return id;
    }

    public IEnumerable<UserProductResponseModel> ViewUserProducts()
    {
        return _repository.GetAll(null).Select(x=>x.MapToModel());
    }

    public async Task DeleteUserProduct(Guid id)
    {
        var userProduct = await _repository.Get(x => x.Id == id);
        if (userProduct == null) throw new SlnException("İşlem yapmak istediğiniz kayıt bulunamadı");
        await _repository.Delete(userProduct);
        await _repository.SaveChange();
    }

    public async Task UpdateUserProduct(UpdateUserProductRequestModel model)
    {
        var userProduct = await _repository.Get(x => x.Id == model.Id);
        if (userProduct == null) throw new SlnException("İşlem yapmak istediğiniz kayıt bulunamadı");
        userProduct.Price = model.Price;
        userProduct.Unit = model.Unit;
        await _repository.Update(userProduct);
        await _repository.SaveChange();
    }

    public UserProductResponseModel GetCheapestUserProduct(Guid id)
    {
        return _repository.GetAll(x=>x.ProductId == id).OrderBy(x=>x.Price).First().MapToModel();
    }
}