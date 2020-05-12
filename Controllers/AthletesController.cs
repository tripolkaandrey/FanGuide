using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FanGuide.Controllers
{
    public class AthletesController : Controller
    {
        // GET: Athletes
        public ActionResult Index()
        {
            return View();
        }

        // GET: Athletes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Athletes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Athletes/Create
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

        // GET: Athletes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Athletes/Edit/5
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

        // GET: Athletes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Athletes/Delete/5
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
