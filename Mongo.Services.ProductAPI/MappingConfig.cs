namespace Mongo.Services.ProductAPI
{
    using AutoMapper;
    using Mongo.Services.ProductAPI.Models;
    using Mongo.Services.ProductAPI.Models.Models.Dto;

    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Product, ProductDto>();
                config.CreateMap<ProductDto, Product>();
            });

            return mappingConfig;
        }
    }
}
