using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace EFSolution.Models;

public partial class OrderDetail
{
    [Required]
    public int OrderDetailId { get; set; }

    public decimal? Price { get; set; }

    public int? Quantity { get; set; }

    [Required]
    public int? DishId { get; set; }

    [Required]
    public int? OrderId { get; set; }

    public virtual Dish? Dish { get; set; }

    public virtual Order? Order { get; set; }
}
