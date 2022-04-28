using System.Collections.Generic;
using FluentAssertions;
using TestU.Models;
using TestU.Providers;
using Xunit;

namespace TestU.UnitTests.Providers
{
    public class EuroNominalProviderTests
    {
        [Fact]
        public void CanGetNominals()
        {
            var provider = new EuroNominalProvider();

            var actual = provider.GetNominals();

            actual.Should().BeEquivalentTo(new List<Banknote>
            {
                new Banknote(500, "500"),
                new Banknote(200, "200"),
                new Banknote(100, "100"),
                new Banknote(50, "50"),
                new Banknote(20, "20"),
                new Banknote(10, "10"),
                new Banknote(5, "5"),
                new Banknote(2, "2"),
                new Banknote(1, "1"),
                new Banknote(0.50m, "50 ct"),
                new Banknote(0.20m, "20 ct"),
                new Banknote(0.10m, "10 ct"),
                new Banknote(0.05m, "5 ct"),
                new Banknote(0.02m, "2 ct"),
                new Banknote(0.01m, "1 ct"),
            });
        }
    }
}
