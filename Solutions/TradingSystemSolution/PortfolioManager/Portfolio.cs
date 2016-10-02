using Observer;
using System.Collections.Generic;

namespace PortfolioManager
{
    public class Portfolio : Subject<Portfolio>, // Portfolios are subjects, and...
                             Observer<Stock>     // Portfolios are Observers on Stocks
    {
        public class PortfolioItem
        {
            public string StockName { get; set; }
            public double Value { get; set; }
            public uint Amount { get; set; }
        }


        public List<PortfolioItem> _portfolio { get; private set;}

        public Portfolio()
        {
            _portfolio = new List<PortfolioItem>();
        }


        public void AddStock(Stock stock)
        {
            var found = _portfolio.Find(s => s.StockName == stock.Name);

            if (found == null)
            {
                _portfolio.Add(new PortfolioItem() { StockName = stock.Name, Value = stock.Value, Amount = 1 });
                stock.Attach(this);
            }
            else
            {
                found.Value = stock.Value;
                ++found.Amount;
            }
            NotifyObservers();
        }

        public void RemoveStock(Stock stock)
        {
            var found = _portfolio.Find(s => s.StockName == stock.Name);

            if (found == null) return;  // No such stock attached

            if (found.Amount == 1)
            {
                _portfolio.Remove(found);
                stock.Detach(this);
            }
            else
            {
                found.Value = stock.Value;
                --found.Amount;
            }
            NotifyObservers();
        }

        // From the Observer interface
        public void Update(Stock stock)
        {
            var stockToUpdate = _portfolio.Find(s => s.StockName == stock.Name);

            if (stockToUpdate == null) return;

            stockToUpdate.Value = stock.Value;
            NotifyObservers();
        }
    }
}
