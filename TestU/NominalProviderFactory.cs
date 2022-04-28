using System;
using TestU.Interfaces;
using TestU.Providers;

namespace TestU
{
    public class NominalProviderFactory
    {
        public INominalProvider Create(string name)
        {
            return name.ToUpperInvariant() switch
            {
                "EUR" => new EuroNominalProvider(),
                _ => throw new Exception()
            };
        }
    }
}
