using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace aimu
{
    class Db
    {
        private SqlConnection connection;
        public Db(string connectionString)
        {
            connection = new SqlConnection(connectionString);
        }

        public bool save(Queue<MultipleDbSql> multipleDbSqls)
        {
            string currentSql = "";
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    while (multipleDbSqls.Count > 0)
                    {
                        MultipleDbSql multipleDbSql = multipleDbSqls.Dequeue();
                        if (multipleDbSql.ConnectionString == null || multipleDbSql.ConnectionString.Length == 0)
                        {
                            throw (new Exception("Connection string is null or empty."));
                        }
                        using (SqlConnection connection = new SqlConnection(multipleDbSql.ConnectionString))
                        {
                            connection.Open();
                            Statement statement = multipleDbSql.Statement;
                            currentSql = statement.Sql;
                            Logger.getLogger().info(currentSql);
                            SqlCommand cmd = new SqlCommand(currentSql, connection);
                            if (statement.Paremeters.Count > 0)
                            {
                                foreach (SqlParameter parameter in statement.Paremeters)
                                {
                                    cmd.Parameters.Add(parameter);
                                }
                            }
                            cmd.ExecuteNonQuery();
                            connection.Close();
                        }
                    }
                    scope.Complete();
                }
            }
            catch (Exception e)
            {
                Logger.getLogger().error("Multiple DB transactions execution failed. " + e.Message + Environment.NewLine + "SQL: " + ((currentSql == null) ? "" : currentSql));
                return false;
            }
            return true;
        }

        public int save(Statement statement)
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            string currentSql = statement.Sql;
            try
            {
                SqlCommand cmd = new SqlCommand(currentSql, connection);
                Logger.getLogger().info(currentSql);
                if (statement.Paremeters.Count > 0)
                {
                    foreach (SqlParameter parameter in statement.Paremeters)
                    {
                        cmd.Parameters.Add(parameter);
                    }
                }
                return cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("执行失败，请发送当前文件夹下的error.log给管理员!");
                Logger.getLogger().error(e.Message + System.Environment.NewLine + "SQL: " + currentSql + System.Environment.NewLine + e.StackTrace);
                return 0;
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
        }

        public bool save(Queue<Statement> sqls)
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            SqlTransaction tranx = connection.BeginTransaction();
            string currentSql = "";
            Object returnedValue = null;
            try
            {
                while (sqls.Count > 0)
                {
                    Statement sql = sqls.Dequeue();
                    currentSql = sql.Sql;
                    SqlCommand cmd = new SqlCommand(currentSql, connection, tranx);
                    Logger.getLogger().info(currentSql);
                    if (sql.UseReturnValue)
                    {
                        if (returnedValue != null)
                        {
                            SqlParameter parameter = new SqlParameter("@returnedValue", returnedValue);
                            cmd.Parameters.Add(parameter);
                        }
                        else
                        {
                            Logger.getLogger().warn("returnedValue is null. SQL: " + currentSql);
                        }
                    }
                    else
                    {
                        returnedValue = null;
                    }
                    if (sql.Paremeters.Count > 0)
                    {
                        foreach (SqlParameter parameter in sql.Paremeters)
                        {
                            cmd.Parameters.Add(parameter);
                        }
                    }
                    if (sql.ReturnValue)
                    {
                        returnedValue = cmd.ExecuteScalar();
                    }
                    else
                    {
                        cmd.ExecuteNonQuery();
                        returnedValue = null;
                    }
                }
                tranx.Commit();
                return true;
            }
            catch (Exception e)
            {
                tranx.Rollback();
                MessageBox.Show("执行失败，请发送当前文件夹下的error.log给管理员!");
                Logger.getLogger().error(e.Message + System.Environment.NewLine + "SQL: " + currentSql + System.Environment.NewLine + e.StackTrace);
                return false;
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
        }
        public Data get(String sql)
        {
            //SqlConnection connection = new SqlConnection(PropertyHandler.DbConnectionString);
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            Data data = new Data();

            DataTable dt = new DataTable();
            try
            {
                da.Fill(dt);
                data.Success = true;
                data.DataTable = dt;
            }
            catch (Exception e)
            {
                data.Success = false;
                MessageBox.Show("执行失败，当前操作将退出，请发送当前文件夹下的error.log给管理员!");
                Logger.getLogger().error(e.Message + System.Environment.NewLine + "SQL: " + sql + System.Environment.NewLine + e.StackTrace);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
            return data;
        }
    }
}
