using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using VendingMachine.Exceptions;
using VendingMachine.Mechanism;

namespace VendingMachine.MachineInterface
{
    public class ControlPanel
    {
        private readonly ICollectCoins _coinCollector;
        private readonly List<Coin> _returnedCoins = new List<Coin>();
        private bool _justVended = false;

        public ControlPanel(ICollectCoins coinCollector)
        {
            _coinCollector = coinCollector;
        }

        public IReadOnlyCollection<Coin> ReturnedCoins => new ReadOnlyCollection<Coin>(_returnedCoins);

        public string GetDisplayMessage()
        {
            if(_justVended)
            {
                _justVended = false;
                return "THANK YOU";
            }
            return "INSERT COIN";
        }

        public bool InsertCoin(Coin coin)
        {
            try
            {
                return _coinCollector.Add(coin);
            }
            catch(InvalidCoinException)
            {
                _returnedCoins.Add(coin);
                return false;
            }
        }

        public bool Vend(int selection)
        {
            _justVended = true;
            _coinCollector.Checkout(75);
            return true;
        }
    }
}