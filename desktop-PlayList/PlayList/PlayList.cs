using music;

PlaylistService playlist = new PlaylistService();

while (true)
{
    Console.WriteLine("Playlist");
    Console.WriteLine("1. add new song");
    Console.WriteLine("2. play song");
    Console.WriteLine("3. stop song");
    Console.WriteLine("4. list available");
    Console.WriteLine("5. get currently playing");

    Console.WriteLine("enter key :");

    string key = Console.ReadLine();

    if (key == "1")
    {
        Console.Clear();
        try
        {
            Console.WriteLine("enter title:");
            string title = Console.ReadLine();
            Console.WriteLine("enter artist");
            string artist = Console.ReadLine();
            Console.WriteLine("enter year:");
            int year = int.Parse(Console.ReadLine());

            playlist.AddSong(title, artist, year);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

    }
    else if (key == "2")
    {
        Console.Clear();
        try
        {
            playlist.ListAvailableSongs();
            Console.WriteLine("");
            Console.WriteLine("enter songid:");
            int songID = int.Parse(Console.ReadLine());
            playlist.PlaySong(songID);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

    }
    else if (key == "3")
    {
        Console.Clear();
        try
        {
            playlist.GetUserPlayingSongs();
            Console.WriteLine("");
            Console.WriteLine("enter songid:");
            int songID = int.Parse(Console.ReadLine());
            playlist.StopSong(songID);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

    }
    else if (key == "4")
    {
        Console.Clear();
        try
        {
            playlist.ListAvailableSongs();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    else if (key == "5")
    {
        Console.Clear();
        try { playlist.GetUserPlayingSongs(); }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

    }
}