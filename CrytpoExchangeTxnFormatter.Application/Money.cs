using System;
using System.Collections.Generic;

namespace CrytpoExchangeTxnFormatter.Application
{
    public class Money
    {
        public Money(string currency, int amount)
            : this(currency, new decimal(amount))
        {
        }

        public Money(string currency, double amount)
            : this(currency, new decimal(amount))
        {
        }

        public Money(string currency, decimal amount)
        {
            Currency = currency ?? throw new ArgumentNullException(nameof(currency));
            Amount = amount;
        }

        public string Currency { get; }

        public decimal Amount { get; }

        public override bool Equals(object obj)
        {
            return obj is Money money &&
                   Currency == money.Currency &&
                   Amount == money.Amount;
        }

        public override int GetHashCode()
        {
            var hashCode = 621650223;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Currency);
            hashCode = hashCode * -1521134295 + Amount.GetHashCode();
            return hashCode;
        }
    }
}