using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyFormatter.Library
{
    public class CurrencyBuilder
    {
        public string CurrencyGroupSeperator { get; set; }
        public string CurrencyDecimalSeperator { get; set; }
        public string CurrencySymbol { get; set; }
        public string CultureCode { get; set; }
        public decimal? Amount { get; set; }
        
        public CurrencyBuilder()
        {

        }

        public CurrencyBuilder(string currencyGroupSeperator, string currencyDecimalSeperator, string currencySymbol, string cultureCode, decimal amount)
        {
            CurrencyGroupSeperator = currencyGroupSeperator;
            CurrencyDecimalSeperator = currencyDecimalSeperator;
            CurrencySymbol = currencySymbol;
            CultureCode = cultureCode;
            Amount = amount;
        }

        public string Currency
        {
            get
            {
                if (!this.Amount.HasValue)
                    return string.Empty;

                var culture = new CultureInfo(CultureCode, false);

                var numberFormatInfo = (NumberFormatInfo)culture.NumberFormat.Clone();

                if (!string.IsNullOrEmpty(this.CurrencyGroupSeperator))
                {
                    numberFormatInfo.CurrencyGroupSeparator = this.CurrencyGroupSeperator;
                }

                if (!string.IsNullOrEmpty(this.CurrencyDecimalSeperator))
                {
                    numberFormatInfo.CurrencyDecimalSeparator = this.CurrencyDecimalSeperator;
                }

                if (!string.IsNullOrEmpty(this.CurrencySymbol))
                {
                    numberFormatInfo.CurrencySymbol = this.CurrencySymbol;
                }


                return Amount.Value.ToString("C", numberFormatInfo);
            }
        }
    }
}
