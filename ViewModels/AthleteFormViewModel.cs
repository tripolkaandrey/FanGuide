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
        public int? Id { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        [Display(Name = "Sport")]
        public int? SportId { get; set; }
        public double? Weight { get; set; }

        public double? Height { get; set; }
        public int Age { get; set; }

        public AthleteFormViewModel()
        {
            Id = 0;
        }

        public AthleteFormViewModel(Athlete athlete)
        {
            Id = athlete.Id;
            Name = athlete.Name;
            SportId = athlete.SportId;
            Weight = athlete.Weight;
            Height = athlete.Height;
            Age = athlete.Age;
        }

    }
}
