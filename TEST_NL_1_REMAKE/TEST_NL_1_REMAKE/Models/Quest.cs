using System;

namespace TEST_NL_1_REMAKE.Models
{
    internal class Quest
    {
        private string title;
        private int reward;

        public string Title
        {
            get { return title; }
            set { if (!string.IsNullOrWhiteSpace(value)) title = value; else Console.WriteLine("Error: Quest title cannot be empty."); }
        }

        public int Reward
        {
            get { return reward; }
            set { if (value >= 0) reward = value; else Console.WriteLine("Error: Reward cannot be negative."); }
        }

        public bool IsCompleted { get; set; }
        public string Difficulty { get; set; }

        public void DisplayQuest() => Console.WriteLine($"Quest: {Title} | Reward: {Reward} Gold | Completed: {IsCompleted} | Difficulty: {Difficulty}");
    }
}