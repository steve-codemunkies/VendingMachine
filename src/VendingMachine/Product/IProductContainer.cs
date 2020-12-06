using VendingMachine.Mechanism;

namespace VendingMachine.Product
{
    public interface IProductContainer
    {
        bool ProcessesSelection(int selection);
        bool CanVend(ICollectCoins coinCollector);
        string GetPriceString();
    }
}