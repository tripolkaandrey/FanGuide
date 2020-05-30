using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FanGuide.Models;

namespace FanGuide.ViewModels
{
    public class TeamListViewModel
    {
        public IEnumerable<Team> Teams { get; set; }
        public SelectList Sports { get; set; }
    }
}