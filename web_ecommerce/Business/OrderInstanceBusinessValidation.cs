using web_ecommerce.RequestResponseModels.OrderInstances;

namespace web_ecommerce.Business;

public partial class OrderInstanceBusiness
{
    private void CreateOrderInstanceValidation(CreateOrderInstanceRequestModel model)
    {
        if (model == null) throw new SlnException("İstek boş olamaz");
        if (model.OrderUnit <= 0) throw new SlnException("Sipariş adedi 0 dan fazla olmalıdır");
        var userProduct = _userProductService.GetCheapestUserProduct(model.ProductId);
        if (model.OrderUnit > userProduct.Unit) throw new SlnException("Bu üründen satın almak istediğiniz adette bulunmamaktadır");
    }
}