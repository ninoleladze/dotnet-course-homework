using System;
using System.Collections.Generic;
using TEST_NL_1_REMAKE.Helpers;
using TEST_NL_1_REMAKE.Models;
using TEST_NL_1_REMAKE.Services;

namespace TEST_NL_1_REMAKE.Menus
{
    internal class WeaponMenu
    {
        public void Run(List<Weapon> list, WeaponService service, ConsoleHelper helper)
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("----------- IARAGHEBI -----------");
                Console.WriteLine("  1. yvela iaraghis naxva");
                Console.WriteLine("  2. filtri: maghali ziani (>50)");
                Console.WriteLine("  3. sortireba: fasi");
                Console.WriteLine("  4. yvelaze iafi iaraghi");
                Console.WriteLine("  5. iaraghebis sashualo fasi");
                Console.WriteLine("  0. ukan dabruneba");

                switch (helper.AskUser("airchie (0-5): "))
                {
                    case "1": Console.Clear(); service.ShowAllWeapons(list); helper.Wait(); break;
                    case "2": Console.Clear(); service.ShowHighDamageWeapons(list); helper.Wait(); break;
                    case "3": Console.Clear(); service.ShowWeaponsSortedByPrice(list); helper.Wait(); break;
                    case "4": Console.Clear(); service.ShowCheapestWeapon(list); helper.Wait(); break;
                    case "5": Console.Clear(); service.ShowAveragePrice(list); helper.Wait(); break;
                    case "0": running = false; break;
                    default: helper.PrintError(); break;
                }
            }
        }
    }
}