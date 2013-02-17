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
        private List<BaseGameObject> gameObjects;
        public string Message;
        Spaceship playerSpaceShip;
        public IGameControl gameControl;

        public Galaxy()
        {
            gameControl = new KeyBoardGameControl();
            gameObjects = new List<BaseGameObject>();
            BuildMap();
        }

        private void BuildMap()
        {
            map = new List<Tile>();
            Debug.WriteLine("Building Map");
            playerSpaceShip = new Spaceship { ID = 1, DirectionImageN = GameImages.DartNorth,DirectionImageE = GameImages.DartEast,
                DirectionImageS = GameImages.DartSouth,DirectionImageW = GameImages.DartWest,
                Row = 5, Col = 5, CurrentFuel = 100,CurrentFood =100, Money = 50 };
            gameObjects.Add(playerSpaceShip);
            AddPlanetsToGameObjects();
            UpdateGameObjectsToMap();
        }

        public void UpdateGameObjectsToMap()
        {
          map.Clear();
           
          gameObjects.ToList().ForEach(go =>
            {
                if (go is Imapable)
                {
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

        internal void ProcessCommand(Command command)
        {
            string commandText = gameControl.takeAction(command);
            TakeComputerActions();
            UpdateGameObjectsToMap();


        }

   

        internal void TakeComputerActions()
        {
            foreach (BaseGameObject go in gameObjects)
            {
                go.ProcessTurn();
            }
        }

        internal List<Job> GetOpenJobsForPlanet(int planet)
        {
            var planets = gameObjects.Where(o => o is Planet);
            var selectedPlanet = (Planet)planets.FirstOrDefault(g => g.ID == planet);

            return selectedPlanet.jobs;
        }

        internal void UpdatePlayerStarshipToGameObject(Tile tile)
        {
            //playerSpaceShip.Col = tile.col;
           // playerSpaceShip.Row = tile.row;
            if (tile.gameObject != null)
            {
                playerSpaceShip  = tile.gameObject;
                playerSpaceShip.Row = tile.row;
                playerSpaceShip.Col = tile.col;
                /*playerSpaceShip.Row = tempSpaceShip.Row;
                playerSpaceShip.Col = tempSpaceShip.Row;
                playerSpaceShip.Money = tempSpaceShip.Money;
                playerSpaceShip.CurrentFood = tempSpaceShip.CurrentFood;
                playerSpaceShip.CurrentFuel = tempSpaceShip.CurrentFuel;*/

            }
            playerSpaceShip.ProcessTurn();


            gameObjects[0] = playerSpaceShip;
            
        }
    }
}