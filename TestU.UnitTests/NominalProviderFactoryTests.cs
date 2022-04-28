using System;
using FluentAssertions;
using TestU.Providers;
using Xunit;

namespace TestU.UnitTests
{
    public class NominalProviderFactoryTests
    {
        private readonly NominalProviderFactory _factory = new NominalProviderFactory();

        [Fact]
        public void CanCreate()
        {
            var actual = _factory.Create("EUR");

            actual.Should().BeOfType<EuroNominalProvider>();
        }

        [Fact]
        public void Create_Exception_WhenUnknownName()
        {
            Action act = () => _factory.Create("NonExistingName");

            act.Should().Throw<Exception>();
        }
    }
}
