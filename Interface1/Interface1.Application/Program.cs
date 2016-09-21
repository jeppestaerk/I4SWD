namespace Interface1.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            IDoThings doHickey = new DoHickey();

            doHickey.DoNothing();
            doHickey.DoSomething(7);
            doHickey.DoSomethingElse("John Doe");

            IDoThings doDickey = new DoDickey();

            doDickey.DoNothing();
            doDickey.DoSomething(7);
            doDickey.DoSomethingElse("John Doe");
        }
    }
}
