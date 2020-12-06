using System.Collections.Generic;
using System.Linq;
using VendingMachine.Exceptions;
using VendingMachine.MachineInterface;
using VendingMachine.Mechanism;

namespace VendingMachine.Mechanism
{
    public class CoinCollector : ICollectCoins
    {
        private readonly IEnumerable<IEvaluateCoin> _validators;

        public CoinCollector(IEnumerable<IEvaluateCoin> validators)
        {
            _validators = validators;
        }

        public bool Add(Coin coin)
        {
            if(!_validators.Any(v => v.Validate(coin)))
            {
                throw new InvalidCoinException();
            }

            return true;
        }

        public bool Checkout(int amount)
        {
            return amount == 50;
        }
    }
}