using SpaceRogueRevolution.Models.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceRogueRevolution.Models.GameObjects
{
    public class Planet : BaseGameObject
    {
        public int CurrentFuel { get; set; }
        public int MaxFuel { get; set; }
        public int CurrentFood { get; set; }
        public int MaxFood { get; set; }
        public Weapon weapon { get; set; }                  //Main Planet weapon
        public int LawLevel { get; set; }
        public int CostLandingPermit { get; set; }          
        public int LandingPermitID { get; set; }            //the ID or code for the landing permit
        public List<Job> jobs { get; set; }                 //All availabled jobs
        public List<Spaceship> spaceShips { get; set; }     //Spaceships docked  
        public List<Planet> friendlyPlanets { get; set; }   //planets that can have jobs to

        public override void ProcessTurn()
        {
            if (jobs.Count < 5)
            {
                while (jobs.Count < 10)
                {
                    jobs.Add(JobFactory.CreateRandomJob(friendlyPlanets));
                }
            }

            if (CurrentFood < MaxFood)
                CurrentFood++;

            if (CurrentFuel < MaxFuel)
                CurrentFuel++;

            foreach (Spaceship s in spaceShips)
            {
                if (!s.landingPermits.Contains(LandingPermitID))
                {         
                    Random r = new Random();
                    int luck = r.Next(10);
                    if (luck < LawLevel)
                    {
                        s.Impounded = true;
                    }
                }
            }

            
        }

        protected string FireGroundDefence(ref Spaceship s)
        {
            string message;
            //is there a weapon
            if (weapon == null)
            {
                message = "No weapon for planet to fire";
            }

            if (true)//spaceship not in range
            {
                message = "spaceship not in range";
            }

            //evade?
            Random r = new Random();
            if (s.Evasion < r.Next(weapon.Accuracy))
            {
                message = "spaceship hit";
                s.TakeDamage(weapon.Damage);
            }
            else
            {
                message = "spaceship missed";
            }

            return message;
        }

    }
}