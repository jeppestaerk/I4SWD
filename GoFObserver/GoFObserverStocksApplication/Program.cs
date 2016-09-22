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
            Stock oswalStock = new Stock("Oswal", 0.50);

            johnDoePortfolio.AddStock(hugoStock, 10);
            johnDoePortfolio.AddStock(oswalStock, 7);

            richardRoePortfolio.AddStock(oswalStock, 15);
            richardRoePortfolio.AddStock(hugoStock, 15);

            johnDoePortfolio.print();
            richardRoePortfolio.print();

            hugoStock.Price = 1.55;
            oswalStock.Price = 2.50;

            johnDoePortfolio.print();
            richardRoePortfolio.print();

            johnDoePortfolio.RemoveStock(oswalStock, 50);
            johnDoePortfolio.RemoveStock(oswalStock, 7);
            johnDoePortfolio.AddStock(hugoStock, 10);
            richardRoePortfolio.RemoveStock(hugoStock, 4);

            hugoStock.Price = 1.60;
            oswalStock.Price = 3.45;

            johnDoePortfolio.print();
            richardRoePortfolio.print();
            
        }
    }
}
