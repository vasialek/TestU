using System.Globalization;
using TestU.Interfaces;

namespace TestU.Services
{
    public class BanknoteNameService : IBanknoteNameService
    {
        public string GetName(decimal money)
        {
            return money >= 1 ? GetMajorName(money) : GetMinorName(money);
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
