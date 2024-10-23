using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace EFSolution.Models;

public partial class Trip
{
    [Required]
    public int TripId { get; set; }

    [Required]
    public int? CyclistId { get; set; }

    public string? PickupAdress { get; set; }

    public string? DeliveryAdress { get; set; }

    public TimeOnly? DeliveryTime { get; set; }

    public TimeOnly? PickupTime { get; set; }

    public DateOnly? TripDate { get; set; }

    public virtual Cyclist? Cyclist { get; set; }
}
