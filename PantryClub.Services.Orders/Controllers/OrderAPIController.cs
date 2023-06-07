using Microsoft.AspNetCore.Mvc;
using PantryClub.Services.Orders.Models.Dto;
using PantryClub.Services.Orders.Repository;

namespace PantryClub.Services.Orders.Controllers
{
    [Route("api/orders")]
    public class OrderAPIController : ControllerBase
    {
        protected ResponseDto _response;
        private IOrderRepository _orderRepository;

        public OrderAPIController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
            this._response = new ResponseDto();
        }

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<OrderDto> ordersDtos = await _orderRepository.GetOrders();
                _response.Result = ordersDtos;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }
    }
}
