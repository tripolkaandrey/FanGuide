using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using FanGuide.Models;

namespace FanGuide.ViewModels
{
    public class TeamFormViewModel
    {
        public IEnumerable<Sport> Sports { get; set; }
        public Team Team { get; set; }

        public TeamFormViewModel()
        {
            Team = new Team {Id = 0};
        }
        public TeamFormViewModel(Team team)
        {
            Team = team;
        }
    }
}