namespace Mango.Web.Service.IService
{
    using Mango.Web.Models;
    using Mango.Web.Models.CouponDtos;

    public interface ICouponService
    {
        Task<ResponceDto?> GetCouponAsync(string couponCode);
        Task<ResponceDto?> GetAllCouponsAsync();
        Task<ResponceDto?> GetCouponByIdAsync(int id);
        Task<ResponceDto?> CreateCouponAsync(CouponDto couponDto);
        Task<ResponceDto?> UpdateCouponAsync(CouponDto couponDto);
        Task<ResponceDto?> DeleteCouponAsync(int id);
    }
}
