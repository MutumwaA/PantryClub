using PantryClub.Services.Orders.Models.Dto;

namespace PantryClub.Services.Orders.Repository
{
    public interface IOrderRepository
    {
        Task<IEnumerable<OrderDto>> GetOrders();
    }
}
