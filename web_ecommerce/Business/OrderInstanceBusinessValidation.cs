using web_ecommerce.RequestResponseModels.OrderInstances;

namespace web_ecommerce.Business;

public partial class OrderInstanceBusiness
{
    private static void CreateOrderInstanceValidation(CreateOrderInstanceRequestModel model)
    {
        if (model == null) throw new SlnException("İstek boş olamaz");
        if (model.OrderUnit <= 0) throw new SlnException("Sipariş adedi 0 dan fazla olmalıdır");
    }

    private async Task WaitingForApprovalValidation(Guid userId)
    {
        var user = await _userService.GetById(userId);
        if (user.UserType != "seller")
        {
            throw new SlnException("Bu sayfayı görüntüleyemezsiniz");
        }
    }
}