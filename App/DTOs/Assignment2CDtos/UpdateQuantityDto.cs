using System.ComponentModel.DataAnnotations;

namespace Assignment2.DTOs.Assignment2CDtos
{
    public class UpdateQuantityDto
    {
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity cannot be negative.")]
        public int Quantity { get; set; }
    }


}
