using System.Collections.Generic;
using System.Text;

namespace CrytpoExchangeTxnFormatter.Application
{
    public class TransactionCsvSerializer
    {
        public string Serialize(IEnumerable<Transaction> transactions)
        {
            var bldr = new StringBuilder();

            bldr.AppendLine("Timestamp,Credit Type,Credit Amount,Debit Type,Debit Amount,Fee Type,Fee Amount");

            foreach (var t in transactions)
            {
                bldr.AppendLine($"{t.Timestamp:o},{t.CreditType},{t.CreditAmount},{t.DebitType},{t.DebitAmount},{t.FeeType},{t.FeeAmount}");
            }

            return bldr.ToString();
        }
    }
}