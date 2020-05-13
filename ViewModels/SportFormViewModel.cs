using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FanGuide.ViewModels
{
    public class SportFormViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string Name { get; set; }
    }
}