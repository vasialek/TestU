using System;
using System.Collections.Generic;
using TestU.Interfaces;
using TestU.Models;

namespace TestU.Services
{
    public class AtmService
    {
        private readonly INominalProvider _nominalProvider;

        public AtmService(INominalProvider nominalProvider)
        {
            _nominalProvider = nominalProvider;
        }

        public Dictionary<string, int> Exchange(decimal money)
        {
            var reminder = money;
            var result = new Dictionary<string, int>();

            foreach (var banknote in _nominalProvider.GetNominals())
            {
                var requested = CalculateBanknoteCount(reminder, banknote);

                if (requested > 0)
                {
                    result.Add(banknote.Name, requested);
                    reminder -= requested * banknote.Value;
                }
            }

            return reminder != 0
                ? throw new Exception($"ATM could not exchange {money}, reminder is {reminder}.")
                : result;
        }

        private static int CalculateBanknoteCount(decimal money, Banknote banknote)
        {
            var requested = (int)(money / banknote.Value);
            return (requested > banknote.Available) ? banknote.Available : requested;
        }
    }
}
