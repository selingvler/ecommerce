using web_ecommerce.Database;
using web_ecommerce.Entities;
using web_ecommerce.RequestResponseModels.User;

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
        var id = await _repository.Add(model.MapToEntity());
        await _repository.SaveChange();
        return id;
    }

    public IEnumerable<UserResponseModel> ViewUsers()
    {
        return _repository.GetAll(null).Select(x=>x.MapToModel());
    }

    public async Task DeleteUser(Guid id)
    {
        var user = await _repository.Get(x => x.Id == id);
        if (user == null) throw new SlnException("İşlem yapmak istediğiniz kayıt bulunamadı");
        await _repository.Delete(user);
        await _repository.SaveChange();
    }

    public async Task UpdateUserPassword(UpdateUserPasswordRequestModel model)
    {
        var user = await _repository.Get(x => x.Id == model.Id);
        if (user == null) throw new SlnException("İşlem yapmak istediğiniz kayıt bulunamadı");
        user.Password = model.Password;
        await _repository.Update(user);
        await _repository.SaveChange();
    }

    public async Task<User> GetById(Guid id)
    {
        var user = await _repository.Get(x => x.Id == id) ??
                   throw new SlnException("Girdiğiniz id ile bir kullanıcı bulunamadı");
        return user;
    }
    
}