using OneToOneHM5UniqueEx.Enums.HotelManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToOneHM5UniqueEx.Models.HotelManagementModels
{
    internal class KeyCard
    {
        public int KeyCardId { get; set; }
        public string CardCode { get; set; }
        public DateTime IssuedAt { get; set; }

        public CardStatus Status { get; set; }

        public int HotelRoomId { get; set; }
        public HotelRoom Room { get; set; }


    }
}
