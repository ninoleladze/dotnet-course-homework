using OneToOneHM5UniqueEx.Enums.OrderProcessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToOneHM5UniqueEx.Models.OrderProcessingModels
{
    internal class Invoice
    {
        public int InvoiceId { get; set; }
        public decimal Amount { get; set; }
        public DateTime IssuedAt { get; set; }

        public PaymentStatus PaymentStatus { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

    }
}
