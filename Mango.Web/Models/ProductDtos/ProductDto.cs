namespace Mango.Web.Models.ProductDtos
{
    using System.ComponentModel.DataAnnotations;

    public class ProductDto
    {
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Range(1, 1000)]
        public double Price { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string ImgUrl { get; set; }
    }
}
