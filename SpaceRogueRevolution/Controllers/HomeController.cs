using SpaceRogueRevolution.Models;
using SpaceRogueRevolution.Models.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpaceRogueRevolution.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Home/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Sync(List<Tile> map)

        {
            Galaxy galaxy = GetGalaxy(map);
            SetGalaxy(galaxy);
            galaxy.TakeComputerActions();
            galaxy.UpdateGameObjectsToMap();
            return Json(galaxy);
        }

        [HttpPost]
        public ActionResult TakeAction(string command)
        {
            Galaxy galaxy = GetGalaxy(null);
            if (command != null)
            {
                galaxy.Message = command.ToString();
            }
            galaxy.ProcessCommand(new Command { ID = int.Parse(command) });
            SetGalaxy(galaxy);
            return Json(galaxy);
        }

          [HttpPost]
        public ActionResult Docking(int planet)
        {
            Galaxy galaxy = GetGalaxy(null);
            SetGalaxy(galaxy);
            List<string> jobs = galaxy.GetOpenJobsForPlanet(planet);
            return Json(jobs);
        }

        private Galaxy GetGalaxy(List<Tile> map)
        {
            Galaxy galaxy;
            if (Session["galaxy"] == null)
            {
                galaxy = new Galaxy();
                Session["galaxy"] = galaxy;
            }

            galaxy = (Galaxy)Session["galaxy"];
            if (map != null)
            {
                galaxy.map = map;
                Tile playerSpaceShipTile = galaxy.map.Last();
                galaxy.playerSpaceShip.Row = playerSpaceShipTile.row;
                galaxy.playerSpaceShip.Col = playerSpaceShipTile.col;
            }
            return galaxy;
        }

        private void SetGalaxy(Galaxy galaxy)
        {
           
           Session["galaxy"] = galaxy;
           
        }
        //
        // GET: /Home/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Home/Create

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

        //
        // GET: /Home/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Home/Edit/5

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
        // GET: /Home/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Home/Delete/5

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
