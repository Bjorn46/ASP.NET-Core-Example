using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace EFSolution.DTO;

public partial class CyclistDto
{

    [Required]
    public int CyclistId { get; set; }

    public int? OrderId { get; set; }

    public string? BikeType { get; set; }
}
