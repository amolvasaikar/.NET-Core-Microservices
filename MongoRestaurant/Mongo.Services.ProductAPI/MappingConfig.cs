using AutoMapper;
using Mongo.Services.ProductAPI.Models;
using Mongo.Services.ProductAPI.Models.DTO;

namespace Mongo.Services.ProductAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfigs = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDto, Product>();
                config.CreateMap<Product, ProductDto>();    
            });
            return mappingConfigs;
        }
    }
}
