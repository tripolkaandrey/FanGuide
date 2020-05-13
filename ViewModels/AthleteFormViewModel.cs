using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using FanGuide.Models;

namespace FanGuide.ViewModels
{
    public class AthleteFormViewModel
    {
        public IEnumerable<Sport> Sports { get; set; }
        public Athlete Athlete;
    }
}
