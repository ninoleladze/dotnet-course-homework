using System;
using System.Collections.Generic;
using System.Text;
using TEST_NL_1.Models;

namespace TEST_NL_1.Services
{
    internal class WeaponService
    {
        public void ShowAllWeapons(List<Weapon> weapons)
        {
            for (int i = 0; i < weapons.Count; i++)
            {
                weapons[i].DisplayWeapon();
            }
        }

        public void ShowHighDamageWeapons(List<Weapon> weapons)
        {
            List<Weapon> filtered = weapons.Where(w => w.Damage > 50).ToList();
            ShowAllWeapons(filtered);
        }

        public void ShowWeaponsSortedByPrice(List<Weapon> weapons)
        {
            List<Weapon> sorted = weapons.OrderBy(w => w.Price).ToList();
            ShowAllWeapons(sorted);
        }

        public void ShowCheapestWeapon(List<Weapon> weapons)
        {
            Weapon cheap = weapons.MinBy(w => w.Price);
            if (cheap != null)
            {
                Console.WriteLine("\n[Yvelaze Iafi Iaraghi]");
                cheap.DisplayWeapon();
            }
        }

        public void ShowAveragePrice(List<Weapon> weapons)
        {
            double avg = weapons.Average(w => w.Price);
            Console.WriteLine($"\nIaraghebis sashualo fasi: {avg:F2} Gold");
        }
    }
}
