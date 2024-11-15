using System;
using System.Collections.Generic;

namespace Assignment2.Models;

public partial class Review
{
    public int ReviewId { get; set; }

    public int? DeliveryRating { get; set; }

    public int? FoodRating { get; set; }

    public string? Comments { get; set; }

    public int OrderId { get; set; }

    public virtual DishOrder Order { get; set; } = null!;
}
