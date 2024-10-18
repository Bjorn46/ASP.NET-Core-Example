using System;
using System.Collections.Generic;

namespace EFSolution.DTO;

public partial class OrderDetailDto
{
    public int OrderDetailId { get; set; }

    public decimal? Price { get; set; }

    public int? Quantity { get; set; }

    public int? DishId { get; set; }

    public int? OrderId { get; set; }

    public virtual DishDto? Dish { get; set; }

    public virtual OrderDto? Order { get; set; }
}
