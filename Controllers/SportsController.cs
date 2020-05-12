using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FanGuide.Controllers
{
    public class SportsController : Controller
    {
        // GET: Sports
        public ActionResult Index()
        {
            return View();
        }

        // GET: Sports/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Sports/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sports/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Sports/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Sports/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Sports/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Sports/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
