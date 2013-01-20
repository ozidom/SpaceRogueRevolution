using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceRogueRevolution.Models
{
    public class Galaxy
    {
        public List<Tile> map;
        private Coord locationPlayer;
        public string Message;
        public Tile playerSpaceShip;

        public Galaxy()
        {
            BuildMap();
        }

        private void BuildMap()
        {
            locationPlayer = new Coord { Row = 5, Col = 5 };
            map = new List<Tile>();

            

            //This stuff is also fairly crap lets get the cleanup going

            //Place the dart
            playerSpaceShip = new Tile { ID = 1, FileName = "/Content/Images/dart.png", Description = "The old but reliable dart", row = 5, col = 5 };

            //Place planets
            Random r = new Random();
            
            Coord axis1 = new Coord { Row = r.Next(30), Col = r.Next(30) };
            Tile planet1 = new Tile { ID = 2, FileName = "/Content/Images/planetwhite.png", Description = "Harina 4 - not much except for rocks dirt and the occaisional pirate",row=axis1.Row,col=axis1.Col };
            map.Add(planet1);

            Coord axis2 = new Coord { Row = r.Next(30), Col = r.Next(30) };
            Tile planet2 = new Tile { ID = 2, FileName = "/Content/Images/planetblue.png", Description = "Gazarnier - Rougher than sandpaper, if I had a buck for every time I broke my nose in a flea infested pub...",row=axis2.Row,col=axis2.Col };
         
            map.Add(planet2);

            Coord axis3 = new Coord { Row = r.Next(30), Col = r.Next(30) };
            Tile planet3 = new Tile { ID = 2, FileName = "/Content/Images/planetwhite.png", Description = "Maranikas, Ice planer - cold man just freakin freezin, and you thought IOWA got cold...",row=axis3.Row,col=axis3.Col };
            map.Add(planet2);

          
        }



        internal void MovePlayer(Coord coord)
        {
            playerSpaceShip.row = coord.Row;
            playerSpaceShip.col = coord.Col;

            //loop thru the planets and work out if docked
        }
    }
}