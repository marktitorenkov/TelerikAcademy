using log4net;

namespace ProjectManager.Common
{
    public class FileLogger : IFileLogger
    {
        private static ILog log;

        static FileLogger()
        {
            log = LogManager.GetLogger(typeof(FileLogger));
        }

        public void Info(object msg)
        {
            log.Info(msg);
        }

        public void Error(object msg)
        {
            log.Error(msg);
        }

        public void Fatal(object msg)
        {
            log.Fatal(msg);
        }
    }
}