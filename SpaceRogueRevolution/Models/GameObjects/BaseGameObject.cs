using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceRogueRevolution.Models.GameObjects
{
    public class BaseGameObject
    {
        public int ID { get; set; }
        public virtual string Description { get; set; }

        public virtual void ProcessTurn()
        {

        }

    }
}