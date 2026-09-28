using System;

class Program
{
    static void Main()
    {
        PrintName("Nini");

        
        int sum = Sum(5, 7);
        Console.WriteLine($"Sum: {sum}");

       
        int max = Max(10, 20);
        Console.WriteLine($"Max: {max}");

    
        int[] numbers = { 1, 2, 3, 4, 5 };
        double average = GetAverage(numbers);
        Console.WriteLine($"Average: {average}");

        PrintInfo("nini");
        PrintInfo("nino", 17);


        if (TryDivide(10, 2, out double result))
            Console.WriteLine($"Division result: {result}");
        else
            Console.WriteLine("Division by zero!");


        Console.WriteLine($"Is 4 even? {IsEven(4)}");
        Console.WriteLine($"Is 7 even? {IsEven(7)}");

        Console.WriteLine($"Is 17 adult? {IsAdult(17)}");
        Console.WriteLine($"Is 18 adult? {IsAdult(18)}");

      

        int a = 3, b = 8;
        Console.WriteLine($"Before swap: a={a}, b={b}");
        Swap(ref a, ref b);
        Console.WriteLine($"After swap: a={a}, b={b}");
    }

    
    static void PrintName(string name)
    {
        Console.WriteLine($"Hello, {name}");
    }

  
    static int Sum(int a, int b)
    {
        return a + b;
    }

    
    static int Max(int a, int b)
    {
        return a > b ? a : b;
    }

    
    static double GetAverage(int[] numbers)
    {
        if (numbers == null || numbers.Length == 0)
            return 0;
        double sum = 0;
        foreach (var num in numbers)
        {
            sum += num;
        }
        return sum / numbers.Length;
    }


    static void PrintInfo(string name)
    {
        Console.WriteLine($"Name: {name}");
    }

    static void PrintInfo(string name, int age)
    {
        Console.WriteLine($"Name: {name}, Age: {age}");
    }


    static bool TryDivide(int a, int b, out double result)
    {
        if (b != 0)
        {
            result = (double)a / b;
            return true;
        }
        result = 0;
        return false;
    }


    static bool IsEven(int num)
    {
        return num % 2 == 0;
    }

    
    static bool IsAdult(int age)
    {
        return age >= 18;
    }


    static void Swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }
}