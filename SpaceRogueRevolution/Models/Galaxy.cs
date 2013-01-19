using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceRogueRevolution.Models
{
    public class Galaxy
    {
        public Tile[,] map;
        private Coord locationPlayer;
        public string Message;

        public Galaxy()
        {
            BuildMap();
        }

        private void BuildMap()
        {
            locationPlayer = new Coord { Row = 5, Col = 5 };
            map = new Tile[30,30];
            for (int row =0;row<30;row++ )
            {
                for (int col = 0; col< 30; col++)
                {
                    Tile t = new Tile { ID = 0, FileName = "blank.png" };
                    map[row, col] = t;
                }
            }

            //This stuff is also fairly crap lets get the cleanup going

            //Place the dart
            Tile dart = new Tile { ID = 1, FileName = "dart.png" };
            dart.Description = "The old but reliable dart";
            map[locationPlayer.Row, locationPlayer.Col] = dart;

            //Place planets
            Random r = new Random();
            Coord locationPlanet2 = new Coord { Row = r.Next(30), Col = r.Next(30) };
            Tile planet2 = new Tile { ID = 2, FileName = "planetblue.png", Description = "Gazarnier - Rougher than sandpaper, if I had a buck for every time I broke my nose in a flea infested pub..." };
            map[locationPlanet2.Row, locationPlanet2.Col] = planet2;

            Coord locationPlanet3 = new Coord { Row = r.Next(30), Col = r.Next(30) };
            Tile planet3 = new Tile { ID = 2, FileName = "planetwhite.png", Description = "Maranikas, Ice planer - cold man just freakin freezin, and you thought IOWA got cold..." };
            map[locationPlanet3.Row, locationPlanet3.Col] = planet3;

            Coord locationPlanet = new Coord { Row = r.Next(30), Col = r.Next(30) };
            Tile planet = new Tile { ID = 2, FileName = "planetwhite.png", Description = "Harina 4 - not much except for rocks dirt and the occaisional pirate" };
            map[locationPlanet.Row, locationPlanet.Col] = planet;
        }



        internal void MovePlayer(Coord coord)
        {
            //This is fairly cr@p might start the cleanup soon hey
            Message = "";
            Tile t = new Tile { ID = 0, FileName = "blank.png" };
            Tile dart = new Tile { ID = 1, FileName = "dart.png" };
            map[locationPlayer.Row, locationPlayer.Col] = t;
            locationPlayer.Row = coord.Row;
            locationPlayer.Col = coord.Col;
            map[locationPlayer.Row, locationPlayer.Col] = dart;

            //loop thru the planets and work out if docked
        }
    }
}