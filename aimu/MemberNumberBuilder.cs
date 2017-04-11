using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aimu
{
    public static class MemberNumberBuilder
    {
        private static object locker = new object();

        private static int sn = 0;

        public static string NextBillNumber()
        {
            lock (locker)
            {
                if (sn == 99)
                    sn = 0;
                else
                    sn++;
                return DateTime.Now.ToString("yyyyMMddHHmmss") + sn.ToString().PadLeft(3, '0');
            }
        }

    }
}
