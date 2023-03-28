using System.ComponentModel.DataAnnotations;

namespace SwiftOrder_Server.Model
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        public int KioskID { get; set; }
        public int MenuID { get; set; }
        public bool IsCompleted { get; set; }
    }
}
