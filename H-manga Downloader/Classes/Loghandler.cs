using System;
using System.Globalization;
using System.IO;

namespace Crawler2._0.Classes
{
    internal class Loghandler
    {
        private const int LoggingLevel = 3; //1 is everything, 2 is debug, 3 is errors
        
        private static readonly object Locker = new object();

        

        public static void LogToFile(Exception exception, int level)
        {
            if (LoggingLevel <= level)
            {
                var date = DateTime.Now.ToString(CultureInfo.CurrentCulture);
                if (!Directory.Exists("Data/Errorlogs"))
                    Directory.CreateDirectory("Data/Errorlogs");

                var logText = date + " : " + exception.Message;
                lock (Locker)
                {
                    var sw = File.AppendText("Data/Errorlogs/errors.log");
                    sw.WriteLine(logText);
                    sw.Close();
                }
            }


            //Kolla den senaste filen, om den är för stor, skapa en ny.


            //
        }

        public static void LogToFile(string message, int level)
        {
            if (LoggingLevel <= level)
            {
                var date = DateTime.Now.ToString();
                if (!Directory.Exists("Data/Errorlogs"))
                    Directory.CreateDirectory("Data/Errorlogs");

                var logText = date + " : " + message;
                lock (Locker)
                {
                    StreamWriter sw;
                    sw = File.AppendText("Data/Errorlogs/errors.log");
                    sw.WriteLine(logText);
                    sw.Close();
                }
            }
            if (LoggingLevel >= level)
            {
                //Debug 
                var date = DateTime.Now.ToString();
                if (!Directory.Exists("Data/Errorlogs"))
                    Directory.CreateDirectory("Data/Errorlogs");

                var logText = date + " : " + message;
                lock (Locker)
                {
                    var sw = File.AppendText("Data/Errorlogs/Debug.log");
                    sw.WriteLine(logText);
                    sw.Close();
                }
            }


            //Kolla den senaste filen, om den är för stor, skapa en ny.


            //
        }
    }
}