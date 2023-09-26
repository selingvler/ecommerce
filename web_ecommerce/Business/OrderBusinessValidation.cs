
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

}