using System;
using System.Collections.Generic;
using System.Linq;
using TEST_NL_1_REMAKE.Models;

namespace TEST_NL_1_REMAKE.Services
{
    internal class MonsterService
    {
        public void ShowAllMonsters(List<Monster> monsters) => monsters.ForEach(m => m.DisplayMonster());
        public void ShowDangerousMonsters(List<Monster> monsters) => ShowAllMonsters(monsters.Where(m => m.Danger >= 8).ToList());
        public void ShowMonstersSortedByHealthDesc(List<Monster> monsters) => ShowAllMonsters(monsters.OrderByDescending(m => m.Health).ToList());
        public void ShowMaxGoldReward(List<Monster> monsters) => Console.WriteLine($"Max Reward: {monsters.Max(m => m.GoldReward)} Gold");
        public void ShowTotalGoldReward(List<Monster> monsters) => Console.WriteLine($"Total Reward: {monsters.Sum(m => m.GoldReward)} Gold");
    }
}