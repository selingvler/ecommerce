using web_ecommerce.Entities;
using web_ecommerce.RequestModels.User;
using web_ecommerce.Service;

namespace web_ecommerce.Business;

public class UserBusiness : IUserBusiness
{
    private readonly IUserService _service;
    public UserBusiness(IUserService service)
    {
        _service = service;
    }
    
    public async Task<Guid> AddUser(CreateUserRequestModel model)
    {
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