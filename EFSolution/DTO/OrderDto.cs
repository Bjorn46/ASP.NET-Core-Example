using System;
using System.Collections.Generic;

namespace EFSolution.DTO;

public partial class OrderDto
{
    public int OrderId { get; set; }

    public int? CustomerId { get; set; }

    public DateOnly? OrderDate { get; set; }

    public decimal? TotalAmount { get; set; }

    public virtual CustomerDto? Customer { get; set; }
}
