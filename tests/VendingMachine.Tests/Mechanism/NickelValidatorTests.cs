using FluentAssertions;
using VendingMachine.MachineInterface;
using VendingMachine.Mechanism;
using Xunit;

namespace VendingMachine.Tests.Mechanism
{
    public class NickelValidatorTests
    {
        [Fact]
        public void GivenThatIAmValidatingANickel_ThenTheValidatorReturnsTrue()
        {
            // Given
            IValidateCoin subject = new NickelValidator();

            // When
            var result = subject.Validate(new Coin(5000, 21210));

            // Then
            result.Should().BeTrue();
        }

        [Fact]
        public void GivenThatIAmValidatingACoinThatIsNotANickel_ThenTheValidatorReturnsFalse()
        {
            // Given
            IValidateCoin subject = new NickelValidator();

            // When
            var result = subject.Validate(new Coin(11340, 30610));

            // Then
            result.Should().BeFalse();
        }
    }

    public class NickelValidator : IValidateCoin
    {
        public bool Validate(Coin coin)
        {
            return true;
        }
    }
}