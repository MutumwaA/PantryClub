using Newtonsoft.Json.Linq;
using PantryClub.Web.Models;
using PantryClub.Web.Services.IServices;

namespace PantryClub.Web.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly IHttpClientFactory _clientFactory;
        public UserService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<T> GetAllUsersAsync<T>()
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.UserAPIBase + "/api/users",
            });
        }

        public async Task<T> GetUserByIdAsync<T>(Guid id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.UserAPIBase + "/api/users/" + id,
            });
        }
    }
}
