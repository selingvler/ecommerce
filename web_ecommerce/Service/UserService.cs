using web_ecommerce.Database;
using web_ecommerce.Entities;
using web_ecommerce.RequestModels.User;

namespace web_ecommerce.Service;

public class UserService : IUserService
{
    private readonly IGenericRepository<User> _repository;

    public UserService(IGenericRepository<User> repository)
    {
        _repository = repository;
    }
    public async Task<Guid> AddUser(CreateUserRequestModel model)
    {
        return await _repository.Add(model.MapToEntity());
    }

    public IEnumerable<User> ViewUsers()
    {
        return _repository.GetAll(null);
    }

    public async Task DeleteUser(Guid id)
    {
        var user = await _repository.Get(x => x.Id == id);
        if (user == null) throw new Exception("İşlem yapmak istediğiniz kayıt bulunamadı");
        await _repository.Delete(user);
    }
}