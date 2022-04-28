using FluentAssertions;
using NSubstitute;
using System;
using TestU.Interfaces;
using TestU.Providers;
using Xunit;

namespace TestU.UnitTests
{
    public class NominalProviderFactoryTests
    {
        private readonly IBanknoteNameService _banknoteNameService = Substitute.For<IBanknoteNameService>();

        private readonly NominalProviderFactory _factory;

        public NominalProviderFactoryTests()
        {
            _factory = new NominalProviderFactory(_banknoteNameService);
        }

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

            act.Should()
                .Throw<Exception>()
                .WithMessage("Can't create Nominal provider for unknown name: NonExistingName");
        }
    }
}
