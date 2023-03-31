using SwiftOrder_Server.Model;

namespace SwiftOrder_Server.Data
{
	public interface ISwiftOrderRepo
	{
		// restaurant
		Restaurant Register(Restaurant restaurant);

		// menu
		IEnumerable<Menu> GetAllMenus();
		Menu AddMenu(Menu menu);

		// validation methods
		public bool ValidateLogin(string emailAddress, string password);
	}
}
