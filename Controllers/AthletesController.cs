using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using FanGuide.Models;
using FanGuide.ViewModels;

namespace FanGuide.Controllers
{
    public class AthletesController : Controller
    {
        private ApplicationDbContext _context;

        public AthletesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Athletes
        [HttpGet]
        public ActionResult Index(string sortOrder, string search, int? sportId)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            var athletes = _context.Athletes.Include(x => x.Sport);
            var sports = _context.Sports.ToList();

            if (!String.IsNullOrEmpty(search))
            {
                athletes = athletes.Where(s => s.Name.ToLower().Contains(search) || s.Sport.Name.ToLower().Contains(search));
            }
            if (sportId != null)
            {
                athletes = athletes.Where(s => s.SportId == sportId);
            }
            switch (sortOrder)
            {
                case "name_desc":
                athletes = athletes.OrderByDescending(s => s.Name);
                break;
                default:
                athletes = athletes.OrderBy(s => s.Name);
                break;
            }
            var viewModel = new AthletesListViewModel()
            {
                Athletes = athletes.ToList(),
                Sports = new SelectList(sports,"Id","Name")
            };
            return View(viewModel);
        }
        [HttpGet]
        public ActionResult ChangeTeam(int id)
        {
            var athlete = _context.Athletes.Include(x => x.Sport).SingleOrDefault(x => x.Id == id);

            if (athlete == null)
                return HttpNotFound();

            var teams = _context.Teams.Where(x => x.SportId == athlete.SportId);
            var viewModel = new AthleteAddToTeamViewModel()
            {
                Teams = teams,
                Athlete = athlete
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult ChangeTeam(Athlete athlete)
        {
            var athleteInDb = _context.Athletes.Single(x => x.Id == athlete.Id);

            athleteInDb.TeamId = athlete.TeamId;
            _context.SaveChanges();
            return RedirectToAction("Index", "Athletes");
        }

        // GET: Athletes/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {
            var athlete = _context.Athletes.Include(x => x.Sport).SingleOrDefault(x=>x.Id==id);

            if (athlete == null)
                return HttpNotFound();

            return View(athlete);
        }


        // GET: Athletes/Create
        [HttpGet]
        public ActionResult Create()
        {
            var sports = _context.Sports.ToList();
            var viewModel = new AthleteFormViewModel()
            {
                Athlete = new Athlete(),
                Sports = sports
            };
            return View("AthleteСreateForm", viewModel);
        }
        [HttpPost]
        public ActionResult Create(Athlete athlete)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Wrong Input");
                var viewModel = new AthleteFormViewModel()
                {
                    Athlete = athlete,
                    Sports = _context.Sports.ToList(),
                };
                return View("AthleteСreateForm", viewModel);
            }


            bool nameAlreadyExists = _context.Athletes.SingleOrDefault(a => a.Name == athlete.Name) != null;

            if (nameAlreadyExists)
            {
                ModelState.AddModelError(string.Empty, "The Athlete already exists.");
                var viewModel = new AthleteFormViewModel()
                {
                    Athlete = athlete,
                    Sports = _context.Sports.ToList()
                };
                return View("AthleteСreateForm", viewModel);
            }

            _context.Athletes.Add(athlete);
            _context.SaveChanges();

            return RedirectToAction("Index", "Athletes");
        }

        // GET: Athletes/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var athlete = _context.Athletes.SingleOrDefault(x => x.Id == id);

            if (athlete == null)
                return HttpNotFound();

            var sports = _context.Sports.ToList();
            var viewModel = new AthleteFormViewModel()
            {
                Athlete = athlete,
                Sports = sports
            };
            return View("AthleteEditForm", viewModel);
        }
        [HttpPost]
        public ActionResult Edit(Athlete athlete)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new AthleteFormViewModel()
                {
                    Athlete = athlete,
                    Sports = _context.Sports.ToList()
                };
                return View("AthleteEditForm", viewModel);
            }

            var athleteInDb = _context.Athletes.Single(m => m.Id == athlete.Id);
            athleteInDb.Name = athlete.Name;
            athleteInDb.SportId = athlete.SportId;
            athleteInDb.Weight = athlete.Weight;
            athleteInDb.Height = athlete.Height;
            athleteInDb.Age = athlete.Age;
            athleteInDb.Citizenship = athlete.Citizenship;
            athleteInDb.Achievements = athlete.Achievements;


            _context.SaveChanges();
            return RedirectToAction("Index", "Athletes");
        }

        // GET: Athletes/Delete/5

        public ActionResult Delete(int id)
        {
            var athlete = _context.Athletes.SingleOrDefault(x => x.Id == id);

            if (athlete == null)
                return HttpNotFound();

            _context.Athletes.Remove(athlete);
            _context.SaveChanges();
            return RedirectToAction("Index","Athletes");
        }
    }
}
