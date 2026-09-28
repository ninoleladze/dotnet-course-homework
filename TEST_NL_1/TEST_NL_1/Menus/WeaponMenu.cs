using System;
using System.Collections.Generic;
using System.Text;
using TEST_NL_1.Helpers;
using TEST_NL_1.Models;
using TEST_NL_1.Services;

namespace TEST_NL_1.Menus
{
    internal class WeaponMenu
    {
        public void Run(List<Weapon> list, WeaponService service, ConsoleHelper helper)
        {
            bool isSubMenuRunning = true;
            while (isSubMenuRunning)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("----------- IARAGHEBI -----------");
                Console.ResetColor();
                Console.WriteLine("  1. yvela iaraghis naxva");
                Console.WriteLine("  2. filtri: ziani (damage > 50)");
                Console.WriteLine("  3. sortireba: fasi (zrdadobit)");
                Console.WriteLine("  4. yvelaze iafi iaraghi");
                Console.WriteLine("  5. iaraghebis sashualo fasi");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("  0. ukan dabruneba");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("---------------------------------");
                Console.ResetColor();

                string archevani = helper.AskUser("airchie (0-5): ");

                switch (archevani)
                {
                    case "1": Console.Clear(); service.ShowAllWeapons(list); helper.Wait(); break;
                    case "2": Console.Clear(); service.ShowHighDamageWeapons(list); helper.Wait(); break;
                    case "3": Console.Clear(); service.ShowWeaponsSortedByPrice(list); helper.Wait(); break;
                    case "4": Console.Clear(); service.ShowCheapestWeapon(list); helper.Wait(); break;
                    case "5": Console.Clear(); service.ShowAveragePrice(list); helper.Wait(); break;
                    case "0": isSubMenuRunning = false; break;
                    default: helper.PrintError(); break;
                }
            }
        }
    }
}
