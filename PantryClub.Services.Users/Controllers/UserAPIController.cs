using Microsoft.AspNetCore.Mvc;
using PantryClub.Services.Users.Models.Dto;
using PantryClub.Services.Users.Repository;

namespace PantryClub.Services.Users.Controllers
{
    [Route("api/users")]
    public class UserAPIController : ControllerBase
    {
        protected ResponseDto _response;
        private IUserRepository _userRepository;

        public UserAPIController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            this._response = new ResponseDto();
        }

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<UserDto> userDtos = await _userRepository.GetUsers();
                _response.Result = userDtos;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<object> Get(Guid id)
        {
            try
            {
                UserDto userDto = await _userRepository.GetUserById(id);
                _response.Result = userDto;
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
