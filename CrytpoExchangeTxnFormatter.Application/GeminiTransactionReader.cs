using System;
using System.Collections.Generic;
using System.IO;
using ExcelDataReader;

namespace CrytpoExchangeTxnFormatter.Application
{
    public class GeminiTransactionReader
    {
        public IEnumerable<Transaction> Read(Stream source)
        {
            using (var reader = ExcelReaderFactory.CreateReader(source))
            {
                if (reader.Name != "Account History")
                {
                    throw new Exception($"Expected sheet name 'Account History', but got '{reader.Name}'.");
                }

                reader.Read();

                var header = ReadHeader(reader);

                while (reader.Read())
                {
                    switch (reader.GetString(header["Type"]))
                    {
                        case "Buy":
                            yield return FromBuy(header, reader);
                            break;
                    }
                }
            }
        }

        private Transaction FromBuy(Dictionary<string, int> header, IExcelDataReader reader)
        {
            return new Transaction
            {
                Timestamp = DateTime.SpecifyKind(reader.GetDateTime(header["Time (UTC)"]), DateTimeKind.Utc),
                DebitType = "USD",
                DebitAmount = new decimal(reader.GetDouble(header["USD Amount"])),
                CreditType = "ETH",
                CreditAmount = new decimal(reader.GetDouble(header["ETH Amount"])),
                FeeType = "USD",
                FeeAmount = new decimal(reader.GetDouble(header["Trading Fee (USD)"])),
            };
        }

        private Dictionary<string, int> ReadHeader(IExcelDataReader rdr)
        {
            var header = new Dictionary<string, int>();

            for (var i = 0; i < rdr.FieldCount; i++)
            {
                header.Add(rdr.GetString(i), i);
            }

            return header;
        }
    }
}