using SpaceRogueRevolution.Models.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceRogueRevolution.Models.Factory
{
    public static class JobFactory
    {
        /*public static Job Create(int id,string description,int desination,int value)
        {
            return new Job { ID = id, Description = description, DestinationID = desination, Value = value };  
        }*/

        public static Job CreateRandomJob(int id, int numberPlanets,int currentPlanetID)
        {
           
            int value = 0;
            int risk = 0;
            string description = "";
            Random r = new Random();
            GetRandomDescriptionAndValue(out description,out value,out risk);
            int destinationID = r.Next(7);
            return new Job { ID = id, Description = description,OriginID = currentPlanetID, DestinationID = destinationID, Value = value,Risk=risk };  
        }

        private static int GetRandomJobValue()
        {
            Random r = new Random();
            return r.Next(1000);
        }

        private static int GetRandomDestination(List<Planet> planets)
        {
            Random r = new Random();
            int randomIndex = r.Next(planets.Count);
            return planets[randomIndex].ID;
        }

        public static void GetRandomDescriptionAndValue(out string description,out int value,out int risk )
        {
            
            var jobs = new [] { new {Name="Transfer of Cash",value=400,risk= 2},
                                new {Name="Transfer Goods",value=200,risk= 1},
                                new {Name="Transport of Government worker travel",value=300,risk= 2},
                                new {Name="Transport for a highly sought after Computer Specialist",value=400,risk= 2},
                                new {Name="Ensure safe passage for an intergalactice Trade Official",value=800,risk= 6},
                                new {Name="Take a famous Sports star to a big game",value=300,risk= 4},
                                new {Name="Take a family to a Bridal Party",value=200,risk= 1},
                                new {Name="Take a load of angry activists to a political conference",value=400,risk= 3},
                                new {Name="Transport a Paranoid Android",value=900,risk= 8},
                                new {Name="You need to transfer a Nuclear Bomb ",value=1400,risk=10}
            };

            Random r = new Random();
            int index = r.Next(jobs.Length);
            description = jobs[index].Name;
            value = jobs[index].value;
            risk = jobs[index].risk;
        }
    }
}