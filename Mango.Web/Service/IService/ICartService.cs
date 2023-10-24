namespace Mango.Web.Service.IService
{
    using Mango.Web.Models;
    using Mango.Web.Models.CouponDtos;
    using Mango.Web.Models.ShoppingCartDtos;

    public interface ICartService
    {
        Task<ResponceDto?> GetCartByUserIdAsync(string userId);
        Task<ResponceDto?> UpsertCartAsync(CartDto cartDto);
        Task<ResponceDto?> RemoveFromCartAsync(int cartDetailsId);
        Task<ResponceDto?> ApplyCouponAsync(CartDto cartDto);
    }
}
