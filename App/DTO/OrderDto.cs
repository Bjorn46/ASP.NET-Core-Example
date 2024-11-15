using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace EFSolution.DTO;

public partial class OrderDto
{

    [Required]
    public int OrderId { get; set; }

    [Required]
    public int? CustomerId { get; set; }

    public DateOnly? OrderDate { get; set; }

    public decimal? TotalAmount { get; set; }

    public virtual CustomerDto? Customer { get; set; }
}
