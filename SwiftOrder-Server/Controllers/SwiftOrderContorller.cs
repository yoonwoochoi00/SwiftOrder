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

        [Authorize(AuthenticationSchemes = "LoginScheme")]
        [Authorize(Policy = "UserOnly")]
        [HttpGet("GetAllRestaurants")]
        public ActionResult<IEnumerable<RestaurantOutDto>> GetAllRestaurants()
        {
            IEnumerable<Restaurant> restaurants = _repository.GetAllRestaurants();
            IEnumerable<RestaurantOutDto> r = restaurants.Select(e => new RestaurantOutDto
            { 
                RestaurantID = e.RestaurantID,
                RestaurantName = e.RestaurantName,
                EmailAddress = e.EmailAddress,
                numTables = e.numTables,
                Password = e.Password
            });

            return Ok(r);
        }

        [HttpPost("AddRestaurant")]
        public ActionResult<RestaurantOutDto> AddRestaurant(RestaurantInDto restaurant)
        {
            Restaurant r = new Restaurant
            {
                RestaurantName = restaurant.RestaurantName,
                EmailAddress = restaurant.EmailAddress,
                Password = restaurant.Password,
                numTables = restaurant.numTables
            };

            Restaurant addedRestaurant = _repository.AddRestaurant(r);

            RestaurantOutDto ro = new RestaurantOutDto
            {
                RestaurantName = addedRestaurant.RestaurantName,
                EmailAddress = addedRestaurant.EmailAddress,
                Password = addedRestaurant.Password,
                numTables = addedRestaurant.numTables
            };

            return CreatedAtAction(nameof(AddRestaurant), new
            {
                id = ro.RestaurantID
            }, ro);
        }
        
    }
}
