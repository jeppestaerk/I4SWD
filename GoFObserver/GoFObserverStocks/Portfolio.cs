using GoFObserver;
using System;
using System.Collections.Generic;

namespace GoFObserverStocks
{
    public class Portfolio : IGoFObserver<Stock>
    {
        private readonly string _name;
        private List<KeyVal<Stock, int>> stocksOwned = new List<KeyVal<Stock, int>>();

        public Portfolio(string name)
        {
            _name = name;
        }

        public void Update(Stock subject)
        {
            Console.WriteLine($"Stock {subject.Name} in Portfolio {_name} has changed value to {subject.Price}");
            Console.WriteLine("");
        }

        public void AddStock(Stock stock, int amout)
        {
            foreach (var KeyVal in stocksOwned)
            {
                if (KeyVal.Id == stock)
                {
                    KeyVal.Text += amout;
                    Console.WriteLine($"Stock {stock.Name} already in portfolio {_name}, added volume: {amout} new volume: {KeyVal.Text}");
                    Console.WriteLine("");
                    return;
                }
            }

            stocksOwned.Add(new KeyVal<Stock, int>(stock, amout));
            stock.Attach(this);
            Console.WriteLine($"Stock {stock.Name} is added to portfolie {_name}");
            Console.WriteLine("");


        }

        public void RemoveStock(Stock stock, int amout)
        {
            foreach (var KeyVal in stocksOwned)
            {
                if (KeyVal.Id == stock)
                {
                    if (amout < KeyVal.Text)
                    {
                        KeyVal.Text -= amout;
                        Console.WriteLine($"Stock {stock.Name} in portfolie {_name} has been reduced by {amout} to {KeyVal.Text}");
                        Console.WriteLine("");
                    }
                    else if (amout == KeyVal.Text)
                    {
                        Console.WriteLine($"Stock {stock.Name} is removed fra portfolie {_name}");
                        Console.WriteLine("");
                        stocksOwned.Remove(new KeyVal<Stock, int>(stock, amout));
                        stock.Detach(this);
                    }
                    else if (amout > KeyVal.Text)
                    {
                        Console.WriteLine(
                            $"ERROR: Remove amount ({amout}) is bigger then volume in portfolie ({KeyVal.Text})");
                        Console.WriteLine("");
                    }
                }
            }
        }

        public void print()
        {
            var portfolietotal = 0.0;
            Console.WriteLine($"Portfoile {_name} contains:");
            foreach (var KeyVal in stocksOwned)
            {
                var stockTotal = KeyVal.Id.Price * (double)KeyVal.Text;

                portfolietotal += stockTotal;

                Console.WriteLine(
                    $"{KeyVal.Text} of {KeyVal.Id.Name} at price {KeyVal.Id.Price}. total value {stockTotal}");
            }
            Console.WriteLine($"Portfolie total: {portfolietotal}");
            Console.WriteLine("");
        }

    }

    public class KeyVal<Key, Val>
    {
        public Key Id { get; set; }
        public Val Text { get; set; }

        public KeyVal() { }

        public KeyVal(Key key, Val val)
        {
            this.Id = key;
            this.Text = val;
        }
    }
}
