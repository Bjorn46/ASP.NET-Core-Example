using System;
using System.Collections.Generic;

namespace Assignment2.Models;

public partial class AvailableDish
{
    public int DishId { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public string Currency { get; set; } = null!;

    public int Quantity { get; set; }

    public DateTime AvailableFrom { get; set; }

    public DateTime AvailableTo { get; set; }

    public string CookId { get; set; } = null!;

    public virtual Cook Cook { get; set; } = null!;

    public virtual ICollection<DishOrder> DishOrders { get; set; } = new List<DishOrder>();
}
