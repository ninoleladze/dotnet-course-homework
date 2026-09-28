using LINQ_sum;

MusicAlbums musicAlbums = new MusicAlbums();

while (true)
{
    Console.WriteLine("music albums");
    Console.WriteLine("");
    Console.WriteLine("1. Add Album");
    Console.WriteLine("2. Delete Album");
    Console.WriteLine("3. Update Album");
    Console.WriteLine("4. Search Album");
    Console.WriteLine("5. Display Albums");
    Console.WriteLine("6. Get Album By Id");
    Console.WriteLine("7. Filter Albums By Year");
    Console.WriteLine("8. Filter Albums By Genre");
    Console.WriteLine("9. Filter Albums By Genre And Year");
    Console.WriteLine("10. Filter Albums By Band Name");
    Console.WriteLine("11. Exit");
    Console.Write("Enter your choice: ");
    string choice = Console.ReadLine();
    try
    {
        switch (choice)
        {
            case "1":
                Console.Clear();
                musicAlbums.addAlbum();
                break;
            case "2":
                Console.Clear();
                musicAlbums.deleteAlbum();
                break;
            case "3":
                Console.Clear();
                musicAlbums.updateAlbum();
                break;
            case "4":
                Console.Clear();
                musicAlbums.searchAlbum();
                break;
            case "5":
                Console.Clear();
                musicAlbums.displayAlbums();
                break;
            case "6":
                Console.Clear();
                musicAlbums.getAlbumById();
                break;
            case "7":
                Console.Clear();
                musicAlbums.filterAlbumsByYear();
                break;
            case "8":
                Console.Clear();
                musicAlbums.filterAlbumsByGenre();
                break;
            case "9":
                Console.Clear();
                musicAlbums.filterAlbumsByGenreByYear();
                break;
            case "10":
                Console.Clear();
                musicAlbums.filterAlbumsByBandName();
                break;
            case "11":
                Console.Clear();
                return;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
   
}







