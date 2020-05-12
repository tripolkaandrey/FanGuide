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
        public double? Weight { get; set; }
        public double? Height { get; set; }
        public string Citizenship { get; set; }
        public string Origin { get; set; }
        public string Team { get; set; }
        public Sport Sport { get; set; }
        public int SportId { get; set; }
    }
}