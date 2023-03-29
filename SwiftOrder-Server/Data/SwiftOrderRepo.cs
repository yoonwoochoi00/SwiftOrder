using Microsoft.EntityFrameworkCore.ChangeTracking;
using SwiftOrder_Server.Model;

namespace SwiftOrder_Server.Data
{
    public class SwiftOrderRepo : ISwiftOrderRepo
    {
        private readonly SwiftOrderDbContext _dbContext;

        public SwiftOrderRepo(SwiftOrderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Restaurant> GetAllRestaurants()
        {
            IEnumerable<Restaurant> restaurants = _dbContext.Restaurant.ToList<Restaurant>();

            return restaurants;
        }

        public Restaurant GetRestaurantByID(int id)
        {
            Restaurant restaurant = _dbContext.Restaurant.FirstOrDefault(e => e.RestaurantID == id);

            return restaurant;
        }

        public Restaurant AddRestaurant(Restaurant restaurant)
        {
            EntityEntry<Restaurant> e = _dbContext.Restaurant.Add(restaurant);
            Restaurant r = e.Entity;
            _dbContext.SaveChanges();

            return r;
        }

        // validation methods
        public bool ValidateLogin(string emailAddress, string password)
        {
            Restaurant restaurantToLogin = _dbContext.Restaurant.FirstOrDefault(
                e => e.EmailAddress == emailAddress && e.Password == password);

            if (restaurantToLogin == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
