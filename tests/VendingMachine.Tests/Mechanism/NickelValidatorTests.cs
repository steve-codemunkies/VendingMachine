using FluentAssertions;
using VendingMachine.MachineInterface;
using VendingMachine.Mechanism;
using Xunit;

namespace VendingMachine.Tests.Mechanism
{
    public class NickelValidatorTests
    {
        [Fact]
        public void GivenThatIAmValidatingANickel_ThenIReturnTrue()
        {
            // Given
            IValidateCoin subject = new NickelValidator();

            // When
            var result = subject.Validate(new Coin(5000, 835));

            // Then
            result.Should().BeTrue();
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