using OneToOneHM5UniqueEx.Enums.HotelManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToOneHM5UniqueEx.Models.HotelManagementModels
{
    internal class HotelRoom
    {
        public int HotelRoomId { get; set; }
        public string RoomNumber { get; set; }
        public RoomType Type { get; set; }

        public KeyCard KeyCard { get; set; }

    }
}
