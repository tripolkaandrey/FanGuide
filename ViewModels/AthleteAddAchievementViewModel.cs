using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FanGuide.Folder;
using FanGuide.Models;

namespace FanGuide.ViewModels
{
    public class AthleteAddAchievementViewModel
    {
        public Athlete Athlete { get; set; }
        public AchievementType Achievement { get; set; }

        public IEnumerable<SelectListItem> AchievementsList
        {
            get
            {
                return Enum.GetNames(typeof(AchievementType)).Select(e => new SelectListItem() { Text = e, Value = e });
            }
        }

    }
}