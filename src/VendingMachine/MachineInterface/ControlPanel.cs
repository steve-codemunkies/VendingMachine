using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using VendingMachine.Exceptions;
using VendingMachine.Mechanism;
using VendingMachine.Product;

namespace VendingMachine.MachineInterface
{
    public class ControlPanel
    {
        private readonly ICollectCoins _coinCollector;
        private readonly IEnumerable<IManageProduct> _productManagers;
        private readonly List<Coin> _returnedCoins = new List<Coin>();
        private bool _justVended = false;
        private string _priceMessage;
        private bool _notEnough = false;
        private bool _notDisplayedPrice = false;

        public ControlPanel(ICollectCoins coinCollector, IEnumerable<IManageProduct> productManagers)
        {
            _coinCollector = coinCollector;
            _productManagers = productManagers;
        }

        public IReadOnlyCollection<Coin> ReturnedCoins => new ReadOnlyCollection<Coin>(_returnedCoins);

        public string GetDisplayMessage()
        {
            if(_justVended)
            {
                _justVended = false;
                return "THANK YOU";
            }

            if(_notEnough)
            {
                if(_notDisplayedPrice)
                {
                    _notDisplayedPrice = false;
                    return _priceMessage;
                }

                _notDisplayedPrice = true;
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
            var pm = _productManagers.FirstOrDefault(p => p.ProcessesSelection(selection));

            if(pm == null)
            {
                return false;
            }

            if(!pm.CanVend(_coinCollector))
            {
                _priceMessage = pm.GetPriceString();
                _notEnough = true;
                _notDisplayedPrice = true;
                return false;
            }

            _justVended = true;
            _coinCollector.Checkout(75);
            return true;
        }
    }
}