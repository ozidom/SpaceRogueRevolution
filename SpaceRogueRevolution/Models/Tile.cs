using SpaceRogueRevolution.Models.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceRogueRevolution.Models
{
    public class Tile : BaseGameObject
    {
        public string FileName {get;set;}
        public int row { get; set; }
        public int col { get; set; }
        public string directionImage { get; set; }
        public Spaceship gameObject { get; set; }

    }
}