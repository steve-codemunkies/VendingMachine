using VendingMachine.MachineInterface;
using VendingMachine.Mechanism;

namespace VendingMachine.Mechanism
{
    public class DimeEvaluator : IEvaluateCoin
    {
        private static Coin MasterCoin = new Coin(2268, 17910);

        public int CoinValue => throw new System.NotImplementedException();

        public bool Validate(Coin coin)
        {
            return MasterCoin.Equals(coin);
        }
    }
}