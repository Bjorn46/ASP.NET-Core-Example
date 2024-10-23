using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace EFSolution.Models;

public partial class Cook
{
    [Required]
    public int CookId { get; set; }

    public int? Rating { get; set; }

    public string? CprNumber { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Adress { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Dish> Dishes { get; set; } = new List<Dish>();
}
