using System;
using System.Collections.Generic;
using System.Text;
using TEST_NL_1.Helpers;
using TEST_NL_1.Models;
using TEST_NL_1.Services;

namespace TEST_NL_1.Menus
{
    internal class QuestMenu
    {
        public void Run(List<Quest> list, QuestService service, ConsoleHelper helper)
        {
            bool isSubMenuRunning = true;
            while (isSubMenuRunning)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("---------- DAVALEBEBI ----------");
                Console.ResetColor();
                Console.WriteLine("  1. yvela davalebis naxva");
                Console.WriteLine("  2. filtri: shesrulebuli davalebebi");
                Console.WriteLine("  3. shesrulebuli davalebebis jamuri jildo");
                Console.WriteLine("  4. shesrulebuli davalebebis raodenoba");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("  0. ukan dabruneba");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("---------------------------------");
                Console.ResetColor();

                string archevani = helper.AskUser("airchie (0-4): ");

                switch (archevani)
                {
                    case "1": Console.Clear(); service.ShowAllQuests(list); helper.Wait(); break;
                    case "2": Console.Clear(); service.ShowCompletedQuests(list); helper.Wait(); break;
                    case "3": Console.Clear(); service.ShowCompletedRewardsSum(list); helper.Wait(); break;
                    case "4": Console.Clear(); service.ShowCompletedCount(list); helper.Wait(); break;
                    case "0": isSubMenuRunning = false; break;
                    default: helper.PrintError(); break;
                }
            }
        }
    }
}
