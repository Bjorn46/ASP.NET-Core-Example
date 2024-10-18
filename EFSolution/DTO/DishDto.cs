using System;
using System.Collections.Generic;

namespace EFSolution.DTO;

public partial class DishDto
{
    public int DishId { get; set; }

    public int? CookId { get; set; }

    public decimal? Price { get; set; }

    public TimeOnly? EndTime { get; set; }

    public TimeOnly? StartTime { get; set; }

    public string? DishName { get; set; }

    public int? Quantity { get; set; }

    public virtual CookDto? Cook { get; set; }
}
