using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FanGuide.Models
{
    public class Team
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]

        public string Name { get; set; }
        public Sport Sport { get; set; }
        [Display(Name = "Sport")]
        [Required]
        public int SportId { get; set; }
    }
}