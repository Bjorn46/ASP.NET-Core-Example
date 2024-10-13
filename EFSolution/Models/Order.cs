namespace EFSolution.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public string OrderDate { get; set; }
        public int TotalAmount { get; set; }
        // CustomerID is a foreign key
        public int CustomerID { get; set; }
    }
}
