using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FanGuide.Models;

namespace FanGuide.ViewModels
{
    public class AthleteChangeTeamViewModel
    {
        public IEnumerable<Team> Teams { get; set; }
        public IEnumerable<TeamRole> TeamRoles { get; set; }
        public Athlete Athlete { get; set; }
    }
}