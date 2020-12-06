using VendingMachine.MachineInterface;

namespace VendingMachine.Mechanism
{
    public interface ICollectCoins
    {
        bool Insert(Coin coin);
        bool Checkout(int amount);
    }
}