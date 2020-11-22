using FluentAssertions;
using VendingMachine.Exceptions;
using VendingMachine.MachineInterface;
using VendingMachine.Mechanism;
using Xunit;

namespace VendingMachine.Tests.Mechanism
{
    public class CoinCollectorTests
    {
        [Fact]
        public void GivenThatTheCoinIAmAddingIsValid_ThenItIsAccepted()
        {
            // Given
            ICollectCoins subject = new CoinCollector();

            // When
            var result = subject.Add(new Coin(2268, 705)); // Dime

            // Then
            result.Should().BeTrue();
        }

        [Fact]
        public void GivenThatTheCoinIAmAddingIsInvalid_ThenAnInvalidCoinExceptionIsThrown()
        {
            // Given
            ICollectCoins subject = new CoinCollector();

            // When
            // Then
            Assert.Throws<InvalidCoinException>(() => subject.Add(new Coin(2268, 705))); // Dime
        }
    }

    public class CoinCollector : ICollectCoins
    {
        public bool Add(Coin coin)
        {
            return true;
        }
    }
}