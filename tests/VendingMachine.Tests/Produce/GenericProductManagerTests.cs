using FluentAssertions;
using Moq;
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
            const int productCode = 123;
            IProductContainer subject = new GenericProductManager(productCode);

            // When
            // Then
            subject.ProcessesSelection(productCode).Should().BeTrue();
        }

        [Fact]
        public void GivenThatTheProductManagerHasBeenSetupToManageASpecificProductCode_WhenSomethingChecksThatADifferentProductCodeCanBeProcessed_ThenTheGenericProductManagerReturnsFalse()
        {
            // Given
            const int productCode = 123;
            IProductContainer subject = new GenericProductManager(productCode);

            // When
            // Then
            subject.ProcessesSelection(productCode + 5).Should().BeFalse();
        }

        [Fact]
        public void GivenThatIHaveCollectedCoins_WhenTheValueOfTheCoinsAreGreaterThanOrEqualToTheValueOfTheProduct_AndThereIsProductAvailable_ThenTheGenericProductManagerRespondsThatItCanVend()
        {
            // Given
            const int productCode = 123;
            IProductContainer subject = new GenericProductManager(productCode);

            var coinCollectorMock = new Mock<ICollectCoins>();

            // When
            // Then
            subject.CanVend(coinCollectorMock.Object).Should().BeTrue();
        }
    }

    public class GenericProductManager : IProductContainer
    {
        private readonly int productCode;

        public GenericProductManager(int productCode)
        {
            this.productCode = productCode;
        }

        public bool CanVend(ICollectCoins coinCollector)
        {
            throw new System.NotImplementedException();
        }

        public string GetPriceString()
        {
            throw new System.NotImplementedException();
        }

        public bool ProcessesSelection(int selection) => selection == productCode;
    }
}