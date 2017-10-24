using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

using System.Collections.Generic;


namespace aimu
{
    public static class DataOperation
    {
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

        public static Data getOrderByCustomerId(string customerId)
        {
            String sql = "select orderId, orderamountafter, totalamount, depositamount, deliverytype,getdate,returndate,address,memo,flowId from [dbo].[Order] where [customerID]='" + customerId + "' order by orderID desc";
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
            string sql = "select A.wd_id,A.wd_big_category,A.wd_litter_category,B.wdSize,A.wd_color,B.id from (SELECT [wd_id] ,[wd_big_category] ,[wd_litter_category] ,[wd_color] FROM [weddingDressProperties]) A,(SELECT [customerID] ,[wdId] ,[wdSize],id FROM [customerTryDressList] where customerID='" + customerID + "') B where A.wd_id=B.wdId";
            return get(sql);
        }

        public static Data getOrderListByCustomerId(string customerID)
        {
            string sql = "select orderid,totalamount,orderAmountafter, depositamount,memo from [order] where customerid='" + customerID + "'";
            return get(sql);
        }

        private static bool save(Queue<SQL> sqls)
        {
            SqlConnection connection = new SqlConnection(PropertyHandler.DbConnectionString);
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            SqlTransaction tranx = connection.BeginTransaction();
            try
            {
                while (sqls.Count > 0)
                {
                    SQL sql = sqls.Dequeue();
                    SqlCommand cmd = new SqlCommand(sql.Sql, connection, tranx);
                    if (sql.Paremeters.Count > 0)
                    {
                        foreach (SqlParameter parameter in sql.Paremeters)
                        {
                            cmd.Parameters.Add(parameter);
                        }
                    }
                    cmd.ExecuteNonQuery();
                }
                tranx.Commit();
                return true;
            }
            catch (Exception e)
            {
                tranx.Rollback();
                //TODO log
                MessageBox.Show("执行失败，请发送当前文件夹下的error.log给管理员!");
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
        public static bool deleteWeddingDressSizeAndNumberByID(string wid)
        {
            Queue<SQL> sqls = new Queue<SQL>();
            SQL sql = new SQL("delete from weddingDressSizeAndNumber  where wd_id='" + wid + "'");
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
            SQL sql = new SQL("update customers set brideName='" + ci.brideName + "', reservetimes=" + ci.reservetimes + ", status='" + ci.status + "',brideContact='" + ci.brideContact + "',groomName='" + ci.groomName + "',groomContact='" + ci.groomContact + "',marryDay='" + ci.marryDay + "',channelId='" + ci.channelId + "',storeId='" + ci.storeId + "',reserveDate='" + ci.reserveDate + "',reserveTime='" + ci.reserveTime + "',tryDress='" + ci.tryDress + "',hisreason='" + ci.reason + "',scsj_jsg='" + ci.scsj_jsg + "',scsj_cxsg='" + ci.scsj_cxsg + "',scsj_tz='" + ci.scsj_tz + "',scsj_xw='" + ci.scsj_xw + "',scsj_xxw='" + ci.scsj_xxw + "',scsj_yw='" + ci.scsj_yw + "',scsj_dqw='" + ci.scsj_dqw + "',scsj_tw='" + ci.scsj_tw + "',scsj_jk='" + ci.scsj_jk + "',scsj_jw='" + ci.scsj_jw + "',scsj_dbw='" + ci.scsj_dbw + "',scsj_yddc='" + ci.scsj_yddc + "',scsj_qyj='" + ci.scsj_qyj + "',scsj_bpjl='" + ci.scsj_bpjl + "',wangwangID='" + ci.wangwangID + "',jdgw='" + ci.jdgw + "',address='" + ci.address + "',retailerMemo='" + ci.retailerMemo + "',refund='" + ci.refund + "',fine='" + ci.fine + "', partnerName='" + ci.partnerName + "' where customerID='" + ci.customerID + "'");
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

        public static bool InsertCustomerTryDressList(string customerID, string wdId, string wdSize, string tryDressDate)
        {
            Queue<SQL> sqls = new Queue<SQL>();
            SQL sql = new SQL("insert into customerTryDressList(customerID,wdId,wdSize,tryDressDate) values('" + customerID + "','" + wdId + "','" + wdSize + "','" + tryDressDate + "')");
            sqls.Enqueue(sql);
            return save(sqls);
        }

        public static bool InsertWeddingDressProperties(string wd_id, string wd_date, string wd_big_category, string wd_litter_category, string wd_factory, string wd_color, string cpml_ls, string cpml_ws, string cpml_duan, string cpml_zs, string cpml_other, string cpbx_yw, string cpbx_ppq, string cpbx_ab, string cpbx_dq, string cpbx_qdhc, string bwcd_qd, string bwcd_xtw, string bwcd_ztw, string bwcd_ctw, string bwcd_hhtw, string cplx_mx, string cplx_sv, string cplx_yzj, string cplx_dd, string cplx_dj, string cplx_gb, string cplx_yl, string cplx_ll, string lxys_bd, string lxys_ll, string lxys_lb, string memo, string emergency_period, string normal_period, string is_renew, decimal settlementPrice)
        {
            SQL sql = new SQL("insert into weddingDressProperties(wd_id,wd_date,wd_big_category,wd_litter_category,wd_factory,wd_color,cpml_ls,cpml_ws,cpml_duan,cpml_zs,cpml_other,cpbx_yw,cpbx_ppq,cpbx_ab,cpbx_dq,cpbx_qdhc,bwcd_qd,bwcd_xtw,bwcd_ztw,bwcd_ctw,bwcd_hhtw,cplx_mx,cplx_sv,cplx_yzj,cplx_dd,cplx_dj,cplx_gb,cplx_yl,cplx_ll,lxys_bd,lxys_ll,lxys_lb,memo,emergency_period,normal_period,is_renew,settlementPrice) values('" + wd_id + "','" + wd_date + "','" + wd_big_category + "','" + wd_litter_category + "','" + wd_factory + "','" + wd_color + "','" + cpml_ls + "','" + cpml_ws + "','" + cpml_duan + "','" + cpml_zs + "','" + cpml_other + "','" + cpbx_yw + "','" + cpbx_ppq + "','" + cpbx_ab + "','" + cpbx_dq + "','" + cpbx_qdhc + "','" + bwcd_qd + "','" + bwcd_xtw + "','" + bwcd_ztw + "','" + bwcd_ctw + "','" + bwcd_hhtw + "','" + cplx_mx + "','" + cplx_sv + "','" + cplx_yzj + "','" + cplx_dd + "','" + cplx_dj + "','" + cplx_gb + "','" + cplx_yl + "','" + cplx_ll + "','" + lxys_bd + "','" + lxys_ll + "','" + lxys_lb + "','" + memo + "','" + emergency_period + "','" + normal_period + "','" + is_renew + "'," + settlementPrice + ")");
            Queue<SQL> sqls = new Queue<SQL>();
            sqls.Enqueue(sql);
            return save(sqls);
        }

        public static bool InsertWeddingDressSizeAndNumber(string wd_id, string wd_size, string wd_price, string wd_huohao, string wd_listing_date, int wd_count, string wd_merchant_code, string wd_barcode, int wd_realtime_count)
        {
            Queue<SQL> sqls = new Queue<SQL>();
            SQL sql = new SQL("insert into weddingDressSizeAndNumber(wd_id,wd_size,wd_price,wd_huohao,wd_listing_date,wd_count,wd_merchant_code,wd_barcode,wd_realtime_count,storeId) values ('" + wd_id.Trim() + "','" + wd_size.Trim() + "','" + wd_price.Trim() + "','" + wd_huohao.Trim() + "','" + wd_listing_date.Trim() + "'," + wd_count + ",'" + wd_merchant_code.Trim() + "','" + wd_barcode.Trim() + "'," + wd_realtime_count + ", " + Sharevariables.StoreId + ")");
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
            SQL sql = new SQL("insert into customers(customerID,brideName,brideContact,memo,channelId,storeId,wangwangID,operatorName,status,createDate,partnerName) values('" + customer.customerID + "','" + customer.brideName + "','" + customer.brideContact + "','" + customer.memo + "'," + customer.channelId + "," + customer.storeId + ",'" + customer.wangwangID + "','" + customer.operatorName + "'," + customer.status + ",'" + DateTime.Today.ToShortDateString() + "','" + customer.partnerName + "')");
            sqls.Enqueue(sql);
            return save(sqls);
        }
        private static Queue<SQL> generateOrderQueue(Order order, List<OrderDetail> orderDetails, OrderFlow orderFlow)
        {
            Queue<SQL> sqls = new Queue<SQL>();
            SQL sql = new SQL("declare @flowId int; insert into [orderFlow] (statusId,changeReason,customizedPrice, expressNumberToStore, expressNumberToFactory, expressNumberToCustomer) values('" + orderFlow.statusId + "','" + ((orderFlow.changeReason == null) ? (object)DBNull.Value : orderFlow.changeReason) + "','" + orderFlow.customizedPrice + "','" + ((orderFlow.expressNumberToStore == null) ? (object)DBNull.Value : orderFlow.expressNumberToStore) + "','" + ((orderFlow.expressNumberToFactory == null) ? (object)DBNull.Value : orderFlow.expressNumberToFactory) + "', '" + ((orderFlow.expressNumberToCustomer == null) ? (object)DBNull.Value : orderFlow.expressNumberToCustomer) + "');     set @flowId=SCOPE_IDENTITY();        insert into [order] (orderid,customerid, orderamountafter, depositamount,totalamount,deliveryType,getdate,returndate,address, memo,createdDate,flowId,storeId) values ('" + order.orderID + "','" + order.customerID + "', " + order.orderAmountafter.ToString() + "," + order.depositAmount.ToString() + ", " + order.totalAmount.ToString() + ",'" + order.deliveryType + "','" + order.getDate.ToShortDateString() + "','" + order.returnDate.ToShortDateString() + "','" + order.address + "','" + order.memo + "', '" + DateTime.Today.ToShortDateString() + "',@flowId,'" + Sharevariables.StoreId + "')");
            sqls.Enqueue(sql);
            sql = new SQL("update customers set accountpayable=" + (order.totalAmount - order.orderAmountafter).ToString() + " where customerid='" + order.customerID + "'");
            sqls.Enqueue(sql);
            foreach (OrderDetail orderDetail in orderDetails)
            {
                sql = new SQL();
                sql.Sql = "insert into orderdetail(orderid,wd_id,wd_size,orderType,wd_color,wd_image) values('" + orderDetail.orderID + "','" + orderDetail.wd_id + "','" + ((orderDetail.wd_size == null) ? (Object)DBNull.Value : orderDetail.wd_size) + "','" + orderDetail.orderType + "','" + ((orderDetail.wd_color == null) ? (Object)DBNull.Value : orderDetail.wd_color) + "',@wd_image)";
                SqlParameter parameter;
                if (orderDetail.wd_image == null)
                {
                    parameter = new SqlParameter("@wd_image", SqlDbType.Image);
                    parameter.Value = DBNull.Value;
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
                if (orderDetail.orderType == "卖样衣")
                {
                    sql = new SQL("update weddingdresssizeandnumber set wd_count=(select wd_count from weddingdresssizeandnumber where wd_id='" + orderDetail.wd_id + "' and wd_size='" + orderDetail.wd_size + "')-1 where wd_id='" + orderDetail.wd_id + "' and wd_size='" + orderDetail.wd_size + "' and storeId=" + Sharevariables.StoreId);
                    sqls.Enqueue(sql);
                }
            }
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
            SQL sql = new SQL("delete from [order] where orderId='" + order.orderID + "'");
            sqls.Enqueue(sql);
            sql = new SQL("delete from [orderdetail] where orderid='" + order.orderID + "'");
            sqls.Enqueue(sql);
            foreach (OrderDetail orderDetail in originalOrderDetails)
            {
                if (orderDetail.orderType == "卖样衣")
                {
                    sql = new SQL("update weddingDressSizeAndNumber set wd_count=(select wd_count from weddingDressSizeAndNumber where wd_id='" + orderDetail.wd_id + "' and wd_size='" + ((orderDetail.wd_size == null) ? (Object)DBNull.Value : orderDetail.wd_size) + "' and storeId=" + Sharevariables.StoreId + ")+1 where wd_id='" + orderDetail.wd_id + "' and wd_size='" + ((orderDetail.wd_size == null) ? (Object)DBNull.Value : orderDetail.wd_size) + "' and storeId=" + Sharevariables.StoreId);
                    sqls.Enqueue(sql);
                }
            }
            Queue<SQL> sqls1 = generateOrderQueue(order, orderDetails, orderFlow);
            while (sqls1.Count > 0)
            {
                sqls.Enqueue(sqls.Dequeue());
            }
            return save(sqls);
        }
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


