using System;
using System.Collections.Generic;
using System.Text;
using TEST_NL_1.Models;

namespace TEST_NL_1.Services
{
    internal class StatisticsService
    {
        public void ShowGlobalStats(List<Hero> heroes, List<Weapon> weapons, List<Monster> monsters)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("==================================================");
            Console.WriteLine("          GLOBALURI STATISTIKIS GVERDI            ");
            Console.WriteLine("==================================================");
            Console.ResetColor();

          
            Hero strongestHero = heroes.MaxBy(h => h.Level);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n[ YVELAZE DZLIERI GMIRI (MAX LEVEL)]");
            Console.ResetColor();
            strongestHero?.DisplayHero();

           
            Weapon mostExpensiveWeapon = weapons.MaxBy(w => w.Price);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n[ YVELAZE DZVIRI IARAGHI (MAX PRICE)]");
            Console.ResetColor();
            mostExpensiveWeapon?.DisplayWeapon();

         
            Monster mostDangerousMonster = monsters.MaxBy(m => m.Danger);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n[ YVELAZE SASHISHI URCHXULI (MAX DANGER)]");
            Console.ResetColor();
            mostDangerousMonster?.DisplayMonster();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n==================================================");
            Console.ResetColor();
        }
    }
}
