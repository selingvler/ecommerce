using web_ecommerce.RequestResponseModels.Category;

namespace web_ecommerce.Business;

public partial class CategoryBusiness
{
    private void AddCategoryValidation(CreateCategoryRequestModel model)
    {
        if (model == null) throw new SlnException("İstek boş olamaz");
        if (string.IsNullOrWhiteSpace(model.CategoryName)) throw new SlnException("kategori adı giriniz");
        /*
        foreach (var propertyInfo in model.GetType().GetProperties())
        {
            if (string.IsNullOrWhiteSpace(propertyInfo.Name))
            {
                throw new SlnException(propertyInfo.Name + " giriniz");
            }
        }
        */
    }
}