using FluentAssertions;
using VendingMachine.Mechanism;
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

    public class GenericProductManager : IProductContainer
    {
        public bool CanVend(ICollectCoins coinCollector)
        {
            throw new System.NotImplementedException();
        }

        public string GetPriceString()
        {
            throw new System.NotImplementedException();
        }

        public bool ProcessesSelection(int selection)
        {
            return true;
        }
    }
}