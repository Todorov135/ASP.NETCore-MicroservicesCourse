namespace Mango.Services.ShoppingCardAPI.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class CartHeader
    {
        [Key]
        public int CartHeaderId { get; set; }

        public string? UserId { get; set; }

        public string? CouponCode { get; set; }

        [NotMapped]
        public double Discount { get; set; }

        [NotMapped]
        public double CartTotal { get; set; }
    }
}
