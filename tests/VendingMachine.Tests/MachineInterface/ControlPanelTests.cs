using FluentAssertions;
using Xunit;

namespace VendingMachine.Tests.MachineInterface
{
    public class ControlPanelTests
    {
        [Fact]
        public void TestName()
        {
            //Given
            var subject = new ControlPanel();

            //When
            var result = subject.GetDisplayMessage();
            
            //Then
            result.Should().Be("INSERT COIN");
        }
    }
}