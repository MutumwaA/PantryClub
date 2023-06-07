using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PantryClub.Services.Orders.DbContexts;
using PantryClub.Services.Orders.Models;
using PantryClub.Services.Orders.Models.Dto;

namespace PantryClub.Services.Orders.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public OrderRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderDto>> GetOrders()
        {
            List<Order> productList = await _db.Orders.ToListAsync();
            return _mapper.Map<List<OrderDto>>(productList);
        }
    }
}
