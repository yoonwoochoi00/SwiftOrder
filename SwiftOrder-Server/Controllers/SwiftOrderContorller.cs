using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SwiftOrder_Server.Data;
using SwiftOrder_Server.Dtos;
using SwiftOrder_Server.Model;

namespace SwiftOrder_Server.Controllers
{
    [Route("SwiftOrder")]
    [ApiController]
    public class SwiftOrderController : Controller
    {
        private readonly ISwiftOrderRepo _repository;

        public SwiftOrderController(ISwiftOrderRepo repository)
        {
            _repository = repository;
        }

        [HttpPost("Register")]
        public ActionResult<RestaurantOutDto> Register(RestaurantInDto restaurant)
        {
            Restaurant r = new Restaurant
            {
                RestaurantName = restaurant.RestaurantName,
                EmailAddress = restaurant.EmailAddress,
                Password = restaurant.Password,
                numTables = restaurant.numTables
            };

            Restaurant addedRestaurant = _repository.Register(r);

            RestaurantOutDto ro = new RestaurantOutDto
            {
                RestaurantName = addedRestaurant.RestaurantName,
                EmailAddress = addedRestaurant.EmailAddress,
                Password = addedRestaurant.Password,
                numTables = addedRestaurant.numTables
            };

            return CreatedAtAction(nameof(Register), new
            {
                id = ro.RestaurantID
            }, ro);
        }

        // menu
        [Authorize(AuthenticationSchemes = "LoginScheme")]
        [Authorize(Policy = "UserOnly")]
        [HttpGet("GetAllMenus")]
        public ActionResult<IEnumerable<MenuOutDto>> GetAllMenus()
        {
            IEnumerable<Menu> menus = _repository.GetAllMenus();
            IEnumerable<MenuOutDto> result = menus.Select(e => new MenuOutDto
            {
                MenuID = e.MenuID,
                RestaurantID = e.RestaurantID,
                MenuName = e.MenuName,
                MenuDescription = e.MenuDescription,
                MenuPrice = e.MenuPrice,
                MenuImage = e.MenuImage,
                MenuAvailability = e.MenuAvailability
            });

            return Ok(result);
        }
    }
}
