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
            var coin = new Coin(2268, 17910); // Dime
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
            var coin = new Coin(5670, 25260);
            var coinCollectorMock = new Mock<ICollectCoins>();
            var subject = new ControlPanel(coinCollectorMock.Object);

            coinCollectorMock.Setup(cc => cc.Add(coin)).Throws(new InvalidCoinException());

            // When
            var result = subject.InsertCoin(coin);

            // Then
            result.Should().BeFalse();
            subject.ReturnedCoins.Contains(coin);
        }

        [Fact]
        public void GivenTheCustomerInsertsMoneyAndSelectsAProduct_WhenThereIsSufficientMoneyAndProduct_ThenTheProductIsVendedAndTheCoinCollectorEmptied()
        {
            // Given
            var coin = new Coin(5670, 25260);
            var coinCollectorMock = new Mock<ICollectCoins>();
            var subject = new ControlPanel(coinCollectorMock.Object);

            coinCollectorMock.Setup(cc => cc.Add(coin)).Returns(true);

            // When
            subject.InsertCoin(coin).Should().BeTrue();
            var result = subject.Vend(1);

            // Then
            result.Should().BeTrue();
            subject.GetDisplayMessage().Should().Be("THANK YOU");
            subject.GetDisplayMessage().Should().Be("INSERT COIN");
            coinCollectorMock.Verify(cc => cc.Checkout(75), Times.Once);
        }


        [Fact]
        public void GivenTheCustomerHasInsertedNoMoneyAndSelectsAProduct_ThenThePriceAndPromptIsDisplayed()
        {
            // Given
            var coinCollectorMock = new Mock<ICollectCoins>();
            var subject = new ControlPanel(coinCollectorMock.Object);

            // When
            var result = subject.Vend(1);

            // Then
            result.Should().BeFalse();
            subject.GetDisplayMessage().Should().Be("PRICE $0.75");
            subject.GetDisplayMessage().Should().Be("INSERT COIN");
            subject.GetDisplayMessage().Should().Be("PRICE $0.75");
            subject.GetDisplayMessage().Should().Be("INSERT COIN");
            coinCollectorMock.Verify(cc => cc.Checkout(It.IsAny<int>()), Times.Never);
        }

    }
}