using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFSolution.Models;

public partial class Dish
{
    [Required]
    public int DishId { get; set; }

    [Required]
    public int? CookId { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "Price must be a non-negative value.")]
    public decimal? Price { get; set; }

    public TimeSpan? EndTime { get; set; }  
    public TimeSpan? StartTime { get; set; } 

    public string? DishName { get; set; }

    public int? Quantity { get; set; }

    public virtual Cook? Cook { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
