using System;
using System.Collections.Generic;
using System.Text;

namespace TEST_NL_1.Models
{
    internal class Monster
    {
        public string Name;
        public int Health;
        public int Danger;
        public int GoldReward;

        public void DisplayMonster()
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine($"Monster:    {Name}");
            Console.WriteLine($"Health:     {Health}");
            Console.WriteLine($"Danger:     {Danger}/10");
            Console.WriteLine($"Reward:     {GoldReward} Gold");
        }
    }
}
