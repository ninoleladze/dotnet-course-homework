using System;
using System.Collections.Generic;
using TEST_NL_1_REMAKE.Helpers;
using TEST_NL_1_REMAKE.Models;
using TEST_NL_1_REMAKE.Services;

namespace TEST_NL_1_REMAKE.Menus
{
    internal class QuestMenu
    {
        public void Run(List<Quest> list, QuestService service, ConsoleHelper helper)
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("---------- DAVALEBEBI ----------");
                Console.WriteLine("  1. yvela davalebis naxva");
                Console.WriteLine("  2. filtri: shesrulebuli");
                Console.WriteLine("  3. shesrulebulis jamuri jildo");
                Console.WriteLine("  4. shesrulebulis raodenoba");
                Console.WriteLine("  0. ukan dabruneba");

                switch (helper.AskUser("airchie (0-4): "))
                {
                    case "1": Console.Clear(); service.ShowAllQuests(list); helper.Wait(); break;
                    case "2": Console.Clear(); service.ShowCompletedQuests(list); helper.Wait(); break;
                    case "3": Console.Clear(); service.ShowCompletedRewardsSum(list); helper.Wait(); break;
                    case "4": Console.Clear(); service.ShowCompletedCount(list); helper.Wait(); break;
                    case "0": running = false; break;
                    default: helper.PrintError(); break;
                }
            }
        }
    }
}