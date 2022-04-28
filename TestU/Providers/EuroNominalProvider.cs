using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TestU.Interfaces;
using TestU.Models;

namespace TestU.Providers
{
    public class EuroNominalProvider : INominalProvider
    {
        public IEnumerable<Banknote> GetNominals()
        {
            var nominals = new [] {0.01m, 0.02m, 0.05m, 0.10m, 0.20m, 0.50m, 1, 2, 5, 10, 20, 50, 100, 200, 500};

            return nominals
                .OrderByDescending(n => n)
                .Select(n => new Banknote(n, GetName(n)));
        }

        private static string GetName(decimal value)
        {
            return value >= 1 ? GetMajorName(value) : GetMinorName(value);
        }
        
        private static string GetMajorName(decimal value)
        {
            return value.ToString(CultureInfo.InvariantCulture);
        }

        private static string GetMinorName(decimal value)
        {
            value *= 100;
            return $"{value:N0} ct";
        }
    }
}
