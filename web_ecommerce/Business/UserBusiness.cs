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

    public IEnumerable<User> ViewUsers()
    {
        return _service.ViewUsers();
    }

    public async Task DeleteUser(Guid id)
    {
        await _service.DeleteUser(id);
    }
}