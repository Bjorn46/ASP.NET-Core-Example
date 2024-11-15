using System;
using System.Collections.Generic;

namespace Assignment2.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public int PaymentOption { get; set; }

    public virtual ICollection<Delivery> Deliveries { get; set; } = new List<Delivery>();

    public virtual PaymentOption PaymentOptionNavigation { get; set; } = null!;
}
