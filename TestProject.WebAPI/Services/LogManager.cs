using System;
using Contracts;

namespace TestProject.WebAPI.Services
{
    /// <summary>
    /// LogManager use Nlog to log the messages.
    /// </summary>
    public class LogManager:ILogManager
    {
        private static NLog.ILogger logger = NLog.LogManager.GetCurrentClassLogger();       

        public void Debug(string message)
        {
            logger.Debug(message);
        }

        public void Error(string message)
        {
            logger.Error(message);
        }

        public void Info(string message)
        {
            logger.Info(message);
        }
    }
}
