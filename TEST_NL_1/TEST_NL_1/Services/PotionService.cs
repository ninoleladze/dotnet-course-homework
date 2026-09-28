using System;
using System.Collections.Generic;
using System.Text;
using TEST_NL_1.Models;

namespace TEST_NL_1.Services
{
    internal class PotionService
    {
        public void ShowAllPotions(List<Potion> potions)
        {
            for (int i = 0; i < potions.Count; i++)
            {
                potions[i].DisplayPotion();
            }
        }

        public void ShowCheapPotions(List<Potion> potions)
        {
            List<Potion> filtered = potions.Where(p => p.Price < 100).ToList();
            ShowAllPotions(filtered);
        }

        public void ShowPotionsSortedByPriceDesc(List<Potion> potions)
        {
            List<Potion> sorted = potions.OrderByDescending(p => p.Price).ToList();
            ShowAllPotions(sorted);
        }

        public void ShowTotalQuantity(List<Potion> potions)
        {
            int total = potions.Sum(p => p.Quantity);
            Console.WriteLine($"\nSul ramebi wamali (Quantity Sum): {total} cali");
        }
    }
}
