namespace EFSolution.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        //OrderId is a foreign key and DishId is a foreign key
        public int OrderId { get; set; }
        public int DishId { get; set; }
    }
}
