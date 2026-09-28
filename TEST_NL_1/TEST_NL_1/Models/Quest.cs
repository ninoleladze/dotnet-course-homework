using System;
using System.Collections.Generic;
using System.Text;

namespace TEST_NL_1.Models
{
    internal class Quest
    {
        public string Title;
        public int Reward;
        public bool IsCompleted;
        public string Difficulty;

        public void DisplayQuest()
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine($"Title:       {Title}");
            Console.WriteLine($"Reward:      {Reward} Gold");
            Console.WriteLine($"Completed:   {IsCompleted}");
            Console.WriteLine($"Difficulty:  {Difficulty}");
            Console.WriteLine("");
        }
    }
}
