using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceRogueRevolution.Models.GameObjects
{
    public class Spaceship : BaseGameObject,Imapable
    {
        public string Name { get; set; }
        public int MaxShields { get; set; }
        public int CurrentShields { get; set; }
        public int MaxPower { get; set; }
        public int CurrentPower { get; set; }
        public int CurrentFuel { get; set; }
        public int MaxFuel { get; set; }
        public int CurrentFood { get; set; }
        public int MaxFood { get; set; }
        public List<Weapon> weapons { get; set; }
        public List<int> landingPermits { get; set; }
        public int Money { get; set; }
        public bool IsDocked { get; set; }
        public string DirectionImage { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }

        public List<Job> jobs { get; set; }
        public List<Spaceship> spaceShips { get; set; }

        public override void ProcessTurn()
        {
            if (IsDocked)
            {
                CurrentShields = MaxShields;
            }
            else
            {
                CurrentFuel--;
                CurrentFood--;
            }
        }

        public bool Impounded { get; set; }

        public int Evasion { get; set; }

        internal void TakeDamage(Weapon weapon)
        {
            CurrentPower =  (CurrentShields < 1) ? CurrentPower - weapon.Damage :  CurrentPower - weapon.Damage;
        }

        public Tile GetTileForMap()
        {
            Tile t = new Tile { ID = 1, FileName = DirectionImage , Description = this.Description, row = Row, col = this.Col, gameObject = this };
            return t;
        }

        public override string Description
        {
            get
            {
                return String.Format("The {0} fuel : {1} , food {2} , ${3} credits ",Name,CurrentFuel,CurrentFood,Money);
            }
            set
            {
                base.Description = value;
            }
        }
    }
}