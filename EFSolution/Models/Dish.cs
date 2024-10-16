using System;
using System.Collections.Generic;

namespace EFSolution.Models;

public partial class Dish
{
    public int DishId { get; set; }

    public int? CookId { get; set; }

    public decimal? Price { get; set; }

    public TimeOnly? EndTime { get; set; }

    public TimeOnly? StartTime { get; set; }

    public string? DishName { get; set; }

    public int? Quantity { get; set; }

    public virtual Cook? Cook { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
