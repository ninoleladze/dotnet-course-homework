// Program.cs
using System;
using TEST_NL_1_REMAKE.Data;
using TEST_NL_1_REMAKE.Helpers;
using TEST_NL_1_REMAKE.Menus;
using TEST_NL_1_REMAKE.Services;

namespace TEST_NL_1_REMAKE
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameData data = new GameData();
            ConsoleHelper helper = new ConsoleHelper();

            HeroService heroService = new HeroService();
            WeaponService weaponService = new WeaponService();
            PotionService potionService = new PotionService();
            MonsterService monsterService = new MonsterService();
            QuestService questService = new QuestService();
            MerchantService merchantService = new MerchantService();
            StatisticsService statisticsService = new StatisticsService();

            HeroMenu heroMenu = new HeroMenu();
            WeaponMenu weaponMenu = new WeaponMenu();
            PotionMenu potionMenu = new PotionMenu();
            MonsterMenu monsterMenu = new MonsterMenu();
            QuestMenu questMenu = new QuestMenu();
            MerchantMenu merchantMenu = new MerchantMenu();

            bool isAppRunning = true;

            while (isAppRunning)
            {
                helper.ShowMainMenu();
                string choice = helper.AskUser();

                switch (choice)
                {
                    case "1":
                        heroMenu.Run(data.Heroes, heroService, helper);
                        break;
                    case "2":
                        weaponMenu.Run(data.Weapons, weaponService, helper);
                        break;
                    case "3":
                        potionMenu.Run(data.Potions, potionService, helper);
                        break;
                    case "4":
                        monsterMenu.Run(data.Monsters, monsterService, helper);
                        break;
                    case "5":
                        questMenu.Run(data.Quests, questService, helper);
                        break;
                    case "6":
                        merchantMenu.Run(data.Merchants, merchantService, helper);
                        break;
                    case "7":
                        Console.Clear();
                        statisticsService.ShowGlobalStats(data.Heroes, data.Weapons, data.Monsters);
                        helper.Wait();
                        break;
                    case "0":
                        Console.Clear();
                        Console.WriteLine("Goodbye!");
                        isAppRunning = false;
                        break;
                    default:
                        helper.PrintError();
                        break;
                }
            }
        }
    }
}