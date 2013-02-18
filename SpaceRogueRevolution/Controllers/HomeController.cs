using SpaceRogueRevolution.Models;
using SpaceRogueRevolution.Models.GameObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpaceRogueRevolution.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public string Ping()
        {
            return "OK";
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Sync(List<Tile> map)
        {
            Galaxy galaxy  = GetGalaxy(map);
            SetGalaxy(galaxy);
            if (map != null && map.Count > 0)
                galaxy.UpdatePlayerStarshipToGameObject(map[0]);
            galaxy.TakeComputerActions();
            galaxy.UpdateGameObjectsToMap();
            return Json(galaxy.map);
        }

        [HttpPost]
        public ActionResult TakeJob(Job job)
        {
            Galaxy galaxy = GetGalaxy(null);
            galaxy.TakeJobOffMarket(job);
            SetGalaxy(galaxy);
            galaxy.UpdateGameObjectsToMap();
            List<Job> jobs = galaxy.GetOpenJobsForPlanet(job.OriginID);
            return Json(jobs);
       
        }

        [HttpPost]
        public ActionResult ProcessEndGame()
        {
            Session["galaxy"] = null;
            return Json(null);

        }

        [HttpPost]
        public ActionResult TakeAction(string command)
        {
            Galaxy galaxy = GetGalaxy(null);
            SetGalaxy(galaxy);
            galaxy.TakeComputerActions();
            galaxy.UpdateGameObjectsToMap();
            return Json(galaxy.map);
        }

        [HttpPost]
        public ActionResult Docking(int planet)
        {
            Galaxy galaxy = GetGalaxy(null);
            SetGalaxy(galaxy);
            List<Job> jobs = galaxy.GetOpenJobsForPlanet(planet);
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
            }
            return galaxy;
        }

        private void SetGalaxy(Galaxy galaxy)
        {
           
           Session["galaxy"] = galaxy;
           
        }
    
    }
}
