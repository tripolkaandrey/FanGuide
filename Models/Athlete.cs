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
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Use English letters only please")]
        public string Name { get; set; }
        [RegularExpression("^[0-9]{1,3}$", ErrorMessage = "Invalid age")]
        [AgeValidation]
        public int Age { get; set; }

        [SexValidation]
        public string Sex { get; set; }
        [Range(30, 300,
            ErrorMessage = "{0} must be between {1} and {2}.")]
        public double? Weight { get; set; }
        [Range(100,270,
            ErrorMessage = "{0} must be between {1} and {2} cm.")]
        public double? Height { get; set; }
        [StringLength(255)]
        public string Achievements { get; set; }
        [StringLength(255)]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Use English letters only please")]
        public string Citizenship { get; set; }
        [StringLength(255)]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Use English letters only please")]
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