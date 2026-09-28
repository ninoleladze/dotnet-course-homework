//Console.ForegroundColor = ConsoleColor.DarkYellow;
//Console.WriteLine("My First C# Program");
//Console.ResetColor();

//Console.ForegroundColor = ConsoleColor.Red;
//Console.WriteLine("ERROR");
//Console.ResetColor();

//Console.BackgroundColor = ConsoleColor.Green;
//Console.ForegroundColor= ConsoleColor.Red;
//Console.WriteLine("tqven warmatebit gadaricxet");
//Console.ResetColor();

////Console.Beep();

//Console.WriteLine("==================================");

//int numberOfPants = 300;
//Console.WriteLine(numberOfPants);


//Console.WriteLine("maragshi amjamad aris " + numberOfPants + " sharvali");
//Console.WriteLine($"maragshi amjamad aris {numberOfPants} sharvali");


//int x = 300;
//int y = 500;

//Console.BackgroundColor = ConsoleColor.Blue;
//Console.WriteLine($"{x} + {y} = {x + y}");
//Console.ResetColor();

//Console.BackgroundColor = ConsoleColor.DarkGreen;
//Console.WriteLine($"{x} - {y} = {x - y}");
//Console.ResetColor();


////string myName = Console.ReadLine();

////Console.WriteLine($"My name is {myName}");
////Console.WriteLine("Shemoiyvanet sruli saxeli gvari");

////string fullName = Console.ReadLine();

////Console.WriteLine("shemoiyvanet misamarti");
////string address = Console.ReadLine();

////Console.WriteLine("shemoiyvanet el. fosta");
////string email = Console.ReadLine();

////Console.BackgroundColor= ConsoleColor.Green;
////Console.WriteLine("=============================");
////Console.ResetColor();


////Console.WriteLine($"Mogesalmebit: {fullName}");
////Console.WriteLine($"tqveni el. fosta {email} chawerilia");
////Console.WriteLine($"amanats {address} miigebt");


//int temperature = 50;

//if(temperature > 30)
//{
//    Console.BackgroundColor = ConsoleColor.Red;
//    Console.ForegroundColor = ConsoleColor.White;
//    Console.WriteLine("its hot outside");
//    Console.WriteLine($"The current temperature is {temperature} degrees.");
//    Console.ResetColor();
//}
//else
//{
//    Console.BackgroundColor = ConsoleColor.Green;
//    Console.ForegroundColor = ConsoleColor.White;
//    Console.WriteLine("its normal");
//    Console.WriteLine($"amjamindeli temperatura aris {temperature} gradusi");
//    Console.ResetColor();
//}


//string role = "admin";

//Console.BackgroundColor= ConsoleColor.Green;
//Console.WriteLine("============================");
//Console.ResetColor();

//if (role == "admin")
//{
//    Console.WriteLine("welcome admin");
//}
//else if (role == "manager")
//{
//    Console.WriteLine("welcome manager");
//}
//else if (role == "customer")
//{
//    Console.WriteLine("welcome customer");
//}
//else
//{
//    Console.WriteLine("rolis amocnoba ver moxerxda");
//}


//Console.WriteLine("Enter your age: ");
//int age = int.Parse(Console.ReadLine());
//if(age > 18)
//    {
//    Console.WriteLine("welcome to our website");
//}
//else
//{
//    Console.WriteLine("sorry, you are not allowed to access this website");
//}



//////////////////////////saklasooo////////////
///1
Console.WriteLine("shemoiyvanet saxeli: ");
string name = Console.ReadLine();

Console.WriteLine("shemoiyvanet gvari: ");
string surname = Console.ReadLine();


Console.BackgroundColor = ConsoleColor.Green;
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine($"gamarjoba, {name} {surname}");
Console.ResetColor();


//2
Console.WriteLine("shemoiyvane ricxvi: ");
int a = int.Parse(Console.ReadLine());

Console.WriteLine("shemoiyvane meore ricxvi: ");
int b = int.Parse(Console.ReadLine());

Console.BackgroundColor = ConsoleColor.Green;
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine($"{a} + {b} = {a + b}");
Console.ResetColor();

Console.BackgroundColor = ConsoleColor.Yellow;
Console.ForegroundColor = ConsoleColor.Black;
Console.WriteLine($"{a} - {b} = {a - b}");
Console.ResetColor();

Console.BackgroundColor = ConsoleColor.Cyan;
Console.ForegroundColor = ConsoleColor.Black;
Console.WriteLine($"{a} * {b} = {a * b}");
Console.ResetColor();

Console.BackgroundColor = ConsoleColor.Magenta;
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine($"{a} / {b} = {a / b}");
Console.ResetColor();


//3
Console.WriteLine("shemoiyvanet temperatura ");
int temp = int.Parse(Console.ReadLine());

if (temp > 30)
{
    Console.BackgroundColor = ConsoleColor.Red;
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("cxela");
}
else if (temp >= 15)
{
    Console.BackgroundColor = ConsoleColor.Yellow;
    Console.ForegroundColor = ConsoleColor.Black;
    Console.WriteLine("tbila");
}
else if (temp >= 0)
{
    Console.BackgroundColor = ConsoleColor.Cyan;
    Console.ForegroundColor = ConsoleColor.Black;
    Console.WriteLine("grila");
}
else
{
    Console.BackgroundColor = ConsoleColor.Blue;
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("civa ");
}
Console.ResetColor();


