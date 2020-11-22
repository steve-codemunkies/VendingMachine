using VendingMachine.MachineInterface;
using VendingMachine.Mechanism;

namespace VendingMachine.Mechanism
{
    public class DimeValidator : IValidateCoin
    {
        private static Coin MasterCoin = new Coin(2268, 17910);
        public bool Validate(Coin coin)
        {
            return MasterCoin.Equals(coin);
        }
    }
}