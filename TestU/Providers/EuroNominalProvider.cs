using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TestU.Interfaces;
using TestU.Models;

namespace TestU.Providers
{
    public class EuroNominalProvider : INominalProvider
    {
        private static readonly decimal[] Nominals = new[] { 0.01m, 0.02m, 0.05m, 0.10m, 0.20m, 0.50m, 1, 2, 5, 10, 20, 50, 100, 200, 500 };

        private readonly IBanknoteNameService _banknoteNameService;

        public EuroNominalProvider(IBanknoteNameService banknoteNameService)
        {
            _banknoteNameService = banknoteNameService;
        }

        public IEnumerable<Banknote> GetNominals()
        {
            return Nominals
                .OrderByDescending(n => n)
                .Select(n => new Banknote(n, GetName(n)));
        }

        private string GetName(decimal value)
        {
            return _banknoteNameService.GetName(value);
        }
    }
}
