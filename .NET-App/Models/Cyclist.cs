using System;
using System.Collections.Generic;

namespace Assignment2.Models;

public partial class Cyclist
{
    public int CyclistId { get; set; }

    public string Name { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public decimal HourlyRate { get; set; }

    public int BikeId { get; set; }

    public virtual Bike Bike { get; set; } = null!;

    public virtual ICollection<Trip> Trips { get; set; } = new List<Trip>();
}
