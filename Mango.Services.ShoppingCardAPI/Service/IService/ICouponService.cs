namespace Mango.Services.ShoppingCartAPI.Service.IService
{
    using Mango.Services.ShoppingCardAPI.Models.Dto;

    public interface ICouponService
    {
        Task<CouponDto> GetCouponAsync(string couponCode);
    }
}
