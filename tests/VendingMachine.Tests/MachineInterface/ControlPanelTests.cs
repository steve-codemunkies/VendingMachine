using System.Linq;
using FluentAssertions;
using Moq;
using VendingMachine.Exceptions;
using VendingMachine.MachineInterface;
using VendingMachine.Mechanism;
using Xunit;

namespace VendingMachine.Tests.MachineInterface
{
    public class ControlPanelTests
    {
        [Fact]
        public void GivenTheControlPanelHasBeenInitialised_WhenIGetTheDisplayMessage_ThenIGetTheExpectedDisplayMessage()
        {
            //Given
            var subject = new ControlPanel(null);

            //When
            var result = subject.GetDisplayMessage();
            
            //Then
            result.Should().Be("INSERT COIN");
        }

        [Fact]
        public void GivenACustomerInsertsACoin_WhenTheCoinIsValid_ThenTheCoinCollectorRetainsTheCoin()
        {
            // Given
            var coin = new Coin(2268, 705); // Dime
            var coinCollectorMock = new Mock<ICollectCoins>();
            var subject = new ControlPanel(coinCollectorMock.Object);

            coinCollectorMock.Setup(cc => cc.Add(coin)).Returns(true);

            // When
            var result = subject.InsertCoin(coin);

            // Then
            result.Should().BeTrue();
            subject.ReturnedCoins.Any().Should().BeFalse();
        }

        [Fact]
        public void GivenACustomerInsertsACoin_WhenTheCoinIsInvalid_ThenTheCoinCollectorReturnsTheCoin()
        {
            // Given
            var coin = new Coin(5670, 955);
            var coinCollectorMock = new Mock<ICollectCoins>();
            var subject = new ControlPanel(coinCollectorMock.Object);

            coinCollectorMock.Setup(cc => cc.Add(coin)).Throws(new InvalidCoinException());

            // When
            var result = subject.InsertCoin(coin);

            // Then
            result.Should().BeFalse();
            subject.ReturnedCoins.Contains(coin);
        }
    }
}