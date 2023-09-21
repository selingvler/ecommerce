using web_ecommerce.RequestResponseModels.UserProduct;

namespace web_ecommerce.Business;

public partial class UserProductBusiness
{
    public async Task AddUserProductValidation(CreateUserProductRequestModel model)
    {
        if (model == null) throw new SlnException("İstek boş olamaz");
        if (model.Price <= 0) throw new SlnException("fiyat 0 dan fazla olmalıdır");
        if (model.Unit <= 0) throw new SlnException("stok adedi 0 dan fazla olmalıdır");
        await _userValidation.CheckUserTypeForSeller(model.UserId);
    }
}