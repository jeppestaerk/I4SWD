using Observer;
using System;
using System.Threading;
using System.Collections.Generic;

namespace PortfolioManager
{
    public class PortfolioPrinter : Observer<Portfolio> // PortfolioPrinters are observers of Portfolios
    {
        private readonly Mutex _consoleMutex = new Mutex();
        private List<Portfolio> _portfolios = new List<Portfolio>();

        private void WriteAt(string s, int top, int left)
        {
            Console.SetCursorPosition(top, left);
            Console.WriteLine(s);
        }

        public void AddPortfolio(Portfolio p)
        {
            if (_portfolios.Find(portfolio => portfolio == p) == null)
            {
                _portfolios.Add(p);
                p.Attach(this);
            }
        }

        public void Update(Portfolio p)
        {
            _consoleMutex.WaitOne();

            var portfolio = p._portfolio;
            Console.Clear();

            var i = 0;
            double total = 0;

            WriteAt("PORTFOLIO:", 0, 0);
            WriteAt("--------------------------------", 0, 1);
            for (; i < portfolio.Count; i++)
            {
                WriteAt(portfolio[i].StockName, 0, i + 2);
                WriteAt($"{portfolio[i].Value:0.00}", 20, i + 2);
                WriteAt($"{portfolio[i].Amount}", 28, i + 2);
                total += portfolio[i].Value * portfolio[i].Amount;
            }
            WriteAt("--------------------------------", 0, i + 2);
            WriteAt($@"Total value of portfolio: {Math.Round(total, 2)}", 0, i + 4);
            _consoleMutex.ReleaseMutex();
        }
    }
}
