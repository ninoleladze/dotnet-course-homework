using System;
using System.Collections.Generic;
using System.Text;

namespace _4._1._2026_DI_remodeling_
{
    public static class CurrencyConverter
    {
        private const decimal GEL_TO_USD = 0.36m;
        private const decimal USD_TO_GEL = 2.75m;

        public static decimal Convert(decimal amount, string from, string to)
        {
            if (from == to) return amount;
            if (from == "GEL" && to == "USD") return amount * GEL_TO_USD;
            if (from == "USD" && to == "GEL") return amount * USD_TO_GEL;
            return amount;
        }
    }
}
