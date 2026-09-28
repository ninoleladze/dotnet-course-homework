using System;
using System.Collections.Generic;
using System.Text;
using static _4._1._2026_DI_remodeling_.ConsoleHelper;

namespace _4._1._2026_DI_remodeling_
{
    internal class TransactionLog
    {
        private Transaction[] transactions = new Transaction[100];
        private int count = 0;

        public void Add(string from, string to, decimal amount, string currency, string status)
        {
            if (count >= transactions.Length)
            {
                PrintError("WARNING: Transaction limit (100) reached.");
                return;
            }

            transactions[count++] = new Transaction()
            {
                From = from,
                To = to,
                Amount = amount,
                Currency = currency,
                Status = status,
                Date = DateTime.Now
            };
        }

        public void PrintAll()
        {
            if (count == 0) { PrintWarning("  No transactions yet."); return; }

            PrintColored("  == Transaction History ================================================", ConsoleColor.Magenta);
            for (int i = 0; i < count; i++)
                Console.WriteLine($"  {i + 1,3}. {transactions[i]}");
            PrintColored("  ======================================================================", ConsoleColor.Magenta);
        }
    }
}

