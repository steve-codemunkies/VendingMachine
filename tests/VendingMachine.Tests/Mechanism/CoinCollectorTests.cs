using FluentAssertions;
using Moq;
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
            var coin = new Coin(2268, 17910); // Dime
            var validatorMock1 = new Mock<IValidateCoin>();
            var validatorMock2 = new Mock<IValidateCoin>();
            ICollectCoins subject = new CoinCollector(new [] { validatorMock1.Object, validatorMock2.Object });

            validatorMock1.Setup(v => v.Validate(coin)).Returns(false);
            validatorMock2.Setup(v => v.Validate(coin)).Returns(true);

            // When
            var result = subject.Add(coin);

            // Then
            result.Should().BeTrue();
        }

        [Fact]
        public void GivenThatTheCoinIAmAddingIsInvalid_ThenAnInvalidCoinExceptionIsThrown()
        {
            // Given
            var coin = new Coin(2268, 17910); // Dime
            var validatorMock1 = new Mock<IValidateCoin>();
            var validatorMock2 = new Mock<IValidateCoin>();
            ICollectCoins subject = new CoinCollector(new [] { validatorMock1.Object, validatorMock2.Object });

            validatorMock1.Setup(v => v.Validate(coin)).Returns(false);
            validatorMock2.Setup(v => v.Validate(coin)).Returns(false);

            // When
            // Then
            Assert.Throws<InvalidCoinException>(() => subject.Add(coin)); 
        }

        [Fact]
        public void GivenThatTheCoinCollectorIsEmpty_WhenITryToCheckoutANonZeroValue_ThenFalseIsReturned()
        {
            // Given
            ICollectCoins subject = new CoinCollector(null);

            // When
            // Then
            subject.Checkout(1).Should().BeFalse();
        }

        [Fact]
        public void GivenThatACoinHasBeenAddedToTheCollector_WhenICheckoutAValueLessThanTheValueOfTheCoin_ThenTrueIsReturned()
        {
            // Given
            var coin = new Coin(2268, 17910); // Dime
            var validatorMock1 = new Mock<IValidateCoin>();
            var validatorMock2 = new Mock<IValidateCoin>();
            ICollectCoins subject = new CoinCollector(new [] { validatorMock1.Object });

            validatorMock1.Setup(v => v.Validate(coin)).Returns(true);

            // When
            // Then
            subject.Add(coin).Should().BeTrue();
            subject.Checkout(50).Should().BeTrue();
        }

        [Fact]
        public void GivenThatACoinHasBeenAddedToTheCollector_WhenICheckoutAValueMoreThanTheValueOfTheCoin_ThenTrueIsReturned()
        {
            // Given
            var coin = new Coin(2268, 17910); // Dime
            var validatorMock1 = new Mock<IValidateCoin>();
            var validatorMock2 = new Mock<IValidateCoin>();
            ICollectCoins subject = new CoinCollector(new [] { validatorMock1.Object });

            validatorMock1.Setup(v => v.Validate(coin)).Returns(true);

            // When
            // Then
            subject.Add(coin).Should().BeTrue();
            subject.Checkout(50).Should().BeFalse();
        }
    }
}