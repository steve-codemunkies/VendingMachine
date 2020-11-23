using VendingMachine.Mechanism;

namespace VendingMachine.Product
{
    public interface IManageProduct
    {
        bool ProcessesSelection(int selection);
        bool CanVend(ICollectCoins coinCollector);
        string GetPriceString();
    }
}