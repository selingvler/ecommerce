using web_ecommerce.RequestResponseModels.User;

namespace web_ecommerce.Business;

public partial class UserBusiness 
{
    private static void AddUserValidation(CreateUserRequestModel model)
    {
        if (model == null) throw new SlnException("İstek boş olamaz");
        if (string.IsNullOrWhiteSpace(model.UserType)) throw new SlnException("kullanıcı tipi giriniz");
        if (string.IsNullOrWhiteSpace(model.Email)) throw new SlnException("email giriniz");
        if (string.IsNullOrWhiteSpace(model.Password)) throw new SlnException("şifre giriniz");
        if (string.IsNullOrWhiteSpace(model.UserName)) throw new SlnException("kullanıcı adı giriniz");
        
    }
}