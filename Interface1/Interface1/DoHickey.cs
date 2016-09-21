using System;

namespace Interface1
{
    public class DoHickey : IDoThings
    {
        public void DoNothing()
        {
            Console.WriteLine("DoHickey::DoNothing()");
        }

        public int DoSomething(int number)
        {
            Console.WriteLine($"DoHickey::DoSomething() : {number}");
            return number;
        }

        public string DoSomethingElse(string input)
        {
            Console.WriteLine($"DoHickey::DoSomethingElse() : {input}");
            return input;
        }
    }
}
