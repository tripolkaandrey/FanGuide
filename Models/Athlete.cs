using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using FanGuide.Folder;

namespace FanGuide.Models
{

    public class Athlete
    {
        public int Id { get; set; }
        [Required]
        [StringLength(40)]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Use English letters only please")]
        public string Name { get; set; }
        [Range(8, 100,
            ErrorMessage = "{0} must be between {1} and {2}.")]
        public int Age { get; set; }
        public Sex Sex { get; set; }
        [Display(Name = "Sex")]
        public int? SexId { get; set; }
        [Range(30, 300,
            ErrorMessage = "{0} must be between {1} and {2}.")]
        public double? Weight { get; set; }
        [Range(100,270,
            ErrorMessage = "{0} must be between {1} and {2} cm.")]
        public double? Height { get; set; }
        public List<Achievement> Achievements { get; set; } = new List<Achievement>();
        [StringLength(30)]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Use English letters only please")]
        public string Citizenship { get; set; }
        [StringLength(30)]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Use English letters only please")]
        public string Origin { get; set; }
        public Team Team { get; set; }
        [Display(Name = "Team")]
        public int? TeamId { get; set; }
        public TeamRole TeamRole { get; set; }
        [Display(Name = "Role in a Team")]
        public int? TeamRoleId { get; set; }
        public Sport Sport { get; set; }
        [Display(Name = "Sport")]
        [Required]
        public int SportId { get; set; }
    }
}