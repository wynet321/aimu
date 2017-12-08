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
            string sql = "select count(*) from [user] where cellphone=" + user.cellPhone;
            Data data = globalDb.get(sql);
            int userCount = Convert.ToInt16(data.DataTable.Rows[0].ItemArray[0]);
            if (userCount > 0)
            {
                Logger.getLogger().error("用户手机已经注册过！" + System.Environment.NewLine + "Cellphone: " + user.cellPhone);
                return false;
            }
            sql = "select count(*) from sys.databases where name='" + tenant.shardName + "'";
            data = globalDb.get(sql);
            if (!data.Success)
            {
                Logger.getLogger().error("查询数据库失败！" + System.Environment.NewLine + "SQL: " + sql);
                return false;
            }
            int dbCount = Convert.ToInt16(data.DataTable.Rows[0].ItemArray[0]);
            if (dbCount == 0)
            {
                Queue<MultipleDbSql> queue = new Queue<MultipleDbSql>();
                MultipleDbSql multipleDbSql;
                Statement statement;
                statement = new Statement("create database " + tenant.shardName);
                globalDb.save(statement);
                multipleDbSql = new MultipleDbSql();
                statement = new Statement();
                statement.Sql = FileHandler.getContent("./Database/ShardDb.sql");
                multipleDbSql.Statement = statement;
                multipleDbSql.ConnectionString = "server=" + PropertyHandler.HostName + ";uid=" + PropertyHandler.UserName + ";pwd=" + PropertyHandler.Password + ";database=" + tenant.shardName;
                queue.Enqueue(multipleDbSql);
                if (globalDb.save(queue))
                {
                    queue = new Queue<MultipleDbSql>();
                    multipleDbSql = new MultipleDbSql();
                    multipleDbSql.ConnectionString = PropertyHandler.GlobalDbConnectionString;
                    statement = new Statement();
                    statement.Sql = "declare @tenantId int;insert into tenant values('" + tenant.name + "','" + tenant.shardName + "'," + tenant.statusId + "," + tenant.categoryId + ",'" + tenant.createdDate + "'," + (tenant.enableWorkFlow ? 1 : 0) + "); set @tenantId=SCOPE_IDENTITY(); select @tenantId;insert into [user] values(" + user.cellPhone + ",'" + user.name + "',@password,@passwordSalt,@tenantId," + user.roleId + "," + user.storeId + ",'" + user.mail + "','" + user.memo + "')";
                    statement.Paremeters = new List<SqlParameter>();
                    SqlParameter password = new SqlParameter("@password", SqlDbType.Image);
                    password.Value = user.password;
                    statement.Paremeters.Add(password);
                    SqlParameter passwordSalt = new SqlParameter("@passwordSalt", SqlDbType.Image);
                    passwordSalt.Value = user.passwordSalt;
                    statement.Paremeters.Add(passwordSalt);
                    multipleDbSql.Statement = statement;
                    queue.Enqueue(multipleDbSql);
                    return globalDb.save(queue);
                }
                else
                {
                    Logger.getLogger().error("数据库建表失败！" + System.Environment.NewLine + "SQL: " + statement.Sql);
                    return false;
                }
            }
            else
            {
                Logger.getLogger().error("数据库已经存在！" + System.Environment.NewLine + "Shard Db Name: " + tenant.shardName);
                return false;
            }
        }

        public static bool createUser(User user)
        {
            Queue<Statement> queue = new Queue<Statement>();
            Statement sql = new Statement();
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
                user.cellPhone = Convert.ToInt64(dt.Rows[0].ItemArray[0]);
                user.name = dt.Rows[0].ItemArray[1].ToString();
                user.password = (byte[])dt.Rows[0].ItemArray[2];
                user.passwordSalt = (byte[])dt.Rows[0].ItemArray[3];
                user.tenantId = Convert.ToInt32(dt.Rows[0].ItemArray[4]);
                user.roleId = Convert.ToUInt16(dt.Rows[0].ItemArray[5]);
                user.storeId = Convert.ToUInt16(dt.Rows[0].ItemArray[6]);
                user.mail = dt.Rows[0].ItemArray[7].ToString();
                user.memo = dt.Rows[0].ItemArray[8].ToString();
            }
            return user;
        }

        public static Data getTenants(int status, int category, long cellphone, string name)
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

            if (cellphone != 0)
            {
                whereClauseBuilder.Append(" and u.cellphone=").Append(cellphone);
            }

            if (name.Length > 0)
            {
                whereClauseBuilder.Append(" and t.name=").Append(name);
            }

            string sql = "select t.id,t.name,t.shardName,s.name,c.name,t.createdDate,t.statusId,t.categoryid,t.enableWorkFlow from tenant as t inner join status as s on t.statusId=s.id inner join category as c on t.categoryid=c.id inner join [user] as u on t.id=u.tenantid "+whereClauseBuilder.ToString();
            return globalDb.get(sql);
        }
    }
}
