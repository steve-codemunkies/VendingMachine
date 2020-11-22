using FluentAssertions;
using VendingMachine.MachineInterface;
using VendingMachine.Mechanism;
using Xunit;

namespace VendingMachine.Tests.Mechanism
{
    public class DimeValidatorTests
    {
        [Fact]
        public void GivenThatIAmValidatingADime_ThenTheValidatorReturnsTrue()
        {
            // Given
            IValidateCoin subject = new DimeValidator();

            // When
            var result = subject.Validate(new Coin(2268, 17910));

            // Then
            result.Should().BeTrue();
        }

        [Fact]
        public void GivenThatIAmNotValidatingADime_ThenTheValidatorReturnsFalse()
        {
            // Given
            IValidateCoin subject = new DimeValidator();

            // When
            var result = subject.Validate(new Coin(5670, 24260));

            // Then
            result.Should().BeFalse();
        }
    }

    public class DimeValidator : IValidateCoin
    {
        private static Coin MasterCoin = new Coin(2268, 17910);
        public bool Validate(Coin coin)
        {
            return MasterCoin.Equals(coin);
        }
    }
}