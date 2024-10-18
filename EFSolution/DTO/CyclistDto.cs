using System;
using System.Collections.Generic;

namespace EFSolution.DTO;

public partial class CyclistDto
{
    public int CyclistId { get; set; }

    public int? OrderId { get; set; }

    public string? BikeType { get; set; }
}
