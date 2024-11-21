using System;
using System.Collections.Generic;

namespace Assignment2.Models;

public partial class Delivery
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public int Trip_ID { get; set; }

    public DateTime? DeliveryTime { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<DishOrder> DishOrders { get; set; } = new List<DishOrder>();

    public virtual Trip TripNavigation { get; set; } = null!;
}
