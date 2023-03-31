namespace SwiftOrder_Server.Dtos
{
    public class MenuOutDto
    {
        public int MenuID { get; set; }
        public int RestaurantID { get; set; }
        public string MenuName { get; set; }
        public string? MenuDescription { get; set; }
        public double MenuPrice { get; set; }
        public string? MenuImage { get; set; }
        public bool MenuAvailability { get; set; }
    }
}
