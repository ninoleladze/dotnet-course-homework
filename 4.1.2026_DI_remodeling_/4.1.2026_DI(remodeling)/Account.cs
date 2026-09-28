using System;
using System.Collections.Generic;
using System.Text;

namespace _4._1._2026_DI_remodeling_
{
    public class Account
    {
        public string UserName;
        public string PIN;
        public decimal Balance;

        public Account(string userName, string pin, decimal balance)
        {
            UserName = userName;
            PIN = pin;
            Balance = balance;
        }

        public bool CheckPIN(string inputPin) => PIN == inputPin;

        public void Deposit(decimal amount, string currency)
        {
            Balance += CurrencyConverter.Convert(amount, currency, "GEL");
        }

        public bool Withdraw(decimal amount, string currency)
        {
            decimal inGEL = CurrencyConverter.Convert(amount, currency, "GEL");
            if (inGEL > Balance) return false;
            Balance -= inGEL;
            return true;
        }

        public bool Transfer(Account recipient, decimal amount, string currency)
        {
            decimal inGEL = CurrencyConverter.Convert(amount, currency, "GEL");
            if (inGEL > Balance) return false;
            Balance -= inGEL;
            recipient.Balance += inGEL;
            return true;
        }
    }
}

