namespace PantryClub.Web.Services.IServices
{
    public interface IUserService : IBaseService
    {
        Task<T> GetAllUsersAsync<T>();
        Task<T> GetUserByIdAsync<T>(Guid id);
    }
}
