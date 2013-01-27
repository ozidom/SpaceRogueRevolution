using SpaceRogueRevolution.Models.Factory;
using SpaceRogueRevolution.Models.GameObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            locationPlayer = new Coord { Row = 5, Col = 5 };
            map = new List<Tile>();
            AddPlanetsToGameObjects();
            playerSpaceShip = new Spaceship();
            //AddGameObjectsToMap();

        }

        private void UpdateGameObjectsToMap()
        {
            map.Clear();
            if (playerSpaceShip == null)
                playerSpaceShip = new Spaceship { ID = 1, DirectionImage = playerSpaceShip.DirectionImage, Description = "The old but reliable dart" };
            
          gameObjects.Add(playerSpaceShip);

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
                Planet pt = PlanetFactory.CreateRandomPlanet();
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
            playerSpaceShip.DirectionImage = "/Content/Images/darteast.png";
            switch(commandText)
            {
                case "n":
                    if (playerSpaceShip.Row - 5 > 0)
                    {
                        playerSpaceShip.Row -= 5;
                        playerSpaceShip.DirectionImage = "/Content/Images/dartnorth.png";
                    }
                    break;
                case "s":
                    if (playerSpaceShip.Row + 5 < 400)
                    {
                        playerSpaceShip.Row += 5;
                        playerSpaceShip.DirectionImage = "/Content/Images/dartsouth.png";
                    }
                    break;
                case "e":
                    if (playerSpaceShip.Col + 5 < 400)
                    {
                        playerSpaceShip.Col += 5;
                        playerSpaceShip.DirectionImage = "/Content/Images/darteast.png";
                    }
                    break;
                case "w":
                    if (playerSpaceShip.Col - 5 > 0)
                    {
                        playerSpaceShip.Col -= 5;
                        playerSpaceShip.DirectionImage = "/Content/Images/dartwest.png";
                    }
                    break;
            }
            playerSpaceShip.ProcessTurn();

        }

        internal void TakeComputerActions()
        {
            foreach (BaseGameObject go in gameObjects)
            {
                
                go.ProcessTurn();
            }
        }
    }
}