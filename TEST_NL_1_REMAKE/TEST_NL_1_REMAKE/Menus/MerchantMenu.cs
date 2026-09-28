using System;
using System.Collections.Generic;
using TEST_NL_1_REMAKE.Helpers;
using TEST_NL_1_REMAKE.Models;
using TEST_NL_1_REMAKE.Services;

namespace TEST_NL_1_REMAKE.Menus
{
    internal class MerchantMenu
    {
        public void Run(List<Merchant> list, MerchantService service, ConsoleHelper helper)
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("----------- VACREBI -----------");
                Console.WriteLine("  1. yvela vachris naxva");
                Console.WriteLine("  2. filtri: mdidari (gold > 1000)");
                Console.WriteLine("  3. yvelaze mdidari vachari");
                Console.WriteLine("  4. dajgufeba qalaqebis mixedvit");
                Console.WriteLine("  0. ukan dabruneba");

                switch (helper.AskUser("airchie (0-4): "))
                {
                    case "1": Console.Clear(); service.ShowAllMerchants(list); helper.Wait(); break;
                    case "2": Console.Clear(); service.ShowRichMerchants(list); helper.Wait(); break;
                    case "3": Console.Clear(); service.ShowRichestMerchant(list); helper.Wait(); break;
                    case "4": Console.Clear(); service.ShowMerchantsGroupedByCity(list); helper.Wait(); break;
                    case "0": running = false; break;
                    default: helper.PrintError(); break;
                }
            }
        }
    }
}