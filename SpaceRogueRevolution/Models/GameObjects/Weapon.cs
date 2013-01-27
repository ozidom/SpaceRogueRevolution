using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceRogueRevolution.Models.GameObjects
{
    public class Weapon : BaseGameObject
    {
        public int Accuracy { get; set; }

        public int Damage { get; set; }

        public int Range { get; set; }
    }
}