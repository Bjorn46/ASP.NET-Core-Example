using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace EFSolution.DTO;

public partial class OrderDetailDto
{

    [Required]
    public int OrderDetailId { get; set; }

    public decimal? Price { get; set; }

    public int? Quantity { get; set; }

    [Required]
    public int? DishId { get; set; }

    [Required]
    public int? OrderId { get; set; }

    public virtual DishDto? Dish { get; set; }

    public virtual OrderDto? Order { get; set; }
}
