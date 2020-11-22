using FluentAssertions;
using Xunit;

namespace VendingMachine.Tests.MachineInterface
{
    public class ControlPanelTests
    {
        [Fact]
        public void GivenTheControlPanelHasBeenInitialised_WhenIGetTheDisplayMessage_ThenIGetTheExpectedDisplayMessage()
        {
            //Given
            var subject = new ControlPanel();

            //When
            var result = subject.GetDisplayMessage();
            
            //Then
            result.Should().Be("INSERT COIN");
        }

        [Fact]
        public void GivenACustomerInsertsACoin_WhenTheCoinIsValid_ThenTheCoinCollectorRetainsTheCoin()
        {
            // Given
            var subject = new ControlPanel();

            // When
            var result = subject.InsertCoin(new Coin());

            // Then
            result.Should().BeTrue();
        }
    }

    public class ControlPanel
    {
        public string GetDisplayMessage()
        {
            return "INSERT COIN";
        }
    }
}