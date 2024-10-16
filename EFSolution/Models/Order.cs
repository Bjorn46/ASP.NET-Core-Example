using System;
using System.Collections.Generic;

namespace EFSolution.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int? CustomerId { get; set; }

    public DateOnly? OrderDate { get; set; }

    public decimal? TotalAmount { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<Cyclist> Cyclists { get; set; } = new List<Cyclist>();

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
