using System;
using System.Collections.Generic;
using TEST_NL_1_REMAKE.Helpers;
using TEST_NL_1_REMAKE.Models;
using TEST_NL_1_REMAKE.Services;

namespace TEST_NL_1_REMAKE.Menus
{
    internal class HeroMenu
    {
        public void Run(List<Hero> list, HeroService service, ConsoleHelper helper)
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("------------- GMIREBI -------------");
                Console.WriteLine("  1. yvela gmiris naxva");
                Console.WriteLine("  2. filtri: maghali done");
                Console.WriteLine("  3. sortireba: health");
                Console.WriteLine("  4. yvelaze maghali donis gmiri");
                Console.WriteLine("  5. dajgufeba klasebis mixedvit");
                Console.WriteLine("  6. axali gmiris damateba");
                Console.WriteLine("  0. ukan dabruneba");

                switch (helper.AskUser("airchie (0-6): "))
                {
                    case "1": Console.Clear(); service.ShowAllHeroes(list); helper.Wait(); break;
                    case "2": Console.Clear(); service.ShowHighLevelHeroes(list); helper.Wait(); break;
                    case "3": Console.Clear(); service.ShowHeroesSortedByHealth(list); helper.Wait(); break;
                    case "4": Console.Clear(); service.ShowMaxLevelHero(list); helper.Wait(); break;
                    case "5": Console.Clear(); service.ShowHeroesGroupedByClass(list); helper.Wait(); break;
                    case "6": Console.Clear(); service.AddHero(list); helper.Wait(); break;
                    case "0": running = false; break;
                    default: helper.PrintError(); break;
                }
            }
        }
    }
}