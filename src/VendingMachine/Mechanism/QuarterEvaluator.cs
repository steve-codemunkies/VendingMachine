using VendingMachine.MachineInterface;
using VendingMachine.Mechanism;

namespace VendingMachine.Mechanism
{
    public class QuarterEvaluator : IEvaluateCoin
    {
        private static Coin MasterCoin = new Coin(5670, 24260);

        public int CoinValue => throw new System.NotImplementedException();

        public bool Validate(Coin coin)
        {
            return MasterCoin.Equals(coin);
        }
    }
}