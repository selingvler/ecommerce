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
        if (model == null) throw new Exception("İstek boş olamaz");
        return await _business.AddUser(model);
    }

    [HttpGet]
    public IEnumerable<User> ViewUsers()
    {
        return _business.ViewUsers();
    }

    [HttpDelete("{id:guid}")]
    public async Task DeleteUser([FromRoute] Guid id)
    {
        await _business.DeleteUser(id);
    }
}