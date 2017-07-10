using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aimu
{
    class Common
    {
        private static readonly object locker = new object();
        private static int sn=0;
        public static string generateId()
        {
            lock (locker)
            {
                if (sn == 99)
                    sn = 0;
                else
                    sn++;
                return DateTime.Now.ToString("yyyyMMddHHmmss") + sn.ToString().PadLeft(4, '0');
            }
        }

        public static Boolean isAuthorized(int userPrivilege, int objectPrivilege)
        {
            int result = userPrivilege & objectPrivilege;
            if (result > 0)
            {
                return true;
            }
            return false;
        }
    }
}
