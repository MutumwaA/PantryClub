using Newtonsoft.Json.Linq;
using PantryClub.Web.Models;
using PantryClub.Web.Services.IServices;

namespace PantryClub.Web.Services
{
    public class OrderService : BaseService, IOrderService
    {
        private readonly IHttpClientFactory _clientFactory;
        public OrderService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<T> GetAllOrdersAsync<T>()
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.OrderAPIBase + "/api/orders",
            });
        }
    }
}
