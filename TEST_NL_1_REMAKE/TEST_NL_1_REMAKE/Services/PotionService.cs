using System;
using System.Collections.Generic;
using System.Linq;
using TEST_NL_1_REMAKE.Models;

namespace TEST_NL_1_REMAKE.Services
{
    internal class PotionService
    {
        public void ShowAllPotions(List<Potion> potions) => potions.ForEach(p => p.DisplayPotion());
        public void ShowCheapPotions(List<Potion> potions) => ShowAllPotions(potions.Where(p => p.Price < 100).ToList());
        public void ShowPotionsSortedByPriceDesc(List<Potion> potions) => ShowAllPotions(potions.OrderByDescending(p => p.Price).ToList());
        public void ShowTotalQuantity(List<Potion> potions) => Console.WriteLine($"Total Potions: {potions.Sum(p => p.Quantity)} items");
    }
}