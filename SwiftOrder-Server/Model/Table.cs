using System.ComponentModel.DataAnnotations;

namespace SwiftOrder_Server.Model
{
    public class Table
    {
        [Key]
        public int TableID { get; set; }
        public int RestaurantID { get; set; }
        public int TableNumber { get; set; }
        public bool TableAvailability { get; set; }
    }
}
