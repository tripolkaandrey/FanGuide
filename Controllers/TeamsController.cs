using System;
using System.Collections.Generic;
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
            var team = _context.Teams.SingleOrDefault(x => x.Id == id);
            var athletes = _context.Athletes.Where(x => x.TeamId == id).ToList();
            var viewModel = new TeamDetailsViewModel(team)
            {
                Athletes = athletes
            };
            return View(viewModel);
        }

        // GET: Teams/Create
        public ActionResult Create()
        {
            var sports = _context.Sports.ToList();
            var viewModel = new TeamFormViewModel()
            {
                Sports = sports
            };
            return View("TeamForm", viewModel);
        }


        // GET: Teams/Edit/5
        public ActionResult Edit(int id)
        {
            var team = _context.Teams.SingleOrDefault(x => x.Id == id);
            if (team == null)
                return HttpNotFound();
            var athletes = _context.Athletes.ToList();
            var viewModel = new TeamDetailsViewModel(team)
            {
                Athletes = athletes
            };
            return View("TeamForm", viewModel);
        }


        // GET: Teams/Delete/5
        public ActionResult Delete(int id)
        {
            var team = _context.Teams.SingleOrDefault(x => x.Id == id);
            if (team == null)
                return HttpNotFound();
            _context.Teams.Remove(team);
            _context.SaveChanges();
            return RedirectToAction("Index", "Teams");
        }

        [HttpPost]
        public ActionResult Save(Team team)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new TeamFormViewModel(team)
                {
                    Sports = _context.Sports.ToList()
                };
                return View("TeamForm", viewModel);
            }
            bool nameAlreadyExists = _context.Teams.SingleOrDefault(t => t.Name == team.Name) != null;
            if (nameAlreadyExists)
            {
                ModelState.AddModelError(string.Empty, "Team already exists.");
                return View("TeamForm");
            }
            if (team.Id == 0)
            {
                _context.Teams.Add(team);
            }
            else
            {
                var teamInDb = _context.Athletes.Single(m => m.Id == team.Id);
                teamInDb.Id = team.Id;
                teamInDb.Name = team.Name;
                teamInDb.SportId = team.SportId;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Teams");
        }
    }
}
