using System.ComponentModel.DataAnnotations;

namespace Assignment2.Validations
{
    // AttributeUsage: Specifies that this attribute can only be used on properties or fields and does not allow multiple instances on the same element.

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class NonNegativeValueAttribute : ValidationAttribute
    {
        public NonNegativeValueAttribute() : base("The {0} field must be a non-negative value.")
        {
        }

        // Overriding the IsValid method to implement custom validation logic.
        public override bool IsValid(object value)
        {
            // Check if the value is of type decimal
            if (value is decimal decimalValue)
            {
                // Return true if the value is non-negative, false otherwise
                return decimalValue >= 0;
            }

            // If the value is not a decimal, return false, indicating invalid input
            return false;
        }

    }
}
