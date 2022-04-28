using System.Collections.Generic;
using TestU.Models;

namespace TestU.Interfaces
{
    public interface INominalProvider
    {
        IEnumerable<Banknote> GetNominals();
    }
}
