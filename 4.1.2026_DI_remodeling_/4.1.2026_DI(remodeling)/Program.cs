using System.Text;
using static _4._1._2026_DI_remodeling_.ConsoleHelper;
namespace _4._1._2026_DI_remodeling_
{
    class Program
    {


        static Account[] accounts = new Account[]
        {
            new Account("g.beridze",  "1234", 1500.00m),
            new Account("n.leladze",  "4321", 3200.50m),
            new Account("m.testuser", "0000",  800.00m),
        };

        static TransactionLog log = new TransactionLog();

        static Account FindAccount(string userName)
        {
            for (int i = 0; i < accounts.Length; i++)
                if (accounts[i].UserName == userName) return accounts[i];
            return null;
        }

        static Account Login()
        {
            while (true)
            {
                Account found = FindAccount(AskInput("Username: "));
                if (found == null) { PrintError("  User not found."); continue; }

                if (found.CheckPIN(AskInput("PIN: ")))
                {
                    PrintSuccess($"  Welcome, {found.UserName}!");
                    return found;
                }

                PrintError("  Incorrect PIN.");
            }
        }

        static void PrintMenu(Account user)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("┌──────────────────────────────────────┐");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"│  Balance: {user.Balance,12:F2} GEL            │");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("├──────────────────────────────────────┤");
            Console.WriteLine("│  1 - Deposit                         │");
            Console.WriteLine("│  2 - Withdraw                        │");
            Console.WriteLine("│  3 - Transfer                        │");
            Console.WriteLine("│  4 - Transaction history             │");
            Console.WriteLine("│  0 - Exit                            │");
            Console.WriteLine("└──────────────────────────────────────┘");
            Console.ResetColor();
        }

        static void HandleDeposit(Account user)
        {
            if (!TryGetAmount("Enter deposit amount: ", out decimal amount)) return;
            string currency = ChooseCurrency();
            user.Deposit(amount, currency);
            log.Add("CASH", user.UserName, amount, currency, "Success");
            PrintSuccess($"  Deposited {amount:F2} {currency}. New balance: {user.Balance:F2} GEL");
        }

        static void HandleWithdraw(Account user)
        {
            if (!TryGetAmount("Enter withdrawal amount: ", out decimal amount)) return;
            string currency = ChooseCurrency();
            bool ok = user.Withdraw(amount, currency);
            log.Add(user.UserName, "CASH", amount, currency, ok ? "Success" : "Failed");
            if (ok) PrintSuccess($"  Withdrew {amount:F2} {currency}. New balance: {user.Balance:F2} GEL");
            else PrintError("  Insufficient funds. Transaction recorded as: Failed");
        }

        static void HandleTransfer(Account user)
        {
            string recipientName = AskInput("Recipient username: ");
            if (recipientName == user.UserName) { PrintError("  Cannot transfer to yourself."); return; }

            Account recipient = FindAccount(recipientName);
            if (recipient == null) { PrintError($"  User '{recipientName}' not found."); return; }

            if (!TryGetAmount("Transfer amount: ", out decimal amount)) return;
            string currency = ChooseCurrency();
            bool ok = user.Transfer(recipient, amount, currency);
            log.Add(user.UserName, recipient.UserName, amount, currency, ok ? "Success" : "Failed");
            if (ok) PrintSuccess($"  Transferred {amount:F2} {currency} to {recipient.UserName}. Your balance: {user.Balance:F2} GEL");
            else PrintError("  Insufficient funds. Transaction recorded as: Failed");
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            PrintColored("╔══════════════════════════════╗\n║       🏦  MINI BANK          ║\n╚══════════════════════════════╝", ConsoleColor.Cyan);

            Account currentUser = Login();
            bool running = true;

            while (running)
            {
                PrintMenu(currentUser);
                switch (AskInput("Choose: "))
                {
                    case "1": HandleDeposit(currentUser); break;
                    case "2": HandleWithdraw(currentUser); break;
                    case "3": HandleTransfer(currentUser); break;
                    case "4": log.PrintAll(); break;
                    case "0": PrintColored("  Goodbye!", ConsoleColor.Cyan); running = false; break;
                    default: PrintError("  Invalid choice. Please enter 0-4."); break;
                }
            }
        }
    }
}