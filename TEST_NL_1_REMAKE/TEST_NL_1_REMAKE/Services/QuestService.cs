using System;
using System.Collections.Generic;
using System.Linq;
using TEST_NL_1_REMAKE.Models;

namespace TEST_NL_1_REMAKE.Services
{
    internal class QuestService
    {
        public void ShowAllQuests(List<Quest> quests) => quests.ForEach(q => q.DisplayQuest());
        public void ShowCompletedQuests(List<Quest> quests) => ShowAllQuests(quests.Where(q => q.IsCompleted).ToList());
        public void ShowCompletedRewardsSum(List<Quest> quests) => Console.WriteLine($"Total Reward from Completed: {quests.Where(q => q.IsCompleted).Sum(q => q.Reward)} Gold");
        public void ShowCompletedCount(List<Quest> quests) => Console.WriteLine($"Completed Quests: {quests.Count(q => q.IsCompleted)}");
    }
}