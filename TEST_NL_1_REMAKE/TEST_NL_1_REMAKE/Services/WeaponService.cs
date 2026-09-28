using System;
using System.Collections.Generic;
using System.Linq;
using TEST_NL_1_REMAKE.Models;

namespace TEST_NL_1_REMAKE.Services
{
    internal class WeaponService
    {
        public void ShowAllWeapons(List<Weapon> weapons) => weapons.ForEach(w => w.DisplayWeapon());
        public void ShowHighDamageWeapons(List<Weapon> weapons) => ShowAllWeapons(weapons.Where(w => w.Damage > 50).ToList());
        public void ShowWeaponsSortedByPrice(List<Weapon> weapons) => ShowAllWeapons(weapons.OrderBy(w => w.Price).ToList());
        public void ShowCheapestWeapon(List<Weapon> weapons) => weapons.MinBy(w => w.Price)?.DisplayWeapon();
        public void ShowAveragePrice(List<Weapon> weapons) => Console.WriteLine($"Average Price: {weapons.Average(w => w.Price):F2} Gold");
    }
}