using System.ComponentModel.DataAnnotations;

namespace SwiftOrder_Server.Model
{
    public class MenuCategory
    {
        [Key]
        public int MenuCategoryID { get; set; }
        public int RestaurantID { get; set; }
        public string MenuCategoryName { get; set; }
    }
}
