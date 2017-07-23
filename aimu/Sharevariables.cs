using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aimu
{
    class Sharevariables
    {
        private static string loginOperatorName="";
        private static int userLevel = 0;
        private static string customerID = "";
        private static string customerName = "";
        private static string userCity = "";
        private static string userAddress = "";
        private static string userTel = "";

        private static string weddingDressID = "";
        private static string wdSize = "";
        private static Dictionary<int,OrderStatus> orderStatuses=new Dictionary<int, OrderStatus>();

        public static string WdSize
        {
            get
            {
                return wdSize;
            }

            set
            {
                wdSize = value;
            }
        }

        public static Dictionary<int,OrderStatus> OrderStatuses
        {
            get
            {
                return orderStatuses;
            }

            set
            {
                orderStatuses = value;
            }
        }
        

        public static void setWeddingDressID(string wdID)
        {
            weddingDressID = wdID;

        }

        public static string getWeddingDressID()
        {
            return weddingDressID;

        }


        public static void setUserTel(string ut)
        {
            userTel = ut;

        }

        public static string getUserTel()
        {
            return userTel;

        }


        public static void setUserAddress(string ua)
        {
            userAddress = ua;

        }
        public static string getUserAddress()
        {
            return userAddress;

        }


        public static void setUserCity(string city)
        {
            userCity = city;

        }
        public static string getUserCity()
        {
            return userCity;

        }

        public static void setCustomerName(string cName)
        {
            customerName = cName;

        }
        public static string getCustomerName()
        {
            return customerName;

        }


        public static void setCustomerID(string cid)
        {
            customerID = cid;

        }
        public static string getCustomerID()
        {
            return customerID;

        }

        public static void setUserLevel(int ul)
        {
            userLevel = ul;
        }

        public static int getUserLevel()
        {
            return userLevel;
        }

        public static void setLoginOperatorName(string lon)
        {
            loginOperatorName = lon;
        }

        public static string getLoginOperatorName()
        {
            return loginOperatorName;
        }

    }
}
