using web_ecommerce.Database;
using web_ecommerce.Entities;
using web_ecommerce.RequestModels.UserProduct;

namespace web_ecommerce.Service;

public class UserProductService : IUserProductService
{
    private readonly IGenericRepository<UserProduct> _repository;

    public UserProductService(IGenericRepository<UserProduct> repository)
    {
        _repository = repository;
    }
    public async Task<Guid> RegisterUserProduct(CreateUserProductRequestModel model)
    {
        return await _repository.Add(model.MapToEntity());
    }

    public IEnumerable<UserProduct> ViewUserProducts()
    {
        return _repository.GetAll(null);
    }

    public async Task DeleteUserProduct(Guid id)
    {
        var userProduct = await _repository.Get(x => x.Id == id);
        if (userProduct == null) throw new Exception("İşlem yapmak istediğiniz kayıt bulunamadı");
        await _repository.Delete(userProduct);
    }

    public IEnumerable<UserProduct> GetUserProductsByAscending(Guid productId)
    {
        var list = _repository.GetAll(x=>x.ProductId == productId).ToList();
        return list.OrderBy(x => x.Price);
    }
}