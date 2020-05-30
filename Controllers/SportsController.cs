using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FanGuide.Domain;
using FanGuide.Models;
using FanGuide.ViewModels;

namespace FanGuide.Controllers
{
    public class SportsController : Controller
    {
        private IRepository<Sport> Sports_db;
        private IRepository<Team> Teams_db;


        public SportsController()
        {
            Sports_db = new SportsRepository();
            Teams_db = new TeamsRepository();
        }
        // GET: Sports
        public ActionResult Index()
        {
            var sports = Sports_db.GetList();
            return View(sports);
        }


        // GET: Sports/Create
        public ActionResult Create()
        {
            var viewModel = new Sport();
            return View("SportForm", viewModel);
        }

        [HttpPost]
        public ActionResult Create(Sport sport)
        {
            if (!ModelState.IsValid)
            {
                return View("SportForm");
            }

            bool nameAlreadyExists = Sports_db.GetList().SingleOrDefault(s => s.Name == sport.Name) != null;

            if (nameAlreadyExists)
            {
                ModelState.AddModelError(string.Empty, "Sport already exists.");
                return View("SportForm");
            }

            Sports_db.Create(sport);

            return RedirectToAction("Index", "Sports");
        }


        // GET: Sports/Edit/5
        public ActionResult Edit(int id)
        {
            var sport = Sports_db.Get(id);

            if (sport == null)
                return HttpNotFound();

            return View("SportForm", sport);
        }

        [HttpPost]
        public ActionResult Edit(Sport sport)
        {
            if (!ModelState.IsValid)
            {
                return View("SportForm", sport);
            }
            var sportInDb = Sports_db.Get(sport.Id);
            sportInDb.Name = sport.Name;
            if (sportInDb.isTeamSport != sport.isTeamSport)
            {
                var teams = Teams_db.GetList().Where(x => x.SportId == sport.Id);
                foreach (var team in teams)
                {
                    Teams_db.Delete(team.Id);
                }
            }
            Sports_db.Update(sportInDb);
            return RedirectToAction("Index", "Sports");
        }


        // GET: Sports/Delete/5

        public ActionResult Delete(int id)
        {
            var sport = Sports_db.Get(id);

            if (sport == null)
                return HttpNotFound();

            Sports_db.Delete(id);
            return RedirectToAction("Index", "Sports");
        }
    }
}
