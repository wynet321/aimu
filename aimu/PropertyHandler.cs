using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace aimu
{
    class PropertyHandler
    {
        // init connection reference
        private static string IP = "103.53.209.42,2433";
        private static string Usr = "sa";
        private static string Pwd = "liu@879698";
        private static string DBn = "aimu_test";
        private static string dbConnectionString = "";
        private static string logPath = "";
        private static string logLevel = "";

        public static string DbConnectionString
        {
            get
            {
                return dbConnectionString;
            }

            set
            {
                dbConnectionString = value;
            }
        }

        public static string LogPath
        {
            get
            {
                return logPath;
            }

            set
            {
                logPath = value;
            }
        }

        public static string LogLevel
        {
            get
            {
                return logLevel;
            }

            set
            {
                logLevel = value;
            }
        }

        public static void getEnvProperties()
        {
            using (XmlReader reader = XmlReader.Create(Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + "\\aimu.xml"))
            {
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        switch (reader.Name.ToString())
                        {
                            case "IP":
                                IP = reader.ReadString();
                                break;

                            case "Usr":
                                Usr = reader.ReadString();
                                break;

                            case "Pwd":
                                Pwd = reader.ReadString();
                                break;

                            case "DBn":
                                DBn = reader.ReadString();
                                break;
                            case "logLevel":
                                logLevel = reader.ReadString();
                                break;
                            case "logPath":
                                logPath = reader.ReadString();
                                break;
                        }
                    }

                }
                reader.Close();
            }
            dbConnectionString = "server=" + IP + ";uid=" + Usr + ";pwd=" + Pwd + ";database=" + DBn;
        }
    }
}