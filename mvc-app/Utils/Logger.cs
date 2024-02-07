using NLog;

namespace mvc_app.Utils
{
    public static class Logger
    {
        private static NLog.ILogger _logger = LogManager.GetCurrentClassLogger();


        static Logger()
        {
            LogManager.Setup().LoadConfigurationFromFile(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
        }

        public static void Trace(string message)
        {
            _logger.Trace(message);
        }

        public static void Info(string msg)
        {
            _logger.Info(msg);
        }

        public static void Warn(string msg)
        {
            _logger.Warn(msg);
        }

        public static void Error(string msg)
        {
            _logger.Error(msg);
        }

        public static void Fatal (string msg)
        {
            _logger.Fatal(msg);
        }

    }

}
