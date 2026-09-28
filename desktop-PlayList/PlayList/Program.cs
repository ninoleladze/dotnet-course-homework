namespace music
{
    internal class PlaylistService
    {
        private List<Song> songs = new List<Song>()
        {
            new Song(){Artist="Artist - 1", Title = "Title - 1", Year = 1990},
            new Song(){Artist="Artist - 2", Title = "Title - 2", Year = 1994},
            new Song(){Artist="Artist - 3", Title = "Title - 3", Year = 1996},
            new Song(){Artist="Artist - 4", Title = "Title - 4", Year = 1999},
            new Song(){Artist="Artist - 5", Title = "Title - 5", Year = 1991},
            new Song(){Artist="Artist - 6", Title = "Title - 6", Year = 1997},
            new Song(){Artist="Artist - 7", Title = "Title - 7", Year = 1995},
        };

        public void AddSong(string title, string artist, int year)
        {
            if (title == null || title.Length < 2 || title.Length > 50)
            { throw new Exception("Min Title Length is 2 and max is 50"); }
            if (artist == null || artist.Length < 2 || artist.Length > 50)
            { throw new Exception("Min Artist Length is 2 and max is 50"); }
            if (year < 1000 || year > 2025)
            { throw new Exception("min year is 1000 and max is 2025 "); }

            Song song = new Song()
            {
                Artist = artist,
                Title = title,
                Year = year
            };

            songs.Add(song);
            Console.WriteLine("song added successfully");
        }

        public void PlaySong(int songId)
        {
            Song? found = null;

            foreach (var item in songs)
            {
                if (item.Id == songId)
                {
                    found = item;
                }
            }

            if (found == null)
            {
                throw new Exception("song not found");
            }

            if (found.IsPlaying)
            {
                throw new Exception("song is already playing");
            }
            else
            {
                found.IsPlaying = true;
                Console.WriteLine("song started playing");
            }
        }

        public void StopSong(int songId)
        {
            Song? found = null;

            foreach (var item in songs)
            {
                if (item.Id == songId && item.IsPlaying)
                {
                    found = item;
                }
            }
            if (found == null)
            {
                throw new Exception("NOT FOUND");
            }

            found.IsPlaying = false;
            Console.WriteLine("stopped successfully");
        }

        public void ListAvailableSongs()
        {
            foreach (var song in songs)
            {
                if (!song.IsPlaying)
                {
                    Console.WriteLine(song);
                }
            }
        }

        public void GetUserPlayingSongs()
        {
            foreach (var song in songs)
            {
                if (song.IsPlaying)
                {
                    Console.WriteLine(song);
                }
            }
        }
    }
}