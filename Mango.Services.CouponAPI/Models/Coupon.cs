namespace Mango.Services.CouponAPI.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Coupon
    {
        [Key]
        public int CouponId { get; set; }
        [Required]
        public string CouponCode { get; set; } = null!;
        [Required]
        public double DiscountAmount { get; set; }
        public int MinAmount { get; set; }
    }
}
