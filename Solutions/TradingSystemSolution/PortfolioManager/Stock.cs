using System;
using System.Threading;
using Observer;


namespace PortfolioManager
{
    public class Stock : Subject<Stock> // Stocks are subjects
    {
        public string Name { get; set; }
        private readonly Random _random;
        private const int UpdateValueRange = 5;

        private double _value;
        public double Value
        {
            get { return _value; }
            set
            {
                if(value != _value)
                {
                    _value = value;
                    NotifyObservers();
                }
            }
        }

        public Stock()
        {
            _random = new Random(Guid.NewGuid().GetHashCode());
            _value = 0;
        }

        // This method is meant to be run in a thread
        public void Runner()
        {
            while(true)
            {
                Value = Value + (double)_random.Next(-UpdateValueRange, UpdateValueRange) / 100 * Value;
                Thread.Sleep(1000);
            }
        }
    }
}
