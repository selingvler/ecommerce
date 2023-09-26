
using web_ecommerce.RequestResponseModels.Orders;

namespace web_ecommerce.Business;
public partial class OrderBusiness
{
    private async Task CreateOrderValidation(Guid userId)
    {
        var user = await _userService.GetById(userId);
        if (user.UserType != "customer")
        {
            throw new SlnException("Sipariş oluşturmak için müşteri olmanız gereklidir");
        }
    }

    private async Task ChangeOrderStatusValidation(ChangeOrderStatusRequestModel model)
    {
        var user = await _userService.GetById(model.UserId);
        if (user.UserType != "customer")
        {
            throw new SlnException("Sipariş durumunu değiştirmek için müşteri olmanız gerekmektedir");
        }

        if (model.OrderStatus != "approved")
        {
            throw new SlnException(
                "Siparişinizin durumunu sadece approved durumuna çevirebilirsiniz");
        }
    }
}