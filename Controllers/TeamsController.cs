using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FanGuide.Domain;
using FanGuide.Models;
using FanGuide.ViewModels;

namespace FanGuide.Controllers
{
    public class TeamsController : Controller
    {
        private IRepository<Team> Teams_db;
        private IRepository<Sport> Sports_db;
        private IRepository<Athlete> Athletes_db;

        public TeamsController()
        {
            Teams_db = new TeamsRepository();
            Sports_db = new SportsRepository();
            Athletes_db = new AthletesRepository();
        }

        // GET: Teams
        public ActionResult Index(string search, int? sportId)
        {
            var teams = Teams_db.GetList(x => x.Sport);
            var sports = Sports_db.GetList();

            if (!string.IsNullOrEmpty(search))
            {
                teams = teams.Where(s => s.Name.ToLower().Contains(search) || s.Sport.Name.ToLower().Contains(search)).ToList();
            }
            if (sportId != null)
            {
                teams = teams.Where(s => s.SportId == sportId).ToList();
            }

            var viewModel = new TeamListViewModel()
            {
                Teams = teams,
                Sports = new SelectList(sports, "Id", "Name")
            };

            return View(viewModel);
        }

        // GET: Teams/Details/5
        public ActionResult Details(int id)
        {
            var team = Teams_db.GetList(x => x.Sport).SingleOrDefault(x => x.Id == id);
            var athletes = Athletes_db.GetList(x=>x.TeamRole)
                                        .Where(x => x.TeamId == id);

            var viewModel = new TeamDetailsViewModel()
            {
                Team = team,
                Athletes = athletes
            };
            return View(viewModel);
        }

        // GET: Teams/Create
        public ActionResult Create()
        {
            var sports = Sports_db.GetList().Where(x=> x.isTeamSport);
            var viewModel = new TeamFormViewModel()
            {
                Sports = sports
            };
            return View("CreateForm", viewModel);
        }

        [HttpPost]
        public ActionResult Create(Team team)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new TeamFormViewModel(team)
                {
                    Sports = Sports_db.GetList()
                };
                return View("CreateForm", viewModel);
            }
            bool nameAlreadyExists = Teams_db.GetList().SingleOrDefault(t => t.Name == team.Name) != null;

            if (nameAlreadyExists)
            {
                ModelState.AddModelError(string.Empty, "Team already exists.");
                return View("CreateForm");
            }
            Teams_db.Create(team);
            Teams_db.Save();
            return RedirectToAction("Index", "Teams");
        }


        // GET: Teams/Edit/5
        public ActionResult Edit(int id)
        {
            var team = Teams_db.Get(id);

            if (team == null)
                return HttpNotFound();

            return View("EditForm", team);
        }

        [HttpPost]
        public ActionResult Edit(Team team)
        {
            if (!ModelState.IsValid)
            {
                return View("EditForm", team);
            }
            Teams_db.Update(team);
            Teams_db.Save();
            return RedirectToAction("Index", "Teams");
        }


        // GET: Teams/Delete/5
        public ActionResult Delete(int id)
        {
            var team = Teams_db.Get(id);
            if (team == null)
                return HttpNotFound();
            var athletes = Athletes_db.GetList().Where(x => x.TeamId == id).ToList();
            if (athletes.Count != 0)
            {
                foreach (var athlete in athletes)
                {
                    athlete.TeamId = null;
                }
            }
            Teams_db.Delete(id);
            Teams_db.Save();
            return RedirectToAction("Index", "Teams");
        }

    }
}
