using movie;
using movie.Services;

Baza baza = new Baza();

MovieService movieService = new MovieService();

while (true)
{
    Console.WriteLine("1. Create Movie");
    Console.WriteLine("2. Delete Movie");
    Console.WriteLine("3. Edit Movie");
    Console.WriteLine("4. List Movies");
    Console.WriteLine("5. Exit");
    Console.Write("Select an option: ");
    string choice = Console.ReadLine();

    try
    {
        switch (choice)
        {
            case "1":
                movieService.CreateMovie();
                break;
            case "2":
                movieService.DeleteMovie();
                break;
            case "3":
                movieService.EditMovie();
                break;
            case "4":
                movieService.ShowMovies();
                break;
            case "5":
                return;
            default:
                Console.WriteLine("Invalid option. Please try again.");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }

    Console.WriteLine();
}