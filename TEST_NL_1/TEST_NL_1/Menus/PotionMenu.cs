using System;
using System.Collections.Generic;
using System.Text;
using TEST_NL_1.Helpers;
using TEST_NL_1.Models;
using TEST_NL_1.Services;

namespace TEST_NL_1.Menus
{
    internal class PotionMenu
    {
        public void Run(List<Potion> list, PotionService service, ConsoleHelper helper)
        {
            bool isSubMenuRunning = true;
            while (isSubMenuRunning)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("------------ WAMLEBI ------------");
                Console.ResetColor();
                Console.WriteLine("  1. yvela wamlis naxva");
                Console.WriteLine("  2. filtri: iafi wamlebi (price < 100)");
                Console.WriteLine("  3. sortireba: fasi (klebadobit)");
                Console.WriteLine("  4. wamlebis jamuri raodenoba (Sum)");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("  0. ukan dabruneba");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("---------------------------------");
                Console.ResetColor();

                string archevani = helper.AskUser("airchie (0-4): ");

                switch (archevani)
                {
                    case "1": Console.Clear(); service.ShowAllPotions(list); helper.Wait(); break;
                    case "2": Console.Clear(); service.ShowCheapPotions(list); helper.Wait(); break;
                    case "3": Console.Clear(); service.ShowPotionsSortedByPriceDesc(list); helper.Wait(); break;
                    case "4": Console.Clear(); service.ShowTotalQuantity(list); helper.Wait(); break;
                    case "0": isSubMenuRunning = false; break;
                    default: helper.PrintError(); break;
                }
            }
        }
    }
}
