namespace Assignment2.DTOs.Assignment2CDtos
{
    public class AvailableDishDto
    {
        public int DishId { get; set; }
        public string CookId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }
        public int Quantity { get; set; }
        public DateTime AvailableFrom { get; set; }
        public DateTime AvailableTo { get; set; }
    }


}
