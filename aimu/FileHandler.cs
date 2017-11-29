using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aimu
{
    class FileHandler
    {
        public static string getContent(string fileName)
        {
            string content = "";
            if (fileName != null && fileName.Length > 0)
            {
                try
                {
                    StreamReader sr = new StreamReader(fileName, Encoding.UTF8);
                    content = sr.ReadToEnd();
                }
                catch (IOException e)
                {
                    Logger.getLogger().error("Failed to read from file '" + fileName + "'" + Environment.NewLine + e.StackTrace);
                }
            }
            else
            {
                Logger.getLogger().warn("Failed to read from file. File name is null or empty string.");
            }
            return content;
        }

    }
}
