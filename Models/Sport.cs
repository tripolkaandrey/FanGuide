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
        public string Name { get; set; }
    }
}