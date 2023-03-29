using SwiftOrder_Server.Model;

namespace SwiftOrder_Server.Data
{
	public interface ISwiftOrderRepo
	{
		IEnumerable<Restaurant> GetAllRestaurants();
		Restaurant GetRestaurantByID(int id);
		Restaurant AddRestaurant(Restaurant customer);

		// validation methods
		public bool ValidateLogin(string emailAddress, string password);
	}
}
