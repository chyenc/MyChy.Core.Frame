﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace MyChy.Core.Frame.Common.Helper
{
    public class LogHelper
    {
        private static readonly Logger ILog = null;

        static LogHelper()
        {

            //Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            //Func<string, LogLevel, bool> filter = (category, level) => true;
            //loggerFactory = new LoggerFactory();
            //loggerFactory.AddProvider(new ConsoleLoggerProvider(filter, false));
            //loggerFactory.AddProvider(new DebugLoggerProvider(filter));
            //ILogger logger = loggerFactory.CreateLogger("App");
            //LogManager.
            ILog = LogManager.GetCurrentClassLogger();
        }

        /// <summary>
        /// 写日志，默认级别是 LogLevel.Error
        /// </summary>
        /// <param name="message">写日志的内容</param>
        public static void LogError(string message)
        {
            ILog.Error(message);
        }

        /// <summary>
        /// 写日志，默认级别是 LogLevel.Error
        /// </summary>
        /// <param name="message">写日志的内容</param>
        public static void LogInfo(string message)
        {
            ILog.Info(message);
        }

        /// <summary>
        /// 写日志，默认日志级别是 LogLevel.Error。会根据异常的类型来判断是否发送通知邮件
        /// </summary>
        /// <param name="exception">异常信息</param>
        public static void Log(Exception exception)
        {
            ILog.Error(exception);
        }

    }
}
