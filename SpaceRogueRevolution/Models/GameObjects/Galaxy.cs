using SpaceRogueRevolution.Models.Factory;
using SpaceRogueRevolution.Models.GameObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;

namespace SpaceRogueRevolution.Models
{
    public class Galaxy
    {
        public List<Tile> map;
        private Coord locationPlayer;
        private List<BaseGameObject> gameObjects;
        public string Message;
        public Spaceship playerSpaceShip;
        public IGameControl gameControl;

        public Galaxy()
        {
            gameControl = new KeyBoardGameControl();
            gameObjects = new List<BaseGameObject>();
            BuildMap();
        }

        private void BuildMap()
        {
            //locationPlayer = new Coord { Row = 5, Col = 5 };
            map = new List<Tile>();
            AddPlanetsToGameObjects();
           
            playerSpaceShip = new Spaceship { ID = 1, DirectionImage = "/Content/Images/darteast.png", Description = "The old but reliable dart",Row=5,Col=5  };
            gameObjects.Add(playerSpaceShip);
            UpdateGameObjectsToMap();

        }


        public void UpdateGameObjectsToMap()
        {
          map.Clear();
           
          gameObjects.ToList().ForEach(go =>
            {
                if (go is Imapable)
                {
                    Debug.WriteLine("mappable");
                    map.Add(((Imapable)go).GetTileForMap());
                }
            });
        }

        private void AddPlanetsToGameObjects()
        {
            //This stuff is also fairly crap lets get the cleanup going

            for(int i=0;i<10;i++)
            {
                Planet pt = PlanetFactory.CreateRandomPlanet(i);
                gameObjects.Add(pt);
            }

        }



        internal void MovePlayer(Coord coord)
        {
            playerSpaceShip.Row = coord.Row;
            playerSpaceShip.Col = coord.Col;

            //loop thru the planets and work out if docked
        }

        internal void ProcessCommand(Command command)
        {
            string commandText = gameControl.takeAction(command);
            TakePlayerActionFromCommand(commandText);
            TakeComputerActions();
            UpdateGameObjectsToMap();


        }

        internal void TakePlayerActionFromCommand(string commandText)
        {
            string imageFileName = "";
            switch(commandText)
            {
                case "n":
                    if (playerSpaceShip.Row - 5 > 0)
                    {
                        playerSpaceShip.Row -= 5;
                        imageFileName = "dartnorth.png";
                    }
                    break;
                case "s":
                    if (playerSpaceShip.Row + 5 < 400)
                    {
                        playerSpaceShip.Row += 5;
                        imageFileName = "dartsouth.png";
                    }
                    break;
                case "e":
                    if (playerSpaceShip.Col + 5 < 400)
                    {
                        playerSpaceShip.Col += 5;
                        imageFileName = "darteast.png";
                    }
                    break;
                case "w":
                    if (playerSpaceShip.Col - 5 > 0)
                    {
                        playerSpaceShip.Col -= 5;
                        imageFileName = "dartwest.png";
                    }
                    break;
                case "j":
                    //list jobs for current planet
                    break;
            }
            //C:\Code\MVC\SpaceRogueRevolution\SpaceRogueRevolution\Content\Images
            //playerSpaceShip.DirectionImage = Path.Combine(System.Web.HttpContext.Current.Server.MapPath(@"~/Content/Images/"), imageFileName);
            playerSpaceShip.DirectionImage = playerSpaceShip.DirectionImage = "/Content/Images/darteast.png";
            playerSpaceShip.ProcessTurn();

        }

        internal void TakeComputerActions()
        {
            foreach (BaseGameObject go in gameObjects)
            {
                go.ProcessTurn();
            }
        }

        internal List<string> GetOpenJobsForPlanet(int planet)
        {
            return new List<string> { "(123) - Computer Transport Job $32000","(143) - Transfer Prisoner $87364","(873) Cargo - Beer","(763) Cargo - Juice","(21) Passengers - Hockey Team" };

        }
    }
}