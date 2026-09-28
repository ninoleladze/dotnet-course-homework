using System;
using System.Collections.Generic;
using System.Text;
using TEST_NL_1.Models;

namespace TEST_NL_1.Services
{
    internal class QuestService
    {
        public void ShowAllQuests(List<Quest> quests)
        {
            for (int i = 0; i < quests.Count; i++)
            {
                quests[i].DisplayQuest();
            }
        }

        public void ShowCompletedQuests(List<Quest> quests)
        {
            List<Quest> filtered = quests.Where(q => q.IsCompleted == true).ToList();
            ShowAllQuests(filtered);
        }

        public void ShowCompletedRewardsSum(List<Quest> quests)
        {
            int totalReward = quests.Where(q => q.IsCompleted == true).Sum(q => q.Reward);
            Console.WriteLine($"\nShesrulebuli davalebebis jamuri jildo: {totalReward} Gold");
        }

        public void ShowCompletedCount(List<Quest> quests)
        {
            int count = quests.Count(q => q.IsCompleted == true);
            Console.WriteLine($"\nShesrulebuli davalebebis raodenoba: {count}");
        }
    }
}
