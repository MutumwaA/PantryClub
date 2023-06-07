using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PantryClub.Services.Users.DbContexts;
using PantryClub.Services.Users.Models;
using PantryClub.Services.Users.Models.Dto;

namespace PantryClub.Services.Users.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public UserRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<UserDto> GetUserById(Guid userId)
        {
            User user = await _db.Users.Where(x => x.UserId == userId).FirstOrDefaultAsync();
            return _mapper.Map<UserDto>(user);
        }

        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            List<User> productList = await _db.Users.ToListAsync();
            return _mapper.Map<List<UserDto>>(productList);
        }
    }
}
