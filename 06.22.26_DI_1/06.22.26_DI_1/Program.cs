using _06._22._26_DI_1.Services;
using System;
using System.Collections.Generic;

Console.Title = "Fight Night Admin Panel";
EmailNotifier notifier = new EmailNotifier();
bool isRunning = true;

while (isRunning)
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("========================================");
    Console.WriteLine("      FIGHT NIGHT NOTIFICATION SYSTEM   ");
    Console.WriteLine("========================================\n");
    Console.ResetColor();

    Console.WriteLine("Select an action:");
    Console.WriteLine("[1] Send Simple Registration Notification");
    Console.WriteLine("[2] Send VIP Notification");
    Console.WriteLine("[3] Send Event Time Reminder");
    Console.WriteLine("[4] Send Mass Schedule Update");
    Console.WriteLine("[5] Send Custom Personal Message");
    Console.WriteLine("[6] View Admin Logs");
    Console.WriteLine("[7] Exit System");
    Console.Write("Your Choice (1-7): ");

    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Console.Write("Enter recipient email: ");
            string simpleEmail = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Sending...");
            notifier.SendNotification(simpleEmail);
            Console.WriteLine("Done!");
            Console.ResetColor();
            WaitForKey();
            break;

        case "2":
            Console.Write("Enter recipient email: ");
            string vipEmail = Console.ReadLine();
            Console.Write("Is user VIP? (yes/no): ");
            bool isVip = Console.ReadLine().ToLower() == "yes";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Sending...");
            notifier.SendNotification(vipEmail, isVip);
            Console.WriteLine("Done!");
            Console.ResetColor();
            WaitForKey();
            break;

        case "3":
            Console.Write("Enter recipient email: ");
            string reminderEmail = Console.ReadLine();
            DateTime fightDate = new DateTime(2026, 7, 15, 21, 0, 0);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Sending countdown reminder...");
            notifier.SendNotification(reminderEmail, fightDate);
            Console.WriteLine("Done!");
            Console.ResetColor();
            WaitForKey();
            break;

        case "4":
            Console.WriteLine("Enter emails separated by comma (e.g. email1@gmail.com, email2@gmail.com): ");
            string massInput = Console.ReadLine();
            string[] emails = massInput.Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Sending update to {emails.Length} users...");
            notifier.SendNotification(emails);
            Console.WriteLine("Done!");
            Console.ResetColor();
            WaitForKey();
            break;

        case "5":
            Console.Write("Enter recipient email: ");
            string customEmail = Console.ReadLine();
            Console.Write("Enter your custom message: ");
            string msg = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Sending...");
            notifier.SendNotification(customEmail, msg);
            Console.WriteLine("Done!");
            Console.ResetColor();
            WaitForKey();
            break;

        case "6":
            notifier.ShowSentLog();
            WaitForKey();
            break;

        case "7":
            isRunning = false;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Shutting down system...");
            Console.ResetColor();
            break;

        default:
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Invalid option. Please try again.");
            Console.ResetColor();
            WaitForKey();
            break;
    }
}

static void WaitForKey()
{
    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
}