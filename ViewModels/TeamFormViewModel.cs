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
        public int? Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Sport")]
        public int? SportId { get; set; }

        public TeamFormViewModel()
        {
            Id = 0;
        }
        public TeamFormViewModel(Team team)
        {
            Id = team.Id;
            Name = team.Name;
            SportId = team.SportId;
        }
    }
}