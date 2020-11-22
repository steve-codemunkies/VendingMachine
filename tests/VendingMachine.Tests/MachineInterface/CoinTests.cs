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
            var subject1 = new Coin(5000, 21210); // Nickel
            var subject2 = new Coin(5000, 21210); // Nickel

            // When
            // Then
            subject1.Equals(subject2).Should().BeTrue();
            subject2.Equals(subject1).Should().BeTrue();
        }

        [Fact]
        public void GivenThatThereAreTwoCoinsOfTheSameWeightAndDifferentDiameters_WhenICompareThem_ThenIGetTheExpectedResponse()
        {
            // Given
            var subject1 = new Coin(5000, 21210); // Nickel
            var subject2 = new Coin(5000, 22000); // Not a Nickel

            // When
            // Then
            subject1.Equals(subject2).Should().BeFalse();
            subject2.Equals(subject1).Should().BeFalse();
        }

        [Fact]
        public void GivenThatIHaveACoin_WhenICompareItToANonCoin_ThenIGetTheExpectedResponse()
        {
            // Given
            var subject = new Coin(5000, 21210); // Still a Nickel

            // When
            // Then
            subject.Equals("this is not a coin");
        }
    }
}