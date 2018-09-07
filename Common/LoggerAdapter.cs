using System;
using NLog;

namespace Common
{
    public class LoggerAdapter
    {
        #region singleton
        private static LoggerAdapter instance = null;
        private static readonly object padlock = new object();
        NLog.Logger logger;
        NLog.Logger dbLogger;
        LoggerAdapter()
        {
            logger = NLog.LogManager.GetCurrentClassLogger();
            dbLogger = LogManager.GetLogger("databaseLogger");
        }

        public static LoggerAdapter Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new LoggerAdapter();
                    }
                    return instance;
                }
            }
        }
        #endregion

        public void Error(Exception ex, string ctx = null)
        {
            logger.Error(ex);
            dbLogger.Error(ex);
        }

        public void HttpError(Exception ex, string ctx = null)
        {
            logger.Error(ex);
        }

        public void Info(string log)
        {
            logger.Info(log);
        }

        public void Debug(string log)
        {
            logger.Debug(log);
        }
    }
}
