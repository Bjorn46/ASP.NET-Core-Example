using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace EFSolution.Models;

public partial class Cyclist
{
    [Required]
    public int CyclistId { get; set; }

    [Required]
    public int? OrderId { get; set; }

    public string? CprNumber { get; set; }

    public string? PhoneNumber { get; set; }

    public string? BikeType { get; set; }

    public virtual Order? Order { get; set; }

    public virtual ICollection<Trip> Trips { get; set; } = new List<Trip>();
}
