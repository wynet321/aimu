using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.IO;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;


namespace aimu
{
    public static class Connection
    {
        // init connection reference
        private static string IP = "103.53.209.42,2433";
        private static string Usr = "sa";
        private static string Pwd = "liu@879698";
        private static string DBn = "aimu_test";
        private static SqlConnection connection = null;

        private static void getEnvProperties()
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
                                IP = reader.ReadString();
                                break;

                            case "Usr":
                                Usr = reader.ReadString();
                                break;

                            case "Pwd":
                                Pwd = reader.ReadString();
                                break;

                            case "DBn":
                                DBn = reader.ReadString();
                                break;
                        }
                    }

                }
                reader.Close();
            }

        }

        //get connection
        public static SqlConnection getConnection()
        {
            if (connection == null)
            {
                getEnvProperties();
                connection = getConnection(IP, Usr, Pwd, DBn);
            }
            return connection;
        }
        //close connection
        public static void Close()
        {
            if (connection != null)
            {
                connection.Close();
            }
        }

        private static SqlConnection getConnection(string ip, string userName, string password, string dbName)
        {
            try
            {
                string cnStr = "server=" + ip + ";uid=" + userName + ";pwd=" + password + ";database=" + dbName;
                SqlConnection connection = new SqlConnection(cnStr);
                connection.Open();
                if (connection.State != ConnectionState.Open)
                {
                    connection = null;
                }
                return connection;
            }
            catch (Exception ef)
            {
                MessageBox.Show(ef.ToString());
                //TODO connection log
                return null;
            }
        }
    }

    public static class ReadData
    {
        private static Data get(String sql)
        {
            SqlConnection connection = Connection.getConnection();
            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            Data data = new Data();

            DataTable dt = new DataTable();
            try
            {
                da.Fill(dt);
                data.Success = true;
            }
            catch (Exception e)
            {
                data.Success = false;
                MessageBox.Show("执行失败，当前操作将退出，请发送当前文件夹下的error.log给管理员!");
            }
            data.DataTable = dt;
            return data;
        }

        public static Data getCityByStoreId(int storeId)
        {
            String sql = "select c.id, c.name from customerStore as s left join customerCity as c on s.cityId=c.id where s.id=" + storeId;
            return get(sql);
        }

        public static Data getCities()
        {
            String sql = "select id,name from customerCity order by id";
            return get(sql);
        }

        public static Data getStores(int cityId)
        {
            String sql = "select id, name from customerStore where cityId=" + cityId + " order by id";
            return get(sql);
        }

        public static Data getChannels()
        {
            string sql = "select id,name from customerchannel";
            return get(sql);
        }

        public static Data getCustomerStatus()
        {
            String sql = "select id,name from customerStatus order by id";
            return get(sql);
        }

        public static Data getDressStatistic(String start, String end, String orderType)
        {
            string sql = "select d.wd_id,COUNT(d.wd_id) as cnt from orderDetail d left join [order] o on o.orderID = d.orderID where d.orderType = '" + orderType + "' and o.getDate > '" + start + "' and o.getDate<'" + end + "'  and o.storeId=" + Sharevariables.StoreId + " group by d.wd_id order by cnt desc";
            return get(sql);
        }

        public static Data getSellerStatistic(String start, String end, String consultant, int channelId, String partnerName)
        {
            string whereClause;
            if (channelId == 0)
            {
                whereClause = " where o.createddate>='" + start + "' and o.createddate<='" + end + "' ";
            }
            else
            {
                whereClause = " where o.createddate>='" + start + "' and o.createddate<='" + end + "' and c.channelId=" + channelId + " ";
            }

            if (consultant.Length > 0)
            {
                whereClause += "and c.jdgw='" + consultant + "' ";
            }
            if (partnerName.Length > 0)
            {
                whereClause += "and c.partnerName='" + partnerName + "'";
            }

            string sql = "SELECT c.customerId, c.brideName, c.brideContact, c.marryDay, c.jdgw, o.createdDate, o.totalAmount, o.orderAmountafter, c.channelId, o.orderID, d.orderType, s.name,c.status,c.partnerName FROM dbo.[order] AS o LEFT OUTER JOIN dbo.customers AS c ON o.customerID = c.customerID left outer JOIN(SELECT orderid, ordertype = STUFF((SELECT DISTINCT ', ' + ordertype FROM orderdetail b WHERE b.orderid = a.orderid FOR XML PATH('')), 1, 2, '') FROM orderdetail a GROUP BY orderid  ) as d on d.orderid = o.orderid left join customerStatus as s on c.status=s.id " + whereClause + " and o.storeId=" + Sharevariables.StoreId;
            return get(sql);
        }

        public static Data getCustomerChannels()
        {
            string sql = "select id,name from customerchannel order by id asc";
            return get(sql);
        }

        public static Data getSumOfSettlementPriceByIds(string[] ids)
        {
            string sql = "select sum(settlementprice) from weddingDressProperties where wd_id in (";
            foreach (string id in ids)
            {
                sql += "'" + id + "',";
            }
            sql = sql.Substring(0, sql.Length - 1) + ")";
            return get(sql);
        }

        public static Data getOrderStatuses()
        {
            String sql = "select id, name, userRole, preStatusId from orderStatus";
            return get(sql);
        }

        public static Data getCustomersByOrderId(string orderId)
        {
            String sql = "select customerId,bridename,bridecontact from customers where customerID=(select customerid from [order] where orderid='" + orderId + "')";
            return get(sql);
        }

        public static Data getOrderByStatus(int statusId)
        {
            String sql = "select [order].orderid,c.brideName,c.brideContact,[order].orderamountafter,[Order].totalamount, [Order].depositamount, [Order].deliverytype,[Order].getdate,replace([Order].returndate,'1900-01-01','') as returndate,[Order].address,[Order].memo from [dbo].[Order] left join customers c on [order].customerId=c.customerid left join [OrderFlow] on [Order].flowId=[OrderFlow].id where [OrderFlow].statusId='" + statusId + "' and [Order].storeId=" + Sharevariables.StoreId + " order by createdDate desc";
            return get(sql);
        }

        public static Data getOrderStatus(int userLevel)
        {
            string sql = "SELECT id,name FROM [dbo].[orderStatus] where (" + userLevel + " & userRole >0)";
            return get(sql);
        }

        public static Order getOrderByCustomerId(string customerId)
        {
            String sql = "select orderId, orderamountafter, totalamount, depositamount, deliverytype,getdate,returndate,address,memo,flowId from [dbo].[Order] where [customerID]='" + customerId + "' order by orderID desc";
            SqlConnection m_envconn = Connection.getConnection();
            SqlCommand cmd = new SqlCommand(sql, m_envconn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            Order order = new Order();
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                order.orderID = dr.ItemArray[0].ToString();
                order.customerID = customerId;
                order.orderAmountafter = (decimal)dr.ItemArray[1];
                order.totalAmount = (decimal)dr.ItemArray[2];
                order.depositAmount = (decimal)dr.ItemArray[3];
                order.deliveryType = dr.ItemArray[4].ToString();
                order.getDate = (DateTime)dr.ItemArray[5];
                order.returnDate = (DateTime)dr.ItemArray[6];
                order.address = dr.ItemArray[7].ToString();
                order.memo = dr.ItemArray[8].ToString();
                order.flowId = (dr.ItemArray[9] == DBNull.Value) ? 0 : int.Parse(dr.ItemArray[9].ToString());
            }
            return order;
        }

        public static OrderFlow getOrderFlowById(int id)
        {
            String sql = "select statusId, changeReason, customizedPrice, expressNumberToStore, expressNumberToFactory,expressNumberToCustomer from [orderFlow] where id=" + id;
            SqlConnection m_envconn = Connection.getConnection();
            SqlCommand cmd = new SqlCommand(sql, m_envconn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            OrderFlow orderFlow = new OrderFlow();
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                orderFlow.statusId = int.Parse(dr.ItemArray[0].ToString());
                orderFlow.changeReason = dr.ItemArray[1].ToString();
                orderFlow.customizedPrice = decimal.Parse(dr.ItemArray[2].ToString());
                orderFlow.expressNumberToStore = dr.ItemArray[3].ToString();
                orderFlow.expressNumberToFactory = dr.ItemArray[4].ToString();
                orderFlow.expressNumberToCustomer = dr.ItemArray[5].ToString();
            }
            return orderFlow;
        }

        public static Data getOrderAmount(DateTime date)
        {
            String sql = "select sum(convert(int,totalAmount)), sum(convert(int,orderAmountAfter)) from [order] where createdDate='" + date.ToShortDateString() + "' and [order].storeId=" + Sharevariables.StoreId;
            return get(sql);
        }

        public static Data getOrderDetailsById(String orderId)
        {

            string sql = "select o.orderId, o.ordertype,o.wd_id,o.wd_color,o.wd_size, o.wd_image, s.wd_price from orderdetail o left join weddingdresssizeandnumber s on o.wd_id=s.wd_id and o.wd_size=s.wd_size where o.orderid='" + orderId + "'";
            return get(sql);
        }

        public static Data getPropertiesByWdId(String wdId)
        {
            string sql = "select wd_size, wd_price from weddingdresssizeandnumber where wd_id='" + wdId + "' and storeId=" + Sharevariables.StoreId;
            return get(sql);
        }

        public static Data getSizesByWdId(String WdId)
        {
            string sql = "select wd_size from weddingdresssizeandnumber where wd_id='" + WdId + "' and storeId=" + Sharevariables.StoreId + " order by wd_size asc";
            return get(sql);
        }

        public static Data getColorsByWdId(String wdId)
        {
            string sql = "select wd_color from weddingdressproperties where wd_id='" + wdId + "' order by wd_color asc";
            return get(sql);
        }

        public static Data getCollisionPeriod(String wd_id)
        {
            string sql = "select  c.brideName as 新娘姓名,c.brideContact as 联系方式, c.marryDay as 婚期, o.getDate as 取纱日期, o.returnDate as 还纱日期, d.orderType as 订单类别, d.wd_size as 尺寸  from [order] o left join OrderDetail d on o.orderid=d.orderid left join customers c on o.customerid=c.customerid where d.wd_id='" + wd_id + "' and o.storeId=" + Sharevariables.StoreId + " order by c.marryDay";
            Data data = get(sql);
            if (data.Success)
            {
                foreach (DataRow row in data.DataTable.Rows)
                {
                    if (row.ItemArray[5].ToString() != "租赁")
                    {
                        row[4] = DBNull.Value;
                    }
                }
            }
            return data;
        }

        public static Data getUser(string username, string password)
        {
            string sql = "SELECT [u_id],[u_name],[u_password],[u_level],[u_memo],[storeId],[u_address],[u_tel] FROM [user] where u_name='" + username + "' and u_password='" + password + "'";
            return get(sql);
        }

        public static Data getDressIdsByCondition(string queryCondition)
        {
            string[] queryArr = queryCondition.Split('\\');
            Data data = new Data();

            //if (queryArr.Length == 2)
            //{
                string sql;
                if (queryArr[0] == "品牌")
                {
                    sql = "SELECT [wd_id] as 货号 FROM [weddingDressProperties] where wd_factory='" + queryArr[1] + "'  order by wd_date desc";
                }
                else
                {
                    sql = "SELECT [wd_id] as 货号 FROM [weddingDressProperties] where wd_big_category='" + queryArr[0] + "' and wd_litter_category='" + queryArr[1] + "' order by wd_date desc";
                }
                data = get(sql);
            //}
            //else
            //{
            //    data.Success = false;
            //}
            return data;
        }


        public static Data getWeddingDressIds(string wd_id)
        {
            string sql = "SELECT [wd_id] FROM [weddingDressproperties] where wd_id like '%" + wd_id + "%'";
            return get(sql);
        }

        public static Data getDressProperties(String wd_id)
        {
            string sql = "SELECT [wd_size] as 尺寸 ,[wd_price] as 价格,[wd_huohao] as 货号 ,[wd_listing_date] as 上市日期,[wd_count] as 数量,[wd_merchant_code] as 商家编码,[wd_barcode] as 条形码 FROM [weddingDressSizeAndNumber] where wd_id='" + wd_id + "' and storeId=" + Sharevariables.StoreId;
            return get(sql);
        }

        public static Data getWeddingDressPropertiesSizeAndNumber(String wd_id)
        {
            string sql = "SELECT [wd_size] ,[wd_price] ,[wd_huohao] ,[wd_listing_date] ,[wd_count] ,[wd_merchant_code] ,[wd_barcode] FROM [weddingDressSizeAndNumber] where wd_id='" + wd_id + "' and storeId=" + Sharevariables.StoreId;
            return get(sql);
        }

        public static Data getWeddingDressProperties(String wd_id)
        {
            string sql = "SELECT [wd_id] ,[wd_date] ,[wd_big_category] ,[wd_litter_category] ,[wd_factory] ,[wd_color] ,[cpml_ls] ,[cpml_ws] ,[cpml_duan] ,[cpml_zs] ,[cpml_other] ,[cpbx_yw] ,[cpbx_ppq] ,[cpbx_ab] ,[cpbx_dq] ,[cpbx_qdhc] ,[bwcd_qd] ,[bwcd_xtw] ,[bwcd_ztw] ,[bwcd_ctw] ,[bwcd_hhtw] ,[cplx_mx] ,[cplx_sv] ,[cplx_yzj] ,[cplx_dd] ,[cplx_dj] ,[cplx_gb] ,[cplx_yl] ,[cplx_ll] ,[lxys_bd] ,[lxys_ll] ,[lxys_lb] ,[memo] ,[emergency_period],[normal_period],[is_renew],[settlementPrice] FROM [weddingDressProperties] where wd_id='" + wd_id + "'";
            return get(sql);
        }

        public static Data getCount(string wd_id, string wd_size)
        {
            string sql = "select wd_count from weddingdresssizeandnumber where wd_id='" + wd_id + "' and wd_size='" + wd_size + "' and storeId='" + Sharevariables.StoreId;
            return get(sql);
        }

        public static Data getCollisionCount(string orderId, string wd_id, string wd_size, DateTime getDate, DateTime returnDate)
        {
            string sql;
            if (orderId == null)
            {
                sql = "select count([order].orderId) from [order] left join orderdetail on [order].orderId=orderdetail.orderId where [order].storeId=" + Sharevariables.StoreId + " and orderdetail.wd_id='" + wd_id + "' and orderdetail.ordertype='租赁' and orderdetail.wd_size='" + wd_size + "' and (([order].[getdate]>='" + getDate.ToShortDateString() + "' and [order].[getdate]<='" + returnDate.ToShortDateString() + "') or ( [order].[returndate]>='" + getDate.ToShortDateString() + "' and  [order].[returndate]<='" + returnDate.ToShortDateString() + "') or ([order].[getdate]<='" + getDate.ToShortDateString() + "' and [order].[returndate]>='" + returnDate.ToShortDateString() + "'))";
            }
            else
            {
                sql = "select count([order].orderId) from [order] left join orderdetail on [order].orderId=orderdetail.orderId where [order].storeId=" + Sharevariables.StoreId + " and [order].orderId<>'" + orderId + "' and orderdetail.wd_id='" + wd_id + "' and orderdetail.ordertype='租赁' and orderdetail.wd_size='" + wd_size + "' and (([order].[getdate]>='" + getDate.ToShortDateString() + "' and [order].[getdate]<='" + returnDate.ToShortDateString() + "') or ( [order].[returndate]>='" + getDate.ToShortDateString() + "' and  [order].[returndate]<='" + returnDate.ToShortDateString() + "') or ([order].[getdate]<='" + getDate.ToShortDateString() + "' and [order].[returndate]>='" + returnDate.ToShortDateString() + "'))";
            }
            return get(sql);
        }

        public static Data getCustomerByName(String name)
        {
            string sql = "SELECT [customerID],[brideName],[brideContact] FROM [customers] where [brideName]='" + name + "' and storeId=" + Sharevariables.StoreId;
            return get(sql);
        }

        public static Data getCustomerByTel(String tel)
        {
            string sql = "SELECT [customerID],[brideName],[brideContact] FROM [customers] where [brideContact]='" + tel + "' and storeId=" + Sharevariables.StoreId;
            return get(sql);
        }

        public static Data getCustomersById(String cid)
        {
            string sql = "SELECT [brideName],[brideContact],[marryDay],[channelId],[reserveDate],[reserveTime],[tryDress],[memo],[scsj_jsg],[scsj_cxsg],[scsj_tz],[scsj_xw],[scsj_xxw],[scsj_yw],[scsj_dqw],[scsj_tw],[scsj_jk],[scsj_jw],[scsj_dbw],[scsj_yddc],[scsj_qyj],[scsj_bpjl],[status],[jdgw],[groomName],[groomContact] ,[wangwangID],[customerID], [reservetimes], [retailerMemo],[hisreason],[storeId],[accountpayable],[refund],[fine],[partnerName] FROM [customers] where [customerID]='" + cid + "'";
            return get(sql);
        }

        public static Data getPic(String wd_id)
        {
            string sql = "SELECT [wd_id] ,[pic_id] ,[pic_name] ,[pic_img] FROM [tblImgData] where wd_id='" + wd_id + "'";
            return get(sql);
        }

        public static Data getPicName(String wd_id)
        {
            string sql = "SELECT [wd_id] ,[pic_id] ,[pic_name] FROM [tblImgData] where wd_id='" + wd_id + "'";
            return get(sql);
        }

        public static Data getCustomers(string field, string filter, string orderBy)
        {
            string sql = "SELECT " + field + " FROM customers left join customerStatus on customers.status=customerStatus.id " + filter + " " + orderBy;
            return get(sql);
        }

        public static Data getTryOnListByCustomerId(string customerID)
        {
            string query = "select A.wd_id,A.wd_big_category,A.wd_litter_category,B.wdSize,A.wd_color,B.id from (SELECT [wd_id] ,[wd_big_category] ,[wd_litter_category] ,[wd_color] FROM [weddingDressProperties]) A,(SELECT [customerID] ,[wdId] ,[wdSize],id FROM [customerTryDressList] where customerID='" + customerID + "') B where A.wd_id=B.wdId";
            return get(query);
        }

        public static Data getOrderListByCustomerId(string customerID)
        {
            string query = "select orderid,totalamount,orderAmountafter, depositamount,memo from [order] where customerid='" + customerID + "'";
            return get(query);
        }
    }

    public static class TruncateTable
    {

        public static bool deleteByCustomerIDInClusterTable(string cid)
        {
            try
            {
                SqlConnection conn = Connection.getConnection();
                if (conn != null)
                {
                    string sql = "delete from customers  where customerID='" + cid + "'";

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("数据库连接异常！");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }


        //WeddingDressProperties delete
        public static bool deleteWeddingDressByID(string wid)
        {
            try
            {
                SqlConnection conn = Connection.getConnection();
                if (conn != null)
                {
                    string sql = "delete from weddingDressProperties  where wd_id='" + wid + "'";

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("数据库连接异常！");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }


        //weddingDressSizeAndNumber delete
        public static bool deleteWeddingDressSizeAndNumberByID(string wid)
        {
            try
            {
                SqlConnection conn = Connection.getConnection();
                if (conn != null)
                {
                    string sql = "delete from weddingDressSizeAndNumber  where wd_id='" + wid + "'";

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("数据库连接异常！");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }


        //tblImgData delete
        public static bool deleteTblImgDataByID(string wid)
        {
            try
            {
                SqlConnection conn = Connection.getConnection();
                if (conn != null)
                {
                    string sql = "delete from tblImgData  where wd_id='" + wid + "'";

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("数据库连接异常！");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }



    }

    public static class UpdateDate
    {
        public static bool updateCustomerInfo(Customer ci)
        {
            try
            {
                SqlConnection conn = Connection.getConnection();
                if (conn != null)
                {
                    string sql = "update customers set brideName='" + ci.brideName + "', reservetimes=" + ci.reservetimes + ", status='" + ci.status + "',brideContact='" + ci.brideContact + "',groomName='" + ci.groomName + "',groomContact='" + ci.groomContact + "',marryDay='" + ci.marryDay + "',channelId='" + ci.channelId + "',storeId='" + ci.storeId + "',reserveDate='" + ci.reserveDate + "',reserveTime='" + ci.reserveTime + "',tryDress='" + ci.tryDress + "',hisreason='" + ci.reason + "',scsj_jsg='" + ci.scsj_jsg + "',scsj_cxsg='" + ci.scsj_cxsg + "',scsj_tz='" + ci.scsj_tz + "',scsj_xw='" + ci.scsj_xw + "',scsj_xxw='" + ci.scsj_xxw + "',scsj_yw='" + ci.scsj_yw + "',scsj_dqw='" + ci.scsj_dqw + "',scsj_tw='" + ci.scsj_tw + "',scsj_jk='" + ci.scsj_jk + "',scsj_jw='" + ci.scsj_jw + "',scsj_dbw='" + ci.scsj_dbw + "',scsj_yddc='" + ci.scsj_yddc + "',scsj_qyj='" + ci.scsj_qyj + "',scsj_bpjl='" + ci.scsj_bpjl + "',wangwangID='" + ci.wangwangID + "',jdgw='" + ci.jdgw + "',address='" + ci.address + "',retailerMemo='" + ci.retailerMemo + "',refund='" + ci.refund + "',fine='" + ci.fine + "', partnerName='"+ci.partnerName+"' where customerID='" + ci.customerID + "'";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("数据库连接异常！");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }


        //Update CustomerOrder
        //public static bool updateCustomerOrder(string orderID, string TmporderStatus)
        //{
        //    try
        //    {
        //        SqlConnection conn = Connection.GetEnvConn();
        //        if (conn != null)
        //        {
        //            string sql = "update customerOrder  set orderStatus='" + TmporderStatus + "' where orderID='" + orderID + "'";

        //            SqlCommand cmd = new SqlCommand(sql, conn);

        //            try
        //            {
        //                cmd.ExecuteNonQuery();
        //                return true;
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show(ex.ToString());
        //                return false;
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("数据库连接异常！");
        //            return false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        return false;
        //    }
        //}


        //public static bool updateCustomerOrder(string orderID, string TmporderStatus, string returnAmount)
        //{
        //    try
        //    {
        //        SqlConnection conn = Connection.GetEnvConn();
        //        if (conn != null)
        //        {
        //            string sql = "update customerOrder  set orderStatus='" + TmporderStatus + "',returnAmount='" + returnAmount + "' where orderID='" + orderID + "'";

        //            SqlCommand cmd = new SqlCommand(sql, conn);

        //            try
        //            {
        //                cmd.ExecuteNonQuery();
        //                return true;
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show(ex.ToString());
        //                return false;
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("数据库连接异常！");
        //            return false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        return false;
        //    }
        //}

        //退单处理
        //public static bool updateCustomerOrderCancelOrder(string orderID, string returnAmount)
        //{
        //    try
        //    {
        //        SqlConnection conn = Connection.GetEnvConn();
        //        if (conn != null)
        //        {
        //            string sql = "update customerOrder  set orderStatus='取消订单',returnAmount='" + returnAmount + "' where orderID='" + orderID + "'";

        //            SqlCommand cmd = new SqlCommand(sql, conn);

        //            try
        //            {
        //                cmd.ExecuteNonQuery();
        //                return true;
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show(ex.ToString());
        //                return false;
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("数据库连接异常！");
        //            return false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        return false;
        //    }
        //}


        //租赁取纱，更新库存
        //public static bool updateWeddingDressSizeAndNumberForReatGet(string wd_id, string wd_size, int wd_count)
        //{
        //    try
        //    {
        //        SqlConnection conn = Connection.GetEnvConn();
        //        if (conn != null)
        //        {
        //            string sql = "update weddingDressSizeAndNumber  set wd_count=" + wd_count + " where wd_id='" + wd_id + "'  and wd_size='" + wd_size + "'";

        //            SqlCommand cmd = new SqlCommand(sql, conn);

        //            try
        //            {
        //                cmd.ExecuteNonQuery();
        //                return true;
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show(ex.ToString());
        //                return false;
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("数据库连接异常！");
        //            return false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        return false;
        //    }
        //}

        //更新婚纱实时库存
        //public static bool updateRealtimeWeddingDressSizeAndNumberForReatGet(string wd_id, string wd_size, int wd_realtime_count)
        //{
        //    try
        //    {
        //        SqlConnection conn = Connection.GetEnvConn();
        //        if (conn != null)
        //        {
        //            string sql = "update weddingDressSizeAndNumber  set wd_realtime_count=" + wd_realtime_count + " where wd_id='" + wd_id + "'  and wd_size='" + wd_size + "'";

        //            SqlCommand cmd = new SqlCommand(sql, conn);

        //            try
        //            {
        //                cmd.ExecuteNonQuery();
        //                return true;
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show(ex.ToString());
        //                return false;
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("数据库连接异常！");
        //            return false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        return false;
        //    }
        //}

        //补交订单尾款
        //public static bool updateCustomerOrderForArrears(string orderID, string orderAmountafter, string totalAmount, string ifarrears)
        //{
        //    try
        //    {
        //        SqlConnection conn = Connection.GetEnvConn();
        //        if (conn != null)
        //        {
        //            string sql = "update customerOrder  set orderAmountafter='" + orderAmountafter + "',totalAmount='" + totalAmount + "',ifarrears='" + ifarrears + "',updatetime='" + DateTime.Now.ToLongDateString() + "' where orderID='" + orderID + "'";

        //            SqlCommand cmd = new SqlCommand(sql, conn);

        //            try
        //            {
        //                cmd.ExecuteNonQuery();
        //                return true;
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show(ex.ToString());
        //                return false;
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("数据库连接异常！");
        //            return false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        return false;
        //    }
        //}

        //public static bool updateCustomerStatus(string customerID, string status)
        //{
        //    try
        //    {
        //        SqlConnection conn = Connection.GetEnvConn();
        //        if (conn != null)
        //        {
        //            string sql = "update customers  set status ='" + status.Trim() + "' where customerID='" + customerID.Trim() + "'";

        //            SqlCommand cmd = new SqlCommand(sql, conn);

        //            try
        //            {
        //                cmd.ExecuteNonQuery();
        //                return true;
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show(ex.ToString());
        //                return false;
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("数据库连接异常！");
        //            return false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        return false;
        //    }
        //}


        //public static bool updateCustomerReservedTimes(string customerID, int reservedTimes)
        //{
        //    try
        //    {
        //        SqlConnection conn = Connection.GetEnvConn();
        //        if (conn != null)
        //        {
        //            string sql = "update customers  set reservetimes ='" + reservedTimes + "' where customerID='" + customerID.Trim() + "'";

        //            SqlCommand cmd = new SqlCommand(sql, conn);

        //            try
        //            {
        //                cmd.ExecuteNonQuery();
        //                return true;
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show(ex.ToString());
        //                return false;
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("数据库连接异常！");
        //            return false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        return false;
        //    }
        //}



        //public static bool updateCustomerInfo(string customerID, string[] customerInfos)
        //{
        //    try
        //    {
        //        SqlConnection conn = Connection.GetEnvConn();
        //        if (conn != null)
        //        {
        //            string sql = "update [customers]  set marryDay ='" + customerInfos[0] + "' , reserveDate ='" + customerInfos[1] + "' , reserveTime ='" + customerInfos[2] + "' , tryDress ='" + customerInfos[3] + "',  hisreason =hisreason+'" + customerInfos[4] + "' where customerID='" + customerID.Trim() + "'";

        //            SqlCommand cmd = new SqlCommand(sql, conn);

        //            try
        //            {
        //                cmd.ExecuteNonQuery();
        //                return true;
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show(ex.ToString());
        //                return false;
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("数据库连接异常！");
        //            return false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        return false;
        //    }
        //}
    }

    public static class SaveData
    {

        public static bool insertChannel(String channelName)
        {
            String sql = "insert into customerChannel values('" + channelName + "')";
            SqlConnection conn = Connection.getConnection();
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        public static bool deleteTryonById(string id)
        {
            SqlConnection conn = Connection.getConnection();
            if (conn != null)
            {
                String sql = "delete from [customerTryDressList] where id='" + id + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return false;
                }
                return true;
            }
            else
            {
                MessageBox.Show("数据库连接异常！");
                return false;
            }
        }

        public static bool InsertCustomerTryDressList(string customerID, string wdId, string wdSize, string tryDressDate)
        {
            try
            {
                SqlConnection conn = Connection.getConnection();
                if (conn != null)
                {
                    String sql = "insert into customerTryDressList(customerID,wdId,wdSize,tryDressDate) values('" + customerID + "','" + wdId + "','" + wdSize + "','" + tryDressDate + "')";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    try
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("数据库连接异常！");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public static bool InsertWeddingDressProperties(string wd_id, string wd_date, string wd_big_category, string wd_litter_category, string wd_factory, string wd_color, string cpml_ls, string cpml_ws, string cpml_duan, string cpml_zs, string cpml_other, string cpbx_yw, string cpbx_ppq, string cpbx_ab, string cpbx_dq, string cpbx_qdhc, string bwcd_qd, string bwcd_xtw, string bwcd_ztw, string bwcd_ctw, string bwcd_hhtw, string cplx_mx, string cplx_sv, string cplx_yzj, string cplx_dd, string cplx_dj, string cplx_gb, string cplx_yl, string cplx_ll, string lxys_bd, string lxys_ll, string lxys_lb, string memo, string emergency_period, string normal_period, string is_renew, decimal settlementPrice)
        {
            try
            {
                SqlConnection conn = Connection.getConnection();
                if (conn != null)
                {
                    String sql = "insert into weddingDressProperties(wd_id,wd_date,wd_big_category,wd_litter_category,wd_factory,wd_color,cpml_ls,cpml_ws,cpml_duan,cpml_zs,cpml_other,cpbx_yw,cpbx_ppq,cpbx_ab,cpbx_dq,cpbx_qdhc,bwcd_qd,bwcd_xtw,bwcd_ztw,bwcd_ctw,bwcd_hhtw,cplx_mx,cplx_sv,cplx_yzj,cplx_dd,cplx_dj,cplx_gb,cplx_yl,cplx_ll,lxys_bd,lxys_ll,lxys_lb,memo,emergency_period,normal_period,is_renew,settlementPrice) values(@wd_id,@wd_date,@wd_big_category,@wd_litter_category,@wd_factory,@wd_color,@cpml_ls,@cpml_ws,@cpml_duan,@cpml_zs,@cpml_other,@cpbx_yw,@cpbx_ppq,@cpbx_ab,@cpbx_dq,@cpbx_qdhc,@bwcd_qd,@bwcd_xtw,@bwcd_ztw,@bwcd_ctw,@bwcd_hhtw,@cplx_mx,@cplx_sv,@cplx_yzj,@cplx_dd,@cplx_dj,@cplx_gb,@cplx_yl,@cplx_ll,@lxys_bd,@lxys_ll,@lxys_lb,@memo,@emergency_period,@normal_period,@is_renew,@settlementPrice)";

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@wd_id", wd_id);
                    cmd.Parameters.AddWithValue("@wd_date", wd_date);
                    cmd.Parameters.AddWithValue("@wd_big_category", wd_big_category);
                    cmd.Parameters.AddWithValue("@wd_litter_category", wd_litter_category);
                    cmd.Parameters.AddWithValue("@wd_factory", wd_factory);
                    cmd.Parameters.AddWithValue("@wd_color", wd_color);
                    cmd.Parameters.AddWithValue("@cpml_ls", cpml_ls);
                    cmd.Parameters.AddWithValue("@cpml_ws", cpml_ws);
                    cmd.Parameters.AddWithValue("@cpml_duan", cpml_duan);
                    cmd.Parameters.AddWithValue("@cpml_zs", cpml_zs);
                    cmd.Parameters.AddWithValue("@cpml_other", cpml_other);
                    cmd.Parameters.AddWithValue("@cpbx_yw", cpbx_yw);
                    cmd.Parameters.AddWithValue("@cpbx_ppq", cpbx_ppq);
                    cmd.Parameters.AddWithValue("@cpbx_ab", cpbx_ab);
                    cmd.Parameters.AddWithValue("@cpbx_dq", cpbx_dq);
                    cmd.Parameters.AddWithValue("@cpbx_qdhc", cpbx_qdhc);
                    cmd.Parameters.AddWithValue("@bwcd_qd", bwcd_qd);
                    cmd.Parameters.AddWithValue("@bwcd_xtw", bwcd_xtw);
                    cmd.Parameters.AddWithValue("@bwcd_ztw", bwcd_ztw);
                    cmd.Parameters.AddWithValue("@bwcd_ctw", bwcd_ctw);
                    cmd.Parameters.AddWithValue("@bwcd_hhtw", bwcd_hhtw);
                    cmd.Parameters.AddWithValue("@cplx_mx", cplx_mx);
                    cmd.Parameters.AddWithValue("@cplx_sv", cplx_sv);
                    cmd.Parameters.AddWithValue("@cplx_yzj", cplx_yzj);
                    cmd.Parameters.AddWithValue("@cplx_dd", cplx_dd);
                    cmd.Parameters.AddWithValue("@cplx_dj", cplx_dj);
                    cmd.Parameters.AddWithValue("@cplx_gb", cplx_gb);
                    cmd.Parameters.AddWithValue("@cplx_yl", cplx_yl);
                    cmd.Parameters.AddWithValue("@cplx_ll", cplx_ll);
                    cmd.Parameters.AddWithValue("@lxys_bd", lxys_bd);
                    cmd.Parameters.AddWithValue("@lxys_ll", lxys_ll);
                    cmd.Parameters.AddWithValue("@lxys_lb", lxys_lb);
                    cmd.Parameters.AddWithValue("@memo", memo);
                    cmd.Parameters.AddWithValue("@emergency_period", emergency_period);
                    cmd.Parameters.AddWithValue("@normal_period", normal_period);
                    cmd.Parameters.AddWithValue("@is_renew", is_renew);
                    cmd.Parameters.AddWithValue("@settlementPrice", settlementPrice);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("商品编号已存在，请重新输入！" + ex.ToString());

                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("数据库连接异常！");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public static bool InsertWeddingDressSizeAndNumber(string wd_id, string wd_size, string wd_price, string wd_huohao, string wd_listing_date, int wd_count, string wd_merchant_code, string wd_barcode, int wd_realtime_count)
        {
            try
            {
                SqlConnection conn = Connection.getConnection();
                if (conn != null)
                {
                    String sql = "insert into weddingDressSizeAndNumber(wd_id,wd_size,wd_price,wd_huohao,wd_listing_date,wd_count,wd_merchant_code,wd_barcode,wd_realtime_count,storeId) values ('" + wd_id.Trim() + "','" + wd_size.Trim() + "','" + wd_price.Trim() + "','" + wd_huohao.Trim() + "','" + wd_listing_date.Trim() + "'," + wd_count + ",'" + wd_merchant_code.Trim() + "','" + wd_barcode.Trim() + "'," + wd_realtime_count + ", " + Sharevariables.StoreId + ")";

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("数据库连接异常！");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }


        public static bool InsertPicture(String wdID, String picID, String picName, byte[] m_barrImg)
        {
            try
            {

                SqlConnection conn = Connection.getConnection();
                if (conn != null)
                {
                    string[] pathNameArray = picName.Split('_');
                    if (pathNameArray.Length >= 3)
                    {
                        picName = pathNameArray[2];
                    }

                    string[] pathNameExtentName = picName.Split('.');
                    if (pathNameExtentName.Length == 1)
                    {
                        picName = picName + ".jpg";
                    }


                    String sql = "INSERT INTO tblImgData(wd_id,pic_id,pic_name,pic_img) values(@wd_id,@pic_id,@pic_name,@pic_img)";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.Add("@wd_id", SqlDbType.VarChar, 50);
                    cmd.Parameters.Add("@pic_id", SqlDbType.VarChar, 50);
                    cmd.Parameters.Add("@pic_name", SqlDbType.VarChar, 50);
                    cmd.Parameters.Add("@pic_img", SqlDbType.Image);


                    cmd.Parameters["@wd_id"].Value = wdID;
                    cmd.Parameters["@pic_id"].Value = picID;
                    cmd.Parameters["@pic_name"].Value = picName;
                    cmd.Parameters["@pic_img"].Value = m_barrImg;

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }


        //insert customer
        public static bool InsertCustomer(string customerID, string brideName, string brideContact, string memo, int channelId, int storeId, string wangwangID, string operatorName, int status, string partnerName)
        {
            try
            {
                SqlConnection conn = Connection.getConnection();
                if (conn != null)
                {
                    String sql = "insert into customers(customerID,brideName,brideContact,memo,channelId,storeId,wangwangID,operatorName,status,createDate,partnerName) values(@customerID,@brideName,@brideContact,@memo,@channelId,@storeId,@wangwangID,@operatorName,@status,'" + DateTime.Today.ToShortDateString() + "','"+partnerName+"')";

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@customerID", customerID);
                    cmd.Parameters.AddWithValue("@brideName", brideName);
                    cmd.Parameters.AddWithValue("@brideContact", brideContact);
                    cmd.Parameters.AddWithValue("@channelId", channelId);
                    cmd.Parameters.AddWithValue("@memo", memo);
                    cmd.Parameters.AddWithValue("@storeId", storeId);
                    cmd.Parameters.AddWithValue("@wangwangID", wangwangID);
                    cmd.Parameters.AddWithValue("@operatorName", operatorName);
                    cmd.Parameters.AddWithValue("@status", status);
                    try
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("客户编号已存在，请重新输入！" + ex.ToString());
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("数据库连接异常！");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public static bool insertOrder(Order order, List<OrderDetail> orderDetails, OrderFlow orderFlow)
        {
            SqlConnection conn = Connection.getConnection();
            if (conn == null)
            {
                MessageBox.Show("数据库连接异常！");
                return false;
            }
            SqlTransaction tranx = conn.BeginTransaction();
            try
            {
                String sql = @"insert into [orderFlow] (statusId,changeReason,customizedPrice, expressNumberToStore, expressNumberToFactory, expressNumberToCustomer) values(@statusId,@changeReason,@customizedPrice, @expressNumberToStore, @expressNumberToFactory, @expressNumberToCustomer); select @id=@@IDENTITY;";
                SqlCommand cmd = new SqlCommand(sql, conn, tranx);
                cmd.Parameters.AddWithValue("@statusId", orderFlow.statusId);
                cmd.Parameters.AddWithValue("@changeReason", (orderFlow.changeReason == null) ? (object)DBNull.Value : orderFlow.changeReason);
                cmd.Parameters.AddWithValue("@customizedPrice", orderFlow.customizedPrice);
                cmd.Parameters.AddWithValue("@expressNumberToStore", (orderFlow.expressNumberToStore == null) ? (object)DBNull.Value : orderFlow.expressNumberToStore);
                cmd.Parameters.AddWithValue("@expressNumberToFactory", (orderFlow.expressNumberToFactory == null) ? (object)DBNull.Value : orderFlow.expressNumberToFactory);
                cmd.Parameters.AddWithValue("@expressNumberToCustomer", (orderFlow.expressNumberToCustomer == null) ? (object)DBNull.Value : orderFlow.expressNumberToCustomer);
                SqlParameter parameter = new SqlParameter("@id", SqlDbType.Int);
                parameter.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(parameter);
                cmd.ExecuteNonQuery();
                int orderFlowId = int.Parse(parameter.Value.ToString());

                sql = "insert into [order] (orderid,customerid, orderamountafter, depositamount,totalamount,deliveryType,getdate,returndate,address, memo,createdDate,flowId,storeId) values (@orderid,@customerid, @orderamountafter,@depositamount, @totalamount,@deliveryType,@getdate,@returndate,@address, @memo,@createdDate,@flowId,@storeId)";
                cmd = new SqlCommand(sql, conn, tranx);
                cmd.Parameters.AddWithValue("@orderid", order.orderID);
                cmd.Parameters.AddWithValue("@customerid", order.customerID);
                cmd.Parameters.AddWithValue("@orderamountafter", order.orderAmountafter);
                cmd.Parameters.AddWithValue("@totalamount", order.totalAmount);
                cmd.Parameters.AddWithValue("@depositamount", order.depositAmount);
                cmd.Parameters.AddWithValue("@deliveryType", order.deliveryType);
                cmd.Parameters.AddWithValue("@getDate", order.getDate);
                cmd.Parameters.AddWithValue("@returnDate", order.returnDate);
                cmd.Parameters.AddWithValue("@address", (order.address == null) ? (object)DBNull.Value : order.address);
                cmd.Parameters.AddWithValue("@memo", order.memo == null ? (object)DBNull.Value : order.memo);
                cmd.Parameters.AddWithValue("@createdDate", DateTime.Today);
                cmd.Parameters.AddWithValue("@flowId", orderFlowId);
                cmd.Parameters.AddWithValue("@storeId", Sharevariables.StoreId);
                cmd.ExecuteNonQuery();

                sql = "update customers set accountpayable=@accountpayable where customerid=@customerid";
                cmd = new SqlCommand(sql, conn, tranx);
                cmd.Parameters.AddWithValue("@accountpayable", (decimal)order.totalAmount - (decimal)order.orderAmountafter);
                cmd.Parameters.AddWithValue("@customerid", order.customerID);
                cmd.ExecuteNonQuery();

                foreach (OrderDetail orderDetail in orderDetails)
                {
                    sql = "insert into orderdetail(orderid,wd_id,wd_size,orderType,wd_color,wd_image) values(@orderid,@wd_id,@wd_size,@ordertype,@wd_color,@wd_image)";
                    cmd = new SqlCommand(sql, conn, tranx);
                    cmd.Parameters.AddWithValue("@wd_id", orderDetail.wd_id);
                    cmd.Parameters.AddWithValue("@ordertype", orderDetail.orderType);
                    cmd.Parameters.AddWithValue("@orderid", orderDetail.orderID);
                    cmd.Parameters.AddWithValue("@wd_size", (orderDetail.wd_size == null) ? (Object)DBNull.Value : orderDetail.wd_size);
                    cmd.Parameters.AddWithValue("@wd_color", (orderDetail.wd_color == null) ? (Object)DBNull.Value : orderDetail.wd_color);
                    cmd.Parameters.Add("@wd_image", SqlDbType.Image);
                    if (orderDetail.wd_image == null)
                    {
                        cmd.Parameters["@wd_image"].Value = (object)DBNull.Value;
                    }
                    else
                    {
                        //cmd.Parameters.Add("@wd_image", SqlDbType.Image);
                        cmd.Parameters["@wd_image"].Value = orderDetail.wd_image;
                    }
                    cmd.ExecuteNonQuery();
                    //if (orderDetail.orderType == "标准码" || orderDetail.orderType == "量身定制")
                    if (orderDetail.orderType == "卖样衣")
                    {
                        sql = "update weddingdresssizeandnumber set wd_count=(select wd_count from weddingdresssizeandnumber where wd_id='" + orderDetail.wd_id + "' and wd_size='" + orderDetail.wd_size + "')-1 where wd_id='" + orderDetail.wd_id + "' and wd_size='" + orderDetail.wd_size + "' and storeId=" + Sharevariables.StoreId;
                        cmd = new SqlCommand(sql, conn, tranx);
                        cmd.ExecuteNonQuery();
                    }
                }
                tranx.Commit();
                return true;
            }
            catch (Exception ex)
            {
                tranx.Rollback();
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public static bool updateOrderbyId(Order order, List<OrderDetail> orderDetails, List<OrderDetail> originalOrderDetails, OrderFlow orderFlow)
        {
            SqlConnection conn = Connection.getConnection();
            if (conn == null)
            {
                MessageBox.Show("数据库连接异常！");
                return false;
            }
            SqlTransaction tranx = conn.BeginTransaction();
            try
            {
                string sql = "delete from [order] where orderId='" + order.orderID + "'";
                SqlCommand cmd = new SqlCommand(sql, conn, tranx);
                cmd.ExecuteNonQuery();
                sql = "update weddingDressSizeAndNumber set wd_count=(select wd_count from weddingDressSizeAndNumber where wd_id=@wd_id and wd_size=@wd_size and storeId=" + Sharevariables.StoreId + ")+1 where wd_id=@wd_id and wd_size=@wd_size and storeId=" + Sharevariables.StoreId;
                foreach (OrderDetail orderDetail in originalOrderDetails)
                {
                    //if (orderDetail.orderType == "标准码" || orderDetail.orderType == "量身定制")
                    if (orderDetail.orderType == "卖样衣")
                    {
                        cmd = new SqlCommand(sql, conn, tranx);
                        cmd.Parameters.AddWithValue("@wd_id", orderDetail.wd_id);
                        cmd.Parameters.AddWithValue("@wd_size", (orderDetail.wd_size == null) ? (Object)DBNull.Value : orderDetail.wd_size);
                        cmd.ExecuteNonQuery();
                    }
                }
                sql = "delete from [orderdetail] where orderid='" + order.orderID + "'";
                cmd = new SqlCommand(sql, conn, tranx);
                cmd.ExecuteNonQuery();

                sql = @"insert into [orderFlow] (statusId,changeReason,customizedPrice, expressNumberToStore, expressNumberToFactory, expressNumberToCustomer) values(@statusId,@changeReason,@customizedPrice, @expressNumberToStore, @expressNumberToFactory, @expressNumberToCustomer); select @id=@@IDENTITY;";
                cmd = new SqlCommand(sql, conn, tranx);
                cmd.Parameters.AddWithValue("@statusId", orderFlow.statusId);
                cmd.Parameters.AddWithValue("@changeReason", (orderFlow.changeReason == null) ? (object)DBNull.Value : orderFlow.changeReason);
                cmd.Parameters.AddWithValue("@customizedPrice", orderFlow.customizedPrice);
                cmd.Parameters.AddWithValue("@expressNumberToStore", (orderFlow.expressNumberToStore == null) ? (object)DBNull.Value : orderFlow.expressNumberToStore);
                cmd.Parameters.AddWithValue("@expressNumberToFactory", (orderFlow.expressNumberToFactory == null) ? (object)DBNull.Value : orderFlow.expressNumberToFactory);
                cmd.Parameters.AddWithValue("@expressNumberToCustomer", (orderFlow.expressNumberToCustomer == null) ? (object)DBNull.Value : orderFlow.expressNumberToCustomer);
                SqlParameter parameter = new SqlParameter("@id", SqlDbType.Int);
                parameter.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(parameter);
                cmd.ExecuteNonQuery();
                int orderFlowId = int.Parse(parameter.Value.ToString());

                sql = "insert into [order] (orderid,customerid, orderamountafter, depositamount,totalamount,deliveryType,getdate,returndate,address, memo,createdDate,flowId,storeId) values (@orderid,@customerid, @orderamountafter,@depositamount, @totalamount,@deliveryType,@getdate,@returndate,@address, @memo, @createdDate,@flowId,@storeId)";
                cmd = new SqlCommand(sql, conn, tranx);
                cmd.Parameters.AddWithValue("@orderid", order.orderID);
                cmd.Parameters.AddWithValue("@customerid", order.customerID);
                cmd.Parameters.AddWithValue("@orderamountafter", order.orderAmountafter);
                cmd.Parameters.AddWithValue("@totalamount", order.totalAmount);
                cmd.Parameters.AddWithValue("@depositamount", order.depositAmount);
                cmd.Parameters.AddWithValue("@deliveryType", order.deliveryType);
                cmd.Parameters.AddWithValue("@getDate", order.getDate);
                cmd.Parameters.AddWithValue("@returnDate", order.returnDate);
                cmd.Parameters.AddWithValue("@address", order.address);
                cmd.Parameters.AddWithValue("@memo", order.memo);
                cmd.Parameters.AddWithValue("@createdDate", DateTime.Today);
                cmd.Parameters.AddWithValue("@flowId", orderFlowId);
                cmd.Parameters.AddWithValue("@storeId", Sharevariables.StoreId);
                cmd.ExecuteNonQuery();

                sql = "update customers set accountpayable=@accountpayable where customerid=@customerid";
                cmd = new SqlCommand(sql, conn, tranx);
                cmd.Parameters.AddWithValue("@accountpayable", (decimal)order.totalAmount - (decimal)order.orderAmountafter);
                cmd.Parameters.AddWithValue("@customerid", order.customerID);
                cmd.ExecuteNonQuery();

                foreach (OrderDetail orderDetail in orderDetails)
                {
                    sql = "insert into orderdetail(orderid,wd_id,wd_size,orderType,wd_color,wd_image) values(@orderid,@wd_id,@wd_size,@ordertype,@wd_color,@wd_image)";
                    cmd = new SqlCommand(sql, conn, tranx);
                    cmd.Parameters.AddWithValue("@wd_id", orderDetail.wd_id);
                    cmd.Parameters.AddWithValue("@ordertype", orderDetail.orderType);
                    cmd.Parameters.AddWithValue("@orderid", orderDetail.orderID);
                    cmd.Parameters.AddWithValue("@wd_size", (orderDetail.wd_size == null) ? (Object)DBNull.Value : orderDetail.wd_size);
                    cmd.Parameters.AddWithValue("@wd_color", (orderDetail.wd_color == null) ? (Object)DBNull.Value : orderDetail.wd_color);
                    cmd.Parameters.Add("@wd_image", SqlDbType.Image);
                    if (orderDetail.wd_image == null)
                    {
                        cmd.Parameters["@wd_image"].Value = (object)DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters["@wd_image"].Value = orderDetail.wd_image;
                    }
                    cmd.ExecuteNonQuery();
                    //if (orderDetail.orderType == "标准码" || orderDetail.orderType == "量身定制")
                    if (orderDetail.orderType == "卖样衣")
                    {
                        sql = "update weddingdresssizeandnumber set wd_count=(select wd_count from weddingdresssizeandnumber where wd_id='" + orderDetail.wd_id + "' and wd_size='" + orderDetail.wd_size + "')-1 where wd_id='" + orderDetail.wd_id + "' and wd_size='" + orderDetail.wd_size + "' and storeId=" + Sharevariables.StoreId;
                        cmd = new SqlCommand(sql, conn, tranx);
                        cmd.ExecuteNonQuery();
                    }
                }

                tranx.Commit();
                return true;
            }
            catch (Exception ex)
            {
                tranx.Rollback();
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}

public static class picDataInfo
{
    public static string picPath1 = "";
    public static string picPath2 = "";
    public static string picPath3 = "";
    public static string picPath4 = "";
    public static string picPath5 = "";
    public static string picPath6 = "";
    public static string picPath7 = "";
    public static string picPath8 = "";
    public static string picPath9 = "";
}

