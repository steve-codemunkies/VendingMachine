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
            var result = subject.Validate(new Coin(2268, 17910));

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
        public bool Validate(Coin coin)
        {
            return true;
        }
    }
}