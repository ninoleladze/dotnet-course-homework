using System;
using System.Collections.Generic;
using System.Text;

namespace _4._1._2026_DI_remodeling_
{
    public class Transaction
    {
        public string From;
        public string To;
        public decimal Amount;
        public string Currency;
        public string Status;
        public DateTime Date;

        public override string ToString() =>
            $"[{Date:yyyy-MM-dd HH:mm}] {From} → {To} | {Amount:F2} {Currency} | {Status}";
    }
}
