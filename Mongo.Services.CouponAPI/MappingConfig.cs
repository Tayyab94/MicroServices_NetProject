using AutoMapper;
using Mongo.Services.CouponAPI.Models;
using Mongo.Services.CouponAPI.Models.Dto;

namespace Mongo.Services.CouponAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration Register()
        {
            var mappingConfig = new MapperConfiguration(con =>
            {
                con.CreateMap<CouponDto, Coupon>();
                con.CreateMap<Coupon, CouponDto>();
            });

            return mappingConfig;   
        }
    }
}
