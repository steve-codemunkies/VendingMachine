using System.Collections.Generic;
using System.Linq;
using VendingMachine.Exceptions;
using VendingMachine.MachineInterface;

namespace VendingMachine.Mechanism
{
    public class CoinCollector : ICollectCoins
    {
        private readonly IEnumerable<IEvaluateCoin> _evaluators;
        private int accumulatedValue = 0;

        public CoinCollector(IEnumerable<IEvaluateCoin> evaluators)
        {
            _evaluators = evaluators;
        }

        public bool Add(Coin coin)
        {
            var evaluator = _evaluators.FirstOrDefault(e => e.Validate(coin));
            accumulatedValue += (evaluator ?? throw new InvalidCoinException()).CoinValue;

            return true;
        }

        public bool Checkout(int amount)
        {
            if(amount > accumulatedValue)
            {
                return false;
            }

            accumulatedValue = 0;
            return true;
        }
    }
}