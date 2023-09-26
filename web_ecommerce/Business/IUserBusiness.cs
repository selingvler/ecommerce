using web_ecommerce.Entities;
using web_ecommerce.RequestResponseModels.User;

namespace web_ecommerce.Business;

public interface IUserBusiness
{
    public Task<Guid> AddUser(CreateUserRequestModel model);
    public IEnumerable<UserResponseModel> ViewUsers();
    public Task DeleteUser(Guid id);
    public Task UpdatePassword(UpdateUserPasswordRequestModel model);
}