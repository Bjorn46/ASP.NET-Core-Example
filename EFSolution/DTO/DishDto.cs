using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFSolution.DTO;

public partial class DishDto
{

    [Required]
    public int DishId { get; set; }
    [Required]
    public int? CookId { get; set; }
    public string? DishName { get; set; }
    public int? Quantity { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "Price must be a non-negative value.")]
    public decimal? Price { get; set; }

    public TimeSpan? EndTime { get; set; }  // Change here
    public TimeSpan? StartTime { get; set; } // Change here
}
