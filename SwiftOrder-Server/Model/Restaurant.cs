using System.ComponentModel.DataAnnotations;

namespace SwiftOrder_Server.Model
{
    public class Restaurant
    {
        [Key]
        public int RestaurantID { get; set; }
        public string RestaurantName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public int numTables { get; set; }
    }
}
