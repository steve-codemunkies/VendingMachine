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
        public void GivenThatTheCoinIAmInsertingIsValid_ThenItIsAccepted()
        {
            // Given
            var coin = new Coin(2268, 17910); // Dime
            var validatorMock1 = new Mock<IEvaluateCoin>();
            var validatorMock2 = new Mock<IEvaluateCoin>();
            ICollectCoins subject = new CoinCollector(new [] { validatorMock1.Object, validatorMock2.Object });

            validatorMock1.Setup(v => v.Validate(coin)).Returns(false);
            validatorMock2.Setup(v => v.Validate(coin)).Returns(true);

            // When
            var result = subject.Insert(coin);

            // Then
            result.Should().BeTrue();
        }

        [Fact]
        public void GivenThatTheCoinIAmInsertingIsInvalid_ThenAnInvalidCoinExceptionIsThrown()
        {
            // Given
            var coin = new Coin(2268, 17910); // Dime
            var validatorMock1 = new Mock<IEvaluateCoin>();
            var validatorMock2 = new Mock<IEvaluateCoin>();
            ICollectCoins subject = new CoinCollector(new [] { validatorMock1.Object, validatorMock2.Object });

            validatorMock1.Setup(v => v.Validate(coin)).Returns(false);
            validatorMock2.Setup(v => v.Validate(coin)).Returns(false);

            // When
            // Then
            Assert.Throws<InvalidCoinException>(() => subject.Insert(coin)); 
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
        public void GivenThatACoinHasBeenInsertedIntoTheCollector_WhenICheckoutAValueLessThanTheValueOfTheCoin_ThenTrueIsReturned()
        {
            // Given
            const int checkoutValue = 50;
            var coin = new Coin(2268, 17910); // Dime
            var validatorMock1 = new Mock<IEvaluateCoin>();
            var validatorMock2 = new Mock<IEvaluateCoin>();
            ICollectCoins subject = new CoinCollector(new [] { validatorMock1.Object, validatorMock2.Object });

            validatorMock1.Setup(v => v.Validate(coin)).Returns(true);
            validatorMock1.SetupGet(v => v.CoinValue).Returns(checkoutValue + 1);
            validatorMock2.Setup(v => v.Validate(coin)).Returns(false);
            validatorMock2.SetupGet(v => v.CoinValue).Returns(checkoutValue - 1);

            // When
            // Then
            subject.Insert(coin).Should().BeTrue();
            subject.Checkout(checkoutValue).Should().BeTrue();
        }

        [Fact]
        public void GivenThatACoinHasBeenInsertedIntoTheCollector_WhenICheckoutAValueMoreThanTheValueOfTheCoin_ThenFalseIsReturned()
        {
            // Given
            const int checkoutValue = 50;
            var coin = new Coin(2268, 17910); // Dime
            var validatorMock1 = new Mock<IEvaluateCoin>();
            var validatorMock2 = new Mock<IEvaluateCoin>();
            ICollectCoins subject = new CoinCollector(new [] { validatorMock1.Object, validatorMock2.Object });


            validatorMock1.Setup(v => v.Validate(coin)).Returns(false);
            validatorMock1.SetupGet(v => v.CoinValue).Returns(checkoutValue + 1);
            validatorMock2.Setup(v => v.Validate(coin)).Returns(true);
            validatorMock2.SetupGet(v => v.CoinValue).Returns(checkoutValue - 1);

            // When
            // Then
            subject.Insert(coin).Should().BeTrue();
            subject.Checkout(checkoutValue).Should().BeFalse();
        }

        [Fact]
        public void GivenThatACoinHasBeenInsertedIntoTheCollector_WhenICheckoutAValueThatIsTheSameAsTheValueOfTheCoin_ThenTrueIsReturned()
        {
            // Given
            const int checkoutValue = 50;
            var coin = new Coin(2268, 17910); // Dime
            var validatorMock1 = new Mock<IEvaluateCoin>();
            var validatorMock2 = new Mock<IEvaluateCoin>();
            ICollectCoins subject = new CoinCollector(new [] { validatorMock1.Object, validatorMock2.Object });


            validatorMock1.Setup(v => v.Validate(coin)).Returns(false);
            validatorMock1.SetupGet(v => v.CoinValue).Returns(checkoutValue + 1);
            validatorMock2.Setup(v => v.Validate(coin)).Returns(true);
            validatorMock2.SetupGet(v => v.CoinValue).Returns(checkoutValue);

            // When
            // Then
            subject.Insert(coin).Should().BeTrue();
            subject.Checkout(checkoutValue).Should().BeTrue();
        }

        [Fact]
        public void GivenThatASuccessfulCheckoutHasOccurred_WhenIAttemptASecondCheckoutWithoutInsertingMoreCoins_ThenFalseIsReturned()
        {
            // Given
            const int checkoutValue = 50;
            var coin = new Coin(2268, 17910); // Dime
            var validatorMock1 = new Mock<IEvaluateCoin>();
            var validatorMock2 = new Mock<IEvaluateCoin>();
            ICollectCoins subject = new CoinCollector(new [] { validatorMock1.Object, validatorMock2.Object });


            validatorMock1.Setup(v => v.Validate(coin)).Returns(false);
            validatorMock1.SetupGet(v => v.CoinValue).Returns(checkoutValue + 1);
            validatorMock2.Setup(v => v.Validate(coin)).Returns(true);
            validatorMock2.SetupGet(v => v.CoinValue).Returns(checkoutValue);

            // When
            // Then - checkout one
            subject.Insert(coin).Should().BeTrue();
            subject.Checkout(checkoutValue).Should().BeTrue();

            // Then - checkout two
            subject.Checkout(checkoutValue).Should().BeFalse();
        }
    }
}