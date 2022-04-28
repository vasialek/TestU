using System;
using System.Collections.Generic;
using TestU.Interfaces;

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
            var result = new Dictionary<string, int>();

            foreach (var banknote in _nominalProvider.GetNominals())
            {
                var count = (int)(money / banknote.Value);
                if (count > 0)
                {
                    result.Add(banknote.Name, count);
                }

                money -= count * banknote.Value;
            }

            return result;
        }
    }

    public class AtmResult
    {
    }
}
