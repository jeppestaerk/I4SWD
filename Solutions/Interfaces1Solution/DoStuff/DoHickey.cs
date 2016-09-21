using System;

namespace DoStuff
{
    public class DoHickey : IDoThings
    {
        public void DoNothing()
        {
            Console.WriteLine("DoHickey::DoNothing()");
        }

        public int DoSomething(int number)
        {
            Console.WriteLine("DoHickey::DoSomething() : {0}", number);
            return number;
        }

        public string DoSomethingElse(string input)
        {
            Console.WriteLine("DoHickey::DoSomethingElse() : '{0}'", input);
            return "OK";
        }
    }
}