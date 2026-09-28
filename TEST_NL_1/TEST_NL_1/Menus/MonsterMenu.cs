using System;
using System.Collections.Generic;
using System.Text;
using TEST_NL_1.Helpers;
using TEST_NL_1.Models;
using TEST_NL_1.Services;

namespace TEST_NL_1.Menus
{
    internal class MonsterMenu
    {
        public void Run(List<Monster> list, MonsterService service, ConsoleHelper helper)
        {
            bool isSubMenuRunning = true;
            while (isSubMenuRunning)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("----------- URCHXULEBI -----------");
                Console.ResetColor();
                Console.WriteLine("  1. yvela urchxulis naxva");
                Console.WriteLine("  2. filtri: opasni (danger >= 8)");
                Console.WriteLine("  3. sortireba: health (klebadobit)");
                Console.WriteLine("  4. maqsimaluri oqros jildo (Max)");
                Console.WriteLine("  5. urchxulebis jamuri oqro (Sum)");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("  0. ukan dabruneba");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("---------------------------------");
                Console.ResetColor();

                string archevani = helper.AskUser("airchie (0-5): ");

                switch (archevani)
                {
                    case "1": Console.Clear(); service.ShowAllMonsters(list); helper.Wait(); break;
                    case "2": Console.Clear(); service.ShowDangerousMonsters(list); helper.Wait(); break;
                    case "3": Console.Clear(); service.ShowMonstersSortedByHealthDesc(list); helper.Wait(); break;
                    case "4": Console.Clear(); service.ShowMaxGoldReward(list); helper.Wait(); break;
                    case "5": Console.Clear(); service.ShowTotalGoldReward(list); helper.Wait(); break;
                    case "0": isSubMenuRunning = false; break;
                    default: helper.PrintError(); break;
                }
            }
        }
    }
}