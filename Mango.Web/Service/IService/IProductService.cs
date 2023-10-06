namespace Mango.Web.Service.IService
{
    using Mango.Web.Models;
    using Mango.Web.Models.ProductDtos;

    public interface IProductService
    {
        Task<ResponceDto?> GetProductAsync(string productName);
        Task<ResponceDto?> GetAllProductsAsync();
        Task<ResponceDto?> GetProductByIdAsync(int id);
        Task<ResponceDto?> CreateProductAsync(ProductDto productDto);
        Task<ResponceDto?> UpdateProductAsync(ProductDto productDto);
        Task<ResponceDto?> DeleteProductAsync(int id);
    }
}
