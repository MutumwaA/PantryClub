using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PantryClub.Web.Models;
using PantryClub.Web.Services.IServices;
using System.Reflection;

namespace PantryClub.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<IActionResult> UserIndex()
        {
            return View();
        }

        public async Task<IActionResult> UserDetails(Guid userId)
        {
            var response = await _userService.GetUserByIdAsync<ResponseDto>(userId);
            if (response != null && response.IsSuccess)
            {
                UserDto model = JsonConvert.DeserializeObject<UserDto>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }

		[HttpPost]
		public async Task<IActionResult> Getdata()
		{
			try
			{
				int totalRecord = 0;
				int filterRecord = 0;

				int draw = int.Parse(Request.Form["draw"].ToString() ?? "0");

				string sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"] + "][name]"].ToString();

				string sortColumnDirection = Request.Form["order[0][dir]"].ToString();

				string searchValue = Request.Form["search[value]"].ToString();

				int pageSize = int.Parse(Request.Form["length"].ToString() ?? "0");

				int skip = int.Parse(Request.Form["start"].ToString() ?? "0");

				List<UserDto> list = new();

				var response = await _userService.GetAllUsersAsync<ResponseDto>();

				if (response != null && response.IsSuccess)
				{
					list = JsonConvert.DeserializeObject<List<UserDto>>(Convert.ToString(response.Result));
				}

				if (!string.IsNullOrEmpty(sortColumn) && !string.IsNullOrEmpty(sortColumnDirection))
				{
					var propertyInfo = typeof(UserDto).GetProperty(sortColumn, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
					if (propertyInfo != null)
					{
						if (sortColumnDirection.ToUpper() == "DESC")
						{
							list = list.OrderByDescending(x => propertyInfo.GetValue(x, null)).ToList();
						}
						else
						{
							list = list.OrderBy(x => propertyInfo.GetValue(x, null)).ToList();
						}
					}
				}

				totalRecord = list.Count();

				if (!(String.IsNullOrEmpty(searchValue)))
				{
					list = list.Where(s =>
						s.FirstName.Contains(searchValue.ToLower()) ||
						s.LastName.Contains(searchValue.ToLower()) ||
						s.Email.Contains(searchValue.ToLower()) ||
						s.DateOfBirth.ToString().Contains(searchValue.ToLower())
					).ToList();
				}

				filterRecord = list.Count();

				var pagedList = list.Skip(skip).Take(pageSize).ToList();

				var returnObj = new
				{
					draw = draw,
					recordsTotal = totalRecord,
					recordsFiltered = filterRecord,
					data = pagedList
				};

				return Json(returnObj);
			}
			catch (Exception ex)
			{
				return BadRequest();
			}
		}

	}
}
