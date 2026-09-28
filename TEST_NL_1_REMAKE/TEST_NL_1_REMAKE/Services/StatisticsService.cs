using System;
using System.Collections.Generic;
using System.Linq;
using TEST_NL_1_REMAKE.Models;

namespace TEST_NL_1_REMAKE.Services
{
    internal class StatisticsService
    {
        public void ShowGlobalStats(List<Hero> heroes, List<Weapon> weapons, List<Monster> monsters)
        {
            Console.WriteLine("=== GLOBAL STATS ===");
            Console.WriteLine("\n[ Strongest Hero ]"); heroes.MaxBy(h => h.Level)?.DisplayHero();
            Console.WriteLine("\n[ Most Expensive Weapon ]"); weapons.MaxBy(w => w.Price)?.DisplayWeapon();
            Console.WriteLine("\n[ Most Dangerous Monster ]"); monsters.MaxBy(m => m.Danger)?.DisplayMonster();
        }
    }
}