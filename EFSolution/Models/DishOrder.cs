using System;
using System.Collections.Generic;

namespace Assignment2.Models;

public partial class DishOrder
{
    public int OrderId { get; set; }

    public int Delivery { get; set; }

    public int DishId { get; set; }

    public DateTime OrderDate { get; set; }

    public int Quantity { get; set; }

    public virtual Delivery DeliveryNavigation { get; set; } = null!;

    public virtual AvailableDish Dish { get; set; } = null!;

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
