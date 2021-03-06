﻿using System;
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
        [StringLength(30)]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Use English letters only please")]

        public string Name { get; set; }
        [Range(1, 20,
            ErrorMessage = "{0} must be between {1} and {2}.")]
        public int Size { get; set; }
        public Sport Sport { get; set; }
        [Display(Name = "Sport")]
        [Required]
        public int SportId { get; set; }

    }
}