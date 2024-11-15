using System;
using System.Collections.Generic;

namespace Assignment2.Models;

public partial class PaymentOption
{
    public int OptionId { get; set; }

    public string PaymentType { get; set; } = null!;

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
