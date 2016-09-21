using System;

namespace DoStuff
{
    public class DoDickey : IDoThings
    {
        public void DoNothing()
        {
            Console.WriteLine("DoDickey::DoNothing()");
        }

        public int DoSomething(int number)
        {
            Console.WriteLine("DoDickey::DoSomething() : {0}", number);
            return number;
        }

        public string DoSomethingElse(string input)
        {
            Console.WriteLine("DoDickey::DoSomethingElse() : '{0}'", input);
            return "OK";
        }
    }
}