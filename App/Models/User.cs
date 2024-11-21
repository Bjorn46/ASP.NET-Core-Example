using Microsoft.AspNetCore.Identity;

namespace Assignment2.Models;

public partial class ApplicationUser : IdentityUser 
{
    public string Name { get; set; }
    public virtual Cook? Cook { get; set; }
    public virtual Cyclist? Cyclist { get; set; }
}

