using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aimu
{
    class GlobalDb
    {
        private static Db globalDb = new Db(PropertyHandler.GlobalDbConnectionString);

        public static Data getCategories()
        {
            string sql = "select * from catetory";
            return globalDb.get(sql);
        }

        public static Data getStatuses()
        {
            string sql = "select * from status";
            return globalDb.get(sql);
        }
        public static User getUserByCellPhone(string cellPhone)
        {
            User user = new User();
            String sql = "select * from user where cellphone=" + cellPhone;
            Data data = globalDb.get(sql);
            if (!data.Success)
            {
                return user;
            }
            DataTable dt = data.DataTable;
            if (dt.Rows.Count > 0)
            {
                user.cellPhone = Convert.ToUInt16(dt.Rows[0].ItemArray[0]);
                user.name = dt.Rows[0].ItemArray[1].ToString();
                user.password = (byte[])dt.Rows[0].ItemArray[2];
                user.passwordSalt = (byte[])dt.Rows[0].ItemArray[3];
                user.tenantId = Convert.ToUInt16(dt.Rows[0].ItemArray[4]);
                user.roleId = Convert.ToUInt16(dt.Rows[0].ItemArray[5]);
                user.storeId = Convert.ToUInt16(dt.Rows[0].ItemArray[6]);
                user.enableWorkFlow = Boolean.Parse(dt.Rows[0].ItemArray[7].ToString());
                user.address = dt.Rows[0].ItemArray[8].ToString();
                user.memo = dt.Rows[0].ItemArray[9].ToString();
            }
            return user;
        }

        public static Tenant getTenantById(int id)
        {
            Tenant tenant = new Tenant();
            String sql = "select * from tenant where id=" + id;
            Data data = globalDb.get(sql);
            if (!data.Success)
            {
                return tenant;
            }
            DataTable dt = data.DataTable;
            if (dt.Rows.Count > 0)
            {
                tenant.id = Convert.ToUInt16(dt.Rows[0].ItemArray[0]);
                tenant.name = dt.Rows[0].ItemArray[1].ToString();
                tenant.shareName = dt.Rows[0].ItemArray[2].ToString();
                tenant.statusId = Convert.ToUInt16(dt.Rows[0].ItemArray[3]);
                tenant.categoryId = Convert.ToUInt16(dt.Rows[0].ItemArray[4]);
                tenant.createdDate = DateTime.Parse(dt.Rows[0].ItemArray[5].ToString());
                tenant.mail = dt.Rows[0].ItemArray[6].ToString();
            }
            return tenant;
        }

        public static Data getTenants()
        {
            string sql = "select t.id,t.name,t.shardName,s.name,c.name,t.createdDate,t.mail,t.statusId,t.categoryid from tenant as t inner join status as s on tenant.statusId=status.id inner join category as c on tenant.categoryid=category.id";
            return globalDb.get(sql);
        }
    }
}
