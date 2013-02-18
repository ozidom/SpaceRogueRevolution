using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceRogueRevolution.Models.GameObjects
{
    public class GameImages
    {
        //public static readonly string ServerLoc = ""; //local
        public static readonly string ServerLoc = "/SpaceRogueRevolution";  //server

        public static readonly string DartNorth = ServerLoc + "/Content/Images/dartnorth.png";
        public static readonly string DartSouth = ServerLoc + "/Content/Images/dartsouth.png";
        public static readonly string DartEast = ServerLoc + "/Content/Images/darteast.png";
        public static readonly string DartWest = ServerLoc + "/Content/Images/dartwest.png";

        public static readonly string DesertPlanet = ServerLoc + "/Content/Images/planetbrown.png";
        public static readonly string WaterPlanet = ServerLoc + "/Content/Images/planetblue.png";
        public static readonly string IcePlanet = ServerLoc + "/Content/Images/planetwhite.png";
        public static readonly string GreenPlanet = ServerLoc + "/Content/Images/planetgreen.png";
        public static readonly string GasPlanet = ServerLoc + "/Content/Images/gas.png";
        public static readonly string Freighter = ServerLoc + "/Content/Images/freighter.png";

    }
}