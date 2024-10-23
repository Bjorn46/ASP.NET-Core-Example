using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace EFSolution.DTO;

public partial class TripDto
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

    public virtual CyclistDto? Cyclist { get; set; }
}
