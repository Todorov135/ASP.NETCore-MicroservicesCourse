namespace Mango.Web.Models.ShoppingCartDtos
{
    using Mango.Web.Models.ProductDtos;

    public class CartDetailsDto
    {
        public int CartDitailsId { get; set; }
        public int CartHeaderId { get; set; }
        public CartHeaderDto? CartHeader { get; set; }
        public int ProductId { get; set; }
        public ProductDto? Product { get; set; }
        public int Count { get; set; }
    }
}
