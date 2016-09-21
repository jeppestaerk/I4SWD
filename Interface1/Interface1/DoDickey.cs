using System;

namespace Interface1
{
    public class DoDickey : IDoThings
    {
        public void DoNothing()
        {
            Console.WriteLine("DoDickey::DoNothing()");
        }

        public int DoSomething(int number)
        {
            Console.WriteLine($"DoDickey::DoSomething() : {number}");
            return number;
        }

        public string DoSomethingElse(string input)
        {
            Console.WriteLine($"DoDickey::DoSomethingElse() : {input}");
            return input;
        }
    }
}
