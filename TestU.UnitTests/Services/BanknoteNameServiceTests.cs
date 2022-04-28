using FluentAssertions;
using TestU.Services;
using Xunit;

namespace TestU.UnitTests.Services
{
    public class BanknoteNameServiceTests
    {
        private readonly BanknoteNameService _banknoteNameService = new BanknoteNameService();

        [Theory]
        [InlineData(0.01, "1 ct")]
        [InlineData(0.5, "50 ct")]
        [InlineData(1, "1")]
        [InlineData(100, "100")]
        public void CanGetName(decimal value, string expected)
        {
            var actual = _banknoteNameService.GetName(value);

            actual.Should().Be(expected);
        }
    }
}
