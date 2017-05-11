using System;

namespace ProjectManager.Common.Providers
{
    public class ConsoleProvider : IConsoleProvider
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void Write(string val)
        {
            Console.Write(val);
        }

        public void WriteLine(string val)
        {
            Console.WriteLine(val);
        }
    }
}
