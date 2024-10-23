using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFSolution.DTO;

public partial class CookDto
{

    [Required]
    public int CookId { get; set; }

    public int? Rating { get; set; }

    public string? Adress { get; set; }

    public string? Name { get; set; }

}
