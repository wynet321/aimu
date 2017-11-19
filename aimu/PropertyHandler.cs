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
        private static string hostName = "103.53.209.42,2433";
        private static string userName = "sa";
        private static string password = "liu@879698";
        private static string dbName = "aimu_test";
        private static string globalDbConnectionString = "";
        private static string logPath = "";
        private static string logLevel = "";

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

        public static string GlobalDbConnectionString
        {
            get
            {
                return globalDbConnectionString;
            }

            set
            {
                globalDbConnectionString = value;
            }
        }

        public static string HostName
        {
            get
            {
                return hostName;
            }

            set
            {
                hostName = value;
            }
        }

        public static string UserName
        {
            get
            {
                return userName;
            }

            set
            {
                userName = value;
            }
        }

        public static string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public static string DbName
        {
            get
            {
                return dbName;
            }

            set
            {
                dbName = value;
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
                                hostName = reader.ReadString();
                                break;

                            case "Usr":
                                userName = reader.ReadString();
                                break;

                            case "Pwd":
                                password = reader.ReadString();
                                break;

                            case "DBn":
                                dbName = reader.ReadString();
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
            globalDbConnectionString = "server=" + hostName + ";uid=" + userName + ";pwd=" + password + ";database=" + dbName;
        }
    }
}