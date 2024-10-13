namespace EFSolution.Models
{
    public class Dish
    {
        public int DishId { get; set; }
        public string DishName { get; set; }
        public string Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        //CookId is a foreign key
        public string CookId { get; set; }
    }
}
