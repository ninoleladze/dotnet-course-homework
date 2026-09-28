using System;
using System.Collections.Generic;
using System.Text;
using TEST_NL_1.Helpers;
using TEST_NL_1.Models;
using TEST_NL_1.Services;

namespace TEST_NL_1.Menus
{
    internal class MerchantMenu
    {
        public void Run(List<Merchant> list, MerchantService service, ConsoleHelper helper)
        {
            bool isSubMenuRunning = true;
            while (isSubMenuRunning)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("------------ VACREBI ------------");
                Console.ResetColor();
                Console.WriteLine("  1. yvela vachris naxva");
                Console.WriteLine("  2. filtri: mdidari vacrebi (gold > 1000)");
                Console.WriteLine("  3. yvelaze mdidari vachari");
                Console.WriteLine("  4. vacrebi qalaqebis mixedvit (dajgufeba)");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("  0. ukan dabruneba");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("---------------------------------");
                Console.ResetColor();

                string archevani = helper.AskUser("airchie (0-4): ");

                switch (archevani)
                {
                    case "1": Console.Clear(); service.ShowAllMerchants(list); helper.Wait(); break;
                    case "2": Console.Clear(); service.ShowRichMerchants(list); helper.Wait(); break;
                    case "3": Console.Clear(); service.ShowRichestMerchant(list); helper.Wait(); break;
                    case "4": Console.Clear(); service.ShowMerchantsGroupedByCity(list); helper.Wait(); break;
                    case "0": isSubMenuRunning = false; break;
                    default: helper.PrintError(); break;
                }
            }
        }
    }
}
