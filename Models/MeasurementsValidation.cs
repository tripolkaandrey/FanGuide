using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FanGuide.Models
{
    public class MeasurementsValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var athlete = (Athlete)validationContext.ObjectInstance;
            if (athlete.Height <= 140 )
            {
                return new ValidationResult("Height should be valid");
            }

            if (athlete.Weight <= 50)
            {
                return new ValidationResult("Weight should be valid");
            }
            return ValidationResult.Success;
        }
    }
}