using System;
using System.Collections.Generic;

namespace Assignment2.Models;

public partial class Cook
{
    public string CookId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Address { get; set; } = null!;
    public bool HasPassedFoodSafetyCourse { get; set; } 
    public virtual ICollection<AvailableDish> AvailableDishes { get; set; } = new List<AvailableDish>();
}
