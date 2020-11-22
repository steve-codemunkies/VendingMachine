using VendingMachine.MachineInterface;

namespace VendingMachine.Mechanism
{
    public interface ICollectCoins
    {
        bool Add(Coin coin);
    }
}