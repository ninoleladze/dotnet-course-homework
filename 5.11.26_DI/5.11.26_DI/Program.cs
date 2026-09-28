
//Console.ForegroundColor = ConsoleColor.Magenta;
//Console.WriteLine("__________                __       \r\n\\______   \\_____    ____ |  | __   \r\n |    |  _/\\__  \\  /    \\|  |/ /   \r\n |    |   \\ / __ \\|   |  \\    <    \r\n |______  /(____  /___|  /__|_ \\   \r\n        \\/      \\/     \\/     \\/   ");

//Console.ResetColor();


//string CORRECT_USER = "Nini1234";
//string CORRECT_PASSWORD = "1234Nini";
//string CORRECT_PIN = "1234";
//decimal BALANCE = 500m;
//bool IS_VIP = false;

//char CURRENCY = '$';


//Console.WriteLine("Welcome to Our Bank!");

//Console.WriteLine("======================================");

//Console.Write("Please enter your username: ");
//string userName = Console.ReadLine();

//Console.Write("Please enter your password: ");
//string password = Console.ReadLine();


//if (userName == CORRECT_USER && password == CORRECT_PASSWORD)
//{
//    Console.Clear();
//    Console.ForegroundColor = ConsoleColor.White;
//    Console.WriteLine("Successfully logged in");
//    Console.WriteLine("1. View My Balance");
//    Console.WriteLine("2. View Balance In Different Currencies");
//    Console.WriteLine("3. View Transaction History");
//    Console.WriteLine("4. Transfer Money");
//    Console.ResetColor();

//    Console.Write("Choose Action: ");
//    string Action = Console.ReadLine();

//    if (Action == "1")
//    {
//        Console.Clear();
//        Console.BackgroundColor = ConsoleColor.Green;
//        Console.ForegroundColor = ConsoleColor.White;
//        Console.WriteLine($"{CORRECT_USER} Your Current Balance is: {BALANCE} {CURRENCY}");
//        Console.ResetColor();

//    }
//    else if (Action == "2")
//    {
//        Console.Clear();
//        if (IS_VIP)
//        {
//            Console.BackgroundColor = ConsoleColor.Green;
//            Console.ForegroundColor = ConsoleColor.White;
//            Console.WriteLine("VIP Member");
//            Console.ResetColor();
//            Console.WriteLine($"IN GEL {BALANCE * 2.7m}");
//            Console.WriteLine($"IN ANOTHER CURRENCY {BALANCE * 2.1m}");
//            Console.WriteLine($"IN ANOTHER CURRENCY {BALANCE * 2.2m}");
//            Console.WriteLine($"IN ANOTHER CURRENCY {BALANCE * 1.3m}");


//        }
//        else
//        {
//            Console.BackgroundColor = ConsoleColor.Green;
//            Console.ForegroundColor = ConsoleColor.White;
//            Console.WriteLine("Not VIP Member");
//            Console.ResetColor();
//            Console.WriteLine($"IN GEL {BALANCE * 2.3m}");
//            Console.WriteLine($"IN ANOTHER CURRENCY {BALANCE * 2.0m}");
//            Console.WriteLine($"IN ANOTHER CURRENCY {BALANCE * 2.1m}");
//            Console.WriteLine($"IN ANOTHER CURRENCY {BALANCE * 1.1m}");
//        }

//    }
//    else if (Action == "3")
//    {
//        Console.Clear();
//        Console.BackgroundColor = ConsoleColor.Green;
//        Console.ForegroundColor = ConsoleColor.White;
//        Console.WriteLine($"Transaction History");
//        Console.ResetColor();
//        Console.WriteLine($"{CORRECT_USER} -> niniko | 100 {CURRENCY}");
//        Console.WriteLine($"{CORRECT_USER} -> giorgi | 500 {CURRENCY}");
//        Console.WriteLine($"{CORRECT_USER} -> nika   | 200 {CURRENCY}");
//        Console.WriteLine($"{CORRECT_USER} -> mari   | 300 {CURRENCY}");

//    }
//    else if (Action == "4")
//    {
//        Console.Clear();
//        Console.BackgroundColor = ConsoleColor.Green;
//        Console.ForegroundColor = ConsoleColor.White;
//        Console.WriteLine("Who are you transferring money to Enter ID number: ");
//        string id = Console.ReadLine();

//        Console.WriteLine("How much money do you want to transfer? ");
//        decimal amount = decimal.Parse(Console.ReadLine());

//        if (amount > BALANCE || amount == 0 || amount < 0)
//        {
//            Console.BackgroundColor = ConsoleColor.Red;
//            Console.ForegroundColor = ConsoleColor.White;
//            Console.WriteLine("Error. Not enough money or invalid amount");
//            Console.ResetColor();

//        }
//        else
//        {
//            Console.WriteLine(" to finish trasaction enter pin");
//            string pin = Console.ReadLine();

//            if (pin == CORRECT_PIN)
//            {
//                Console.BackgroundColor = ConsoleColor.Green;
//                Console.ForegroundColor = ConsoleColor.White;
//                Console.WriteLine($"Successfully transferred {amount} {CURRENCY} to ID: {id}");
//                Console.ResetColor();
//                BALANCE = BALANCE - amount;
//                Console.WriteLine($"Your new balance is: {BALANCE} {CURRENCY}");
//            }
//            else
//            {
//                Console.BackgroundColor = ConsoleColor.Red;
//                Console.ForegroundColor = ConsoleColor.White;
//                Console.WriteLine("Error. Wrong pin");
//                Console.ResetColor();


//            }
//        }
//    }


//    else
//    {
//        Console.BackgroundColor = ConsoleColor.Red;
//        Console.ForegroundColor = ConsoleColor.White;
//        Console.WriteLine("Error. Wrong action");
//        Console.ResetColor();

