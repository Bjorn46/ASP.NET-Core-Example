using System;
using System.Collections.Generic;

namespace EFSolution.DTO;

public partial class CookDto
{
    public int CookId { get; set; }

    public int? Rating { get; set; }

    public string? Adress { get; set; }

    public string? Name { get; set; }

}
