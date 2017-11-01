using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

using System.Collections.Generic;
using System.Text;

namespace aimu
{
    public static class DataOperation
    {
        private static bool save(Queue<SQL> sqls)
        {
            SqlConnection connection = new SqlConnection(PropertyHandler.DbConnectionString);
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            SqlTransaction tranx = connection.BeginTransaction();
            string currentSql = "";
            Object returnedValue=null;
            try
            {
                while (sqls.Count > 0)
                {
                    SQL sql = sqls.Dequeue();
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
                            Logger.getLogger().warn("returnedValue is null. SQL: "+currentSql);
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
                        returnedValue=cmd.ExecuteScalar();
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
        private static Data get(String sql)
        {
            SqlConnection connection = new SqlConnection(PropertyHandler.DbConnectionString);
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
            string sql = "select d.wd_id,COUNT(d.wd_id) as cnt from orderDetail d left join [order] o on o.id = d.orderID where d.orderType = '" + orderType + "' and o.getDate > '" + start + "' and o.getDate<'" + end + "'  and o.storeId=" + Sharevariables.StoreId + " group by d.wd_id order by cnt desc";
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

            string sql = "SELECT c.id, c.brideName, c.brideContact, c.marryDay, c.jdgw, o.createdDate, o.totalAmount, o.orderAmountafter, c.channelId, o.id, d.orderType, s.name,c.status,c.partnerName FROM dbo.[order] AS o LEFT OUTER JOIN dbo.customers AS c ON o.customerID = c.id left outer JOIN(SELECT orderid, ordertype = STUFF((SELECT DISTINCT ', ' + ordertype FROM orderdetail b WHERE b.orderid = a.orderid FOR XML PATH('')), 1, 2, '') FROM orderdetail a GROUP BY orderid  ) as d on d.orderid = o.orderid left join customerStatus as s on c.status=s.id " + whereClause + " and o.storeId=" + Sharevariables.StoreId;
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
            String sql = "select id,bridename,bridecontact from customers where id=(select customerid from [order] where id='" + orderId + "')";
            return get(sql);
        }

        public static Data getOrderByStatus(int statusId)
        {
            String sql = "select [order].id,c.brideName,c.brideContact,[order].orderamountafter,[Order].totalamount, [Order].depositamount, [Order].deliverytype,[Order].getdate,replace([Order].returndate,'1900-01-01','') as returndate,[Order].address,[Order].memo from [dbo].[Order] left join customers c on [order].customerId=c.id left join [OrderFlow] on [Order].flowId=[OrderFlow].id where [OrderFlow].statusId='" + statusId + "' and [Order].storeId=" + Sharevariables.StoreId + " order by createdDate desc";
            return get(sql);
        }

        public static Data getOrderStatus(int userLevel)
        {
            string sql = "SELECT id,name FROM [dbo].[orderStatus] where (" + userLevel + " & userRole >0)";
            return get(sql);
        }

        public static Data getOrderByCustomerId(int customerId)
        {
            String sql = "select id, orderamountafter, totalamount, depositamount, deliverytype,getdate,returndate,address,memo,flowId from [dbo].[Order] where [customerID]=" + customerId + " order by id desc";
            return get(sql);
        }

        public static Data getOrders()
        {
            String sql = "select id, orderamountafter, totalamount, depositamount, deliverytype,getdate,returndate,address,memo from [dbo].[Order] order by id desc";
            return get(sql);
        }

        public static Data getOrderFlowById(int id)
        {
            String sql = "select statusId, changeReason, customizedPrice, expressNumberToStore, expressNumberToFactory,expressNumberToCustomer from [orderFlow] where id=" + id;
            return get(sql);
        }

        public static Data getOrderAmount(DateTime date)
        {
            String sql = "select sum(convert(int,totalAmount)), sum(convert(int,orderAmountAfter)) from [order] where createdDate='" + date.ToShortDateString() + "' and [order].storeId=" + Sharevariables.StoreId;
            return get(sql);
        }

        public static Data getOrderDetailsById(int orderId)
        {
            string sql = "select o.orderId, o.ordertype,o.wd_id,o.wd_color,o.wd_size, o.wd_image, s.wd_price from orderdetail o left join dress s on o.wd_id=s.wd_id and o.wd_size=s.wd_size where o.orderid=" + orderId ;
            return get(sql);
        }

        public static Data getPropertiesByWdId(String wdId)
        {
            string sql = "select wd_size, wd_price from dress where wd_id='" + wdId + "' and storeId=" + Sharevariables.StoreId;
            return get(sql);
        }

        public static Data getSizesByWdId(String WdId)
        {
            string sql = "select wd_size from dress where wd_id='" + WdId + "' and storeId=" + Sharevariables.StoreId + " order by wd_size asc";
            return get(sql);
        }

        public static Data getColorsByWdId(String wdId)
        {
            string sql = "select wd_color from weddingdressproperties where wd_id='" + wdId + "' order by wd_color asc";
            return get(sql);
        }

        public static Data getCollisionPeriod(String wd_id)
        {
            string sql = "select  c.brideName as 新娘姓名,c.brideContact as 联系方式, c.marryDay as 婚期, o.getDate as 取纱日期, o.returnDate as 还纱日期, d.orderType as 订单类别, d.wd_size as 尺寸  from [order] o left join OrderDetail d on o.id=d.orderid left join customers c on o.customerid=c.id where d.wd_id='" + wd_id + "' and o.storeId=" + Sharevariables.StoreId + " order by c.marryDay";
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
            string sql = "SELECT [u_id],[u_name],[u_password],[u_level],[u_memo],[storeId],[u_address],[u_tel],enableWorkFlow FROM [user] where u_name='" + username + "' and u_password='" + password + "'";
            return get(sql);
        }

        public static Data getDressIdsByCondition(string queryCondition)
        {
            string[] queryArr = queryCondition.Split('\\');
            Data data = new Data();
            string sql;
            if (queryArr[0] == "品牌")
            {
                sql = "SELECT [wd_id] as 货号 FROM [weddingDressProperties] where wd_factory='" + queryArr[1] + "'  order by wd_date desc";
            }
            else
            {
                sql = "SELECT [wd_id] as 货号 FROM [weddingDressProperties] where wd_big_category='" + queryArr[0] + "' and wd_litter_category='" + queryArr[1] + "' order by wd_date desc";
            }
            return get(sql);
        }

        public static Data getThumbnailsByIds(DataTable Ids)
        {
            StringBuilder idBuilder = new StringBuilder();
            foreach(DataRow row in Ids.Rows)
            {
                idBuilder.Append("'").Append(row.ItemArray[0].ToString()).Append("',");
            }
            string ids = idBuilder.ToString();
            ids=ids.Substring(0, ids.Length - 1);
            string sql = "select wd_id,thumbnail from tblImgData where wd_id in (" + ids+") and pic_id='1'";
            return get(sql);
        }

        public static Data getWeddingDressIds(string wd_id)
        {
            string sql = "SELECT [wd_id] FROM [weddingDressproperties] where wd_id='" + wd_id + "'";
            return get(sql);
        }

        //public static Data getDressPropertiesById(String wd_id)
        //{
        //    string sql = "SELECT [wd_size] as 尺寸 ,[wd_price] as 价格,[wd_listing_date] as 上市日期,[wd_count] as 数量 FROM [dress] where wd_id='" + wd_id + "' and storeId=" + Sharevariables.StoreId;
        //    return get(sql);
        //}

        public static Data getWeddingDressPropertiesSizeAndNumberById(String wd_id)
        {
            string sql = "SELECT id,[wd_size] ,[wd_price] ,[wd_listing_date] ,[wd_count],storeId  FROM [dress] where wd_id='" + wd_id + "' and storeId=" + Sharevariables.StoreId+" order by id";
            return get(sql);
        }

        public static Data getDressPropertiesById(String wd_id)
        {
            string sql = "SELECT [wd_date] ,[wd_big_category] ,[wd_litter_category] ,[wd_factory] ,[wd_color] ,[attribute] ,[memo] ,[emergency_period],[normal_period],[is_renew],[settlementPrice] FROM [weddingDressProperties] where wd_id='" + wd_id + "'";
            return get(sql);
        }

        public static Data getCount(string wd_id, string wd_size)
        {
            string sql = "select wd_count from dress where wd_id='" + wd_id + "' and wd_size='" + wd_size + "' and storeId=" + Sharevariables.StoreId;
            return get(sql);
        }

        public static Data getCollisionCount(Order order, string wd_id, string wd_size, DateTime getDate, DateTime returnDate)
        {
            string sql;
            if (order == null)
            {
                sql = "select count([order].id) from [order] left join orderdetail on [order].id=orderdetail.orderId where [order].storeId=" + Sharevariables.StoreId + " and orderdetail.wd_id='" + wd_id + "' and orderdetail.ordertype='租赁' and orderdetail.wd_size='" + wd_size + "' and (([order].[getdate]>='" + getDate.ToShortDateString() + "' and [order].[getdate]<='" + returnDate.ToShortDateString() + "') or ( [order].[returndate]>='" + getDate.ToShortDateString() + "' and  [order].[returndate]<='" + returnDate.ToShortDateString() + "') or ([order].[getdate]<='" + getDate.ToShortDateString() + "' and [order].[returndate]>='" + returnDate.ToShortDateString() + "'))";
            }
            else
            {
                sql = "select count([order].id) from [order] left join orderdetail on [order].id=orderdetail.orderId where [order].storeId=" + Sharevariables.StoreId + " and [order].id<>" + order.id + " and orderdetail.wd_id='" + wd_id + "' and orderdetail.ordertype='租赁' and orderdetail.wd_size='" + wd_size + "' and (([order].[getdate]>='" + getDate.ToShortDateString() + "' and [order].[getdate]<='" + returnDate.ToShortDateString() + "') or ( [order].[returndate]>='" + getDate.ToShortDateString() + "' and  [order].[returndate]<='" + returnDate.ToShortDateString() + "') or ([order].[getdate]<='" + getDate.ToShortDateString() + "' and [order].[returndate]>='" + returnDate.ToShortDateString() + "'))";
            }
            return get(sql);
        }

        public static Data getCustomerByName(String name)
        {
            string sql = "SELECT [id],[brideName],[brideContact] FROM [customers] where [brideName]='" + name + "' and storeId=" + Sharevariables.StoreId;
            return get(sql);
        }

        public static Data getCustomerByTel(String tel)
        {
            string sql = "SELECT [id],[brideName],[brideContact] FROM [customers] where [brideContact]='" + tel + "' and storeId=" + Sharevariables.StoreId;
            return get(sql);
        }

        public static Data getCustomersById(int id)
        {
            string sql = "SELECT [brideName],[brideContact],[marryDay],[channelId],[reserveDate],[reserveTime],[tryDress],[memo],[scsj_jsg],[scsj_cxsg],[scsj_tz],[scsj_xw],[scsj_xxw],[scsj_yw],[scsj_dqw],[scsj_tw],[scsj_jk],[scsj_jw],[scsj_dbw],[scsj_yddc],[scsj_qyj],[scsj_bpjl],[status],[jdgw],[groomName],[groomContact] ,[wangwangID],[id], [reservetimes], [retailerMemo],[hisreason],[storeId],[accountpayable],[refund],[fine],[partnerName] FROM [customers] where [id]='" + id + "'";
            return get(sql);
        }

        public static Data getImagesByDressId(String wd_id)
        {
            string sql = "SELECT [wd_id] ,[pic_id] ,[pic_img], thumbnail FROM [tblImgData] where wd_id='" + wd_id + "'";
            return get(sql);
        }

        public static Data getPicName(String wd_id)
        {
            string sql = "SELECT [wd_id] ,[pic_id] ,[pic_name] FROM [tblImgData] where wd_id='" + wd_id + "'";
            return get(sql);
        }

        public static Data getCustomers(string filter, string orderBy)
        {
            string sql = "SELECT c.id,brideName,brideContact,customerStatus.name,jdgw,reserveDate,reserveTime,marryDay,infoChannel,wangwangId,operatorName FROM customers as c left join customerStatus on c.status=customerStatus.id " + filter + " " + orderBy;
            return get(sql);
        }

        public static Data getTryOnListByCustomerId(string customerID)
        {
            string sql = "select A.wd_id,A.wd_big_category,A.wd_litter_category,B.wdSize,A.wd_color,B.id from (SELECT [wd_id] ,[wd_big_category] ,[wd_litter_category] ,[wd_color] FROM [weddingDressProperties]) A,(SELECT [customerID] ,[wdId] ,[wdSize],id FROM [customerTryDressList] where customerID='" + customerID + "') B where A.wd_id=B.wdId";
            return get(sql);
        }

        public static Data getOrderListByCustomerId(string customerID)
        {
            string sql = "select id,createdDate,totalamount,orderAmountafter, depositamount,memo from [order] where customerid='" + customerID + "'";
            return get(sql);
        }

        public static bool deleteByCustomerIDInClusterTable(string cid)
        {
            Queue<SQL> sqls = new Queue<SQL>();
            SQL sql = new SQL("delete from customers  where customerID='" + cid + "'");
            sqls.Enqueue(sql);
            return save(sqls);
        }

        public static bool deleteWeddingDressByID(string wid)
        {
            Queue<SQL> sqls = new Queue<SQL>();
            SQL sql = new SQL("delete from weddingDressProperties  where wd_id='" + wid + "'");
            sqls.Enqueue(sql);
            return save(sqls);
        }
        public static bool deletedressByID(string wid)
        {
            Queue<SQL> sqls = new Queue<SQL>();
            SQL sql = new SQL("delete from dress  where wd_id='" + wid + "'");
            sqls.Enqueue(sql);
            return save(sqls);
        }
        public static bool deleteTblImgDataByID(string wid)
        {
            Queue<SQL> sqls = new Queue<SQL>();
            SQL sql = new SQL("delete from tblImgData  where wd_id='" + wid + "'");
            sqls.Enqueue(sql);
            return save(sqls);
        }
        public static bool updateCustomerInfo(Customer ci)
        {
            Queue<SQL> sqls = new Queue<SQL>();
            SQL sql = new SQL("update customers set brideName='" + ci.brideName + "', reservetimes=" + ci.reservetimes + ", status='" + ci.status + "',brideContact='" + ci.brideContact + "',groomName='" + ci.groomName + "',groomContact='" + ci.groomContact + "',marryDay='" + ci.marryDay + "',channelId='" + ci.channelId + "',storeId='" + ci.storeId + "',reserveDate='" + ci.reserveDate + "',reserveTime='" + ci.reserveTime + "',tryDress='" + ci.tryDress + "',hisreason='" + ci.reason + "',scsj_jsg='" + ci.scsj_jsg + "',scsj_cxsg='" + ci.scsj_cxsg + "',scsj_tz='" + ci.scsj_tz + "',scsj_xw='" + ci.scsj_xw + "',scsj_xxw='" + ci.scsj_xxw + "',scsj_yw='" + ci.scsj_yw + "',scsj_dqw='" + ci.scsj_dqw + "',scsj_tw='" + ci.scsj_tw + "',scsj_jk='" + ci.scsj_jk + "',scsj_jw='" + ci.scsj_jw + "',scsj_dbw='" + ci.scsj_dbw + "',scsj_yddc='" + ci.scsj_yddc + "',scsj_qyj='" + ci.scsj_qyj + "',scsj_bpjl='" + ci.scsj_bpjl + "',wangwangID='" + ci.wangwangID + "',jdgw='" + ci.jdgw + "',address='" + ci.address + "',retailerMemo='" + ci.retailerMemo + "',refund='" + ci.refund + "',fine='" + ci.fine + "', partnerName='" + ci.partnerName + "' where id='" + ci.id + "'");
            sqls.Enqueue(sql);
            return save(sqls);
        }
        public static bool insertChannel(String channelName)
        {
            Queue<SQL> sqls = new Queue<SQL>();
            SQL sql = new SQL("insert into customerChannel values('" + channelName + "')");
            sqls.Enqueue(sql);
            return save(sqls);
        }

        public static bool deleteTryonById(string id)
        {
            Queue<SQL> sqls = new Queue<SQL>();
            SQL sql = new SQL("delete from [customerTryDressList] where id='" + id + "'");
            sqls.Enqueue(sql);
            return save(sqls);
        }

        public static bool InsertCustomerTryDressList(int customerId, string wdId, string wdSize, string tryDressDate)
        {
            Queue<SQL> sqls = new Queue<SQL>();
            SQL sql = new SQL("insert into customerTryDressList(customerID,wdId,wdSize,tryDressDate) values(" + customerId + ",'" + wdId + "','" + wdSize + "','" + tryDressDate + "')");
            sqls.Enqueue(sql);
            return save(sqls);
        }

        public static bool UpdateWeddingDress(WeddingDressProperties dress)
        {
            Queue<SQL> sqls = new Queue<SQL>();
            SQL sql = new SQL("delete from weddingDressProperties where wd_id='"+dress.wd_id+"'");
            sqls.Enqueue(sql);
            sql = new SQL("delete from dress where wd_id='" + dress.wd_id + "'");
            sqls.Enqueue(sql);
            sql = new SQL("delete from tblImgData where wd_id='" + dress.wd_id + "'");
            sqls.Enqueue(sql);
            Queue<SQL> insertSqls = generateDressQueue(dress);
            while (insertSqls.Count > 0)
            {
                sqls.Enqueue(insertSqls.Dequeue());
            }
            return save(sqls);
        }

        private static Queue<SQL> generateDressQueue(WeddingDressProperties dress)
        {
            Queue<SQL> sqls = new Queue<SQL>();
            SQL sql = new SQL("insert into weddingDressProperties(wd_id,wd_date,wd_big_category,wd_litter_category,wd_factory,wd_color,memo,emergency_period,normal_period,is_renew,settlementPrice,attribute) values('" + dress.wd_id + "','" + dress.wd_date + "','" + dress.wd_big_category + "','" + dress.wd_litter_category + "','" + dress.wd_factory + "','" + dress.wd_color + "','" + dress.memo + "','" + dress.emergency_period + "','" + dress.normal_period + "','" + dress.is_renew + "'," + dress.settlementPrice.ToString() + "," + dress.attribute + ")");
            sqls.Enqueue(sql);

            for (int i = 0; i < 7; i++)
            {
                WeddingDressSizeAndCount wdsc = dress.wdscs[i];
                sql = new SQL("insert into dress(wd_id, wd_size, wd_price,  wd_listing_date, wd_count, storeId) values('" + dress.wd_id + "', '" + wdsc.wd_size + "', '" + wdsc.wd_price + "', '" + wdsc.wd_listing_date + "', " + wdsc.wd_count + ", " + Sharevariables.StoreId + ")");
                sqls.Enqueue(sql);
            }

            for (int i = 1; i <= dress.pictures.Count; i++)
            {
                byte[] image = dress.pictures[i];
                byte[] thumbnail = dress.thumbnails[i];
                sql = new SQL();
                sql.Sql = "insert into tblImgData(wd_id,pic_id,pic_img,thumbnail) values('" + dress.wd_id + "'," + i + ",@pic_img,@thumbnail)";
                SqlParameter parameter = new SqlParameter("@pic_img", SqlDbType.Image);
                parameter.Value = image;
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(parameter);
                parameter = new SqlParameter("thumbnail", SqlDbType.Image);
                parameter.Value = thumbnail;
                parameters.Add(parameter);
                sql.Paremeters = parameters;
                sqls.Enqueue(sql);
            }
            return sqls;
        }
        public static bool InsertWeddingDress(WeddingDressProperties dress)
        {
            Queue<SQL> sqls=generateDressQueue(dress);
            return save(sqls);
        }

        public static bool InsertWeddingDressProperties(string wd_id, string wd_date, string wd_big_category, string wd_litter_category, string wd_factory, string wd_color, string cpml_ls, string cpml_ws, string cpml_duan, string cpml_zs, string cpml_other, string cpbx_yw, string cpbx_ppq, string cpbx_ab, string cpbx_dq, string cpbx_qdhc, string bwcd_qd, string bwcd_xtw, string bwcd_ztw, string bwcd_ctw, string bwcd_hhtw, string cplx_mx, string cplx_sv, string cplx_yzj, string cplx_dd, string cplx_dj, string cplx_gb, string cplx_yl, string cplx_ll, string lxys_bd, string lxys_ll, string lxys_lb, string memo, string emergency_period, string normal_period, string is_renew, decimal settlementPrice)
        {
            SQL sql = new SQL("insert into weddingDressProperties(wd_id,wd_date,wd_big_category,wd_litter_category,wd_factory,wd_color,cpml_ls,cpml_ws,cpml_duan,cpml_zs,cpml_other,cpbx_yw,cpbx_ppq,cpbx_ab,cpbx_dq,cpbx_qdhc,bwcd_qd,bwcd_xtw,bwcd_ztw,bwcd_ctw,bwcd_hhtw,cplx_mx,cplx_sv,cplx_yzj,cplx_dd,cplx_dj,cplx_gb,cplx_yl,cplx_ll,lxys_bd,lxys_ll,lxys_lb,memo,emergency_period,normal_period,is_renew,settlementPrice) values('" + wd_id + "','" + wd_date + "','" + wd_big_category + "','" + wd_litter_category + "','" + wd_factory + "','" + wd_color + "','" + cpml_ls + "','" + cpml_ws + "','" + cpml_duan + "','" + cpml_zs + "','" + cpml_other + "','" + cpbx_yw + "','" + cpbx_ppq + "','" + cpbx_ab + "','" + cpbx_dq + "','" + cpbx_qdhc + "','" + bwcd_qd + "','" + bwcd_xtw + "','" + bwcd_ztw + "','" + bwcd_ctw + "','" + bwcd_hhtw + "','" + cplx_mx + "','" + cplx_sv + "','" + cplx_yzj + "','" + cplx_dd + "','" + cplx_dj + "','" + cplx_gb + "','" + cplx_yl + "','" + cplx_ll + "','" + lxys_bd + "','" + lxys_ll + "','" + lxys_lb + "','" + memo + "','" + emergency_period + "','" + normal_period + "','" + is_renew + "'," + settlementPrice + ")");
            Queue<SQL> sqls = new Queue<SQL>();
            sqls.Enqueue(sql);
            return save(sqls);
        }

        public static bool Insertdress(string wd_id, string wd_size, string wd_price, string wd_huohao, string wd_listing_date, int wd_count, string wd_merchant_code, string wd_barcode, int wd_realtime_count)
        {
            Queue<SQL> sqls = new Queue<SQL>();
            SQL sql = new SQL("insert into dress(wd_id,wd_size,wd_price,wd_huohao,wd_listing_date,wd_count,wd_merchant_code,wd_barcode,wd_realtime_count,storeId) values ('" + wd_id.Trim() + "','" + wd_size.Trim() + "','" + wd_price.Trim() + "','" + wd_huohao.Trim() + "','" + wd_listing_date.Trim() + "'," + wd_count + ",'" + wd_merchant_code.Trim() + "','" + wd_barcode.Trim() + "'," + wd_realtime_count + ", " + Sharevariables.StoreId + ")");
            sqls.Enqueue(sql);
            return save(sqls);
        }


        public static bool InsertPicture(String wdID, String picID, String picName, byte[] m_barrImg)
        {
            Queue<SQL> sqls = new Queue<SQL>();
            SQL sql = new SQL();
            sql.Sql = "INSERT INTO tblImgData(wd_id,pic_id,pic_name,pic_img) values('" + wdID + "','" + picID + "','" + picName + "',@pic_img)";
            SqlParameter parameter = new SqlParameter("@pic_img", SqlDbType.Image);
            parameter.Value = m_barrImg;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(parameter);
            sql.Paremeters = parameters;
            sqls.Enqueue(sql);
            return save(sqls);
        }

        public static bool InsertCustomer(Customer customer)
        {
            Queue<SQL> sqls = new Queue<SQL>();
            SQL sql = new SQL("insert into customers(brideName,brideContact,memo,channelId,storeId,wangwangID,operatorName,status,createDate,partnerName) values('" + customer.brideName + "','" + customer.brideContact + "','" + customer.memo + "'," + customer.channelId + "," + customer.storeId + ",'" + customer.wangwangID + "','" + customer.operatorName + "'," + customer.status + ",'" + DateTime.Today.ToShortDateString() + "','" + customer.partnerName + "')");
            sqls.Enqueue(sql);
            return save(sqls);
        }
        private static Queue<SQL> generateOrderQueue(Order order, List<OrderDetail> orderDetails, OrderFlow orderFlow)
        {
            Queue<SQL> sqls = new Queue<SQL>();
            SQL sql;
            if (Sharevariables.EnableWorkFlow)
            {
                sql = new SQL("declare @flowId int; insert into [orderFlow] (statusId,changeReason,customizedPrice, expressNumberToStore, expressNumberToFactory, expressNumberToCustomer,parentId) values('" + orderFlow.statusId + "','" + ((orderFlow.changeReason == null) ? (object)DBNull.Value : orderFlow.changeReason) + "','" + orderFlow.customizedPrice + "','" + ((orderFlow.expressNumberToStore == null) ? (object)DBNull.Value : orderFlow.expressNumberToStore) + "','" + ((orderFlow.expressNumberToFactory == null) ? (object)DBNull.Value : orderFlow.expressNumberToFactory) + "', '" + ((orderFlow.expressNumberToCustomer == null) ? (object)DBNull.Value : orderFlow.expressNumberToCustomer) + "'," + orderFlow.parentId + "); set @flowId=SCOPE_IDENTITY(); select @flowId;");
                sql.ReturnValue = true;
                sqls.Enqueue(sql);
                sql = new SQL("declare @orderId int;insert into [order] (customerid, orderamountafter, depositamount,totalamount,deliveryType,getdate,returndate,address, memo,createdDate,flowId,storeId) values ('" + order.customerID + "', " + order.orderAmountafter.ToString() + "," + order.depositAmount.ToString() + ", " + order.totalAmount.ToString() + ",'" + order.deliveryType + "','" + order.getDate.ToShortDateString() + "','" + order.returnDate.ToShortDateString() + "','" + order.address + "','" + order.memo + "', '" + DateTime.Today.ToShortDateString() + "',@returnedValue,'" + Sharevariables.StoreId + "'); set @orderId=SCOPE_IDENTITY(); select @orderId");
                sql.ReturnValue = true;
                sql.UseReturnValue = true;
                sqls.Enqueue(sql);
            }
            else
            {
                sql = new SQL("declare @orderId int;insert into [order] (customerid, orderamountafter, depositamount,totalamount,deliveryType,getdate,returndate,address, memo,createdDate,storeId) values ('" + order.customerID + "', " + order.orderAmountafter.ToString() + "," + order.depositAmount.ToString() + ", " + order.totalAmount.ToString() + ",'" + order.deliveryType + "','" + order.getDate.ToShortDateString() + "','" + order.returnDate.ToShortDateString() + "','" + order.address + "','" + order.memo + "', '" + DateTime.Today.ToShortDateString() + "','" + Sharevariables.StoreId + "'); set @orderId=SCOPE_IDENTITY(); select @orderId");
                sql.ReturnValue = true;
                sql.UseReturnValue = true;
                sqls.Enqueue(sql);
            }
            
            foreach (OrderDetail orderDetail in orderDetails)
            {
                sql = new SQL();
                sql.UseReturnValue = true;
                sql.Sql = "insert into orderdetail(orderid,wd_id,wd_size,orderType,wd_color,wd_image) values(@returnedValue,'" + orderDetail.wd_id + "','" + ((orderDetail.wd_size == null) ? (Object)DBNull.Value : orderDetail.wd_size) + "','" + orderDetail.orderType + "','" + ((orderDetail.wd_color == null) ? (Object)DBNull.Value : orderDetail.wd_color) + "',@wd_image)";
                SqlParameter parameter;
                if (orderDetail.wd_image == null)
                {
                    parameter = new SqlParameter("@wd_image", SqlDbType.Image);
                    parameter.Value = new byte[0];
                }
                else
                {
                    parameter = new SqlParameter("@wd_image", SqlDbType.Image);
                    parameter.Value = orderDetail.wd_image;
                }
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(parameter);
                sql.Paremeters = parameters;
                sqls.Enqueue(sql);
            }
            foreach (OrderDetail orderDetail in orderDetails)
            {
                if (orderDetail.orderType == "卖样衣")
                {
                    sql = new SQL("update dress set wd_count=(select wd_count from dress where wd_id='" + orderDetail.wd_id + "' and wd_size='" + orderDetail.wd_size + "')-1 where wd_id='" + orderDetail.wd_id + "' and wd_size='" + orderDetail.wd_size + "' and storeId=" + Sharevariables.StoreId);
                    sqls.Enqueue(sql);
                }
            }
            sql = new SQL("update customers set accountpayable=" + (order.totalAmount - order.orderAmountafter).ToString() + " where id='" + order.customerID + "'");
            sqls.Enqueue(sql);
            return sqls;
        }
        public static bool insertOrder(Order order, List<OrderDetail> orderDetails, OrderFlow orderFlow)
        {
            Queue<SQL> sqls = generateOrderQueue(order, orderDetails, orderFlow);
            return save(sqls);
        }
        public static bool updateOrderbyId(Order order, List<OrderDetail> orderDetails, List<OrderDetail> originalOrderDetails, OrderFlow orderFlow)
        {
            Queue<SQL> sqls = new Queue<SQL>();
            SQL sql = new SQL("delete from [order] where id=" + order.id);
            sqls.Enqueue(sql);
            sql = new SQL("delete from [orderdetail] where orderid=" + order.id );
            sqls.Enqueue(sql);
            foreach (OrderDetail orderDetail in originalOrderDetails)
            {
                if (orderDetail.orderType == "卖样衣")
                {
                    sql = new SQL("update dress set wd_count=(select wd_count from dress where wd_id='" + orderDetail.wd_id + "' and wd_size='" + ((orderDetail.wd_size == null) ? (Object)DBNull.Value : orderDetail.wd_size) + "' and storeId=" + Sharevariables.StoreId + ")+1 where wd_id='" + orderDetail.wd_id + "' and wd_size='" + ((orderDetail.wd_size == null) ? (Object)DBNull.Value : orderDetail.wd_size) + "' and storeId=" + Sharevariables.StoreId);
                    sqls.Enqueue(sql);
                }
            }
            Queue<SQL> sqlsNewOrder = generateOrderQueue(order, orderDetails, orderFlow);
            while (sqlsNewOrder.Count > 0)
            {
                sqls.Enqueue(sqlsNewOrder.Dequeue());
            }
            return save(sqls);
        }
    }
}



