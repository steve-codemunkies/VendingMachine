using VendingMachine.MachineInterface;

namespace VendingMachine.Mechanism
{
    public class NickelEvaluator : IEvaluateCoin
    {
        private static Coin MasterCoin = new Coin(5000, 21210);

        public int CoinValue => 5;

        public bool Validate(Coin coin)
        {
            return MasterCoin.Equals(coin);
        }
    }
}