using VendingMachine.MachineInterface;

namespace VendingMachine.Mechanism
{
    public class NickelValidator : IValidateCoin
    {
        private static Coin MasterCoin = new Coin(5000, 21210);
        public bool Validate(Coin coin)
        {
            return MasterCoin.Equals(coin);
        }
    }
}