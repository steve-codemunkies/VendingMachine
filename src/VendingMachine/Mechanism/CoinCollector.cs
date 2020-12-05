using System.Collections.Generic;
using System.Linq;
using VendingMachine.Exceptions;
using VendingMachine.MachineInterface;
using VendingMachine.Mechanism;

namespace VendingMachine.Mechanism
{
    public class CoinCollector : ICollectCoins
    {
        private readonly IEnumerable<IValidateCoin> _validators;

        public CoinCollector(IEnumerable<IValidateCoin> validators)
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
            return false;
        }
    }
}