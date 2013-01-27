using SpaceRogueRevolution.Models.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceRogueRevolution.Models
{
    public class Tile : BaseGameObject
    {
        public  int ID { get; set; }
        public string FileName {get;set;}
        public string Description { get; set; }
        public int row { get; set; }
        public int col { get; set; }

    }
}