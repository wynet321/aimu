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

        public static bool createTenant(Tenant tenant, User user)
        {
            Queue<SQL> queue = new Queue<SQL>();
            SQL sql = new SQL();
            //create database
            sql.Sql = "Existing check; create database " + tenant.shardName + ";";
            queue.Enqueue(sql);
            //TODO create shard db
            sql = new SQL();
            sql.Sql = "create table test (id int not null);";
            queue.Enqueue(sql);

            sql = new SQL();
            sql.Sql = "declare @tenantId int;insert into tenant values('" + tenant.name + "','" + tenant.shardName + "'," + tenant.statusId + "," + tenant.categoryId + ",'" + tenant.createdDate + "'," + tenant.enableWorkFlow + "); set @tenantId=SCOPE_IDENTITY(); select @tenantId;";
            sql.ReturnValue = true;
            queue.Enqueue(sql);
            sql = new SQL();
            sql.Sql = "insert into [user] values(" + user.cellPhone + ",'" + user.name + "',@password,@passwordSalt,@returnedValue," + user.roleId + "," + user.storeId + ",'" + user.mail + "','" + user.memo + "')";
            SqlParameter password = new SqlParameter("@password", SqlDbType.Image);
            password.Value = user.password;
            sql.Paremeters.Add(password);
            SqlParameter passwordSalt = new SqlParameter("@passwordSalt", SqlDbType.Image);
            passwordSalt.Value = user.passwordSalt;
            sql.Paremeters.Add(passwordSalt);
            sql.UseReturnValue = true;
            queue.Enqueue(sql);


            return globalDb.save(queue);
        }

        public static bool createUser(User user)
        {
            Queue<SQL> queue = new Queue<SQL>();
            SQL sql = new SQL();
            sql.Sql = "insert into [user] values(" + user.cellPhone + ",'" + user.name + "',@password,@passwordSalt," + user.tenantId + "," + user.roleId + "," + user.storeId + ",'" + user.mail + "','" + user.memo + "')";
            sql.Paremeters = new List<SqlParameter>();
            SqlParameter password = new SqlParameter("@password", SqlDbType.Image);
            password.Value = user.password;
            sql.Paremeters.Add(password);
            SqlParameter passwordSalt = new SqlParameter("@passwordSalt", SqlDbType.Image);
            passwordSalt.Value = user.passwordSalt;
            sql.Paremeters.Add(passwordSalt);
            queue.Enqueue(sql);
            return globalDb.save(queue);

        }
        public static Data getCategories()
        {
            string sql = "select * from category";
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
            String sql = "select * from [user] where cellphone=" + cellPhone;
            Data data = globalDb.get(sql);
            if (!data.Success)
            {
                return user;
            }
            DataTable dt = data.DataTable;
            if (dt.Rows.Count > 0)
            {
                user.cellPhone = Convert.ToInt64(dt.Rows[0].ItemArray[0]);
                user.name = dt.Rows[0].ItemArray[1].ToString();
                user.password = (byte[])dt.Rows[0].ItemArray[2];
                user.passwordSalt = (byte[])dt.Rows[0].ItemArray[3];
                user.tenantId = Convert.ToUInt16(dt.Rows[0].ItemArray[4]);
                user.roleId = Convert.ToUInt16(dt.Rows[0].ItemArray[5]);
                user.storeId = Convert.ToUInt16(dt.Rows[0].ItemArray[6]);
                user.mail = dt.Rows[0].ItemArray[7].ToString();
                user.memo = dt.Rows[0].ItemArray[8].ToString();
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
                tenant.shardName = dt.Rows[0].ItemArray[2].ToString();
                tenant.statusId = Convert.ToUInt16(dt.Rows[0].ItemArray[3]);
                tenant.categoryId = Convert.ToUInt16(dt.Rows[0].ItemArray[4]);
                tenant.createdDate = DateTime.Parse(dt.Rows[0].ItemArray[5].ToString());
                tenant.enableWorkFlow = bool.Parse(dt.Rows[0].ItemArray[6].ToString());
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
