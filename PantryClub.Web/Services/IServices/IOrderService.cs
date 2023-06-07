namespace PantryClub.Web.Services.IServices
{
    public interface IOrderService : IBaseService
    {
        Task<T> GetAllOrdersAsync<T>();
    }
}
