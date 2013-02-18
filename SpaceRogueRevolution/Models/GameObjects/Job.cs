using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceRogueRevolution.Models.GameObjects
{
    public class Job : BaseGameObject
    {
        public int DestinationID { get; set; }
        public int OriginID { get; set; }
        public int Value { get; set; }
        public int Risk { get; set; }               //Risk of a disaster per turn

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