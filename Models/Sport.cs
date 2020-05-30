using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FanGuide.Models
{
    public class Sport
    {
        public int Id  { get; set; }
        [Required]
        [StringLength(30)]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Use English letters only please")]
        public string Name { get; set; }
        [Display(Name="Is it a team sport?")]
        [Required] public bool isTeamSport { get; set; } = false;
    }
}