namespace Mango.Services.ShoppingCartAPI
{
    using AutoMapper;
    using Mango.Services.ShoppingCardAPI.Models;
    using Mango.Services.ShoppingCardAPI.Models.Dto;

    public static class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<CartHeader, CartHeaderDto>().ReverseMap();
                config.CreateMap<CartDetails, CartDetailsDto>().ReverseMap();
            });
           

            return mapper;
        }
    }
}
