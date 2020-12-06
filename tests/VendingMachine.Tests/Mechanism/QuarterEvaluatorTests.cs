using FluentAssertions;
using VendingMachine.MachineInterface;
using VendingMachine.Mechanism;
using Xunit;

namespace VendingMachine.Tests.Mechanism
{
    public class QuarterEvaluatorTests
    {
        [Fact]
        public void GivenThatIAmValidatingAQuarter_ThenTheValidatorReturnsTrue()
        {
            // Given
            IEvaluateCoin subject = new QuarterEvaluator();

            // When
            var result = subject.Validate(new Coin(5670, 24260));

            // Then
            result.Should().BeTrue();
        }

        [Fact]
        public void GivenThatIAmNotValidatingAQuarter_ThenTheValidatorReturnsFalse()
        {
            // Given
            IEvaluateCoin subject = new QuarterEvaluator();

            // When
            var result = subject.Validate(new Coin(5000, 21210));

            // Then
            result.Should().BeFalse();
        }
    }
}