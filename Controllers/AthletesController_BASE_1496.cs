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
        public async Task<ActionResult> Index(string sortOrder, string search)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            var athletes = _context.Athletes.Include(x => x.Sport);

            if (!String.IsNullOrEmpty(search))
            {
                athletes = athletes.Where(s => s.Name.Contains(search) || s.Sport.Name.Contains(search));
            }
            switch(sortOrder)
            {
                case "name_desc":
                athletes = athletes.OrderByDescending(s => s.Name);
                break;
                default:
                athletes = athletes.OrderBy(s => s.Name);
                break;
            }
            return View(await athletes.ToListAsync());
        }

        // GET: Athletes/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {
            var athlete = _context.Athletes.Include(x => x.Sport).SingleOrDefault(x=>x.Id==id);
            return View(athlete);
        }

        // GET: Athletes/Create
        [HttpGet]
        public ActionResult Create()
        {
            var sports = _context.Sports.ToList();
            var viewModel = new AthleteFormViewModel()
            {
                Sports = sports
            };
            return View("AthleteForm",viewModel);
        }

        // GET: Athletes/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var athlete = _context.Athletes.SingleOrDefault(x => x.Id == id);
            if (athlete == null)
                return HttpNotFound();
            var sports = _context.Sports.ToList();
            var viewModel = new AthleteFormViewModel(athlete)
            {
                Sports = sports
            };
            return View("AthleteForm", viewModel);
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

        [HttpPost]
        public ActionResult Save(Athlete athlete)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new AthleteFormViewModel(athlete)
                {
                    Sports = _context.Sports.ToList()
                };
                return View("AthleteForm", viewModel);
            }
            if (athlete.Id == 0)
            {
                _context.Athletes.Add(athlete);
            }
            else
            {
                var athleteInDb = _context.Athletes.Single(m => m.Id == athlete.Id);
                athleteInDb.Id = athlete.Id;
                athleteInDb.Name = athlete.Name;
                athleteInDb.SportId = athlete.SportId;
                athleteInDb.Weight = athlete.Weight;
                athleteInDb.Height = athlete.Height;
                athleteInDb.Age = athlete.Age;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Athletes");
        }
    }
}
