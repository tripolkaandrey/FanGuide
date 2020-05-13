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
        public string Name { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }

        public double? Weight { get; set; }
        public double? Height { get; set; }
        public string Achievements { get; set; }
        public string Citizenship { get; set; }
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