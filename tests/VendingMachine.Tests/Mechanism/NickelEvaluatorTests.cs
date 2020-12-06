using FluentAssertions;
using VendingMachine.MachineInterface;
using VendingMachine.Mechanism;
using Xunit;

namespace VendingMachine.Tests.Mechanism
{
    public class NickelEvaluatorTests
    {
        [Fact]
        public void GivenThatIAmValidatingANickel_ThenTheValidatorReturnsTrue()
        {
            // Given
            IEvaluateCoin subject = new NickelEvaluator();

            // When
            var result = subject.Validate(new Coin(5000, 21210));

            // Then
            result.Should().BeTrue();
        }

        [Fact]
        public void GivenThatIAmValidatingACoinThatIsNotANickel_ThenTheValidatorReturnsFalse()
        {
            // Given
            IEvaluateCoin subject = new NickelEvaluator();

            // When
            var result = subject.Validate(new Coin(11340, 30610));

            // Then
            result.Should().BeFalse();
        }

        [Fact]
        public void GivenThatIRequestTheValueFromTheEvaluator_ThenIAmReturnedTheValueAsAnInteger()
        {
            // Given
            IEvaluateCoin subject = new NickelEvaluator();

            // When
            // Then
            subject.CoinValue.Should().Be(5);
        }
    }
}