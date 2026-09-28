//1
Console.WriteLine("shemoiyvanet saxeli: ");
string name = Console.ReadLine();

Console.WriteLine("airchie zoma (1=patara, 2=sashualo, 3=didi): ");
int size = int.Parse(Console.ReadLine());

if (size == 1)
{
    Console.BackgroundColor = ConsoleColor.Green;
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine($"{name}, sheni patara pica girs 15 lari");
    Console.ResetColor();
}
else if (size == 2)
{
    Console.BackgroundColor = ConsoleColor.Yellow;
    Console.ForegroundColor = ConsoleColor.Black;
    Console.WriteLine($"{name}, sheni sashualo pica girs 25 lari");
    Console.ResetColor();
}
else if (size == 3)
{
    Console.BackgroundColor = ConsoleColor.Magenta;
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine($"{name}, sheni didi pica girs 35 lari");
    Console.ResetColor();
}
else
{
    Console.BackgroundColor = ConsoleColor.Red;
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("araswori zoma");
    Console.ResetColor();
}


//2
Console.WriteLine("shemoiyvanet litrebis raodenoba: ");
int liters = int.Parse(Console.ReadLine());

Console.WriteLine("airchie sacavi (1=regulari, 2=premium, 3=dizeli): ");
int fuel = int.Parse(Console.ReadLine());

int pricePerLiter = 0;
string fuelName = "";

if (fuel == 1)
{
    pricePerLiter = 3;
    fuelName = "regulari";
}
else if (fuel == 2)
{
    pricePerLiter = 4;
    fuelName = "premium";
}
else if (fuel == 3)
{
    pricePerLiter = 3;
    fuelName = "dizeli";
}

int total = liters * pricePerLiter;

Console.BackgroundColor = ConsoleColor.Blue;
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("==========CHEKI==========");
Console.ResetColor();

Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine($"sacavi: {fuelName}");
Console.WriteLine($"litri: {liters}");
Console.WriteLine($"fasi/litri: {pricePerLiter} lari");
Console.ResetColor();

Console.BackgroundColor = ConsoleColor.Yellow;
Console.ForegroundColor = ConsoleColor.Black;
Console.WriteLine($"jami: {total} lari");
Console.ResetColor();


//3
Console.WriteLine("shemoiyvane qula: ");
int score = int.Parse(Console.ReadLine());

if (score >= 0 && score <= 100)
{
    Console.BackgroundColor = ConsoleColor.DarkYellow;
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine($"qula: {score} - Beginner");
    Console.ResetColor();
}
else if (score >= 101 && score <= 500)
{
    Console.BackgroundColor = ConsoleColor.Gray;
    Console.ForegroundColor = ConsoleColor.Black;
    Console.WriteLine($"qula: {score} - Intermediate");
    Console.ResetColor();
}
else if (score >= 501 && score <= 1000)
{
    Console.BackgroundColor = ConsoleColor.Yellow;
    Console.ForegroundColor = ConsoleColor.Black;
    Console.WriteLine($"qula: {score} - Pro");
    Console.ResetColor();
}
else if (score > 1000)
{
    Console.BackgroundColor = ConsoleColor.Magenta;
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine($"qula: {score} - Legend");
    Console.ResetColor();
}


//4
Console.WriteLine("shemoiyvanet asaki: ");
int age = int.Parse(Console.ReadLine());

Console.WriteLine("shemoiyvanet dge (1-7): ");
int day = int.Parse(Console.ReadLine());

int ticketPrice = 0;

if (age <= 12)
{
    ticketPrice = 5;
}
else if (age <= 64)
{
    ticketPrice = 15;
}
else
{
    ticketPrice = 7;
}

if (day == 1 || day == 2)
{
    ticketPrice = ticketPrice - ticketPrice * 30 / 100;
}

Console.BackgroundColor = ConsoleColor.Yellow;
Console.ForegroundColor = ConsoleColor.Black;
Console.WriteLine($"biletis fasi: {ticketPrice} lari");
Console.ResetColor();


//5
Console.WriteLine("shemoiyvanet qalaqi: ");
string city = Console.ReadLine();

Console.WriteLine("shemoiyvanet dgeebis raodenoba: ");
int days = int.Parse(Console.ReadLine());

int budgetPerDay = 200;

if (city == "Tbilisi")
{
    budgetPerDay = 100;
}
else if (city == "Paris")
{
    budgetPerDay = 400;
}
else if (city == "Tokyo")
{
    budgetPerDay = 500;
}

int totalBudget = budgetPerDay * days;

Console.BackgroundColor = ConsoleColor.Cyan;
Console.ForegroundColor = ConsoleColor.Black;
Console.WriteLine("======mogzaurobis gegma======");
Console.ResetColor();

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine($"qalaqi: {city}");
Console.WriteLine($"dgeebi: {days}");
Console.WriteLine($"budgeti dgeshi: {budgetPerDay} lari");
Console.ResetColor();

Console.BackgroundColor = ConsoleColor.Yellow;
Console.ForegroundColor = ConsoleColor.Black;
Console.WriteLine($"jamuri budgeti: {totalBudget} lari");
Console.ResetColor();


//6
Console.WriteLine("ramdeni burgeri (10 lari): ");
int burgers = int.Parse(Console.ReadLine());

Console.WriteLine("ramdeni kartopili (5 lari): ");
int fries = int.Parse(Console.ReadLine());

