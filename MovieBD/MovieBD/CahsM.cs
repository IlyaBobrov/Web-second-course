using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieBD
{
    public class CashManager
    {
        private StorageManager _storageManager;
        private MovieManager _moveManager;
        
        private Dictionary<string, int> _prices;

        public Dictionary<string, int> Prices
        {
            get => _prices;
            set => _prices = value;
        }

        public CashManager(StorageManager storageManager, MovieManager moveManager)
        {
            _prices = new Dictionary<string, int>();
            _storageManager = storageManager;
            _moveManager = moveManager;
        }

        public bool ChangePrice(string name, int price)
        {
            if (_prices.ContainsKey(name)) {
                _prices[name] = price;
                return true;
            }

            if (!_storageManager.ContainsMovie(name)) return false;
            _prices.Add(name, price);
            return true;
        }

        public bool OfferSale(string name, int sale)
        {
            if (!_prices.ContainsKey(name)) return false;

            if (sale <= 0 || sale > 100)
            {
                Console.WriteLine("The sale is too big!");
                return false;
            }

            _prices[name] -= _prices[name] % sale;
            return true;
        }

        public int GetQuantity(string name)
        {
            return _storageManager.GetQuantity(name);
        }

        public int GetPrice(string name)
        {
            return _prices.ContainsKey(name) ? _prices[name] : 0;
        }

        public int Sell(string name, int quantity, int money)
        {
            if (GetQuantity(name) < quantity)
            {
                Console.WriteLine("Not enough " + name + "(s) in storage");
                return money;
            }

            if (!_prices.ContainsKey(name))
            {
                Console.WriteLine(name + " does not have a price yet");
                return money;
            }

            var cost = quantity * GetPrice(name);

            if (cost > money)
            {
                Console.WriteLine("Not enough money to buy " + quantity + " " + name + "(s)");
                return money;
            }

            _storageManager.Remove(name, quantity);
            return money - cost;
        }

        public HashSet<int> GetStudio()
        {
            var result = new HashSet<int>();
            foreach (var i in _prices)
            {
                if (!_storageManager.ContainsMovie(i.Key)) continue;
                var movie = _moveManager.GetName(i.Key);
                result.Add(movie.IdStudio);
            }

            return result;
        }

        public HashSet<int> GetDirector()
        {
            var result = new HashSet<int>();
            
            foreach (var i in _prices)
            {
                if (!_storageManager.ContainsMovie(i.Key)) continue;
                var toy = _moveManager.GetName(i.Key);
                result.Add(toy.IdDirector);
            }

            return result;
        }

        public HashSet<int> GetGenre()
        {
            var result = new HashSet<int>();
            
            foreach (var i in _prices)
            {
                if (!_storageManager.ContainsMovie(i.Key)) continue;
                var toy = _moveManager.GetName(i.Key);
                result.Add(toy.IdGenre);
            }

            return result;
        }

        public HashSet<string> GetMovie()
        {
            var result = new HashSet<string>();
            foreach (var t in _prices.Where(t => _storageManager.ContainsMovie(t.Key)))
            {
                result.Add(t.Key);
            }

            return result;
        }
    }
}