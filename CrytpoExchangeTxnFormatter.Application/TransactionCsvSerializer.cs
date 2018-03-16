using System.Collections.Generic;
using System.Text;

namespace CrytpoExchangeTxnFormatter.Application
{
    public class TransactionCsvSerializer
    {
        public string Serialize(IEnumerable<Transaction> transactions)
        {
            var bldr = new StringBuilder();

            bldr.AppendLine("Timestamp,Credit Currency,Credit Amount,Debit Currency,Debit Amount,Fee Currency,Fee Amount,Exchange Rate Currency,Exchange Rate Amount");

            foreach (var t in transactions)
            {
                bldr.AppendLine($"{t.Timestamp:o},{t.Credit.Currency},{t.Credit.Amount},{t.Debit.Currency},{t.Debit.Amount},{t.Fee.Currency},{t.Fee.Amount},{t.ExchangeRate.Currency},{t.ExchangeRate.Amount}");
            }

            return bldr.ToString();
        }
    }
}