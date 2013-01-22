using SpaceRogueRevolution.Models.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace SpaceRogueRevolution.Models.Factory
{
    public class PlanetFactory
    {
        public Planet CreateRandomPlanet()
        {
            int CurrentFuel = Utility.Rnd(100);
            int MaxFuel = Utility.Rnd(100);
            int CurrentFood = Utility.Rnd(100);
            int MaxFood = Utility.Rnd(100);

            Weapon weapon = GetRandomGroundDefenceWeapon();
            int LawLevel = Utility.Rnd(10);
            int CostLandingPermit = Utility.Rnd(10);
            int LandingPermitID = Utility.Rnd(10);            //the ID or code for the landing permit
            List<Job> jobs = GetRandomJobs();

            //All availabled jobs
            List<Spaceship> spaceShips = GetRandomSpaceship();  //Spaceships docked  
            List<Planet> friendlyPlanets = GetRandomFriendlyPlanets();

            return null;
        }

        private static Weapon GetRandomGroundDefenceWeapon()
        {
            return null;
        }

        private static List<Job> GetRandomJobs()
        {
            return null; ;
        }

        private static List<Spaceship> GetRandomSpaceship()
        {
            return null;
        }

        private static List<Planet> GetRandomFriendlyPlanets()
        {
            return null; ;
        }
    }
}