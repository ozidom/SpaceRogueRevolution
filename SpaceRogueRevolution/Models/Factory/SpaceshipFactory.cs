using SpaceRogueRevolution.Models.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceRogueRevolution.Models.Factory
{
    public class SpaceshipFactory
    {
        public static Spaceship CreateRandomSpaceship()
        {
            Spaceship s = new Spaceship();
            s.CurrentFood = Utility.Rnd(10);
            s.CurrentFuel = Utility.Rnd(20);
            s.CurrentPower = Utility.Rnd(20);
            s.CurrentShields = Utility.Rnd(20);
            s.Description = "A random ship";
            s.Evasion = Utility.Rnd(10);
            s.Impounded = false;
            s.jobs = null;
            s.Money = Utility.Rnd(2000);
            s.weapons = GetRandomWeapons(1);

            return s;

        }

        private static List<Weapon> GetRandomWeapons(int numberOfRandomWeapons)
        {
            List<Weapon> allWeapons = BuildWeaponsList();
            List<Weapon> selectedWeapons = new List<Weapon>();
            int weaponCount = 0;
            while(weaponCount < numberOfRandomWeapons) 
            {
                Weapon selectedWeapon = allWeapons[Utility.Rnd(allWeapons.Count)];
                if (!allWeapons.Contains(selectedWeapon))
                {
                    selectedWeapons.Add(selectedWeapon);
                    weaponCount++;
                }
            }
            return selectedWeapons;
        }

        private static List<Weapon> BuildWeaponsList()
        {
            List<Weapon> allWeapons = new List<Weapon>();
            allWeapons.Add(new Weapon { Accuracy = 3, Damage = 8, Description = "Heavy Spaceship Cannon" });
            allWeapons.Add(new Weapon { Accuracy = 3, Damage = 3, Description = "Light Spaceship Cannon" });
            allWeapons.Add(new Weapon { Accuracy = 4, Damage = 2, Description = "Light Laser" });
            allWeapons.Add(new Weapon { Accuracy = 5, Damage = 6, Description = "Portable Power Blast (PPB)" });
            allWeapons.Add(new Weapon { Accuracy = 4, Damage = 2, Description = "Guided Missiles" });
            allWeapons.Add(new Weapon { Accuracy = 3, Damage = 2, Description = "Heavy Spaceship Cannon" });
            return allWeapons;
        }
    }
}