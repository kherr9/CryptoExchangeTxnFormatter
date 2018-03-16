using System;
using System.Collections.Generic;
using System.IO;
using ExcelDataReader;

namespace CrytpoExchangeTxnFormatter.Application
{
    public class Transaction
    {
        public DateTimeOffset Timestamp { get; set; }
    }

    public class GeminiService
    {
        public IEnumerable<Transaction> Convert(Stream source)
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
                Timestamp = DateTime.SpecifyKind(reader.GetDateTime(header["Time (UTC)"]), DateTimeKind.Utc)
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