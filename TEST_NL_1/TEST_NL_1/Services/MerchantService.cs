using System;
using System.Collections.Generic;
using System.Text;
using TEST_NL_1.Models;

namespace TEST_NL_1.Services
{
    internal class MerchantService
    {
        public void ShowAllMerchants(List<Merchant> merchants)
        {
            for (int i = 0; i < merchants.Count; i++)
            {
                merchants[i].DisplayMerchant();
            }
        }

        public void ShowRichMerchants(List<Merchant> merchants)
        {
            List<Merchant> filtered = merchants.Where(m => m.Gold > 1000).ToList();
            ShowAllMerchants(filtered);
        }

        public void ShowRichestMerchant(List<Merchant> merchants)
        {
            Merchant richest = merchants.MaxBy(m => m.Gold);
            if (richest != null)
            {
                Console.WriteLine("\n[Yvelaze Mdidari Vachari]");
                richest.DisplayMerchant();
            }
        }

        public void ShowMerchantsGroupedByCity(List<Merchant> merchants)
        {
            var grouped = merchants.GroupBy(m => m.City);
            foreach (var group in grouped)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"\n=== City: {group.Key} ===");
                Console.ResetColor();
                foreach (var merchant in group)
                {
                    Console.WriteLine($" - {merchant.Name} (Gold: {merchant.Gold}, Items: {merchant.ItemCount})");
                }
            }
        }
    }
}
