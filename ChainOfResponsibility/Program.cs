using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    enum LogLevel
    {
        None = 0,                 //        0
        Info = 1,                 //        1
        Debug = 2,                //       10
        Warning = 4,              //      100
        Error = 8,                //     1000
        FunctionalMessage = 16,   //    10000
        FunctionalError = 32,     //   100000
        All = 63                  //   111111
    }
    abstract class Logger
    {
        protected LogLevel logMask;
        protected Logger next;
        public Logger(LogLevel mask)
        {
            logMask = mask;
        }
        public Logger SetNext(Logger nextLogger)
        {
            Logger lastLogger = this;
            while(lastLogger.next != null)
            {
                lastLogger = lastLogger.next;
            }
            lastLogger.next = nextLogger;
            return this;
        }
        public void Message(string msg, LogLevel severity)
        {
            if ((severity & logMask) != 0) // True only if any of the logMask bits are set in severity
            {
                WriteMessage(msg);
            }            
            if (next != null)
            {
                next.Message(msg, severity);
            }
        }
        abstract protected void WriteMessage(string msg);
    }
    class ConsoleLogger : Logger
    {
        public ConsoleLogger(LogLevel mask)
            : base(mask)
        { }

        protected override void WriteMessage(string msg)
        {
            Console.WriteLine("Writing to console: " + msg);
        }
    }

    class EmailLogger : Logger
    {
        public EmailLogger(LogLevel mask)
            : base(mask)
        { }

        protected override void WriteMessage(string msg)
        {
            // Placeholder for mail send logic, usually the email configurations are saved in config file.
            Console.WriteLine("Sending via email: " + msg);
        }
    }

    class FileLogger : Logger
    {
        public FileLogger(LogLevel mask)
            : base(mask)
        { }

        protected override void WriteMessage(string msg)
        {
            // Placeholder for File writing logic
            Console.WriteLine("Writing to Log File: " + msg);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Logger logger;
            logger = new ConsoleLogger(LogLevel.All)
                             .SetNext(new EmailLogger(LogLevel.Debug))
                             .SetNext(new FileLogger(LogLevel.Debug));
            
            logger.Message("Entering function ProcessOrder().", LogLevel.Debug);

            Console.ReadKey();
        }
    }
}
