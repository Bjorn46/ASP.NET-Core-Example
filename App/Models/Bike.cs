using System;
using System.Collections.Generic;

namespace Assignment2.Models;

public partial class Bike
{
    public int BikeId { get; set; }

    public string BikeType { get; set; } = null!;

    public virtual ICollection<Cyclist> Cyclists { get; set; } = new List<Cyclist>();
}
