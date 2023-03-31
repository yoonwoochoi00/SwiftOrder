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

        // restaurant
        public Restaurant Register(Restaurant restaurant)
        {
            EntityEntry<Restaurant> e = _dbContext.Restaurant.Add(restaurant);
            Restaurant r = e.Entity;
            _dbContext.SaveChanges();

            return r;
        }

        // menu
        public IEnumerable<Menu> GetAllMenus()
        {
            IEnumerable<Menu> menus = _dbContext.Menu.ToList<Menu>();

            return menus;
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
