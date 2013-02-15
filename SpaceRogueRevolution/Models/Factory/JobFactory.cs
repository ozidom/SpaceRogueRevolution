using SpaceRogueRevolution.Models.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceRogueRevolution.Models.Factory
{
    public static class JobFactory
    {
        public static Job Create(int id,string description,int desination,int value)
        {
            return new Job { ID = id, Description = description, DestinationID = desination, Value = value };  
        }

        public static Job CreateRandomJob(int numberPlanets)
        {
            int id = 0;
            int value = 0;
       
            string description = "";
            Random r = new Random();
            GetRandomDescriptionAndValue(out description,out value);
            int destinationID = r.Next(7);
            return new Job { ID = id++, Description = description, DestinationID = destinationID, Value = value };  
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

        public static void GetRandomDescriptionAndValue(out string description,out int value )
        {
            
            var jobs = new [] { new {Name="Transfer of Cash",value=100},
                                new {Name="Transfer Goods",value=200},
                                new {Name="Government worker travel",value=300},
                                new {Name="Computer Specialist",value=500},
                                new {Name="Trade Official",value=200},
                                new {Name="Sport Star Transfer",value=400},
                                new {Name="Bridal Party",value=200},
                                new {Name="Angry Activists",value=600},
                                new {Name="Paranoid Android",value=800},
                                new {Name="Bomb Transfer",value=1400}};

            Random r = new Random();
            int index = r.Next(jobs.Length);
            description = jobs[index].Name;
            value = jobs[index].value;
        }
    }
}