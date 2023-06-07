using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PantryClub.Web.Models;
using PantryClub.Web.Services;
using PantryClub.Web.Services.IServices;
using System.Reflection;

namespace PantryClub.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<IActionResult> OrderIndex()
        {
            List<OrderDto> list = new();
            var response = await _orderService.GetAllOrdersAsync<ResponseDto>();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<OrderDto>>(Convert.ToString(response.Result));
            }
            return View(list);
        }

		[HttpPost]
		public async Task<IActionResult> Insert_data()
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

				List<OrderDto> list = new();

				var response = await _orderService.GetAllOrdersAsync<ResponseDto>();

				if (response != null && response.IsSuccess)
				{
					list = JsonConvert.DeserializeObject<List<OrderDto>>(Convert.ToString(response.Result));
				}

				if (!string.IsNullOrEmpty(sortColumn) && !string.IsNullOrEmpty(sortColumnDirection))
				{
					var propertyInfo = typeof(OrderDto).GetProperty(sortColumn, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
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
						s.ProductName.Contains(searchValue.ToLower()) ||
						s.Price.ToString().Contains(searchValue.ToLower()) ||
						s.Quantity.ToString().Contains(searchValue.ToLower())
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
