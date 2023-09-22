using Microsoft.AspNetCore.Mvc;
using web_ecommerce.Business;
using web_ecommerce.Entities;
using web_ecommerce.RequestResponseModels.User;

namespace web_ecommerce.Controller;
[ApiController]
[Route("Users")]
public class UserController
{
    private readonly IUserBusiness _business;
    public UserController(IUserBusiness business)
    {
        _business = business;
    }
    
    [HttpPost]
    public async Task<Guid> AddUser(CreateUserRequestModel model)
    {
        return await _business.AddUser(model);
    }

    [HttpGet]
    public IEnumerable<UserResponseModel> ViewUsers()
    {
        return _business.ViewUsers();
    }

    [HttpDelete("{id:guid}")]
    public async Task DeleteUser([FromRoute] Guid id)
    {
        await _business.DeleteUser(id);
    }

    [HttpPut]
    public async Task UpdatePassword(UpdateUserPasswordRequestModel model)
    {
        model?.Initialize(model.Id);
        await _business.UpdatePassword(model);
    }
}