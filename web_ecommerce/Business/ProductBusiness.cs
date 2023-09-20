using web_ecommerce.Entities;
using web_ecommerce.RequestModels.Product;
using web_ecommerce.Service;

namespace web_ecommerce.Business;

public class ProductBusiness : IProductBusiness
{
    private readonly IProductService _service;
    private readonly IGenericRepository<User> _userRepository;
    public ProductBusiness(IProductService service, IGenericRepository<User> userRepository)
    {
        _service = service;
        _userRepository = userRepository;
    }
    
    public async Task<Guid> AddProduct(CreateProductRequestModel model)
    {
        CheckUserType(model.UserId);
        return await _service.AddProduct(model);
    }

    public async Task DeleteProduct(Guid id)
    {
        await _service.DeleteProduct(id);
    }


    private async void CheckUserType(Guid userId)
    {
        var user = await _userRepository.Get(x => x.Id == userId);
        if (user == null) throw new Exception("Girdiğiniz id ile bir kullanıcı bulunamadı");
        if (user.UserType != "manager")
        {
            throw new Exception("Ürün eklemek için yönetici olmanız gereklidir");
        }
    }
}