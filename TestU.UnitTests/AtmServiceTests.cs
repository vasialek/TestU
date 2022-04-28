using FluentAssertions;
using NSubstitute;
using TestU.Interfaces;
using TestU.Models;
using TestU.Services;
using Xunit;

namespace TestU.UnitTests
{
    public class AtmServiceTests
    {
        private readonly AtmService _atmService;
        private readonly INominalProvider _nominalProvider = Substitute.For<INominalProvider>();

        public AtmServiceTests()
        {
            _atmService = new AtmService(_nominalProvider);
        }

        [Theory]
        [InlineData(200, 1)]
        [InlineData(400, 2)]
        public void CanExchange(int money, int expected)
        {
            _nominalProvider.GetNominals().Returns(new[] {new Banknote(200, "200")});

            var actual = _atmService.Exchange(money);

            actual.Should().HaveCount(1);
            actual["200"].Should().Be(expected);
        }

        [Fact]
        public void Exchange_WhenFraction()
        {
            _nominalProvider.GetNominals()
                .Returns(new[]
                {
                    new Banknote(200, "200"),
                    new Banknote(0.01m, "1 ct"),
                });

            var actual = _atmService.Exchange(201);

            actual.Should().HaveCount(2);
            actual["200"].Should().Be(1);
            actual["1 ct"].Should().Be(100);
        }

        [Fact]
        public void Exchange_NoZeroBanknotes()
        {
            _nominalProvider.GetNominals()
                .Returns(new[]
                {
                    new Banknote(200, "200"),
                    new Banknote(0.01m, "1 ct"),
                });

            var actual = _atmService.Exchange(200);

            actual.Should().HaveCount(1);
            actual["200"].Should().Be(1);
        }
    }
}
