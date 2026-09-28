namespace MiniBank
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
    }
}