using web_ecommerce.Entities;
using web_ecommerce.RequestModels.User;

namespace web_ecommerce.Business;

public interface IUserBusiness
{
    public Task<Guid> AddUser(CreateUserRequestModel model);
    public IEnumerable<User> ViewUsers();
    public Task DeleteUser(Guid id);
}