using System;

public class BankAccount
{
    private decimal balance;

    public decimal Balance
    {
        get { return balance; }
    }

    public void Deposit(decimal amount)
    {
        if (amount > 0)
            balance += amount;
        else
            Console.WriteLine("Error: Deposit amount must be positive.");
    }

    public void Withdraw(decimal amount)
    {
        if (amount > 0 && amount <= balance)
            balance -= amount;
        else
            Console.WriteLine("Error: Insufficient balance or invalid amount.");
    }
}