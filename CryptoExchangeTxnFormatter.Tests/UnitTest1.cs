using System;
using System.IO;
using System.Linq;
using CrytpoExchangeTxnFormatter.Application;
using Xunit;

namespace CryptoExchangeTxnFormatter.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            var source = File.OpenRead(@"C:\Users\kherr\Downloads\transaction_history.xlsx");

            var target = new GeminiTransactionReader().Read(source).ToArray();

            Assert.Equal(11, target.Length);

            var head = target.First();

            Assert.Equal(new DateTimeOffset(2018, 1, 21, 20, 57, 44, 785, TimeSpan.Zero), head.Timestamp);
            Assert.Equal("USD", head.DebitType);
            Assert.Equal(new decimal(-497.93), head.DebitAmount);
            Assert.Equal("ETH", head.CreditType);
            Assert.Equal(new decimal(.493), head.CreditAmount);
            Assert.Equal("USD", head.FeeType);
            Assert.Equal(new decimal(-1.244825), head.FeeAmount);
        }
    }
}
