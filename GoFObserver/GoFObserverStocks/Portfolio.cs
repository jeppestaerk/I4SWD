using GoFObserver;
using System;

namespace GoFObserverStocks
{
    public class Portfolio : IGoFObserver<Stock>
    {
        private readonly string _name;

        public Portfolio(string name)
        {
            _name = name;
        }

        public void Update(Stock subject)
        {
            Console.WriteLine($"Stock {subject.Name} in Portfolio {_name} has changed value to {subject.Price}");
        }

        public void Update(GoFSubject<Stock> subject)
        {
            Console.WriteLine("Øv");
        }
    }
}
