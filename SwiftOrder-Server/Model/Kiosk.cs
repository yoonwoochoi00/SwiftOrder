using System.ComponentModel.DataAnnotations;

namespace SwiftOrder_Server.Model
{
    public class Kiosk
    {
        [Key]
        public int KioskID { get; set; }
        public int RestaurantID { get; set; }
        public bool IsPaid { get; set; }
        public bool IsKitchen { get; set; }
    }
}
