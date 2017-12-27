using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aimu
{
    class GlobalDb
    {
        private static Db globalDb = new Db(PropertyHandler.GlobalDbConnectionString);

        public static bool createTenant(Tenant tenant, User user)
        {
            int count = getUserCountByCellPhone(user.cellPhone);
            if (count > 0)
            {
                MessageBox.Show("此手机号码已经注册过，请选择其他手机号码注册");
                return false;
            }
            string sql = "select count(*) from sys.databases where name='" + tenant.shardName + "'";
            Data data = globalDb.get(sql);
            if (!data.Success)
            {
                Logger.getLogger().error("查询数据库失败！" + System.Environment.NewLine + "SQL: " + sql);
                return false;
            }
            int dbCount = Convert.ToInt16(data.DataTable.Rows[0].ItemArray[0]);
            if (dbCount == 0)
            {
                Queue<Statement> queue = new Queue<Statement>();
                Statement statement = new Statement("create database " + tenant.shardName);
                globalDb.save(statement);
                statement = new Statement();
                statement.Sql = FileHandler.getContent("./Database/ShardDb.sql");
                statement.Sql = statement.Sql.Replace("[dbo].", tenant.shardName + ".[dbo].");
                queue.Enqueue(statement);
                statement = new Statement();
                statement.Sql = "declare @tenantId int;insert into tenant values('" + tenant.name + "','" + tenant.shardName + "'," + tenant.statusId + "," + tenant.categoryId + ",'" + tenant.createdDate + "'," + (tenant.enableWorkFlow ? 1 : 0) + "); set @tenantId=SCOPE_IDENTITY(); select @tenantId;insert into [user] values('" + user.cellPhone + "','" + user.name + "',@password,@passwordSalt,@tenantId," + user.roleId + "," + user.storeId + ",'" + user.mail + "','" + user.memo + "'," + (user.active ? 1 : 0) + ")";
                statement.Paremeters = new List<SqlParameter>();
                SqlParameter password = new SqlParameter("@password", SqlDbType.Image);
                password.Value = user.password;
                statement.Paremeters.Add(password);
                SqlParameter passwordSalt = new SqlParameter("@passwordSalt", SqlDbType.Image);
                passwordSalt.Value = user.passwordSalt;
                statement.Paremeters.Add(passwordSalt);
                queue.Enqueue(statement);
                return globalDb.save(queue);
            }
            else
            {
                Logger.getLogger().error("数据库已经存在！" + System.Environment.NewLine + "Shard Db Name: " + tenant.shardName);
                return false;
            }
        }

        public static bool deleteTenant(int tenantId)
        {
            Tenant tenant = getTenantById(tenantId);
            if (tenant.id == 0)
            {
                return false;
            }
            Statement statement = new Statement("ALTER DATABASE " + tenant.shardName + " SET SINGLE_USER WITH ROLLBACK IMMEDIATE; drop database " + tenant.shardName);
            int count = globalDb.save(statement);
            Queue<Statement> queue = new Queue<Statement>();
            statement = new Statement("delete from [user] where tenantid=" + tenantId);
            queue.Enqueue(statement);
            statement = new Statement("delete from tenant where id=" + tenantId);
            queue.Enqueue(statement);
            return globalDb.save(queue);
        }
        public static bool updateTenant(Tenant tenant, User user)
        {
            Queue<Statement> queue = new Queue<Statement>();
            Statement statement = new Statement();
            statement.Sql = "update [user] set cellphone='" + user.cellPhone + "', name='" + user.name + "', password=@password,passwordSalt=@passwordSalt,mail='" + user.mail + "',memo='" + user.memo + "' where id=" + user.id;
            statement.Paremeters = new List<SqlParameter>();
            SqlParameter password = new SqlParameter("@password", SqlDbType.Image);
            password.Value = user.password;
            statement.Paremeters.Add(password);
            SqlParameter passwordSalt = new SqlParameter("@passwordSalt", SqlDbType.Image);
            passwordSalt.Value = user.passwordSalt;
            statement.Paremeters.Add(passwordSalt);
            queue.Enqueue(statement);
            statement = new Statement();
            statement.Sql = "update tenant set name='" + tenant.name + "', statusId=" + tenant.statusId + ", categoryId=" + tenant.categoryId + ", enableWorkFlow=" + (tenant.enableWorkFlow ? 1 : 0) + " where id=" + tenant.id;
            queue.Enqueue(statement);
            return globalDb.save(queue);
        }

        public static bool createUser(User user)
        {
            Queue<Statement> queue = new Queue<Statement>();
            Statement sql = new Statement();
            sql.Sql = "insert into [user] values('" + user.cellPhone + "','" + user.name + "',@password,@passwordSalt," + user.tenantId + "," + user.roleId + "," + user.storeId + ",'" + user.mail + "','" + user.memo + "'," + (user.active ? 1 : 0) + ")";
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

        public static Data getRoles()
        {
            string sql = "select * from [role]";
            return globalDb.get(sql);
        }

        public static Data getStatuses()
        {
            string sql = "select * from status";
            return globalDb.get(sql);
        }

        public static int getUserCountByCellPhone(string cellPhone)
        {
            String sql = "select * from [user] where cellphone=" + cellPhone;
            Data data = globalDb.get(sql);
            if (!data.Success)
            {
                return 0;
            }
            return data.DataTable.Rows.Count;
        }
        public static User getUserByCellPhone(string cellPhone)
        {
            User user = new User();
            String sql = "select id,cellphone,name,password,passwordSalt,tenantId,roleId,storeId,mail,memo from [user] where cellphone=" + cellPhone;
            Data data = globalDb.get(sql);
            if (!data.Success)
            {
                return user;
            }
            DataTable dt = data.DataTable;
            if (dt.Rows.Count > 0)
            {
                user.id = Convert.ToInt16(dt.Rows[0].ItemArray[0]);
                user.cellPhone = dt.Rows[0].ItemArray[1].ToString();
                user.name = dt.Rows[0].ItemArray[2].ToString();
                user.password = (byte[])dt.Rows[0].ItemArray[3];
                user.passwordSalt = (byte[])dt.Rows[0].ItemArray[4];
                user.tenantId = Convert.ToInt32(dt.Rows[0].ItemArray[5]);
                user.roleId = Convert.ToUInt16(dt.Rows[0].ItemArray[6]);
                user.storeId = Convert.ToUInt16(dt.Rows[0].ItemArray[7]);
                user.mail = dt.Rows[0].ItemArray[8].ToString();
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
                tenant.id = Convert.ToInt32(dt.Rows[0].ItemArray[0]);
                tenant.name = dt.Rows[0].ItemArray[1].ToString();
                tenant.shardName = dt.Rows[0].ItemArray[2].ToString();
                tenant.statusId = Convert.ToUInt16(dt.Rows[0].ItemArray[3]);
                tenant.categoryId = Convert.ToUInt16(dt.Rows[0].ItemArray[4]);
                tenant.createdDate = DateTime.Parse(dt.Rows[0].ItemArray[5].ToString());
                tenant.enableWorkFlow = bool.Parse(dt.Rows[0].ItemArray[6].ToString());
            }
            return tenant;
        }

        public static User getUserByTenantId(int id)
        {
            User user = new User();
            String sql = "select * from [user] where tenantId=" + id;
            Data data = globalDb.get(sql);
            if (!data.Success)
            {
                return user;
            }
            DataTable dt = data.DataTable;
            if (dt.Rows.Count > 0)
            {
                user.id = Convert.ToInt16(dt.Rows[0].ItemArray[0]);
                user.cellPhone = dt.Rows[0].ItemArray[1].ToString();
                user.name = dt.Rows[0].ItemArray[2].ToString();
                user.password = (byte[])dt.Rows[0].ItemArray[3];
                user.passwordSalt = (byte[])dt.Rows[0].ItemArray[4];
                user.tenantId = Convert.ToInt32(dt.Rows[0].ItemArray[5]);
                user.roleId = Convert.ToUInt16(dt.Rows[0].ItemArray[6]);
                user.storeId = Convert.ToUInt16(dt.Rows[0].ItemArray[7]);
                user.mail = dt.Rows[0].ItemArray[8].ToString();
                user.memo = dt.Rows[0].ItemArray[9].ToString();
            }
            return user;
        }

        public static Data getTenants(int status, int category, string cellphone, string name)
        {
            StringBuilder whereClauseBuilder = new StringBuilder(" where 1=1 ");
            if (status != 0)
            {
                whereClauseBuilder.Append(" and s.id=").Append(status);
            }

            if (category != 0)
            {
                whereClauseBuilder.Append(" and c.id=").Append(category);
            }

            if (cellphone.Length > 0)
            {
                whereClauseBuilder.Append(" and u.cellphone=").Append(cellphone);
            }

            if (name.Length > 0)
            {
                whereClauseBuilder.Append(" and t.name=").Append(name);
            }

            string sql = "select t.id,t.name,t.shardName,s.name,c.name,t.createdDate,t.statusId,t.categoryid,t.enableWorkFlow from tenant as t inner join status as s on t.statusId=s.id inner join category as c on t.categoryid=c.id inner join [user] as u on t.id=u.tenantid " + whereClauseBuilder.ToString();
            return globalDb.get(sql);
        }

        private static string getShardName(int tenantId)
        {
            string sql = "select shardName from tenant where id=" + tenantId;
            Data tenant = globalDb.get(sql);
            if (!tenant.Success)
            {
                return "";
            }
            return tenant.DataTable.Rows[0].ItemArray[0].ToString();
        }
        public static Data getUsers(int tenantId, int roleId, string cellphone, string name)
        {
            string shardName = getShardName(tenantId);
            if (shardName.Length == 0)
            {
                Data data = new Data();
                data.Success = false;
                return data;
            }
            StringBuilder whereClauseBuilder = new StringBuilder(" where tenantId=" + tenantId);
            if (roleId != 0)
            {
                whereClauseBuilder.Append(" and u.roleId=").Append(roleId);
            }

            if (cellphone.Length > 0)
            {
                whereClauseBuilder.Append(" and u.cellphone='").Append(cellphone).Append("'");
            }

            if (name.Length > 0)
            {
                whereClauseBuilder.Append(" and u.name='").Append(name).Append("'");
            }
            string sql = "select u.id, u.active, u.cellphone, u.name, u.password, u.passwordSalt,u.roleId, r.name, u.storeId,c.name, s.name, u.mail, u.memo from [user] as u inner join [role] as r on r.id=u.roleId left join " + shardName + ".dbo.customerStore as s on s.id=u.storeId left join " + shardName + ".dbo.customerCity as c on c.id=s.cityId " + whereClauseBuilder.ToString();
            return globalDb.get(sql);
        }

        public static User getUser(int id)
        {
            string sql = "select * from [user] where id=" + id;
            Data data = globalDb.get(sql);
            User user = new User();
            if (!data.Success)
            {
                return user;
            }
            DataRow row = data.DataTable.Rows[0];
            user.active = Boolean.Parse(row["active"].ToString());
            user.cellPhone = row["cellphone"].ToString();
            user.id = Convert.ToInt16(row["id"]);
            user.mail = row["mail"].ToString();
            user.memo = row["memo"].ToString();
            user.name = row["name"].ToString();
            user.password = (byte[])row["password"];
            user.passwordSalt = (byte[])row["passwordSalt"];
            user.roleId = Convert.ToInt16(row["roleId"]);
            user.storeId = Convert.ToInt16(row["storeId"]);
            user.tenantId = Convert.ToInt32(row["tenantId"]);
            return user;
        }

        public static bool deleteUser(int id)
        {
            Statement statement = new Statement("delete from [user] where id=" + id);
            return (globalDb.save(statement) == 1) ? true : false;
        }

        public static bool updateUser(User user)
        {
            Statement statement = new Statement("update [user] set cellphone='" + user.cellPhone + "', name='" + user.name + "',password=@password,passwordSalt=@passwordSalt, roleId=" + user.roleId + ",storeId=" + user.storeId + ",mail='" + user.mail + "',memo='" + user.memo + "',active=" + (user.active ? 1 : 0) + " where id=" + user.id);
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("password", user.password));
            parameters.Add(new SqlParameter("passwordSalt", user.passwordSalt));
            statement.Paremeters = parameters;
            return (globalDb.save(statement) == 1) ? true : false;
        }
        //public static Data getStores(int tenantId)
        //{
        //    string shardName = getShardName(tenantId);
        //    if (shardName.Length == 0)
        //    {
        //        Data data = new Data();
        //        data.Success = false;
        //        return data;
        //    }
        //    string sql = "select * from "+shardName+".dbo.customerStore";
        //    return globalDb.get(sql);
        //}
    }
}
