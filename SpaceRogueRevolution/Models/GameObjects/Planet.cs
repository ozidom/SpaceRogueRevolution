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
        public Weapon weapon { get; set; }
        public int LawLevel { get; set; }
        public int CostLandingPermit { get; set; }
        public int LandingPermitID { get; set; }
        public List<Jobs> jobs { get; set; }
        public List<Spaceship> spaceShips { get; set; }

        public Planet()
        {

        }

        public override void ProcessTurn()
        {
            if (jobs.Count < 5)
            {
                //Add new jobs
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


    }
}