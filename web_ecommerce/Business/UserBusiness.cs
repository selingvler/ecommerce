using web_ecommerce.Entities;
using web_ecommerce.RequestResponseModels.User;
using web_ecommerce.Service;

namespace web_ecommerce.Business;

public partial class UserBusiness : IUserBusiness
{
    private readonly IUserService _service;
    public UserBusiness(IUserService service)
    {
        _service = service;
    }
    
    public async Task<Guid> AddUser(CreateUserRequestModel model)
    {
        AddUserValidation(model);
        return await _service.AddUser(model);
    }

    public IEnumerable<UserResponseModel> ViewUsers()
    {
        return _service.ViewUsers();
    }

    public async Task DeleteUser(Guid id)
    {
        await _service.DeleteUser(id);
    }

    public async Task UpdatePassword(UpdateUserPasswordRequestModel model)
    {
        if (string.IsNullOrWhiteSpace(model.Password)) throw new SlnException("şifre giriniz");
        await _service.UpdateUserPassword(model);
    }
}