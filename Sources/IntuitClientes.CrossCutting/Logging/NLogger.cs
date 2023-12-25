using NLog;

namespace IntuitClientes.CrossCutting.Logging
{
    public class NLogger : ILog, ILoggingManager
    {
        private static ILogger _logger = LogManager.GetCurrentClassLogger();

        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public NLogger()
        {
        }

        public void Info(string message)
        {
            _logger.Info(message);
        }

        public void Warn(string message)
        {
            _logger.Warn(message);
        }

        public void Debug(string message)
        {
            _logger.Debug(message);
        }

        public void Error(string message)
        {
            _logger.Error(message);
        }

        public void Info(string message, Exception e)
        {
            _logger.Info(e, message);
        }

        public void Warn(string message, Exception e)
        {
            _logger.Warn(e, message);
        }

        public void Debug(string message, Exception e)
        {
            _logger.Debug(e, message);
        }

        public void Error(string message, Exception e)
        {
            _logger.Error(e, message);
        }

        public void Fatal(string message)
        {
            throw new NotImplementedException();
        }

        public void Trace(string message)
        {
            throw new NotImplementedException();
        }

        public void Trace(string message, Exception ex)
        {
            throw new NotImplementedException();
        }
    }
}
