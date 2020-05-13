using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FanGuide.Models
{
    public class SexValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var athlete = (Athlete)validationContext.ObjectInstance;
            if (athlete.Sex == "Woman" || athlete.Sex == "Man")
            {
                return ValidationResult.Success;
            }
            else if (athlete.Sex == null)
            {
                return new ValidationResult("Sex is required");
            }
            return new ValidationResult("Sex should be valid");
        }
    }
}