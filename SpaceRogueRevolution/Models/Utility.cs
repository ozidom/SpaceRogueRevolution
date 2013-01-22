using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceRogueRevolution.Models
{
    public class Utility
    {
        public static int Rnd(int max)
        {
            Random r = new Random();
            return r.Next(max);
        }
    }
}