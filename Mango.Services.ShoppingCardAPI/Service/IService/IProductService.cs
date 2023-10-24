namespace Mango.Services.ShoppingCartAPI.Service.IService
{
    using Mango.Services.ShoppingCardAPI.Models.Dto;

    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts();
    }
}
