using System;
using System.Collections.Generic;
using System.Text;
using TEST_NL_1.Helpers;
using TEST_NL_1.Models;
using TEST_NL_1.Services;

namespace TEST_NL_1.Menus
{
    internal class HeroMenu
    {
        public void Run(List<Hero> list, HeroService service, ConsoleHelper helper)
        {
            bool isSubMenuRunning = true;
            while (isSubMenuRunning)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("------------- GMIREBI -------------");
                Console.ResetColor();
                Console.WriteLine("  1. yvela gmiris naxva");
                Console.WriteLine("  2. filtri: maghali done (level > 10)");
                Console.WriteLine("  3. sortireba: (health) klebadobit");
                Console.WriteLine("  4. yvelaze maghali donis gmiri");
                Console.WriteLine("  5. gmirebi klasebis mixedvit (dajgufeba)");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("  6. axali gmiris damateba (Add) ➕");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("  7. dzebna saxelit (Search) 🔍");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("  0. ukan dabruneba");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("-----------------------------------");
                Console.ResetColor();

                string archevani = helper.AskUser("airchie (0-7): ");

                switch (archevani)
                {
                    case "1": Console.Clear(); service.ShowAllHeroes(list); helper.Wait(); break;
                    case "2": Console.Clear(); service.ShowHighLevelHeroes(list); helper.Wait(); break;
                    case "3": Console.Clear(); service.ShowHeroesSortedByHealth(list); helper.Wait(); break;
                    case "4": Console.Clear(); service.ShowMaxLevelHero(list); helper.Wait(); break;
                    case "5": Console.Clear(); service.ShowHeroesGroupedByClass(list); helper.Wait(); break;
                    case "6": Console.Clear(); service.AddHero(list); helper.Wait(); break;
                    case "7": Console.Clear(); service.SearchByName(list); helper.Wait(); break;
                    case "0": isSubMenuRunning = false; break;
                    default: helper.PrintError(); break;
                }
            }
        }
    }
}