Console.WriteLine("ramdeni sasmeli (3 lari): ");
int drinks = int.Parse(Console.ReadLine());

int totalFood = burgers * 10 + fries * 5 + drinks * 3;

Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine($"burgeri x{burgers} = {burgers * 10} lari");
Console.WriteLine($"kartopili x{fries} = {fries * 5} lari");
Console.WriteLine($"sasmeli x{drinks} = {drinks * 3} lari");
Console.ResetColor();

Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine($"jami: {totalFood} lari");
Console.ResetColor();

if (totalFood > 100)
{
    Console.BackgroundColor = ConsoleColor.DarkYellow;
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("upaso mitana + uposo deserti");
    Console.ResetColor();
}
else if (totalFood > 50)
{
    Console.BackgroundColor = ConsoleColor.Green;
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("uposo deserti");
    Console.ResetColor();
}


//7
Console.WriteLine("shemoiyvanet pacientis saxeli: ");
string patient = Console.ReadLine();

Console.WriteLine("shemoiyvanet temperatura: ");
double temperature = double.Parse(Console.ReadLine());

Console.WriteLine("xvela aqvs (1=ki, 0=ara): ");
int cough = int.Parse(Console.ReadLine());

Console.WriteLine($"pacienti: {patient}");

if (temperature > 38)
{
    if (cough == 1)
    {
        Console.BackgroundColor = ConsoleColor.Red;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("diagnozi: gripi");
        Console.ResetColor();
    }
    else
    {
        Console.BackgroundColor = ConsoleColor.Yellow;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine("diagnozi: cxeleba");
        Console.ResetColor();
    }
}
else
{
    if (cough == 1)
    {
        Console.BackgroundColor = ConsoleColor.Cyan;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine("diagnozi: gacieba");
        Console.ResetColor();
    }
    else
    {
        Console.BackgroundColor = ConsoleColor.Green;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("diagnozi: janmrtelia");
        Console.ResetColor();
    }
}


//8
Console.WriteLine("airchie wevroba (1=tviuri, 2=kvartaluri, 3=wliuri): ");
int membership = int.Parse(Console.ReadLine());

Console.WriteLine("shemoiyvane asaki: ");
int gymAge = int.Parse(Console.ReadLine());

int gymPrice = 0;

if (membership == 1)
{
    gymPrice = 80;
}
else if (membership == 2)
{
    gymPrice = 200;
}
else if (membership == 3)
{
    gymPrice = 700;
}

if (gymAge >= 18 && gymAge <= 25)
{
    gymPrice = gymPrice - gymPrice * 20 / 100;
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("studenturi fasdakleba 20%");
    Console.ResetColor();
}
else if (gymAge >= 65)
{
    gymPrice = gymPrice - gymPrice * 30 / 100;
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("pensionerta fasdakleba 30%");
    Console.ResetColor();
}

Console.BackgroundColor = ConsoleColor.Magenta;
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine($"saboloo fasi: {gymPrice} lari");
Console.ResetColor();


//9
Console.WriteLine("ramdeni km gaiare: ");
int km = int.Parse(Console.ReadLine());

Console.WriteLine("dro (1=dge, 2=game): ");
int time = int.Parse(Console.ReadLine());

int kmPrice = 0;
string timeName = "";

if (time == 1)
{
    kmPrice = 1;
    timeName = "dge";
}
else if (time == 2)
{
    kmPrice = 2;
    timeName = "game";
}

int startFee = 3;
int tripFee = km * kmPrice;
int taxiTotal = startFee + tripFee;

if (km > 50)
{
    taxiTotal = taxiTotal - taxiTotal * 10 / 100;
}

Console.BackgroundColor = ConsoleColor.DarkYellow;
Console.ForegroundColor = ConsoleColor.Black;
Console.WriteLine("==========taxi==========");
Console.ResetColor();

Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine($"manzili: {km} km");
Console.WriteLine($"dro: {timeName}");
Console.WriteLine($"dajdoma: {startFee} lari");
Console.WriteLine($"mgzavroba: {tripFee} lari");
Console.ResetColor();

Console.BackgroundColor = ConsoleColor.Yellow;
Console.ForegroundColor = ConsoleColor.Black;
Console.WriteLine($"jami: {taxiTotal} lari");
Console.ResetColor();


//10
Console.WriteLine("shemoiyvane saxeli: ");
string birthName = Console.ReadLine();

Console.WriteLine("shemoiyvane dabadebis weli: ");
int birthYear = int.Parse(Console.ReadLine());

Console.WriteLine("shemoiyvane mimdinare weli: ");
int currentYear = int.Parse(Console.ReadLine());

int userAge = currentYear - birthYear;

if (userAge == 18)
{
    Console.BackgroundColor = ConsoleColor.Green;
    Console.ForegroundColor = ConsoleColor.Black;
    Console.WriteLine($"{birthName}, oficialurad zrdasruli xar!");
    Console.ResetColor();
}
else if (userAge == 16)
{
    Console.BackgroundColor = ConsoleColor.Cyan;
    Console.ForegroundColor = ConsoleColor.Black;
    Console.WriteLine($"{birthName}, martvis uplebis ageba shegidzlia!");
    Console.ResetColor();
}
else if (userAge == 21)
{
    Console.BackgroundColor = ConsoleColor.DarkYellow;
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine($"{birthName}, srulad zrdasruli");
    Console.ResetColor();
}
else
{
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine($"gilocav {userAge} wlis iubiles, {birthName}!");
    Console.ResetColor();
}
