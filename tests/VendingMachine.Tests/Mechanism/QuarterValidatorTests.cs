using FluentAssertions;
using VendingMachine.MachineInterface;
using VendingMachine.Mechanism;

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

    }
}