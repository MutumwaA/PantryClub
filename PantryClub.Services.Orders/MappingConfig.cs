using AutoMapper;
using PantryClub.Services.Orders.Models;
using PantryClub.Services.Orders.Models.Dto;

namespace PantryClub.Services.Orders
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<OrderDto, Order>();
                config.CreateMap<Order, OrderDto>();
            });

            return mappingConfig;
        }
    }
}
