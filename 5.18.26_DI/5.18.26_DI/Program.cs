string studentName = "Nino";

string[] studentNames = new string[3] { "Nino", "Lasha", "Gio" };
Console.WriteLine(studentNames[0]);
Console.WriteLine(studentNames[1]);
Console.WriteLine(studentNames[2]);


string[] gasStations =
{
    "Shell",
    "BP",
    "Texaco",
    "Exxon",
    "Chevron"
};

Console.WriteLine(gasStations[3]);

//for (int i = 0; i < 10; i++)
//{
//    Console.WriteLine($"ganmeoreba {i}");
//}


//for (int i = -10; i <= 10; i+=3)
//{
//    Console.WriteLine($"ganmeoreba {i}");
//}


//for(int i = 10; i > 0; i--)
//{
//    Console.WriteLine($"ganmeoreba {i}");
//}


//string[] rooms =
//    {
//    "Room 101",
//    "Room 102",
//    "Room 103",
//    "Room 104",
//    "Room 105"
//};

//for (int i = 0; i < rooms.Length; i++)
//{
//    Console.WriteLine(rooms[i]);
//}

////////saklaso

// 1. Traffic light
{
    string[] lights = { "Red", "Yellow", "Green" };
    Console.Write("Traffic light - enter a color (Red/Yellow/Green): ");
    string input = Console.ReadLine() ?? string.Empty;
    if (input.Equals("Red", StringComparison.OrdinalIgnoreCase))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Stop!");
    }
    else if (input.Equals("Yellow", StringComparison.OrdinalIgnoreCase))
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Get ready!");
    }
    else if (input.Equals("Green", StringComparison.OrdinalIgnoreCase))
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Go!");
    }
    else
    {
        Console.ResetColor();
        Console.WriteLine("Unknown color.");
    }
    Console.ResetColor();
}

// 2. Rainbow
{
    ConsoleColor[] rainbow = { ConsoleColor.Red, ConsoleColor.Yellow, ConsoleColor.Green, ConsoleColor.Cyan, ConsoleColor.Blue, ConsoleColor.Magenta, ConsoleColor.DarkYellow };
    for (int i = 0; i < rainbow.Length; i++)
    {
        Console.ForegroundColor = rainbow[i];
        Console.WriteLine("Rainbow");
    }
    Console.ResetColor();
}

// 3. Number guessing
{
    int[] numbers = { 3, 7, 12, 25, 40, 55, 78, 99 };
    Console.Write("Enter a number to search: ");
    string? s = Console.ReadLine();
    if (int.TryParse(s, out int n))
    {
        bool found = false;
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] == n)
            {
                found = true;
                break;
            }
        }
        if (found)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Found! 🎉");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Try again 😢");
        }
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Invalid number input.");
    }
    Console.ResetColor();
}

// 4. Grades evaluator
{
    int[] grades = { 85, 42, 91, 67, 55 };
    for (int i = 0; i < grades.Length; i++)
    {
        int g = grades[i];
        if (g >= 90)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{g} - Excellent");
        }
        else if (g >= 70)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{g} - Good");
        }
        else if (g >= 50)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"{g} - Average");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{g} - Failed");
        }
    }
    Console.ResetColor();
}

// 5. Password strength
{
    Console.Write("Enter a password: ");
    string pass = Console.ReadLine() ?? string.Empty;
    int len = pass.Length;
    if (len < 6)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Weak password");
    }
    else if (len <= 10)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Medium password");
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Strong password");
    }
    Console.ResetColor();
}

// 6. Pizzeria menu
{
    string[] pizzas = { "Margherita", "Pepperoni", "Hawaii", "Veggie" };
    int[] prices = { 15, 20, 18, 17 };
    Console.WriteLine("Menu:");
    for (int i = 0; i < pizzas.Length; i++)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write($"{i}. {pizzas[i]} ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"- {prices[i]}$");
    }
    Console.ResetColor();
    Console.Write("Choose a pizza by number (0-3): ");
    string? choice = Console.ReadLine();
    if (int.TryParse(choice, out int idx) && idx >= 0 && idx < prices.Length)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Price: {prices[idx]}$");
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Invalid choice.");
    }
    Console.ResetColor();
}

// 7. Christmas tree
{
    // a single yellow star on top
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("    *");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("   ***");
    Console.WriteLine("  *****");
    Console.WriteLine(" *******");
    Console.WriteLine("*********");
    Console.ResetColor();
}

// 8. Hotel rooms
{
    string[] rooms = { "Room 1", "Room 2", "Room VIP", "Room 4", "Room VIP2" };
    for (int i = 0; i < rooms.Length; i++)
    {
        if (rooms[i].Contains("VIP"))
        {
            Console.ForegroundColor = ConsoleColor.Yellow; // gold-like
            Console.WriteLine(rooms[i]);
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(rooms[i]);
        }
    }
    Console.ResetColor();
}

// 9. Weather indicator
{
    Console.Write("Enter temperature (°C): ");
    string? t = Console.ReadLine();
    if (int.TryParse(t, out int temp))
    {
        if (temp < 0)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("It's cold, wear a jacket!");
        }
        else if (temp <= 15)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Chilly");
        }
        else if (temp <= 25)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Nice weather");
        }
        else
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Hot, drink water!");
        }
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Invalid temperature input.");
    }
    Console.ResetColor();
}

// 10. Mini quiz
{
    string[] questions = {
        "Capital of Georgia?",
        "How many days are in a year?",
        "Who painted the Mona Lisa?"
    };
    string[] answers = { "Tbilisi", "365", "Leonardo" };
    int score = 0;
    for (int i = 0; i < questions.Length; i++)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(questions[i]);
        Console.ResetColor();
        string? ans = Console.ReadLine() ?? string.Empty;
        if (answers[i].Equals(ans, StringComparison.OrdinalIgnoreCase))
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Correct answer! ✅");
            score++;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Wrong 😢. Correct: {answers[i]}");
        }
        Console.ResetColor();
    }
    // final score
    if (score == 3)
    {
        Console.ForegroundColor = ConsoleColor.Yellow; // gold-like
        Console.WriteLine($"{score}/3 - Excellent! 🏆");
    }
    else if (score == 2)
    {
        Console.ForegroundColor = ConsoleColor.Gray; // silver-like
        Console.WriteLine($"{score}/3 - Good!");
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"{score}/3 - Try again");
    }
    Console.ResetColor();
}


