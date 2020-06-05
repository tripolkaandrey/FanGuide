using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using FanGuide.Domain;
using FanGuide.HelperClasses;
using FanGuide.Models;
using FanGuide.ViewModels;

namespace FanGuide.Controllers
{
    public class AthletesController : Controller
    {
        private IRepository<Team> Teams_db;
        private IRepository<Sport> Sports_db;
        private IRepository<Athlete> Athletes_db;
        private IRepository<TeamRole> TeamRoles_db;


        public AthletesController()
        {
            Teams_db = new TeamsRepository();
            Sports_db = new SportsRepository();
            Athletes_db = new AthletesRepository();
            TeamRoles_db = new TeamRolesRepository();
        }
        // GET: Athletes
        [HttpGet]
        public ActionResult Index(string sortOrder, string search, int? sportId,bool RecordmanSearch = false)
        {
            ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            var athletes = Athletes_db.GetList(x => x.Sport);
            var sports = Sports_db.GetList();

            if (!string.IsNullOrEmpty(search))
            {
                athletes = athletes.Where(s => s.Name.ToLower().Contains(search)
                                               || s.Sport.Name.ToLower().Contains(search)
                                               || s.Citizenship.ToLower().Contains(search)
                                               || s.Origin.ToLower().Contains(search));
            }
            if (sportId != null)
            {
                athletes = athletes.Where(s => s.SportId == sportId);
            }
            if (RecordmanSearch && athletes.Count() != 0)
            {
                var res = athletes.Select(x => x.Achievements)
                    .Max(x => x.Sum(z => (byte)z.Type));
                athletes = athletes.Where(x => x.Achievements.Sum(z => (byte)z.Type) == res);
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
                Athletes = athletes,
                Sports = new SelectList(sports,"Id","Name")
            };
            return View(viewModel);
        }
        // GET: Athletes/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {
            var athlete =
                Athletes_db.GetList(x => x.Sport, x => x.Achievements, x => x.Team, x => x.TeamRole).SingleOrDefault(x=>x.Id==id);

            if (athlete == null)
                return HttpNotFound();

            return View(athlete);
        }

        // GET: Athletes/Create
        [HttpGet]
        public ActionResult Create()
        {
            var sports = Sports_db.GetList();
            var viewModel = new AthleteFormViewModel()
            {
                Athlete = new Athlete(),
                Sports = sports
            };
            return View("CreateForm", viewModel);
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
                    Sports = Sports_db.GetList()
                };
                return View("CreateForm", viewModel);
            }

            bool nameAlreadyExists = Athletes_db.GetList().SingleOrDefault(a => a.Name == athlete.Name) != null;

            if (nameAlreadyExists)
            {
                ModelState.AddModelError(string.Empty, "The Athlete already exists.");
                var viewModel = new AthleteFormViewModel()
                {
                    Athlete = athlete,
                    Sports = Sports_db.GetList()
                };
                return View("CreateForm",viewModel);
            }

            Athletes_db.Create(athlete);

            return RedirectToAction("Index", "Athletes");
        }

        // GET: Athletes/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var athlete = Athletes_db.Get(id);

            if (athlete == null)
                return HttpNotFound();

            var sports = Sports_db.GetList();
            var viewModel = new AthleteFormViewModel()
            {
                Athlete = athlete,
                Sports = sports
            };
            return View("EditForm",viewModel);
        }
        [HttpPost]
        public ActionResult Edit(Athlete athlete)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new AthleteFormViewModel()
                {
                    Athlete = athlete,
                    Sports = Sports_db.GetList()
                };
                return View("EditForm",viewModel);
            }

            var athleteInDb = Athletes_db.Get(athlete.Id);
            athleteInDb.Name = athlete.Name;
            athleteInDb.SportId = athlete.SportId;
            athleteInDb.Weight = athlete.Weight;
            athleteInDb.Height = athlete.Height;
            athleteInDb.Age = athlete.Age;
            athleteInDb.Citizenship = athlete.Citizenship;

            Athletes_db.Update(athleteInDb);

            return RedirectToAction("Index", "Athletes");
        }

        // GET: Athletes/Delete/5
        [HttpGet]
        public ActionResult ChangeTeam(int id)
        {
            var athlete = Athletes_db.Get(id);
            var teamRoles = TeamRoles_db.GetList().Where(x => x.SportId == athlete.SportId);

            if (athlete == null)
                return HttpNotFound();

            var teams = Teams_db.GetList().Where(x => x.SportId == athlete.SportId && x.Size != Athletes_db.GetList().Count(y => y.TeamId == x.Id));
            var viewModel = new AthleteChangeTeamViewModel()
            {
                Teams = teams,
                Athlete = athlete,
                TeamRoles = teamRoles
            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult ChangeTeam(Athlete athlete)
        {
            var athleteInDb = Athletes_db.Get(athlete.Id);
            athleteInDb.TeamId = athlete.TeamId;
            athleteInDb.TeamRoleId = athlete.TeamRoleId;
            Athletes_db.Update(athleteInDb);
            return RedirectToAction("Details", "Athletes",new {id = athlete.Id});
        }

        [HttpGet]
        public ActionResult AddAchievement(int id)
        {
            var athlete = Athletes_db.Get(id);

            if (athlete == null)
                return HttpNotFound();

            var viewModel = new AthleteAddAchievementViewModel()
            {
                Athlete = athlete,
            };
            return View("AddAchievement", viewModel);
        }

        [HttpPost]
        public ActionResult AddAchievement(Athlete athlete, AchievementType achievement)
        {
            var athleteInDb = Athletes_db.Get(athlete.Id);
            athleteInDb.Achievements.Add(new Achievement() { Type = achievement });
            Athletes_db.Update(athleteInDb);
            return RedirectToAction("Details", "Athletes",new {id = athlete.Id});
        }


        public ActionResult Delete(int id)
        {
            Athletes_db.Delete(id);
            return RedirectToAction("Index","Athletes");
        }
    }
}
