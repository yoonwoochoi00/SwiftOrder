using SwiftOrder_Server.Model;

namespace SwiftOrder_Server.Data
{
	public interface ISwiftOrderRepo
	{
		Restaurant Register(Restaurant restaurant);

		// validation methods
		public bool ValidateLogin(string emailAddress, string password);
	}
}
