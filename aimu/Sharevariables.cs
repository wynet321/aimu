using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aimu
{
    class Sharevariables
    {
        private static string loginOperatorName = "";
        private static int userLevel = 0;
        private static string customerID = "";
        private static string customerName = "";
        private static Dictionary<int, String> customerChannels = new Dictionary<int, string>();
        private static Dictionary<int, String> customerCities = new Dictionary<int, string>();
        private static Dictionary<int, string> customerStatuses = new Dictionary<int, string>();
        private static int storeId = 0;
        private static string userAddress = "";
        private static string userTel = "";
        private static string weddingDressID = "";
        private static string wdSize = "";
        private static Dictionary<int, OrderStatus> orderStatuses = new Dictionary<int, OrderStatus>();
        private static bool enableWorkFlow=false;

        public static void reset()
        {
            loginOperatorName = "";
            userLevel = 0;
            customerID = "";
            customerName = "";
            //defaultStoreId = 0;
            storeId = 0;
            userAddress = "";
            userTel = "";
            weddingDressID = "";
            wdSize = "";
            orderStatuses = new Dictionary<int, OrderStatus>();
            customerChannels = new Dictionary<int, string>();
         customerCities = new Dictionary<int, string>();
         customerStatuses = new Dictionary<int, string>();
    }

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

        public static Dictionary<int, OrderStatus> OrderStatuses
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

        //public static int DefaultStoreId
        //{
        //    get
        //    {
        //        return defaultStoreId;
        //    }

        //    set
        //    {
        //        defaultStoreId = value;
        //    }
        //}

        public static int StoreId
        {
            get
            {
                return storeId;
            }

            set
            {
                storeId = value;
            }
        }

        public static string LoginOperatorName
        {
            get
            {
                return loginOperatorName;
            }

            set
            {
                loginOperatorName = value;
            }
        }

        public static int UserLevel
        {
            get
            {
                return userLevel;
            }

            set
            {
                userLevel = value;
            }
        }

        public static string CustomerID
        {
            get
            {
                return customerID;
            }

            set
            {
                customerID = value;
            }
        }

        public static string CustomerName
        {
            get
            {
                return customerName;
            }

            set
            {
                customerName = value;
            }
        }

        public static string UserAddress
        {
            get
            {
                return userAddress;
            }

            set
            {
                userAddress = value;
            }
        }

        public static string UserTel
        {
            get
            {
                return userTel;
            }

            set
            {
                userTel = value;
            }
        }

        public static string WeddingDressID
        {
            get
            {
                return weddingDressID;
            }

            set
            {
                weddingDressID = value;
            }
        }

        public static Dictionary<int, string> CustomerChannels
        {
            get
            {
                return customerChannels;
            }

            set
            {
                customerChannels = value;
            }
        }

        public static Dictionary<int, string> CustomerCities
        {
            get
            {
                return customerCities;
            }

            set
            {
                customerCities = value;
            }
        }

        public static Dictionary<int, string> CustomerStatuses
        {
            get
            {
                return customerStatuses;
            }

            set
            {
                customerStatuses = value;
            }
        }

        public static bool EnableWorkFlow
        {
            get
            {
                return enableWorkFlow;
            }

            set
            {
                enableWorkFlow = value;
            }
        }

        //public static void setWeddingDressID(string wdID)
        //{
        //    weddingDressID = wdID;

        //}

        //public static string getWeddingDressID()
        //{
        //    return weddingDressID;

        //}


        //public static void setUserTel(string ut)
        //{
        //    userTel = ut;

        //}

        //public static string getUserTel()
        //{
        //    return userTel;

        //}


        //public static void setUserAddress(string ua)
        //{
        //    userAddress = ua;

        //}
        //public static string getUserAddress()
        //{
        //    return userAddress;

        //}


        //public static void setUserStoreId(int id)
        //{
        //    storeId = id;

        //}
        //public static int getUserStoreId()
        //{
        //    return storeId;

        //}

        //public static void setCustomerName(string cName)
        //{
        //    customerName = cName;

        //}
        //public static string getCustomerName()
        //{
        //    return customerName;

        //}


        //public static void setCustomerID(string cid)
        //{
        //    customerID = cid;

        //}
        //public static string getCustomerID()
        //{
        //    return customerID;

        //}

        //public static void setUserLevel(int ul)
        //{
        //    userLevel = ul;
        //}

        //public static int getUserLevel()
        //{
        //    return userLevel;
        //}

        //public static void setLoginOperatorName(string lon)
        //{
        //    loginOperatorName = lon;
        //}

        //public static string getLoginOperatorName()
        //{
        //    return loginOperatorName;
        //}

    }
}
