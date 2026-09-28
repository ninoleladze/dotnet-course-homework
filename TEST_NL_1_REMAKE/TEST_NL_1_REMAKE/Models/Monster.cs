using System;

namespace TEST_NL_1_REMAKE.Models
{
    internal class Monster
    {
        private string name;
        private int health;
        private int danger;
        private int goldReward;

        public string Name
        {
            get { return name; }
            set { if (!string.IsNullOrWhiteSpace(value)) name = value; else Console.WriteLine("Error: Monster name is required."); }
        }

        public int Health
        {
            get { return health; }
            set { if (value >= 0) health = value; else Console.WriteLine("Error: Monster health must be at least 0."); }
        }

        public int Danger
        {
            get { return danger; }
            set { if (value >= 1 && value <= 10) danger = value; else { Console.WriteLine("Error: Danger 1-10."); danger = 1; } }
        }

        public int GoldReward
        {
            get { return goldReward; }
            set { if (value >= 0) goldReward = value; else Console.WriteLine("Error: Gold reward cannot be negative."); }
        }

        public void DisplayMonster() => Console.WriteLine($"Monster: {Name} | Health: {Health} | Danger: {Danger}/10 | Reward: {GoldReward} Gold");
    }
}