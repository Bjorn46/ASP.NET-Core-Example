using System;
using System.Collections.Generic;

namespace Assignment2.Models;

public partial class Trip
{
    public int TripId { get; set; }

    public int CyclistId { get; set; }

    public TimeOnly? CompletionTime { get; set; }

    public virtual Cyclist Cyclist { get; set; } = null!;

    public virtual ICollection<Delivery> Deliveries { get; set; } = new List<Delivery>();
}
