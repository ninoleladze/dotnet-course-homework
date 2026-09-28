using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace _06._08._26_DI
{
    internal class BankAccount
    {
        public int balance;

        public void Deposit(int amount)
        {
            balance += amount;
        }

        public void Withdraw(int amount)
        {
            if (amount <= balance)
            {
                balance -= amount;
            }
            else
            {
                Console.WriteLine("Insufficient funds.");
            }
        }

        public int GetBalance()
        {
            return balance;
        }

    }
}
