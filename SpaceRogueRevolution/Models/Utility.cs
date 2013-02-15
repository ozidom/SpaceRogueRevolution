using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceRogueRevolution.Models
{
    public class Utility
    {
        static Random r;
        private static readonly object syncLock = new object();

        public Utility()
        {
            r = new Random();
        }
        public static int Rnd(int max)
        {
            //Random r = new Random();
            if (r == null)
                r = new Random();
            lock (syncLock)
            {
                return r.Next(max);
            }
        }

        public enum PlanetType
        {
            Desert,
            Ice,
            Water,
            Gas
        }
    }
}