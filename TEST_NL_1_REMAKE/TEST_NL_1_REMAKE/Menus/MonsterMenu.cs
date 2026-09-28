using System;
using System.Collections.Generic;
using TEST_NL_1_REMAKE.Helpers;
using TEST_NL_1_REMAKE.Models;
using TEST_NL_1_REMAKE.Services;

namespace TEST_NL_1_REMAKE.Menus
{
    internal class MonsterMenu
    {
        public void Run(List<Monster> list, MonsterService service, ConsoleHelper helper)
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("----------- URCHXULEBI -----------");
                Console.WriteLine("  1. yvela urchxulis naxva");
                Console.WriteLine("  2. filtri: opasni (danger >= 8)");
                Console.WriteLine("  3. sortireba: health");
                Console.WriteLine("  4. maqsimaluri oqros jildo");
                Console.WriteLine("  5. urchxulebis jamuri oqro");
                Console.WriteLine("  0. ukan dabruneba");

                switch (helper.AskUser("airchie (0-5): "))
                {
                    case "1": Console.Clear(); service.ShowAllMonsters(list); helper.Wait(); break;
                    case "2": Console.Clear(); service.ShowDangerousMonsters(list); helper.Wait(); break;
                    case "3": Console.Clear(); service.ShowMonstersSortedByHealthDesc(list); helper.Wait(); break;
                    case "4": Console.Clear(); service.ShowMaxGoldReward(list); helper.Wait(); break;
                    case "5": Console.Clear(); service.ShowTotalGoldReward(list); helper.Wait(); break;
                    case "0": running = false; break;
                    default: helper.PrintError(); break;
                }
            }
        }
    }
}