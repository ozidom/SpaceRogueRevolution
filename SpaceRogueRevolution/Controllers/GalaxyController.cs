using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SpaceRogueRevolution.Models;

namespace SpaceRogueRevolution.Controllers
{
    public class GalaxyController : Controller
    {
        //
        // GET: /Galaxy/

        public void Index()
        {
           // Galaxy galaxy = GetGalaxy();
            RedirectToAction("Index", "Galaxy");
        }

        private Galaxy GetGalaxy()
        {
            Galaxy galaxy;
            if (Session["galaxy"] == null)
            {
                galaxy = new Galaxy();
                Session["galaxy"] = galaxy;
            }

            galaxy = (Galaxy)Session["galaxy"];
            return galaxy;
        }

        //
        // GET: /Galaxy/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Galaxy/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Galaxy/Create

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

        public ActionResult Move(string command)
        {

            Galaxy galaxy = GetGalaxy();
            //galaxy.MovePlayer(coord);
            return RedirectToAction("Index", "Home", "Hi");
        }

        //
        // GET: /Galaxy/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Galaxy/Edit/5

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

        //
        // GET: /Galaxy/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Galaxy/Delete/5

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
