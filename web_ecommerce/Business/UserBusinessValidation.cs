using web_ecommerce.RequestResponseModels.User;

namespace web_ecommerce.Business;

public partial class UserBusiness 
{
    public async Task CheckUserTypeForManager(Guid userId)
    {
        var user = await _service.GetById(userId);
        if (user == null) throw new SlnException("Girdiğiniz id ile bir kullanıcı bulunamadı");
        if (user.UserType != "manager")
        {
            throw new SlnException("Ürün eklemek için yönetici olmanız gereklidir");
        }
    }

    public async Task CheckUserTypeForSeller(Guid userId)
    {
        var user = await _service.GetById(userId);
        if (user == null) throw new SlnException("Girdiğiniz id ile bir kullanıcı bulunamadı");
        if (user.UserType != "seller")
        {
            throw new SlnException("Ürüne fiyat verebilmek için satıcı olmanız gereklidir");
        }
    }

    private void AddUserValidation(CreateUserRequestModel model)
    {
        if (model == null) throw new SlnException("İstek boş olamaz");
        if (string.IsNullOrWhiteSpace(model.UserType)) throw new SlnException("kullanıcı tipi giriniz");
        if (string.IsNullOrWhiteSpace(model.Email)) throw new SlnException("email giriniz");
        if (string.IsNullOrWhiteSpace(model.Password)) throw new SlnException("şifre giriniz");
        if (string.IsNullOrWhiteSpace(model.UserName)) throw new SlnException("kullanıcı adı giriniz");
        
    }
}