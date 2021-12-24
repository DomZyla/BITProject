using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDrivers
{
    class Logging
    {
        
        // Three type of logging can be done, file, db ,event
    }

    public enum LogTarget
    { 
        File,Database,EventLog
    }

    abstract class LogBase
    {
        public abstract void Log(string message);
    }

    class FileLogger : LogBase
    {
        string fileName = "C:\\Temp\\myLog2.txt";

        public override void Log(string message)
        {
            using (StreamWriter writer = new StreamWriter(fileName, true))
            {
                writer.WriteLine(DateTime.Now.ToString() + ": " + message);
                writer.Close();
            }
        }
    }

    class DBLogger : LogBase    {

        public override void Log(string message)
        {
            throw new NotImplementedException();
        }
    }

    class EventLogger : LogBase
    {

        public override void Log(string message)
        {
            throw new NotImplementedException();
        }
    }

    public static class LogHelper
    {
        private static LogBase logger = null;

        public static void Log(LogTarget target, string message)
        {
            switch (target)
            {
                case LogTarget.File:
                    logger = new FileLogger();
                    logger.Log(message);
                    break;

                case LogTarget.Database:
                    logger = new DBLogger();
                    logger.Log(message);
                    break;

                case LogTarget.EventLog:
                    logger = new EventLogger();
                    logger.Log(message);
                    break;
            }
        }
    }


}
