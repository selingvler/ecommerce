using web_ecommerce.RequestResponseModels.UserProduct;

namespace web_ecommerce.Business;

public partial class UserProductBusiness
{
    private async Task AddUserProductValidation(CreateUserProductRequestModel model)
    {
        if (model == null) throw new SlnException("İstek boş olamaz");
        if (model.Price <= 0) throw new SlnException("fiyat 0 dan fazla olmalıdır");
        if (model.Unit <= 0) throw new SlnException("stok adedi 0 dan fazla olmalıdır");
        var user = await _userService.GetById(model.UserId);
        if (user.UserType != "seller")
        {
            throw new SlnException("Ürün bilgisi girebilmek için satıcı olmanız gerekmektedir");
        }
    }
    private async Task UpdateUserProductValidation(UpdateUserProductRequestModel model)
    {
        if (model == null) throw new SlnException("İstek boş olamaz");
        if (model.Price <= 0) throw new SlnException("fiyat 0 dan fazla olmalıdır");
        if (model.Unit <= 0) throw new SlnException("stok adedi 0 dan fazla olmalıdır");
        var user = await _userService.GetById(model.UserId);
        if (user.UserType != "seller")
        {
            throw new SlnException("Ürün bilgisi güncellemek için satıcı olmanız gerekmektedir");
        }
    }
}