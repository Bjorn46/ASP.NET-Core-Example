using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace EFSolution.Models;

public partial class Customer
{
    [Required]
    public int CustomerId { get; set; }

    public string? Name { get; set; }

    public string? Adress { get; set; }

    public string? PhoneNumber { get; set; }

    public string? PaymentOption { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
