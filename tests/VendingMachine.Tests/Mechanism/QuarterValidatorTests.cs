using FluentAssertions;
using VendingMachine.MachineInterface;
using VendingMachine.Mechanism;
using Xunit;

namespace VendingMachine.Tests.Mechanism
{
    public class QuarterValidatorTests
    {
        [Fact]
        public void GivenThatIAmValidatingAQuarter_ThenTheValidatorReturnsTrue()
        {
            // Given
            IValidateCoin subject = new QuarterValidator();

            // When
            var result = subject.Validate(new Coin(5670, 24260));

            // Then
            result.Should().BeTrue();
        }

        [Fact]
        public void GivenThatIAmNotValidatingAQuarter_ThenTheValidatorReturnsFalse()
        {
            // Given
            IValidateCoin subject = new QuarterValidator();

            // When
            var result = subject.Validate(new Coin(5000, 21210));

            // Then
            result.Should().BeFalse();
        }
    }

    public class QuarterValidator : IValidateCoin
    {
        private static Coin MasterCoin = new Coin(5670, 24260);
        public bool Validate(Coin coin)
        {
            return MasterCoin.Equals(coin);
        }
    }
}