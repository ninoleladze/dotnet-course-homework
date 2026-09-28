using _06._08._26_DI;

//1
Rectangle rectangle = new Rectangle()
{
    width = 5,
    height = 10
};

Console.WriteLine($"Area: {rectangle.GetArea()}");
Console.WriteLine($"Perimeter: {rectangle.GetPerimeter()}");


//2
Student student = new Student()
{
    name = "John",
    grade = 7
};

student.DisplayStudentInfo();
Console.WriteLine($"Passed: {student.IsPassing()}");

//3
BankAccount account = new BankAccount()
{
    balance = 500
};

account.Deposit(200);
account.Withdraw(100);
account.Withdraw(1000);
Console.WriteLine($"Balance: {account.GetBalance()}");

//4
Calculator calculator = new Calculator();

Console.WriteLine($"Add: {calculator.Add(10, 5)}");
Console.WriteLine($"Subtract: {calculator.Subtract(10, 5)}");
Console.WriteLine($"Multiply: {calculator.Multiply(10, 5)}");
Console.WriteLine($"Divide: {calculator.Divide(10, 5)}");
Console.WriteLine($"Divide by zero: {calculator.Divide(10, 0)}");



//5

Temperature temperature = new Temperature()
{
    celsius = -5
};

Console.WriteLine($"Fahrenheit: {temperature.ToFahrenheit()}");
Console.WriteLine($"Is Freezing: {temperature.IsFreezing()}");


//6

Circle circle = new Circle()
{
    radius = 7
};

Console.WriteLine($"Area: {circle.GetArea()}");
Console.WriteLine($"Circumference: {circle.GetCircumference()}");


//7
Counter counter = new Counter();

counter.Increment();
counter.Increment();
counter.Increment();
counter.Decrement();
Console.WriteLine($"Count: {counter.GetCount()}");
counter.Reset();
Console.WriteLine($"Count after reset: {counter.GetCount()}");

//8
Person person = new Person()
{
    name = "nini",
    age = 18
};

person.Greet();
Console.WriteLine($"Is Adult: {person.IsAdult()}");


//9
NumberBox numberBox = new NumberBox();

numberBox.AddNumber(3);
numberBox.AddNumber(7);
numberBox.AddNumber(1);
numberBox.AddNumber(9);

Console.WriteLine($"Sum: {numberBox.GetSum()}");
Console.WriteLine($"Max: {numberBox.GetMax()}");
numberBox.PrintAll();

//10
ProductStore store = new ProductStore();

store.AddProduct(new Product() { name = "Laptop", price = 1200 });
store.AddProduct(new Product() { name = "Mouse", price = 25 });
store.AddProduct(new Product() { name = "Keyboard", price = 150 });

Console.WriteLine($"Expensive count: {store.CountExpensive()}");
Console.WriteLine($"Cheapest: {store.GetCheapest().name}");
Console.WriteLine($"Has Laptop: {store.HasProduct("Laptop")}");
Console.WriteLine($"Has Monitor: {store.HasProduct("Monitor")}");








//saklaso


//Car manqana = new Car()
//{
//    model = "Model S",
//    brand = "Tesla",
//    cylinderCount = 8,

//};

//manqana.DisplayCarInfo();
//manqana.getSomething();

//Console.WriteLine($"Something: {manqana.getSomething()}");
//int test = manqana.getSomething();
//Console.WriteLine($"Test: {test}");

//void testing(int raghac)
//{
//    if (raghac > 15)
//    {
//        Console.WriteLine("okay");
//    }
//    else
//    {
//        Console.WriteLine("not okay");
//    }
//}


//testing(manqana.getSomething());








//void PrintHello(string message = "Default Message")
//{
//    Console.BackgroundColor = ConsoleColor.Green;
//    Console.ForegroundColor = ConsoleColor.White;
//    Console.WriteLine($"{message}");
//    Console.ResetColor();

//}