using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceRogueRevolution.Models.GameObjects
{
    public class Spaceship : BaseGameObject
    {
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

        public List<Job> jobs { get; set; }
        public List<Spaceship> spaceShips { get; set; }

        public override void ProcessTurn()
        {
            //base.ProcessTurn();
        }

        public bool Impounded { get; set; }

        public int Evasion { get; set; }

        internal void TakeDamage(object p)
        {
            throw new NotImplementedException();
        }
    }
}