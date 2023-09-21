using web_ecommerce.RequestResponseModels.Product;

namespace web_ecommerce.Business;

public partial class ProductBusiness
{
    public void AddProductValidation(CreateProductRequestModel model)
    {
        if (model == null) throw new SlnException("İstek boş olamaz");
        if (string.IsNullOrWhiteSpace(model.ProductName)) throw new SlnException("ürün adı giriniz");
    }
}