using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FanGuide.Models;

namespace FanGuide.ViewModels
{
    public class TeamEditFormViewModel
    {
        public Team Team { get; set; }
        public IEnumerable<Athlete> Athletes { get; set; }
    }
}