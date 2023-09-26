using web_ecommerce.RequestResponseModels.Product;

namespace web_ecommerce.Business;

public partial class ProductBusiness
{
    private async Task AddProductValidation(CreateProductRequestModel model)
    {
        if (model == null) throw new SlnException("İstek boş olamaz");
        if (string.IsNullOrWhiteSpace(model.ProductName)) throw new SlnException("ürün adı giriniz");
        var user = await _userService.GetById(model.UserId);
        if (user.UserType != "manager")
        {
            throw new SlnException("Ürün eklemek için yönetici olmanız gereklidir");
        }
    }
}