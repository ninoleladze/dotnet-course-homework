
namespace MiniBank
{
    public class Transaction
    {
        public decimal Amount;
        public DateTime Date;
        public string From;
        public string To;
        public string Currency;
        public string Status;

        public override string ToString()
        {
            return $"[{Date:yyyy-MM-dd HH:mm}]  {From,-15} -> {To,-15}  {Amount,10:F2} {Currency,-4}  {Status}";
        }
    }
}