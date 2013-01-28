using SpaceRogueRevolution.Models.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace SpaceRogueRevolution.Models.Factory
{
    public class PlanetFactory
    {
        int CurrentFuel;
        int MaxFuel = Utility.Rnd(100);
        int CurrentFood = Utility.Rnd(100);
        int MaxFood = Utility.Rnd(100);

        int LawLevel = Utility.Rnd(10);
        int CostLandingPermit = Utility.Rnd(10);
        int LandingPermitID = Utility.Rnd(10);            //the ID or code for the landing permit


        //All availabled jobs

        List<Spaceship> spaceShips = GetRandomSpaceship();  //Spaceships docked  
        //if (friendlyPlanets != null)
        //    List<Job> jobs = GetRandomJobs(6,friendlyPlanets);

        Weapon weapon = GetRandomGroundDefenceWeapon();


        public static Planet CreateRandomPlanet(int id)
        {
            Planet p = new Planet();
            p.ID = id;
            p.Name = GenRandomName();
            p.CurrentFuel = Utility.Rnd(100);
            p.MaxFuel = Utility.Rnd(100);
            p.CurrentFood = Utility.Rnd(100);
            p.MaxFood = Utility.Rnd(100);
            p.type = GetRandomPlanetType();
            p.LawLevel = Utility.Rnd(10);
            p.CostLandingPermit = Utility.Rnd(10);
            p.LandingPermitID = Utility.Rnd(10);
           
            p.Row = Utility.Rnd(400);
            p.Col = Utility.Rnd(400);
            List<Spaceship> spaceShips = GetRandomSpaceship();  //Spaceships docked  
            //if (friendlyPlanets != null)
            //    List<Job> jobs = GetRandomJobs(6,friendlyPlanets);

                   p.weapon = GetRandomGroundDefenceWeapon();

            return p;
        }

        

        //private string GetRandomName()
        //{
        //    string firstbit
        //}

        private static Utility.PlanetType GetRandomPlanetType()
        {
            Utility.PlanetType planetType = new Utility.PlanetType();
            int i = Utility.Rnd(3);
            switch (i)
            {
                    
                case 0:
                    planetType = Utility.PlanetType.Desert;
                    break;
                case 1:
                    planetType = Utility.PlanetType.Ice;
                    break;
                case 2:
                    planetType = Utility.PlanetType.Gas;
                    break;
                case 3:
                    planetType = Utility.PlanetType.Water;
                    break;
            }
            return planetType;
        }

        private static Weapon GetRandomGroundDefenceWeapon()
        {
            List<Weapon> weapons = new List<Weapon>();
            weapons.Add(new Weapon { Damage = 5, Accuracy = 4, Range = 3, Description = "Hammer Gun" });
            weapons.Add(new Weapon { Damage = 2, Accuracy = 9, Range = 9, Description = "Ground Defence Tracking Laser " });
            weapons.Add(new Weapon { Damage = 15, Accuracy = 6, Range = 5, Description = "Heavy Cruiser Battle Cannon (HCBC)" });
            weapons.Add(new Weapon { Damage = 18, Accuracy = 4, Range = 8, Description = "Ground Nuclear Defence Missiles (Wappa)" });
            weapons.Add(new Weapon { Damage = 5, Accuracy = 2, Range = 3, Description = "Anti-Spaceship Missiles (ASM)" });
            weapons.Add(new Weapon { Damage = 4, Accuracy = 9, Range = 3, Description = "High Energy Beam (Scotty) " });

            int randomIndex = Utility.Rnd(weapons.Count);

            return weapons[randomIndex];
        }

        private static List<Job> GetRandomJobs(int numberOfRandomJobs,List<Planet> friendlyPlanets)
        {
            List<Job> jobs = new List<Job>();
            for (int i = 0; i < numberOfRandomJobs; i++)
            {
                jobs.Add(JobFactory.CreateRandomJob(friendlyPlanets));
            }
            return jobs;
        }

        private static List<Spaceship> GetRandomSpaceship()
        {
            return null;
        }

        private static string GenRandomName()
        {
            List<string> lst = new List<string>();
            string str = string.Empty;
            lst.Add("Aiden");
            lst.Add("Jackson");
            lst.Add("Mason");
            lst.Add("Liam");
            lst.Add("Jacob");
            lst.Add("Jayden");
            lst.Add("Ethan");
            lst.Add("Noah");    
            lst.Add("Sophia");
            lst.Add("Emma");
            lst.Add("Isabella");
            lst.Add("Olivia");
            lst.Add("Ava");
            lst.Add("Lily");
            lst.Add("Chloe");
            lst.Add("Madison");
            lst.Add("Emily");
            lst.Add("Abigail");
            lst.Add("Addison");
            lst.Add("Mia");
            string number = Utility.Rnd(8765).ToString();
            str = lst[Utility.Rnd(lst.Count())] + number;
            return str;
        }
     
    }
}