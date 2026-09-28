using _06._03._26_DI;


//es mocemuli davaleba :DDD

List<Car> cars = new List<Car>()
        {
            new Car(){ Brand="Toyota", Model="Corolla", Year=2018, Price=25000, Mileage=60000, FuelType="Petrol", Color="White"},
            new Car(){ Brand="BMW", Model="X5", Year=2022, Price=95000, Mileage=15000, FuelType="Diesel", Color="Black"},
            new Car(){ Brand="Tesla", Model="Model 3", Year=2023, Price=120000, Mileage=5000, FuelType="Electric", Color="Blue"},
            new Car(){ Brand="Mercedes", Model="C-Class", Year=2020, Price=70000, Mileage=30000, FuelType="Petrol", Color="Silver"},
            new Car(){ Brand="Hyundai", Model="Elantra", Year=2019, Price=28000, Mileage=40000, FuelType="Hybrid", Color="Red"}
        };

while (true)
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("╔══════════════════════════════════════════════════════════════╗");
    Console.WriteLine("║                     CAR DEALERSHIP MENU                      ║");
    Console.WriteLine("╚══════════════════════════════════════════════════════════════╝");
    Console.ResetColor();

    Console.WriteLine("  [1] Show all cars            [10] Released after year");
    Console.WriteLine("  [2] Price limit search       [11] Electric car check");
    Console.WriteLine("  [3] Brand search             [12] Budget check (<100k)");
    Console.WriteLine("  [4] Fuel type search         [13] Sort by Price (Asc)");
    Console.WriteLine("  [5] Cheapest car             [14] Sort by Year (Desc)");
    Console.WriteLine("  [6] Most expensive car       [15] Top 3 newest cars");
    Console.WriteLine("  [7] Lowest mileage           [16] Price range search");
    Console.WriteLine("  [8] Average price            [17] Unique brands count");
    Console.WriteLine("  [9] Total dealership value");
    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine("  [0] Exit");
    Console.ResetColor();
    Console.WriteLine("────────────────────────────────────────────────────────────────");

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write(" Choose option: ");
    Console.ResetColor();

    if (!int.TryParse(Console.ReadLine(), out int choice))
    {
        ShowError("Invalid input! Please enter a number.");
        continue;
    }

    if (choice == 0) break;

    Console.WriteLine();

    switch (choice)
    {
        case 1:
            PrintHeader();
            foreach (var car in cars) PrintCar(car);
            break;

        case 2:
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Enter price limit: ");
            Console.ResetColor();
            double priceLimit = double.Parse(Console.ReadLine());
            var cheapCars = cars.Where(c => c.Price < priceLimit).ToList();

            if (cheapCars.Any())
            {
                PrintHeader();
                cheapCars.ForEach(PrintCar);
            }
            else ShowError("No cars found under this price.");
            break;

        case 3:
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Enter brand: ");
            Console.ResetColor();
            string brand = Console.ReadLine();
            var brandCars = cars.Where(c => c.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase)).ToList();

            if (brandCars.Any())
            {
                PrintHeader();
                brandCars.ForEach(PrintCar);
            }
            else ShowError("No cars found for this brand.");
            break;

        case 4:
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Enter fuel type: ");
            Console.ResetColor();
            string fuel = Console.ReadLine();
            var fuelCars = cars.Where(c => c.FuelType.Equals(fuel, StringComparison.OrdinalIgnoreCase)).ToList();

            if (fuelCars.Any())
            {
                PrintHeader();
                fuelCars.ForEach(PrintCar);
            }
            else ShowError("No cars found for this fuel type.");
            break;

        case 5: 
            var cheapest = cars.MinBy(c => c.Price);
            if (cheapest != null)
            {
                PrintHeader();
                PrintCar(cheapest);
            }
            else ShowError("List is empty.");
            break;

        case 6: 
            var mostExpensive = cars.MaxBy(c => c.Price);
            if (mostExpensive != null)
            {
                PrintHeader();
                PrintCar(mostExpensive);
            }
            else ShowError("List is empty.");
            break;

        case 7: 
            var lowestMileage = cars.MinBy(c => c.Mileage);
            if (lowestMileage != null)
            {
                PrintHeader();
                PrintCar(lowestMileage);
            }
            else ShowError("List is empty.");
            break;

        case 8:
            ShowSuccess($"Average price: {cars.Average(c => c.Price):N0} GEL");
            break;

        case 9:
            ShowSuccess($"Total dealership value: {cars.Sum(c => c.Price):N0} GEL");
            break;

        case 10:
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Enter year: ");
            Console.ResetColor();
            int year = int.Parse(Console.ReadLine());
            int count = cars.Count(c => c.Year > year);
            ShowSuccess($"{count} cars released after {year}.");
            break;

        case 11:
            if (cars.Any(c => c.FuelType == "Electric"))
                ShowSuccess("There is an electric car.");
            else
                ShowError("No electric cars found.");
            break;

        case 12:
            if (cars.All(c => c.Price < 100000))
                ShowSuccess("All cars are cheaper than 100000.");
            else
                ShowError("There are cars more expensive than 100000.");
            break;

        case 13:
            PrintHeader();
            var orderedByPrice = cars.OrderBy(c => c.Price).ToList();
            orderedByPrice.ForEach(PrintCar);
            break;

        case 14:
            PrintHeader();
            var orderedByYear = cars.OrderByDescending(c => c.Year).ToList();
            orderedByYear.ForEach(PrintCar);
            break;

        case 15:
            PrintHeader();
            var newest3 = cars.OrderByDescending(c => c.Year).Take(3).ToList();
            newest3.ForEach(PrintCar);
            break;

        case 16:
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Enter minimum price: ");
            double minPrice = double.Parse(Console.ReadLine());
            Console.Write("Enter maximum price: ");
            double maxPrice = double.Parse(Console.ReadLine());
            Console.ResetColor();

            var rangeCars = cars.Where(c => c.Price >= minPrice && c.Price <= maxPrice).ToList();

            if (rangeCars.Any())
            {
                PrintHeader();
                rangeCars.ForEach(PrintCar);
            }
            else ShowError("No cars found in this price range.");
            break;

        case 17:
            int uniqueBrandsCount = cars.Select(c => c.Brand).Distinct().Count();
          
            ShowSuccess($"There are {uniqueBrandsCount} distinct car brands in the dealership.");
            break;

        default:
            ShowError("Invalid choice!");
            break;
    }

    Console.WriteLine();
}
    

    static void PrintHeader()
{
    Console.ForegroundColor = ConsoleColor.DarkCyan;
    Console.WriteLine($"{"Brand",-12} | {"Model",-12} | {"Year",-6} | {"Price",14} | {"Mileage",13} | {"Fuel",-10} | {"Color",-10}");
    Console.WriteLine(new string('-', 88));
    Console.ResetColor();
}

