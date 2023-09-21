using web_ecommerce.Entities;
using web_ecommerce.RequestResponseModels.User;

namespace web_ecommerce.Service;

public interface IUserService
{
    public Task<Guid> AddUser(CreateUserRequestModel model);
    public IEnumerable<User> ViewUsers();
    public Task DeleteUser(Guid id);
    public Task<User> GetById(Guid id);
}