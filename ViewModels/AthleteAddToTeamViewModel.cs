using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FanGuide.Models;

namespace FanGuide.ViewModels
{
    public class AthleteAddToTeamViewModel
    {
        public IEnumerable<Team> Teams { get; set; }
        public Athlete Athlete { get; set; }
    }
}