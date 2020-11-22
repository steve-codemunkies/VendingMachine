using VendingMachine.MachineInterface;
using VendingMachine.Mechanism;

namespace VendingMachine.Mechanism
{
    public class QuarterValidator : IValidateCoin
    {
        private static Coin MasterCoin = new Coin(5670, 24260);
        public bool Validate(Coin coin)
        {
            return MasterCoin.Equals(coin);
        }
    }
}