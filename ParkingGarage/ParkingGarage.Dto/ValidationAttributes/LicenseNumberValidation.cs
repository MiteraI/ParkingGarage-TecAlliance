using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ParkingGarage.Dto.ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,
        AllowMultiple = false)]
    public class LicenseNumberValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var licenseNumber = value as string;
            if (string.IsNullOrEmpty(licenseNumber))
            {
                return new ValidationResult("License number is required");
            }

            // Define the regular expression pattern
            string pattern = @"^(?:[A-Z]{2}[0-9]{4}|[A-Z]{1}[0-9]{5}|[A-Z]{2}[0-9]{3}[A-Z]{2})$";

            // Check if the license number matches the pattern
            if (!Regex.IsMatch(licenseNumber, pattern))
            {
                return new ValidationResult("Invalid license number format. It must be in Italy format");
            }

            return ValidationResult.Success;
        }
    }
}
