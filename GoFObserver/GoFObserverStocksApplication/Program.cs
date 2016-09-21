using GoFObserverStocks;

namespace GoFObserverStocksApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Portfolio johnDoePortfolio = new Portfolio("John");
            Portfolio richardRoePortfolio = new Portfolio("Richard");
            Stock hugoStock = new Stock("Hugo", 1.50);

            hugoStock.Attach(johnDoePortfolio);
            hugoStock.Attach(richardRoePortfolio);

            hugoStock.Price = 1.55;
            hugoStock.Price = 1.60;

            hugoStock.Detach(richardRoePortfolio);

            Stock oswalStock = new Stock("Oswal", 0.50);

            oswalStock.Attach(richardRoePortfolio);

            oswalStock.Price = 2.50;

            oswalStock.Attach(johnDoePortfolio);

            oswalStock.Price = 3.45;
        }
    }
}