//    }


//}
//else
//{
//    Console.ForegroundColor = ConsoleColor.White;
//    Console.BackgroundColor = ConsoleColor.Red;
//    Console.WriteLine("Error. Wrong credentials");
//    Console.ResetColor();
//}



///////////////////საკლასო: ავიაბილეთების სააგენტო


        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("                                                                                                \r\n                                                                                                \r\n▄█████ ▄▄ ▄▄ ▄▄ ▄▄ ██████ ▄▄▄▄   ▄▄▄  ▄▄ ▄▄ ▄▄▄▄▄ ▄▄      ▄████▄  ▄▄▄▄ ▄▄▄▄▄ ▄▄  ▄▄  ▄▄▄▄ ▄▄ ▄▄ \r\n▀▀▀▄▄▄ ██▄█▀ ▀███▀   ██   ██▄█▄ ██▀██ ██▄██ ██▄▄  ██      ██▄▄██ ██ ▄▄ ██▄▄  ███▄██ ██▀▀▀ ▀███▀ \r\n█████▀ ██ ██   █     ██   ██ ██ ██▀██  ▀█▀  ██▄▄▄ ██▄▄▄   ██  ██ ▀███▀ ██▄▄▄ ██ ▀██ ▀████   █   \r\n                                                                                                ");

        Console.ResetColor();

        string AGENCY_USER = "Nino";
        string AGENCY_PASS = "n123";
        string SECURE_PIN = "8888";

        decimal TRAVEL_FUNDS = 1200m;
        bool PREMIUM_MEMBER = true;
        char MAIN_CURRENCY = '$';

        Console.WriteLine("Welcome to SkyTravel Agency!");
        Console.WriteLine("======================================");

        Console.Write("Please enter your username: ");
        string userName = Console.ReadLine();

        Console.Write("Please enter your password: ");
        string password = Console.ReadLine();

        if (userName == AGENCY_USER && password == AGENCY_PASS)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Successfully logged in");
            Console.WriteLine("1. View Destinations");
            Console.WriteLine("2. Buy Ticket");
            Console.WriteLine("3. View Funds In Different Currencies");
            Console.WriteLine("4. Flight History");
            Console.WriteLine("5. Miles Program");
            Console.ResetColor();

            Console.Write("Choose Action: ");
            string menuChoice = Console.ReadLine();

            if (menuChoice == "1")
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Available Destinations:");
                Console.ResetColor();
                Console.WriteLine("Tbilisi → Paris");
                Console.WriteLine("Tbilisi → New York");
                Console.WriteLine("Tbilisi → Tokyo");
                Console.WriteLine("Tbilisi → Dubai");
            }
            else if (menuChoice == "2")
            {
                Console.Clear();
                Console.WriteLine("Choose Seat Class (E/B/F): ");
                char seatClass = char.Parse(Console.ReadLine());

                decimal ticketPrice = 0m;
                if (seatClass == 'E') ticketPrice = 250m;
                else if (seatClass == 'B') ticketPrice = 600m;
                else if (seatClass == 'F') ticketPrice = 1200m;
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error. Wrong seat class");
                    Console.ResetColor();
                    return;
                }

                if (PREMIUM_MEMBER) ticketPrice *= 0.85m; 

                Console.WriteLine($"Ticket Price: {ticketPrice} {MAIN_CURRENCY}");
                Console.Write("Enter PIN to confirm purchase: ");
                string pin = Console.ReadLine();

                if (pin == SECURE_PIN && TRAVEL_FUNDS >= ticketPrice)
                {
                    TRAVEL_FUNDS -= ticketPrice;
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Successfully purchased ticket! Remaining Funds: {TRAVEL_FUNDS} {MAIN_CURRENCY}");
                    Console.ResetColor();
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error. Wrong PIN or Not Enough Funds");
                    Console.ResetColor();
                }
            }
            else if (menuChoice == "3")
            {
                Console.Clear();
                if (PREMIUM_MEMBER)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine("Premium Member Conversion Rates:");
                    Console.ResetColor();
                    Console.WriteLine($"In GEL {TRAVEL_FUNDS * 2.8m}");
                    Console.WriteLine($"In EUR {TRAVEL_FUNDS * 0.95m}");
                    Console.WriteLine($"In GBP {TRAVEL_FUNDS * 0.85m}");
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine("Standard Conversion Rates:");
                    Console.ResetColor();
                    Console.WriteLine($"In GEL {TRAVEL_FUNDS * 2.5m}");
                    Console.WriteLine($"In EUR {TRAVEL_FUNDS * 0.9m}");
                    Console.WriteLine($"In GBP {TRAVEL_FUNDS * 0.8m}");
                }
            }
            else if (menuChoice == "4")
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine("Flight History:");
                Console.ResetColor();
                Console.WriteLine($"{AGENCY_USER} → Paris | 250 {MAIN_CURRENCY}");
                Console.WriteLine($"{AGENCY_USER} → New York | 600 {MAIN_CURRENCY}");
                Console.WriteLine($"{AGENCY_USER} → Dubai | 500 {MAIN_CURRENCY}");
            }
            else if (menuChoice == "5")
            {
                Console.Clear();
                if (PREMIUM_MEMBER)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine("Premium Miles Program");
                    Console.ResetColor();
                    Console.WriteLine("You earn double miles for each flight!");
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Standard Miles Program");
                    Console.ResetColor();
                    Console.WriteLine("Earn 1 mile per $1 spent.");
                }
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Error. Wrong action");
                Console.ResetColor();
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Error. Wrong credentials");
            Console.ResetColor();
        }
    