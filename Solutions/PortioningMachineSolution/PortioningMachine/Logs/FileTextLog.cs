using System.IO;

namespace PortioningMachine.Logs
{
    public class FileTextLog : TextLog
    {
        private readonly string _filename;

        public FileTextLog(string fn)
        {
            _filename = fn;
            Write("\n\n***** LOG STARTED *****");
        }

        protected override void Write(string str)
        {
            var writer = new StreamWriter(_filename, true);
            writer.WriteLine(str);
            writer.Close();
        }
    }
}