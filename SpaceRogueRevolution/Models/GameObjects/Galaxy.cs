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
        public Tile playerSpaceShip;
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
            AddGameObjectsToMap();

        }

        private void AddGameObjectsToMap()
        {
            //Place planets
            
            playerSpaceShip = new Tile { ID = 1, FileName = "/Content/Images/dart.png", Description = "The old but reliable dart", row = 5, col = 5 };
            map.Add(playerSpaceShip);

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
            playerSpaceShip.row = coord.Row;
            playerSpaceShip.col = coord.Col;

            //loop thru the planets and work out if docked
        }

        internal void ProcessCommand(Command command)
        {
            string commandText = gameControl.takeAction(command);
            TakePlayerActionFromCommand(commandText);


        }

        internal void TakePlayerActionFromCommand(string commandText)
        {
            switch(commandText)
            {
                case "n":
                    if (playerSpaceShip.row - 5 > 0)
                        playerSpaceShip.row -= 5;
                    break;
                case "s":
                    if (playerSpaceShip.row + 5 < 400)
                         playerSpaceShip.row += 5;
                    break;
                case "e":
                    if (playerSpaceShip.col + 5 < 400)
                        playerSpaceShip.col += 5;
                    break;
                case "w":
                    if (playerSpaceShip.col - 5 > 0)
                         playerSpaceShip.col -=5;
                    break;
            }
        }

        internal void TakeComputerActions()
        {
           // foreach(BaseGameObject object in 
        }
    }
}