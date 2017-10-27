using System;
using System.IO;
using System.Text;

namespace aimu
{
    class Logger
    {
        private LogLevel level;
        private static Logger logger;
        private string path;
        private StringBuilder buffer;
        public static Logger getLogger()
        {
            if (logger == null)
            {
                logger = new Logger();
                logger.level = (LogLevel)Enum.Parse(typeof(LogLevel), PropertyHandler.LogLevel);
                logger.path = PropertyHandler.LogPath;
                logger.buffer = new StringBuilder();
            }
            return logger;
        }
        private void print(string text, LogLevel level)
        {
            if (level >= this.level)
            {
                write(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + " - " + text + System.Environment.NewLine, false);
            }
        }

        public void error(string text)
        {
            print(text, LogLevel.ERROR);
        }

        public void info(string text)
        {
            print(text, LogLevel.INFO);
        }

        public void warn(string text)
        {
            print(text, LogLevel.WARN);
        }

        private void write(string text, bool isClose)
        {
            StreamWriter sw;
            buffer.Append(text);
            if (buffer.Length > 1024 || isClose)
            {
                if (File.Exists(path))
                {
                    FileInfo info = new FileInfo(logger.path);
                    if (info.Length > 4000)
                    {
                        sw = new StreamWriter(path, false, Encoding.UTF8);
                    }
                    else
                    {
                        sw = new StreamWriter(path, true, Encoding.UTF8);
                    }
                    sw.Write(text);
                    sw.Flush();
                    sw.Close();
                    buffer.Clear();
                }
                else
                {
                    sw = new StreamWriter(path, true, Encoding.UTF8);
                    sw.Write(text);
                    sw.Flush();
                    sw.Close();
                    buffer.Clear();
                }
            }
        }
        public void close()
        {
            write("", true);
        }

    }
}
