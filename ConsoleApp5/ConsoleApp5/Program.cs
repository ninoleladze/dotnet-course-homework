
class Program
{
    static void Main()
    {
        Console.Write("sheiiyvane int: ");
        int num1 = int.Parse(Console.ReadLine()!);

        Console.Write("sheiyvane double ");
        double num2 = double.Parse(Console.ReadLine()!);

        Console.Write("decimal");
        decimal num3 = decimal.Parse(Console.ReadLine()!);

        var numbers = GetNumbers(num1, num2, num3);
        Console.WriteLine($"Int: {numbers.Item1}, Double: {numbers.Item2}, Decimal: {numbers.Item3}");

        Console.Write("pirveli text");
        string firstText = Console.ReadLine()!;

        Console.Write("meore text");
        string secondText = Console.ReadLine()!;

        ShowTexts(firstText, secondText);


        Console.Write("luwi an kenti sheiyvane ");
        int checkNum = int.Parse(Console.ReadLine()!);
        Console.WriteLine($"{checkNum} luwia: {IsEven(checkNum)}");


        Console.Write("Enter a string to print: ");
        string userString = Console.ReadLine()!;
        Print(userString);

        Console.Write("Enter 'true' or 'false' to print as boolean: ");
        bool userBool = bool.Parse(Console.ReadLine()!);
        Print(userBool);
    }
    static (int, double, decimal) GetNumbers(int num1, double num2, decimal num3)
    {
        return (num1, num2, num3);
    }
    
    static void ShowTexts(string firstText, string secondText)
    {
        Console.WriteLine(firstText);
        Console.WriteLine(secondText);
    }

   
    static bool IsEven(int number)
    {
        return number % 2 == 0;
    }


    static void Print(string text)
    {
        Console.WriteLine($"String: {text}");
    }

    static void Print(bool value)
    {
        Console.WriteLine($"Boolean: {value}");
    }

    
}