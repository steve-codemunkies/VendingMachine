using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using FluentAssertions;
using Moq;
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
            var coin = new Coin();
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
            var coin = new Coin();
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

    [System.Serializable]
    public class InvalidCoinException : System.Exception
    {
        public InvalidCoinException()
        {
        }

        public InvalidCoinException(string message) : base(message)
        {
        }

        public InvalidCoinException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidCoinException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    public class Coin
    {
        public Coin()
        {
        }
    }

    public class ControlPanel
    {
        private readonly ICollectCoins _coinCollector;
        private readonly List<Coin> _returnedCoins = new List<Coin>();

        public ControlPanel(ICollectCoins coinCollector)
        {
            _coinCollector = coinCollector;
        }

        public IReadOnlyCollection<Coin> ReturnedCoins => new ReadOnlyCollection<Coin>(_returnedCoins);

        public string GetDisplayMessage()
        {
            return "INSERT COIN";
        }

        public bool InsertCoin(Coin coin)
        {
            try
            {
                return _coinCollector.Add(coin);
            }
            catch(InvalidCoinException)
            {
                _returnedCoins.Add(coin);
                return false;
            }
        }
    }

    public interface ICollectCoins
    {
        bool Add(Coin coin);
    }
}