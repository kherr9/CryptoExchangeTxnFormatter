using System;

namespace CrytpoExchangeTxnFormatter.Application
{
    public class Transaction
    {
        public DateTimeOffset Timestamp { get; set; }

        public string DebitType { get; set; }

        public decimal DebitAmount { get; set; }

        public string CreditType { get; set; }

        public decimal CreditAmount { get; set; }

        public string FeeType { get; set; }

        public decimal FeeAmount { get; set; }
    }
}