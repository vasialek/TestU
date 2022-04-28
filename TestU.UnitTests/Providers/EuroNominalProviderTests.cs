using FluentAssertions;
using NSubstitute;
using System.Collections.Generic;
using TestU.Interfaces;
using TestU.Models;
using TestU.Providers;
using Xunit;

namespace TestU.UnitTests.Providers
{
    public class EuroNominalProviderTests
    {
        private readonly IBanknoteNameService _banknoteNameService = Substitute.For<IBanknoteNameService>();

        [Fact]
        public void CanGetNominals()
        {
            var provider = new EuroNominalProvider(_banknoteNameService);
            _banknoteNameService.GetName(default).ReturnsForAnyArgs("Name");

            var actual = provider.GetNominals();

            actual.Should().BeEquivalentTo(new List<Banknote>
            {
                new Banknote(500, "Name"),
                new Banknote(200, "Name"),
                new Banknote(100, "Name"),
                new Banknote(50, "Name"),
                new Banknote(20, "Name"),
                new Banknote(10, "Name"),
                new Banknote(5, "Name"),
                new Banknote(2, "Name"),
                new Banknote(1, "Name"),
                new Banknote(0.50m, "Name"),
                new Banknote(0.20m, "Name"),
                new Banknote(0.10m, "Name"),
                new Banknote(0.05m, "Name"),
                new Banknote(0.02m, "Name"),
                new Banknote(0.01m, "Name"),
            });
        }
    }
}
