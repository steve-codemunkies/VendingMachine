using FluentAssertions;
using VendingMachine.Product;
using Xunit;

namespace VendingMachine.Tests.Product
{
    public class GenericProductManagerTests
    {
        [Fact]
        public void GivenThatTheProductManagerHasBeenSetupToManageASpecificProductCode_WhenSomethingChecksThatTheProductCodeCanBeProcessed_ThenTheGenericProductManagerReturnsTrue()
        {
            // Given
            IProductContainer subject = new GenericProductManager();

            // When
            // Then
            subject.ProcessesSelection(123).Should().BeTrue();
        }
    }
}