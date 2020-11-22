using VendingMachine.MachineInterface;

namespace VendingMachine.Mechanism
{
    public interface IValidateCoin
    {
        bool Validate(Coin coin);
    }
}