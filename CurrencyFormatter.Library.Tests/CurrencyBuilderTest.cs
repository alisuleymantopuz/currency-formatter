using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CurrencyFormatter.Library.Tests
{
    [TestClass]
    public class CurrencyBuilderTest
    {
        [TestMethod]
        public void Test_Currency()
        {
            var currencyBuilder = new CurrencyBuilder("'", ",", "CHF", "de-CH", 125000000000);

            var result = currencyBuilder.Currency; 
        }
    }
}
