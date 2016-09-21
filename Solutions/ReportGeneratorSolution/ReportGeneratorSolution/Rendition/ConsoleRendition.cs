using System;

namespace ReportGenerator.Rendition
{
    public class ConsoleRendition : IRendition
    {
        public void Render(string l)
        {
            Console.WriteLine(l);
        }
    }
}