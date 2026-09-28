using System;
using System.Collections.Generic;
using System.Text;

namespace _06._29._26_DI.Models.EX10
{
    public class BankAccount
    {
        private string _owner;
        protected double _balance;

        public string Owner
        {
            get { return _owner; }
            set { _owner = value; }
        }

        public void Deposit(double amount)
        {
            _balance += amount;
        }

        public void ShowBalance()
        {
            Console.WriteLine($"Balance: {_balance}");
        }
    }
}
