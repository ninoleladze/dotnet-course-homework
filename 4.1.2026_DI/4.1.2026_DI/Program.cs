using System.Text;

namespace MiniBank
{
    class Program
    {
        static Transaction[] transactions = new Transaction[100];
        static int transactionCount = 0;

        static void AddTransaction(string from, string to, decimal amount, string currency, string status)
        {
            if (transactionCount >= transactions.Length)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("WARNING: Transaction limit (100) reached.");
                Console.ResetColor();
                return;
            }

            Transaction t = new Transaction();
            t.From = from;
            t.To = to;
            t.Amount = amount;
            t.Currency = currency;
            t.Status = status;
            t.Date = DateTime.Now;

            transactions[transactionCount] = t;
            transactionCount++;
        }

        static string ChooseCurrency()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("Currency (1 = GEL, 2 = USD) [default: GEL]: ");
            Console.ResetColor();
            string input = Console.ReadLine()?.Trim();
            return input == "2" ? "USD" : "GEL";
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Account[] accounts = new Account[]
            {
                new Account("g.beridze",       "1234", 1500.00m),
                new Account("n.leladze", "4321", 3200.50m),
                new Account("m.testuser",      "0000",  800.00m),
            };

          
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔══════════════════════════════╗");
            Console.WriteLine("║       🏦  MINI BANK          ║");
            Console.WriteLine("╚══════════════════════════════╝");
            Console.ResetColor();

            Account currentUser = null;

            while (currentUser == null)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Username: ");
                Console.ResetColor();
                string inputUser = Console.ReadLine()?.Trim();

                bool found = false;
                Account foundAccount = null;

                for (int i = 0; i < accounts.Length; i++)
                {
                    if (accounts[i].UserName == inputUser)
                    {
                        found = true;
                        foundAccount = accounts[i];
                        break;
                    }
                }

                if (!found)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("  User not found. Please try again.");
                    Console.ResetColor();
                    continue;
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("PIN: ");
                Console.ResetColor();
                string inputPin = Console.ReadLine()?.Trim();

                if (foundAccount.PIN == inputPin)
                {
                    currentUser = foundAccount;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"  Welcome, {currentUser.UserName}!");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("  Incorrect PIN. Please try again.");
                    Console.ResetColor();
                }
            }


            bool running = true;
            while (running)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("┌──────────────────────────────────────┐");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"│  Balance: {currentUser.Balance,12:F2} GEL            │");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("├──────────────────────────────────────┤");
                Console.WriteLine("│  1 - Deposit                         │");
                Console.WriteLine("│  2 - Withdraw                        │");
                Console.WriteLine("│  3 - Transfer                        │");
                Console.WriteLine("│  4 - Transaction history             │");
                Console.WriteLine("│  0 - Exit                            │");
                Console.WriteLine("└──────────────────────────────────────┘");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Choose: ");
                Console.ResetColor();

                string choice = Console.ReadLine()?.Trim();

                switch (choice)
                {

                    case "1":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Enter deposit amount: ");
                        Console.ResetColor();

                        if (!decimal.TryParse(Console.ReadLine(), out decimal depositAmount) || depositAmount <= 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("  Invalid amount. Must be greater than 0.");
                            Console.ResetColor();
                            break;
                        }

                        string depCurrency = ChooseCurrency();
                        currentUser.Balance += depositAmount;
                        AddTransaction("CASH", currentUser.UserName, depositAmount, depCurrency, "Success");

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"  Deposited {depositAmount:F2} {depCurrency}. New balance: {currentUser.Balance:F2} GEL");
                        Console.ResetColor();
                        break;


                    case "2":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Enter withdrawal amount: ");
                        Console.ResetColor();

                        if (!decimal.TryParse(Console.ReadLine(), out decimal withdrawAmount) || withdrawAmount <= 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("  Invalid amount. Must be greater than 0.");
                            Console.ResetColor();
                            break;
                        }

                        string wdCurrency = ChooseCurrency();

                        if (withdrawAmount > currentUser.Balance)
                        {
                            AddTransaction(currentUser.UserName, "CASH", withdrawAmount, wdCurrency, "Failed");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("  Insufficient funds. Transaction recorded as: Failed");
                            Console.ResetColor();
                        }
                        else
                        {
                            currentUser.Balance -= withdrawAmount;
                            AddTransaction(currentUser.UserName, "CASH", withdrawAmount, wdCurrency, "Success");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"  Withdrew {withdrawAmount:F2} {wdCurrency}. New balance: {currentUser.Balance:F2} GEL");
                            Console.ResetColor();
                        }
                        break;


                    case "3":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Recipient username: ");
                        Console.ResetColor();

                        string recipientName = Console.ReadLine()?.Trim();

                        if (recipientName == currentUser.UserName)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("  Cannot transfer to yourself.");
                            Console.ResetColor();
                            break;
                        }

                        Account recipient = null;
                        for (int i = 0; i < accounts.Length; i++)
                        {
                            if (accounts[i].UserName == recipientName)
                            {
                                recipient = accounts[i];
                                break;
                            }
                        }

                        if (recipient == null)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"  User '{recipientName}' not found.");
                            Console.ResetColor();
                            break;
                        }

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Transfer amount: ");
                        Console.ResetColor();

                        if (!decimal.TryParse(Console.ReadLine(), out decimal transferAmount) || transferAmount <= 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("  Invalid amount. Must be greater than 0.");
                            Console.ResetColor();
                            break;
                        }

                        string trCurrency = ChooseCurrency();

                        if (transferAmount > currentUser.Balance)
                        {
                            AddTransaction(currentUser.UserName, recipient.UserName, transferAmount, trCurrency, "Failed");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("  Insufficient funds. Transaction recorded as: Failed");
                            Console.ResetColor();
                        }
                        else
                        {
                            currentUser.Balance -= transferAmount;
                            recipient.Balance += transferAmount;
                            AddTransaction(currentUser.UserName, recipient.UserName, transferAmount, trCurrency, "Success");

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"  Transferred {transferAmount:F2} {trCurrency} to {recipient.UserName}.");
                            Console.WriteLine($"  Your balance: {currentUser.Balance:F2} GEL");
                            Console.ResetColor();
                        }
                        break;


                    case "4":
                        if (transactionCount == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("  No transactions yet.");
                            Console.ResetColor();
                            break;
                        }

                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("  == Transaction History ================================================");
                        Console.ForegroundColor = ConsoleColor.White;
                        for (int i = 0; i < transactionCount; i++)
                        {
                            Console.WriteLine($"  {i + 1,3}. {transactions[i]}");
                        }
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("  ======================================================================");
                        Console.ResetColor();
                        break;


                    case "0":
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("  Goodbye!");
                        Console.ResetColor();
                        running = false;
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("  Invalid choice. Please enter 0-4.");
                        Console.ResetColor();
                        break;
                }
            }
        }
    }
}