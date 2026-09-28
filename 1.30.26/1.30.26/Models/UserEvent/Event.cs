using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._30._26.Models.UserEvent
{
    internal class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public List<UserEvent> UserEvents { get; set; } = new List<UserEvent>();
    }
}
