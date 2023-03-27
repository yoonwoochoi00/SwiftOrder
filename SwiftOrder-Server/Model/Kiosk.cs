using System.ComponentModel.DataAnnotations;

namespace SwiftOrder_Server.Model
{
    public class Kiosk
    {
        [Key]
        public int KioskID { get; set; }
        public int RestaurantID { get; set; }
        public int MenuID { get; set; }
    }
}
