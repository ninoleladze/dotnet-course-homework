using System;
using System.Collections.Generic;
using System.Linq;
using TEST_NL_1_REMAKE.Models;

namespace TEST_NL_1_REMAKE.Services
{
    internal class MerchantService
    {
        public void ShowAllMerchants(List<Merchant> merchants) => merchants.ForEach(m => m.DisplayMerchant());
        public void ShowRichMerchants(List<Merchant> merchants) => ShowAllMerchants(merchants.Where(m => m.Gold > 1000).ToList());
        public void ShowRichestMerchant(List<Merchant> merchants) => merchants.MaxBy(m => m.Gold)?.DisplayMerchant();
        public void ShowMerchantsGroupedByCity(List<Merchant> merchants)
        {
            foreach (var group in merchants.GroupBy(m => m.City))
            {
                Console.WriteLine($"\n=== City: {group.Key} ===");
                foreach (var m in group) Console.WriteLine($" - {m.Name} (Gold: {m.Gold})");
            }
        }
    }
}