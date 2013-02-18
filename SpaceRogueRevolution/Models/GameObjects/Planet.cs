using SpaceRogueRevolution.Models.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceRogueRevolution.Models.GameObjects
{
    public class Planet : BaseGameObject, Imapable
    {
        public int CurrentFuel { get; set; }
        public int MaxFuel { get; set; }
        public int CurrentFood { get; set; }
        public int MaxFood { get; set; }
        public Weapon weapon { get; set; }                  //Main Planet weapon
        public SpaceRogueRevolution.Models.Utility.PlanetType type { get;set;}
        public int LawLevel { get; set; }
        public int CostLandingPermit { get; set; }          
        public int LandingPermitID { get; set; }            //the ID or code for the landing permit
        public List<Job> jobs { get; set; }                 //All availabled jobs
        public List<Spaceship> spaceShips { get; set; }     //Spaceships docked  
        public List<Planet> friendlyPlanets { get; set; }   //planets that can have jobs to
        public int Row { get; set; }
        public int Col { get; set; }

        public override string Description 
        {
           get{
               return this.Name + " food " + this.CurrentFood + " LawLevel " + this.LawLevel;
           }
        }
        
        public  string Name { get; set; }

        public Planet()
        {
        }

        public override void ProcessTurn()
        {
            CurrentFood++;
            CurrentFuel++;

            if (spaceShips != null)
            {
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
                s.TakeDamage(weapon);
            }
            else
            {
                message = "spaceship missed";
            }

            return message;
        }


        public Tile GetTileForMap()
        {
            Tile t = new Tile { ID = this.ID, FileName = GetFileNameForPlanet(), Description = this.Description, row = this.Row, col = this.Col };
            return t;
        }

        private string GetFileNameForPlanet()
        {
            switch (type)
            {
                case SpaceRogueRevolution.Models.Utility.PlanetType.Desert:
                    return GameImages.DesertPlanet;
                case SpaceRogueRevolution.Models.Utility.PlanetType.Water:
                    return GameImages.WaterPlanet;
                case SpaceRogueRevolution.Models.Utility.PlanetType.Ice:
                    return GameImages.IcePlanet;
                case SpaceRogueRevolution.Models.Utility.PlanetType.Gas:
                    return GameImages.GasPlanet;
            }
            return GameImages.DesertPlanet;
        }

    
    }
}