using System.Collections.Generic;
using System.Threading;
using PortfolioManager;

namespace ConsoleApplication1
{
    class Program
    {
        private static List<Stock> _stocks;
        private static List<Thread> _stockThreads;
        private static Portfolio _portfolio;
        private static PortfolioPrinter _printer;

        private static void Init()
        {
            _stocks = new List<Stock>();
            _stockThreads = new List<Thread>();
            _portfolio = new Portfolio();
            _printer = new PortfolioPrinter();
            _printer.AddPortfolio(_portfolio);
        }

        static void Main(string[] args)
        {
            Init();
            CreateStock("Vestas", 100);
            CreateStock("Bang & Olufsen", 30);
            CreateStock("Bang & Olufsen", 30);
            CreateStock("Bang & Olufsen", 30);
            CreateStock("Siemens", 90);
            CreateStock("Siemens", 98);
            CreateStock("Wanker, inc.", 200);


            foreach (var stock in _stocks)
            {
                _stockThreads.Add(new Thread(new ThreadStart(stock.Runner)));
                _stockThreads[_stockThreads.Count - 1].Start();
                _portfolio.AddStock(stock);
            }


            Thread.Sleep(1000000);

            foreach (var stock in _stockThreads)
            {
                stock.Abort();
            }
        }

        private static void CreateStock(string name, int val)
        {
            _stocks.Add(new Stock() { Name = name, Value = val });
        }
    }
}
