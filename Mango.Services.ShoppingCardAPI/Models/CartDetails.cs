namespace Mango.Services.ShoppingCardAPI.Models
{
    using Mango.Services.ShoppingCardAPI.Models.Dto;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class CartDetails
    {
        [Key]
        public int CartDitailsId { get; set; }

        [ForeignKey(nameof(CartHeader))]
        public int CartHeaderId { get; set; }
        public CartHeader CartHeader { get; set; }
        public int ProductId { get; set; }
        [NotMapped]
        public ProductDto Product { get; set; }
        public int Count { get; set; }
    }
}
