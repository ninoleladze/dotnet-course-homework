using System;
using System.Collections.Generic;
using System.Text;

namespace _06._29._26_DI.Models.EX10
{
    public class SavingsAccount : BankAccount
    {
        private double _interestRate;

        public double InterestRate
        {
            get { return _interestRate; }
            set { _interestRate = value; }
        }

        public void AddInterest()
        {
            double interest = _balance * (_interestRate / 100);
            _balance += interest;
            Console.WriteLine($"Added Interest: {interest}");
        }
    }
}
