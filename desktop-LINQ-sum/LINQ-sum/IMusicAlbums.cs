using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_sum
{
    internal interface IMusicAlbums
    {
        void addAlbum();
        void deleteAlbum();
        void updateAlbum();
        void searchAlbum();
        void displayAlbums();
        void getAlbumById();
        void filterAlbumsByYear();
        void filterAlbumsByGenre();
        void filterAlbumsByGenreByYear();
        void filterAlbumsByBandName();
        

    }
}
