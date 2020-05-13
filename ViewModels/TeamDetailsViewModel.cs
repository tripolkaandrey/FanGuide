using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FanGuide.Models;

namespace FanGuide.ViewModels
{
    public class TeamDetailsViewModel
    {
        public List<Athlete> Athletes { get; set; }
        public string Name { get; set; }
        public int SportId { get; set; }

        public TeamDetailsViewModel(Team team)
        {
            Name = team.Name;
            SportId = team.SportId;
        }
    }
}