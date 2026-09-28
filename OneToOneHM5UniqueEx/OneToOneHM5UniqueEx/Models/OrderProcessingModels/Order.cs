using OneToOneHM5UniqueEx.Enums.OrderProcessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToOneHM5UniqueEx.Models.OrderProcessingModels
{
    internal class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; }

        public Invoice Invoice { get; set; }

    }
}
