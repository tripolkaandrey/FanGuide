using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FanGuide.Models
{
    public class AgeValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var athlete = (Athlete)validationContext.ObjectInstance;
            if (athlete.Age >= 10)
            {
                return ValidationResult.Success;
            }
            else if (athlete.Age < 10)
            {
                return new ValidationResult("Age must be greater than 10");
            }
            return new ValidationResult("Age should be valid");
        }
    }
}