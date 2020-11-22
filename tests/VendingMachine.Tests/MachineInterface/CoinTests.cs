using FluentAssertions;
using VendingMachine.MachineInterface;
using Xunit;

namespace VendingMachine.Tests.MachineInterface
{
    public class CoinTests
    {
        [Fact]
        public void GivenThatThereAreTwoCoinsOfTheSameWeightAndDiameter_WhenICompareThem_ThenIGetTheExpectedResponse()
        {
            // Given
            var subject1 = new Coin();
            var subject2 = new Coin();

            // When
            // Then
            subject1.Equals(subject2).Should().BeTrue();
            subject2.Equals(subject1).Should().BeTrue();
        }
    }
}