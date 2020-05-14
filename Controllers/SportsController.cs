using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FanGuide.Models;
using FanGuide.ViewModels;

namespace FanGuide.Controllers
{
    public class SportsController : Controller
    {
        private ApplicationDbContext _context;

        public SportsController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Sports
        public ActionResult Index()
        {
            var sports = _context.Sports.ToList();
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

            bool nameAlreadyExists = _context.Sports.SingleOrDefault(s => s.Name == sport.Name) != null;

            if (nameAlreadyExists)
            {
                ModelState.AddModelError(string.Empty, "Sport already exists.");
                return View("SportForm");
            }

            _context.Sports.Add(sport);
            _context.SaveChanges();

            return RedirectToAction("Index", "Sports");
        }


        // GET: Sports/Edit/5
        public ActionResult Edit(int id)
        {
            var sport = _context.Sports.SingleOrDefault(x => x.Id == id);

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

            var sportInDb = _context.Sports.Single(s => s.Id == sport.Id);
            sportInDb.Name = sport.Name;

            _context.SaveChanges();
            return RedirectToAction("Index", "Sports");
        }


        // GET: Sports/Delete/5

        public ActionResult Delete(int id)
        {
            var sport = _context.Sports.SingleOrDefault(x => x.Id == id);

            if (sport == null)
                return HttpNotFound();

            _context.Sports.Remove(sport);
            _context.SaveChanges();
            return RedirectToAction("Index", "Sports");
        }
    }
}
