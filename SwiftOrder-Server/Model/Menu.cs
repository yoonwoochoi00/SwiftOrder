using System.ComponentModel.DataAnnotations;

namespace SwiftOrder_Server.Model
{
    public class Menu
    {
        [Key]
        public int MenuID { get; set; }
        public int RestaurantID { get; set; }
        public string MenuName { get; set; }
        public string MenuDescription { get; set; }
        public string MenuImage { get; set; }
        public bool MenuAvailability { get; set; }
    }
}
