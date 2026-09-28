using _06._10._26_DI2.Helpers;
using _06._10._26_DI2.Models;
using _06._10._26_DI2.Services;

List<LibraryBook> books = new List<LibraryBook>()
{
    new LibraryBook { Title = "Clean Code",       Author = "Robert Martin",  Genre = "Tech",     Pages = 431, PublishedYear = 2008, IsAvailable = true  },
    new LibraryBook { Title = "1984",             Author = "George Orwell",  Genre = "Fiction",  Pages = 328, PublishedYear = 1949, IsAvailable = false },
    new LibraryBook { Title = "Dune",             Author = "Frank Herbert",  Genre = "Sci-Fi",   Pages = 688, PublishedYear = 1965, IsAvailable = true  },
    new LibraryBook { Title = "Atomic Habits",    Author = "James Clear",    Genre = "Self-Help",Pages = 320, PublishedYear = 2018, IsAvailable = true  },
    new LibraryBook { Title = "The Hobbit",       Author = "J.R.R. Tolkien", Genre = "Fantasy",  Pages = 310, PublishedYear = 1937, IsAvailable = false },
    new LibraryBook { Title = "Deep Work",        Author = "Cal Newport",    Genre = "Self-Help",Pages = 296, PublishedYear = 2016, IsAvailable = true  },
    new LibraryBook { Title = "Project Hail Mary",Author = "Andy Weir",      Genre = "Sci-Fi",   Pages = 476, PublishedYear = 2021, IsAvailable = true  },
    new LibraryBook { Title = "Sapiens",          Author = "Yuval Harari",   Genre = "History",  Pages = 443, PublishedYear = 2011, IsAvailable = false },
};

List<Car> cars = new List<Car>()
{
    new Car { Brand = "Toyota",  Model = "Camry",      Year = 2022, Price = 26000, MaxSpeedKmh = 180, IsNew = true  },
    new Car { Brand = "BMW",     Model = "M3",         Year = 2023, Price = 75000, MaxSpeedKmh = 290, IsNew = true  },
    new Car { Brand = "Ford",    Model = "Mustang",    Year = 2019, Price = 35000, MaxSpeedKmh = 250, IsNew = false },
    new Car { Brand = "Tesla",   Model = "Model S",    Year = 2023, Price = 90000, MaxSpeedKmh = 250, IsNew = true  },
    new Car { Brand = "Honda",   Model = "Civic",      Year = 2020, Price = 22000, MaxSpeedKmh = 185, IsNew = false },
    new Car { Brand = "Porsche", Model = "911",        Year = 2022, Price = 120000,MaxSpeedKmh = 310, IsNew = true  },
    new Car { Brand = "Toyota",  Model = "Corolla",    Year = 2018, Price = 18000, MaxSpeedKmh = 175, IsNew = false },
    new Car { Brand = "BMW",     Model = "X5",         Year = 2021, Price = 65000, MaxSpeedKmh = 240, IsNew = false },
};

List<Student> students = new List<Student>()
{
    new Student { Name = "Alice",   Faculty = "Computer Science", GPA = 3.9,  Age = 20, IsActive = true  },
    new Student { Name = "Bob",     Faculty = "Mathematics",      GPA = 2.7,  Age = 22, IsActive = false },
    new Student { Name = "Carol",   Faculty = "Computer Science", GPA = 3.5,  Age = 21, IsActive = true  },
    new Student { Name = "David",   Faculty = "Physics",          GPA = 1.8,  Age = 23, IsActive = false },
    new Student { Name = "Emma",    Faculty = "Mathematics",      GPA = 4.0,  Age = 20, IsActive = true  },
    new Student { Name = "Frank",   Faculty = "Physics",          GPA = 3.1,  Age = 24, IsActive = true  },
    new Student { Name = "Grace",   Faculty = "Computer Science", GPA = 3.7,  Age = 19, IsActive = true  },
    new Student { Name = "Henry",   Faculty = "Mathematics",      GPA = 2.4,  Age = 21, IsActive = false },
};

bool IS_APP_RUNNING = true;
MenuHelper menuHelper = new MenuHelper();
LibraryService libraryService = new LibraryService();
CarService carService = new CarService();
StudentService studentService = new StudentService();

while (IS_APP_RUNNING)
{
    menuHelper.ShowMenu();
    string archevani = menuHelper.AskUser();

    switch (archevani)
    {
        case "1":
            Console.Clear();
            libraryService.ShowAllBooks(books);
            menuHelper.Wait();
            break;
        case "2":
            Console.Clear();
            libraryService.ShowAvailableBooks(books);
            menuHelper.Wait();
            break;
        case "3":
            Console.Clear();
            libraryService.SearchByGenre(books);
            menuHelper.Wait();
            break;
        case "4":
            Console.Clear();
            libraryService.ShowBooksSortedByPages(books);
            menuHelper.Wait();
            break;
        case "5":
            Console.Clear();
            libraryService.ShowBooksPublishedAfter2000(books);
            menuHelper.Wait();
            break;
        case "6":
            Console.Clear();
            carService.ShowAllCars(cars);
            menuHelper.Wait();
            break;
        case "7":
            Console.Clear();
            carService.ShowNewCars(cars);
            menuHelper.Wait();
            break;
        case "8":
            Console.Clear();
            carService.ShowCarsSortedByPrice(cars);
            menuHelper.Wait();
            break;
        case "9":
            Console.Clear();
            carService.SearchByBrand(cars);
            menuHelper.Wait();
            break;
        case "10":
            Console.Clear();
            carService.ShowFastCars(cars);
            menuHelper.Wait();
            break;
        case "11":
            Console.Clear();
            studentService.ShowAllStudents(students);
            menuHelper.Wait();
            break;
        case "12":
            Console.Clear();
            studentService.ShowStudentsSortedByGPADescending(students);
            menuHelper.Wait();
            break;
        case "13":
            Console.Clear();
            studentService.ShowActiveStudents(students);
            menuHelper.Wait();
            break;
        case "14":
            Console.Clear();
            studentService.SearchByFaculty(students);
            menuHelper.Wait();
            break;
        case "15":
            Console.Clear();
            studentService.ShowHighAchievers(students);
            menuHelper.Wait();
            break;
        case "0":
            Console.Clear();
            Console.WriteLine("Goodbye!");
            IS_APP_RUNNING = false;
            break;
        default:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid option. Please try again.");
            Console.ResetColor();
            menuHelper.Wait();
            break;
    }
}