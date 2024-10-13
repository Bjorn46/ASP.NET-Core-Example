namespace EFSolution.Models
{
    public class Trip
    {
        public int TripId { get; set; }
        public string PickupAdress { get; set; }
        public string DeliveryAdress { get; set; }
        public DateTime PickupTime { get; set; }
        public DateTime DeliveryTime { get; set; }
        // CyclistId is a foreign key
        public int CyclistId { get; set; }
    }
}
