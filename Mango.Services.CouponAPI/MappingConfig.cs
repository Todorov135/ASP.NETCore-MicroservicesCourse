﻿namespace Mango.Services.CouponAPI
{
    using AutoMapper;
    using Mango.Services.CouponAPI.Models;
    using Mango.Services.CouponAPI.Models.Dto;

    public class MappingConfig
    {
       public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponDto, Coupon>();
                config.CreateMap<Coupon, CouponDto>();
            });

            return mappingConfig;
        }
    }
}
