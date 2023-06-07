using AutoMapper;
using PantryClub.Services.Users.Models;
using PantryClub.Services.Users.Models.Dto;

namespace PantryClub.Services.Users
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<UserDto, User>();
                config.CreateMap<User, UserDto>();
            });

            return mappingConfig;
        }
    }
}
