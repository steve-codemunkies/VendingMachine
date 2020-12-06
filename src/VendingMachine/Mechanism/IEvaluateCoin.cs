using VendingMachine.MachineInterface;

namespace VendingMachine.Mechanism
{
    public interface IEvaluateCoin
    {
        int CoinValue { get; }

        bool Validate(Coin coin);
    }
}