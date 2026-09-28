using System;
using System.Collections.Generic;
using System.Text;
using TEST_NL_1.Models;

namespace TEST_NL_1.Services
{
    internal class MonsterService
    {
        public void ShowAllMonsters(List<Monster> monsters)
        {
            for (int i = 0; i < monsters.Count; i++)
            {
                monsters[i].DisplayMonster();
            }
        }

        public void ShowDangerousMonsters(List<Monster> monsters)
        {
            List<Monster> filtered = monsters.Where(m => m.Danger >= 8).ToList();
            ShowAllMonsters(filtered);
        }

        public void ShowMonstersSortedByHealthDesc(List<Monster> monsters)
        {
            List<Monster> sorted = monsters.OrderByDescending(m => m.Health).ToList();
            ShowAllMonsters(sorted);
        }

        public void ShowMaxGoldReward(List<Monster> monsters)
        {
            int maxGold = monsters.Max(m => m.GoldReward);
            Console.WriteLine($"\nYvelaze maghali oqros jildo: {maxGold} Gold");
        }

        public void ShowTotalGoldReward(List<Monster> monsters)
        {
            int total = monsters.Sum(m => m.GoldReward);
            Console.WriteLine($"\nYvela urchxulis jamuri oqros jildo: {total} Gold");
        }
    }
    }
