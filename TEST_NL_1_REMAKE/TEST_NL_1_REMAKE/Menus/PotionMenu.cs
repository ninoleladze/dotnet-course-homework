using System;
using System.Collections.Generic;
using TEST_NL_1_REMAKE.Helpers;
using TEST_NL_1_REMAKE.Models;
using TEST_NL_1_REMAKE.Services;

namespace TEST_NL_1_REMAKE.Menus
{
    internal class PotionMenu
    {
        public void Run(List<Potion> list, PotionService service, ConsoleHelper helper)
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("------------ WAMLEBI ------------");
                Console.WriteLine("  1. yvela wamlis naxva");
                Console.WriteLine("  2. filtri: iafi wamlebi");
                Console.WriteLine("  3. sortireba: fasi");
                Console.WriteLine("  4. wamlebis jamuri raodenoba");
                Console.WriteLine("  0. ukan dabruneba");

                switch (helper.AskUser("airchie (0-4): "))
                {
                    case "1": Console.Clear(); service.ShowAllPotions(list); helper.Wait(); break;
                    case "2": Console.Clear(); service.ShowCheapPotions(list); helper.Wait(); break;
                    case "3": Console.Clear(); service.ShowPotionsSortedByPriceDesc(list); helper.Wait(); break;
                    case "4": Console.Clear(); service.ShowTotalQuantity(list); helper.Wait(); break;
                    case "0": running = false; break;
                    default: helper.PrintError(); break;
                }
            }
        }
    }
}