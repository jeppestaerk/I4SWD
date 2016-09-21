using System;

namespace PortioningMachine.Logs
{
    public class SimpleTextLog : TextLog
    {
        protected override void Write(string str)
        {
            var str2 = DateTime.Now + " : " + str;
            Console.WriteLine(str2);
        }
    }
}