namespace ProjectManager.Common.Providers
{
    public interface IConsoleProvider
    {
        string ReadLine();

        void Write(string val);

        void WriteLine(string val);
    }
}