static void PrintCar(Car car)
{
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write("{0,-12} | {1,-12} | ", car.Brand, car.Model);

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("{0,-6} | ", car.Year);

    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write("{0,10:N0} GEL | ", car.Price);

    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.Write("{0,10:N0} km | ", car.Mileage);

    Console.ForegroundColor = ConsoleColor.Gray;
    Console.WriteLine("{0,-10} | {1,-10}", car.FuelType, car.Color);

    Console.ResetColor();
}

static void ShowError(string message)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($" {message}");
    Console.ResetColor();
}

static void ShowSuccess(string message)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($" {message}");
    Console.ResetColor();
}





























//klasshi gaketebulia ess

//List<Student> students = new List<Student>() { new Student() { fullName = "Lasha Kakashvili", GPA = 2.0, course = "C#" }, new Student() { fullName = "Luka Giorgadze", GPA = 3.4, course = "Angular" }, new Student() { fullName = "Nino Beridze", GPA = 3.8, course = "C#" }, new Student() { fullName = "Giorgi Mamaladze", GPA = 2.7, course = "Java" }, new Student() { fullName = "Tamar Kvaratskhelia", GPA = 3.9, course = "React" }, new Student() { fullName = "Davit Tsiklauri", GPA = 3.1, course = "Angular" }, new Student() { fullName = "Mariam Gelashvili", GPA = 3.5, course = "Python" }, new Student() { fullName = "Saba Lomidze", GPA = 2.4, course = "C#" }, new Student() { fullName = "Ana Kapanadze", GPA = 4.0, course = "React" }, new Student() { fullName = "Nika Chkheidze", GPA = 2.9, course = "Java" }, new Student() { fullName = "Salome Maisuradze", GPA = 3.6, course = "Python" }, new Student() { fullName = "Irakli Dolidze", GPA = 3.2, course = "Angular" }, new Student() { fullName = "Elene Tatishvili", GPA = 3.7, course = "C#" }, new Student() { fullName = "Beka Asatiani", GPA = 2.6, course = "Java" }, new Student() { fullName = "Keti Janjghava", GPA = 3.3, course = "React" } };
//List<Student> gpa37 = students.Where(student => student.GPA > 3.7).ToList();

//double averageGPA = students.Average(student => student.GPA);
//double maxGPA = students.Max(student => student.GPA);
//double minGPA = students.Min(student => student.GPA);

//Console.WriteLine($"Average GPA: {averageGPA}");
//Console.WriteLine($"Max GPA: {maxGPA}");
//Console.WriteLine($"Min GPA: {minGPA}");





//Console.WriteLine("SHEMOIYVANE AXALI STUDENTIS SAXELI");
//string fullName = Console.ReadLine();

//Console.WriteLine("SHEMOIYVANE AXALI STUDENTIS GPA:");
//double gpa = double.Parse(Console.ReadLine());

//Console.WriteLine("SHEMOIYVANE AXALI STUDENTIS KURSI:");
//string course = Console.ReadLine();

//Student axaliStudenti = new Student() {

//    fullName = fullName,
//    GPA = gpa,
//    course = course
//};

//students.Add(axaliStudenti);


//for (int i = 0; i < students.Count; i++)
//{
//    Console.WriteLine($"STUDENTI: {students[i].fullName}, GPA: {students[i].GPA}, KURSI: {students[i].course}");
//}










//List<string> userNames = new List<string>() {

//    "Alice",
//    "Bob",
//    "Charlie",
//    "David",
//    "Eve"
//};

//Console.WriteLine("RAMDENI MOMXAREBLIS CHAMATEBA GSURT?");
//int count = int.Parse(Console.ReadLine());


//for (int i = 0; i < count; i++)
//{
//    Console.WriteLine("SHEMOIYVANE SAXELI:");
//    string name = Console.ReadLine();

//    userNames.Add(name);
//}

//Console.Clear();



//for(int i = 0; i < userNames.Count; i++)
//{
//    Console.WriteLine(userNames[i]);
//}



//Console.WriteLine("SABOLOOO SIA:");

//foreach (string user in userNames)
//{
//    Console.WriteLine(user);
//}


