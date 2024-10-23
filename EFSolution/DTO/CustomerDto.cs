using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace EFSolution.DTO;

public partial class CustomerDto
{

    [Required]
    public int CustomerId { get; set; }

    public string? Name { get; set; }

    public string? Adress { get; set; }

}
