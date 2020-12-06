using VendingMachine.MachineInterface;

namespace VendingMachine.Mechanism
{
    public interface IEvaluateCoin
    {
        bool Validate(Coin coin);
    }
}