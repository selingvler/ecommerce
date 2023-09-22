using web_ecommerce.RequestResponseModels.Category;

namespace web_ecommerce.Business;

public partial class CategoryBusiness
{
    private void AddCategoryValidation(CreateCategoryRequestModel model)
    {
        if (model == null) throw new SlnException("İstek boş olamaz");
        if (string.IsNullOrWhiteSpace(model.CategoryName)) throw new SlnException("kategori adı giriniz");
    }
}