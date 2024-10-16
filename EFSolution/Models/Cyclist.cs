using System;
using System.Collections.Generic;

namespace EFSolution.Models;

public partial class Cyclist
{
    public int CyclistId { get; set; }

    public int? OrderId { get; set; }

    public string? CprNumber { get; set; }

    public string? PhoneNumber { get; set; }

    public string? BikeType { get; set; }

    public virtual Order? Order { get; set; }

    public virtual ICollection<Trip> Trips { get; set; } = new List<Trip>();
}
