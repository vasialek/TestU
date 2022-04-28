using System;
using TestU.Interfaces;
using TestU.Providers;

namespace TestU
{
    public class NominalProviderFactory
    {
        private readonly IBanknoteNameService _banknoteNameService;

        public NominalProviderFactory(IBanknoteNameService banknoteNameService)
        {
            _banknoteNameService = banknoteNameService;
        }

        public INominalProvider Create(string name)
        {
            return name.ToUpperInvariant() switch
            {
                "EUR" => new EuroNominalProvider(_banknoteNameService),
                _ => throw new Exception($"Can't create Nominal provider for unknown name: {name}")
            };
        }
    }
}
