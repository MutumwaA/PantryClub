using PantryClub.Services.Users.Models;
using PantryClub.Services.Users.Models.Dto;

namespace PantryClub.Services.Users.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserDto>> GetUsers();
        Task<UserDto> GetUserById(Guid userId);
    }
}
