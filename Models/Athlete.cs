using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FanGuide.Models
{
    public class Athlete
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string Name { get; set; }
        [RegularExpression("^[0-9]{1,3}$", ErrorMessage = "Age must be valid")]
        [AgeValidation]
        public int Age { get; set; }

        [SexValidation]
        public string Sex { get; set; }
        [MeasurementsValidation]
        public double? Weight { get; set; }
        [MeasurementsValidation]
        public double? Height { get; set; }
        [StringLength(255)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string Achievements { get; set; }
        [StringLength(255)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string Citizenship { get; set; }
        [StringLength(255)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string Origin { get; set; }
        public Team Team { get; set; }
        [Display(Name = "Team")]
        public int? TeamId { get; set; }
        public Sport Sport { get; set; }
        [Display(Name = "Sport")]
        [Required]
        public int SportId { get; set; }
    }
}