//4

Console.WriteLine("enter age: ");
int age = int.Parse(Console.ReadLine());

if (age <= 12)
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("bavshvi");
    Console.ResetColor();
}
else if (age <= 17)
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("mozardi");
    Console.ResetColor();

}
else if (age <= 64)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("zrdasruli");
    Console.ResetColor();
}
else
{
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("xandazmuli");
    Console.ResetColor();
}


//5

string userName = "admin";
string  password = "12345";

Console.WriteLine("username: ");
string inputUserName = Console.ReadLine();
Console.WriteLine("password: ");
string inputPassword = Console.ReadLine();

if (inputUserName == userName && inputPassword == password)
{
    Console.BackgroundColor = ConsoleColor.Green;
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("warmatebit shexvedit");
    Console.ResetColor();
}
else
{
    Console.BackgroundColor = ConsoleColor.Red;
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("shesvla ver moxerxda");
    Console.ResetColor();
}

//6

Console.WriteLine("shemoiyvane (0-100): ");
int score = int.Parse(Console.ReadLine());

if(score >= 90)
{
    Console.BackgroundColor = ConsoleColor.Green;
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("grade: A");
    Console.ResetColor();
}
else if (score >= 80)
{
    Console.BackgroundColor = ConsoleColor.Yellow;
    Console.ForegroundColor = ConsoleColor.Black;
    Console.WriteLine("grade: B");
    Console.ResetColor();
}
else if (score >= 70)
{
    Console.BackgroundColor = ConsoleColor.Cyan;
    Console.ForegroundColor = ConsoleColor.Black;
    Console.WriteLine("grade: C");
    Console.ResetColor();
}
else if (score >= 60)
{
    Console.BackgroundColor = ConsoleColor.Magenta;
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("grade: D");
    Console.ResetColor();
}
else
{
    Console.BackgroundColor = ConsoleColor.Red;
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("grade: F");
    Console.ResetColor();
}


//7
Console.WriteLine("shemoiyvane  produqtis fasi: ");
int price = int.Parse(Console.ReadLine());

int discount = 0;

if(price > 100)
{
    discount = price / 10 * 2;
}
else if(price >= 50)
{
    discount = price / 10;
}
int finalPrice = price - discount;

Console.WriteLine($"start price: {price} lari");
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine($"fasdakleba: {discount} lari");
Console.ResetColor();

Console.ForegroundColor = ConsoleColor.Green;
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine($"final price: {finalPrice} lari");
Console.ResetColor();

//8
Console.WriteLine("shemoiyvane lari: ");
int gel = int.Parse(Console.ReadLine());

int usd = gel / 3;
int eur = gel / 3;

Console.BackgroundColor = ConsoleColor.Green;
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine($"{gel} GEL = {usd} USD 💵");
Console.ResetColor();

Console.BackgroundColor = ConsoleColor.Blue;
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine($"{gel} GEL = {eur} EUR 💶");
Console.ResetColor();


//9
Console.WriteLine("shemoiyvanet saati (0-23)");
int hour = int.Parse(Console.ReadLine());
if (hour >= 6 && hour <= 11)
{
    Console.BackgroundColor = ConsoleColor.Yellow;
    Console.ForegroundColor = ConsoleColor.Black;
    Console.WriteLine("dila mshvidobisa");
    Console.ResetColor();
}
else if (hour >= 12 && hour <= 17)
{
    Console.BackgroundColor = ConsoleColor.Cyan;
    Console.ForegroundColor = ConsoleColor.Black;
    Console.WriteLine("mogesalmebit");
    Console.ResetColor();
}
else if (hour >= 18 && hour <= 21)
{
    Console.BackgroundColor = ConsoleColor.Magenta;
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("sagamo mshvidobisa");
    Console.ResetColor();
}
else
{
    Console.BackgroundColor = ConsoleColor.DarkBlue;
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("game mshvidobisa");
    Console.ResetColor();
}


//10

Console.WriteLine("product name:");
string productName = Console.ReadLine();

Console.WriteLine("unit price");
int unitPrice = int.Parse(Console.ReadLine());

Console.WriteLine("quantity");
int quantity = int.Parse(Console.ReadLine());

int totalPrice = unitPrice * quantity;

Console.WriteLine();
Console.WriteLine("==============RECEPT=============");
Console.WriteLine($"Product:  {productName}");
Console.WriteLine($"Price:    {unitPrice} GEL");
Console.WriteLine($"Quantity: {quantity}");
Console.WriteLine("=================================");
Console.WriteLine($"Total:    {totalPrice} GEL");

if(totalPrice > 100)
{
    Console.BackgroundColor = ConsoleColor.Green;
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("madloba shedzenistvis");
    Console.ResetColor();
}
else
{
    Console.BackgroundColor = ConsoleColor.Red;
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("madloba shedzenistvis");
    Console.ResetColor();
}
