using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FanGuide.Folder;
using FanGuide.Models;

namespace FanGuide.ViewModels
{

    public class AthleteFormViewModel
    {
        public IEnumerable<Sport> Sports { get; set; }
        public IEnumerable<SelectListItem> SexList
        {
            get
            {
                return Enum.GetNames(typeof(SexType)).Select(e => new SelectListItem() { Text = e, Value = e });
            }
        }
        public Athlete Athlete;
    }
}
