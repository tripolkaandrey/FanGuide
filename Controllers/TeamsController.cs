using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FanGuide.Models;
using FanGuide.ViewModels;

namespace FanGuide.Controllers
{
    public class TeamsController : Controller
    {
        private ApplicationDbContext _context;

        public TeamsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Teams
        public ActionResult Index()
        {
            var teams = _context.Teams.ToList();
            return View(teams);
        }

        // GET: Teams/Details/5
        public ActionResult Details(int id)
        {
            var team = _context.Teams.Include(x => x.Sport).SingleOrDefault(x => x.Id == id);
            var athletes = _context.Athletes.Include(x=>x.TeamRole)
                                        .Where(x => x.TeamId == id).ToList();

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
            var sports = _context.Sports.Where(x=> x.isTeamSport).ToList();
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
                    Sports = _context.Sports.ToList()
                };
                return View("CreateForm", viewModel);
            }
            bool nameAlreadyExists = _context.Teams.SingleOrDefault(t => t.Name == team.Name) != null;

            if (nameAlreadyExists)
            {
                ModelState.AddModelError(string.Empty, "Team already exists.");
                return View("CreateForm");
            }
            _context.Teams.Add(team);
            _context.SaveChanges();
            return RedirectToAction("Index", "Teams");
        }


        // GET: Teams/Edit/5
        public ActionResult Edit(int id)
        {
            var team = _context.Teams.SingleOrDefault(x => x.Id == id);

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
            var teamInDb = _context.Teams.Single(m => m.Id == team.Id);
            teamInDb.Name = team.Name;


            _context.SaveChanges();
            return RedirectToAction("Index", "Teams");
        }


        // GET: Teams/Delete/5
        public ActionResult Delete(int id)
        {
            var team = _context.Teams.SingleOrDefault(x => x.Id == id);
            if (team == null)
                return HttpNotFound();
            var athletes = _context.Athletes.Where(x => x.TeamId == id).ToList();
            if (athletes.Count != 0)
            {
                foreach (var athlete in athletes)
                {
                    athlete.TeamId = null;
                }
            }
            _context.Teams.Remove(team);
            _context.SaveChanges();
            return RedirectToAction("Index", "Teams");
        }

    }
}
