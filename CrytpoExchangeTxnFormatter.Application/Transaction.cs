using System;

namespace CrytpoExchangeTxnFormatter.Application
{
    public class Transaction
    {
        public DateTimeOffset Timestamp { get; set; }

        public Money Debit { get; set; }

        public Money Credit { get; set; }

        public Money Fee { get; set; }

        public Money ExchangeRate => new Money($"{Credit.Currency}/{Debit.Currency}", Math.Abs(Debit.Amount / Credit.Amount));
    }
}