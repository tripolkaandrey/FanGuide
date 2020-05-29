using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FanGuide.Models;

namespace FanGuide.ViewModels
{
    public class AthleteEditFormViewModel
    {
        public IEnumerable<Sport> Sports { get; set; }
        public Athlete Athlete;
    }
}