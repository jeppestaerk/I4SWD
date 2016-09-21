using GoFObserver;

namespace GoFObserverStocks
{
    public class Stock : GoFSubject<Stock>
    {
        private double _price;
        private readonly string _name;

        public Stock(string name, double price)
        {
            _name = name;
            _price = price;
        }

        public string Name
        {
            get { return _name; }
        }

        public double Price
        {
            get { return _price; }
            set
            {
                if (_price != value)
                {
                    _price = value;
                    Notify();
                }
            }
        }
    }
}
