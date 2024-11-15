using System.ComponentModel.DataAnnotations;
using Assignment2.Validations;

namespace Assignment2.DTOs.Assignment2CDtos
{
    public class CreateAvailableDishDto
    {
        [Required]
        public string CookId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required] // ensures Price is not left empty
        [NonNegativeValue] // ensures Price cannot be negative.
        public decimal Price { get; set; }

        [Required]
        public string Currency { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")] // ensures a minimum quantity constraint.
        public int Quantity { get; set; }

        [Required]
        public DateTime AvailableFrom { get; set; }

        [Required]
        public DateTime AvailableTo { get; set; }
    }


}
