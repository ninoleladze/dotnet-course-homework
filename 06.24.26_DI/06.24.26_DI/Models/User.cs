using System;
using System.Collections.Generic;
using System.Text;

namespace _06._24._26_DI.Models
{
    internal class User
    {
        private string _userName;
        private decimal _balance;

        public string UserName
        {
            get { return _userName; }
            set { 
            if(value.Length > 12)
                {
                    Console.WriteLine("User name is too long.");
                }
                else
                {
                    _userName = value;
                }

            }
        }

        public decimal Balance
        {
            get
            {
                Console.WriteLine("Enter PIN");
                string pin = Console.ReadLine();

                if (pin == "1234")
                {
                    return _balance;
                }
                else
                {
                    return -1;
                }
            }
        }


        public void deposit(decimal amount) {
        if(amount< 0|| amount > 100)
            {
                Console.WriteLine("Invalid deposit amount.");
            }
            else
            {
                _balance += amount;
            }
        }
}
}
