using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceRogueRevolution.Models.GameObjects
{
    public class Job : BaseGameObject
    {
        public int DestinationID { get; set; }
        public int Value { get; set; }

        private int timeOnMarket { get;set; }

        public Job ()
	    {
            timeOnMarket = 0;
	    }

        public override void ProcessTurn()
        {
 	         timeOnMarket++;
             Value++;
        } 
    }
    
}