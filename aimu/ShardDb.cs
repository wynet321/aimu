﻿using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

using System.Collections.Generic;
using System.Text;

namespace aimu
{
    public static class ShardDb
    {
        private static Db shardDb = new Db(Sharevariables.ShardDbConnectionString);
        public static Data getCityByStoreId(int storeId)
        {
            String sql = "select c.id, c.name from customerStore as s left join customerCity as c on s.cityId=c.id where s.id=" + storeId;
            return shardDb.get(sql);
        }

        public static Store getStore(int id)
        {
            string sql = "select * from customerStore where id=" + id;
            Store store = new Store();
            Data data = shardDb.get(sql);
            if (!data.Success)
            {
                return store;
            }
            store.id = id;
            store.cityId = Convert.ToInt16(data.DataTable.Rows[0]["cityId"]);
            store.name = data.DataTable.Rows[0]["name"].ToString();
            return store;
        }

        public static Data getCities()
        {
            String sql = "select id,name from customerCity order by id";
            return shardDb.get(sql);
        }

        public static Data getStatuses()
        {
            String sql = "select id,name from customerStatus order by id";
            return shardDb.get(sql);
        }

        public static Data getStores(int cityId)
        {
            String sql = "select id, name from customerStore where cityId=" + cityId + " order by id";
            return shardDb.get(sql);
        }

        public static Data getChannels()
        {
            string sql = "select id,name from customerchannel";
            return shardDb.get(sql);
        }

        public static Data getCustomerStatus()
        {
            String sql = "select id,name from customerStatus order by id";
            return shardDb.get(sql);
        }

        public static Data getDressStatistic(String start, String end, String orderType)
        {
            string sql = "select d.wd_id,COUNT(d.wd_id) as cnt from orderDetail d left join [order] o on o.id = d.orderID where d.orderType = '" + orderType + "' and o.getDate > '" + start + "' and o.getDate<'" + end + "'  and o.storeId=" + Sharevariables.StoreId + " group by d.wd_id order by cnt desc";
            return shardDb.get(sql);
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

            string sql = "SELECT c.id, c.brideName, c.brideContact, c.marryDay, c.jdgw, o.createdDate, o.totalAmount, o.orderAmountafter, c.channelId, o.id, d.orderType, s.name,c.status,c.partnerName FROM dbo.[order] AS o LEFT OUTER JOIN dbo.customers AS c ON o.customerID = c.id left outer JOIN(SELECT orderid, ordertype = STUFF((SELECT DISTINCT ', ' + ordertype FROM orderdetail b WHERE b.orderid = a.orderid FOR XML PATH('')), 1, 2, '') FROM orderdetail a GROUP BY orderid  ) as d on d.orderid = o.id left join customerStatus as s on c.status=s.id " + whereClause + " and o.storeId=" + Sharevariables.StoreId;
            return shardDb.get(sql);
        }

        public static Data getCustomerChannels()
        {
            string sql = "select id,name from customerchannel order by id asc";
            return shardDb.get(sql);
        }

        public static Data getSumOfSettlementPriceByIds(string[] ids)
        {
            string sql = "select sum(settlementprice) from dressDefinition where wd_id in (";
            foreach (string id in ids)
            {
                sql += "'" + id + "',";
            }
            sql = sql.Substring(0, sql.Length - 1) + ")";
            return shardDb.get(sql);
        }

        public static Data getOrderStatuses()
        {
            String sql = "select id, name, userRole, preStatusId from orderStatus";
            return shardDb.get(sql);
        }

        public static Data getCustomersByOrderId(string orderId)
        {
            String sql = "select id,bridename,bridecontact from customers where id=(select customerid from [order] where id='" + orderId + "')";
            return shardDb.get(sql);
        }

        public static Data getOrderByStatus(int statusId)
        {
            String sql = "select [order].id,c.brideName,c.brideContact,[order].orderamountafter,[Order].totalamount, [Order].depositamount, [Order].deliverytype,[Order].getdate,replace([Order].returndate,'1900-01-01','') as returndate,[Order].address,[Order].memo from [dbo].[Order] left join customers c on [order].customerId=c.id left join [OrderFlow] on [Order].flowId=[OrderFlow].id where [OrderFlow].statusId='" + statusId + "' and [Order].storeId=" + Sharevariables.StoreId + " order by createdDate desc";
            return shardDb.get(sql);
        }

        public static Data getOrderStatus(int userLevel)
        {
            string sql = "SELECT id,name FROM [dbo].[orderStatus] where (" + userLevel + " & userRole >0)";
            return shardDb.get(sql);
        }

        public static Data getOrderByCustomerId(int customerId)
        {
            String sql = "select id, orderamountafter, totalamount, depositamount, deliverytype,getdate,returndate,address,memo,flowId from [dbo].[Order] where [customerID]=" + customerId + " order by id desc";
            return shardDb.get(sql);
        }

        public static Data getOrders()
        {
            String sql = "select id, orderamountafter, totalamount, depositamount, deliverytype,getdate,replace(returndate,'1900-01-01','') as returndate,address,memo from [dbo].[Order] order by id desc";
            return shardDb.get(sql);
        }

        public static Data getOrderFlowById(int id)
        {
            String sql = "select statusId, changeReason, customizedPrice, expressNumberToStore, expressNumberToFactory,expressNumberToCustomer from [orderFlow] where id=" + id;
            return shardDb.get(sql);
        }

        public static Data getOrderAmount(DateTime date)
        {
            String sql = "select sum(convert(int,totalAmount)), sum(convert(int,orderAmountAfter)) from [order] where createdDate='" + date.ToShortDateString() + "' and [order].storeId=" + Sharevariables.StoreId;
            return shardDb.get(sql);
        }

        public static Data getOrderDetailsById(int orderId)
        {
            string sql = "select o.orderId, o.ordertype,o.wd_id,o.wd_color,o.wd_size, o.wd_image, s.wd_price from orderdetail o left join dress s on o.wd_id=s.wd_id and o.wd_size=s.wd_size where o.orderid=" + orderId;
            return shardDb.get(sql);
        }

        public static Data getPropertiesByWdId(String wdId)
        {
            string sql = "select wd_size, wd_price from dress where wd_id='" + wdId + "' and storeId=" + Sharevariables.StoreId;
            return shardDb.get(sql);
        }

        public static Data getSizesByWdId(String WdId)
        {
            string sql = "select wd_size from dress where wd_id='" + WdId + "' and storeId=" + Sharevariables.StoreId + " order by wd_size asc";
            return shardDb.get(sql);
        }

        public static Data getColorsByWdId(String wdId)
        {
            string sql = "select wd_color from dressDefinition where wd_id='" + wdId + "' order by wd_color asc";
            return shardDb.get(sql);
        }

        public static Data getCollisionPeriod(String wd_id)
        {
            string sql = "select  c.brideName as 新娘姓名,c.brideContact as 联系方式, c.marryDay as 婚期, o.getDate as 取纱日期, o.returnDate as 还纱日期, d.orderType as 订单类别, d.wd_size as 尺寸  from [order] o left join OrderDetail d on o.id=d.orderid left join customers c on o.customerid=c.id where d.wd_id='" + wd_id + "' and o.storeId=" + Sharevariables.StoreId + " order by c.marryDay";
            Data data = shardDb.get(sql);
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
            return shardDb.get(sql);
        }

        //public static Data getUser(string username, string password)
        //{
        //    string sql = "SELECT * FROM [user] where u_name='" + username + "' and u_password='" + password + "'";
        //    return shardDb.get(sql);
        //}

        public static Data getDressIdsByCondition(string queryCondition)
        {
            string[] queryArr = queryCondition.Split('\\');
            Data data = new Data();
            if (queryArr.Length == 2)
            {
                string sql;
                sql = "SELECT [wd_id] as 货号 FROM [dressDefinition] where wd_big_category='" + queryArr[0] + "' and wd_litter_category='" + queryArr[1] + "' order by wd_date desc";
                return shardDb.get(sql);
            }
            data.Success = true;
            return data;
        }

        public static Data getThumbnailsByIds(DataTable Ids)
        {
            StringBuilder idBuilder = new StringBuilder();
            foreach (DataRow row in Ids.Rows)
            {
                idBuilder.Append("'").Append(row.ItemArray[0].ToString()).Append("',");
            }
            string ids = idBuilder.ToString();
            ids = ids.Substring(0, ids.Length - 1);
            string sql = "select wd_id,thumbnail from dressImage where wd_id in (" + ids + ") and pic_id='1'";
            return shardDb.get(sql);
        }

        public static Data getWeddingDressIds(string wd_id)
        {
            string sql = "SELECT [wd_id] FROM [dressDefinition] where wd_id='" + wd_id + "'";
            return shardDb.get(sql);
        }

        public static Data getDressById(String wd_id)
        {
            string sql = "SELECT id,[wd_size] ,[wd_price] ,[wd_listing_date] ,[wd_count],storeId  FROM [dress] where wd_id='" + wd_id + "' and storeId=" + Sharevariables.StoreId + " order by id";
            return shardDb.get(sql);
        }

        public static Data getDressDefinitionById(String wd_id)
        {
            string sql = "SELECT [wd_date] ,[wd_big_category] ,[wd_litter_category] ,[wd_factory] ,[wd_color] ,[attribute] ,[memo] ,[emergency_period],[normal_period],[is_renew],[settlementPrice] FROM [dressDefinition] where wd_id='" + wd_id + "'";
            return shardDb.get(sql);
        }

        public static Data getCount(string wd_id, string wd_size)
        {
            string sql = "select wd_count from dress where wd_id='" + wd_id + "' and wd_size='" + wd_size + "' and storeId=" + Sharevariables.StoreId;
            return shardDb.get(sql);
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
            return shardDb.get(sql);
        }

        public static Data getCustomerByName(String name)
        {
            string sql = "SELECT [id],[brideName],[brideContact] FROM [customers] where [brideName]='" + name + "' and storeId=" + Sharevariables.StoreId;
            return shardDb.get(sql);
        }

        public static Data getCustomerByTel(String tel)
        {
            string sql = "SELECT [id],[brideName],[brideContact] FROM [customers] where [brideContact]='" + tel + "' and storeId=" + Sharevariables.StoreId;
            return shardDb.get(sql);
        }

        public static Data getCustomersById(int id)
        {
            string sql = "SELECT [brideName],[brideContact],[marryDay],[channelId],[reserveDate],[reserveTime],[tryDress],[memo],[scsj_jsg],[scsj_cxsg],[scsj_tz],[scsj_xw],[scsj_xxw],[scsj_yw],[scsj_dqw],[scsj_tw],[scsj_jk],[scsj_jw],[scsj_dbw],[scsj_yddc],[scsj_qyj],[scsj_bpjl],[status],[jdgw],[groomName],[groomContact] ,[wangwangID],[id], [reservetimes], [retailerMemo],[hisreason],[storeId],[accountpayable],[refund],[fine],[partnerName] FROM [customers] where [id]='" + id + "'";
            return shardDb.get(sql);
        }

        public static Data getImagesByDressId(String wd_id)
        {
            string sql = "SELECT [wd_id] ,[pic_id] ,[pic_img], thumbnail FROM [dressImage] where wd_id='" + wd_id + "'";
            return shardDb.get(sql);
        }

        public static Data getImages(int start, int end)
        {
            string sql = "SELECT [wd_id] ,[pic_id] ,[pic_img], thumbnail from (select [wd_id],[pic_id],[pic_img], thumbnail, row_number() over(order by wd_id, pic_id) as r from dressImage) t where r > '" + start + "' and r <= '" + end + "';";
            return shardDb.get(sql);
        }

        public static Data getImageCount()
        {
            string sql = "select count(*) from dressImage";
            return shardDb.get(sql);
        }

        public static Data getPicName(String wd_id)
        {
            string sql = "SELECT [wd_id] ,[pic_id] ,[pic_name] FROM [dressImage] where wd_id='" + wd_id + "'";
            return shardDb.get(sql);
        }

        public static Data getCustomers(string filter, string orderBy)
        {
            string sql = "SELECT c.id,brideName,brideContact,customerStatus.name,jdgw,reserveDate,reserveTime,marryDay,infoChannel,wangwangId,operatorName FROM customers as c left join customerStatus on c.status=customerStatus.id " + filter + " " + orderBy;
            return shardDb.get(sql);
        }

        public static Data getTryOnListByCustomerId(string customerID)
        {
            string sql = "select A.wd_id,A.wd_big_category,A.wd_litter_category,B.wdSize,A.wd_color,B.id from (SELECT [wd_id] ,[wd_big_category] ,[wd_litter_category] ,[wd_color] FROM [dressDefinition]) A,(SELECT [customerID] ,[wdId] ,[wdSize],id FROM [customerTryDressList] where customerID='" + customerID + "') B where A.wd_id=B.wdId";
            return shardDb.get(sql);
        }

        public static Data getOrderListByCustomerId(string customerID)
        {
            string sql = "select id,createdDate,totalamount,orderAmountafter, depositamount,memo from [order] where customerid='" + customerID + "'";
            return shardDb.get(sql);
        }

        public static bool deleteByCustomerIDInClusterTable(string cid)
        {
            Queue<Statement> sqls = new Queue<Statement>();
            Statement sql = new Statement("delete from customers  where customerID='" + cid + "'");
            sqls.Enqueue(sql);
            return shardDb.save(sqls);
        }

        public static bool deleteWeddingDressByID(string wid)
        {
            Queue<Statement> sqls = new Queue<Statement>();
            Statement sql = new Statement("delete from dressDefinition  where wd_id='" + wid + "'");
            sqls.Enqueue(sql);
            return shardDb.save(sqls);
        }
        public static bool deletedressByID(string wid)
        {
            Queue<Statement> sqls = new Queue<Statement>();
            Statement sql = new Statement("delete from dress  where wd_id='" + wid + "'");
            sqls.Enqueue(sql);
            return shardDb.save(sqls);
        }
        public static bool deleteDressImageByID(string wid)
        {
            Queue<Statement> sqls = new Queue<Statement>();
            Statement sql = new Statement("delete from dressImage  where wd_id='" + wid + "'");
            sqls.Enqueue(sql);
            return shardDb.save(sqls);
        }
        public static bool updateCustomerInfo(Customer ci)
        {
            Queue<Statement> sqls = new Queue<Statement>();
            Statement sql = new Statement("update customers set brideName='" + ci.brideName + "', reservetimes=" + ci.reservetimes + ", status='" + ci.status + "',brideContact='" + ci.brideContact + "',groomName='" + ci.groomName + "',groomContact='" + ci.groomContact + "',marryDay='" + ci.marryDay + "',channelId='" + ci.channelId + "',storeId='" + ci.storeId + "',reserveDate='" + ci.reserveDate + "',reserveTime='" + ci.reserveTime + "',tryDress='" + ci.tryDress + "',hisreason='" + ci.reason + "',scsj_jsg='" + ci.scsj_jsg + "',scsj_cxsg='" + ci.scsj_cxsg + "',scsj_tz='" + ci.scsj_tz + "',scsj_xw='" + ci.scsj_xw + "',scsj_xxw='" + ci.scsj_xxw + "',scsj_yw='" + ci.scsj_yw + "',scsj_dqw='" + ci.scsj_dqw + "',scsj_tw='" + ci.scsj_tw + "',scsj_jk='" + ci.scsj_jk + "',scsj_jw='" + ci.scsj_jw + "',scsj_dbw='" + ci.scsj_dbw + "',scsj_yddc='" + ci.scsj_yddc + "',scsj_qyj='" + ci.scsj_qyj + "',scsj_bpjl='" + ci.scsj_bpjl + "',wangwangID='" + ci.wangwangID + "',jdgw='" + ci.jdgw + "',address='" + ci.address + "',retailerMemo='" + ci.retailerMemo + "',refund='" + ci.refund + "',fine='" + ci.fine + "', partnerName='" + ci.partnerName + "' where id='" + ci.id + "'");
            sqls.Enqueue(sql);
            return shardDb.save(sqls);
        }
        public static bool insertChannel(String channelName)
        {
            Queue<Statement> sqls = new Queue<Statement>();
            Statement sql = new Statement("insert into customerChannel values('" + channelName + "')");
            sqls.Enqueue(sql);
            return shardDb.save(sqls);
        }

        public static bool deleteTryonById(string id)
        {
            Queue<Statement> sqls = new Queue<Statement>();
            Statement sql = new Statement("delete from [customerTryDressList] where id='" + id + "'");
            sqls.Enqueue(sql);
            return shardDb.save(sqls);
        }

        public static bool InsertCustomerTryDressList(int customerId, string wdId, string wdSize, string tryDressDate)
        {
            Queue<Statement> sqls = new Queue<Statement>();
            Statement sql = new Statement("insert into customerTryDressList(customerID,wdId,wdSize,tryDressDate) values(" + customerId + ",'" + wdId + "','" + wdSize + "','" + tryDressDate + "')");
            sqls.Enqueue(sql);
            return shardDb.save(sqls);
        }

        public static bool UpdateWeddingDress(DressDefinition dress)
        {
            Queue<Statement> sqls = new Queue<Statement>();
            Statement sql = new Statement("delete from dressDefinition where wd_id='" + dress.wd_id + "'");
            sqls.Enqueue(sql);
            sql = new Statement("delete from dress where wd_id='" + dress.wd_id + "'");
            sqls.Enqueue(sql);
            sql = new Statement("delete from dressImage where wd_id='" + dress.wd_id + "'");
            sqls.Enqueue(sql);
            Queue<Statement> insertSqls = generateDressQueue(dress);
            while (insertSqls.Count > 0)
            {
                sqls.Enqueue(insertSqls.Dequeue());
            }
            return shardDb.save(sqls);
        }

        private static Queue<Statement> generateDressQueue(DressDefinition dress)
        {
            Queue<Statement> sqls = new Queue<Statement>();
            Statement sql = new Statement("insert into dressDefinition(wd_id,wd_date,wd_big_category,wd_litter_category,wd_factory,wd_color,memo,emergency_period,normal_period,is_renew,settlementPrice,attribute) values('" + dress.wd_id + "','" + dress.wd_date + "','" + dress.wd_big_category + "','" + dress.wd_litter_category + "','" + dress.wd_factory + "','" + dress.wd_color + "','" + dress.memo + "','" + dress.emergency_period + "','" + dress.normal_period + "','" + dress.is_renew + "'," + dress.settlementPrice.ToString() + "," + dress.attribute + ")");
            sqls.Enqueue(sql);

            for (int i = 0; i < dress.wdscs.Length; i++)
            {
                WeddingDressSizeAndCount wdsc = dress.wdscs[i];
                sql = new Statement("insert into dress(wd_id, wd_size, wd_price,  wd_listing_date, wd_count, storeId) values('" + dress.wd_id + "', '" + wdsc.wd_size + "', '" + wdsc.wd_price + "', '" + wdsc.wd_listing_date + "', " + wdsc.wd_count + ", " + Sharevariables.StoreId + ")");
                sqls.Enqueue(sql);
            }

            for (int i = 1; i <= dress.pictures.Count; i++)
            {
                byte[] image = dress.pictures[i];
                byte[] thumbnail = dress.thumbnails[i];
                sql = new Statement();
                sql.Sql = "insert into dressImage(wd_id,pic_id,pic_img,thumbnail) values('" + dress.wd_id + "'," + i + ",@pic_img,@thumbnail)";
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
        public static bool InsertWeddingDress(DressDefinition dress)
        {
            Queue<Statement> sqls = generateDressQueue(dress);
            return shardDb.save(sqls);
        }


        public static bool updatePictures(Picture[] pictures)
        {
            Queue<Statement> sqls = new Queue<Statement>();
            for (int i = 0; i < pictures.Length; i++)
            {
                byte[] image = pictures[i].pic_image;
                byte[] thumbnail = pictures[i].thumbnail;
                Statement sql = new Statement();
                sql.Sql = "update dressImage set pic_img=@pic_img, thumbnail=@thumbnail where wd_id='" + pictures[i].wd_id + "' and pic_id='" + pictures[i].pic_id + "'";
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
            return shardDb.save(sqls);
        }

        public static bool insertStore(Store store)
        {
            Statement statement = new Statement("insert into customerStore values('" + store.name + "'," + store.cityId + ")");
            return (shardDb.save(statement) == 1) ? true : false;
        }

        public static bool insertCustomer(Customer customer)
        {
            Queue<Statement> sqls = new Queue<Statement>();
            Statement sql = new Statement("insert into customers(brideName,brideContact,memo,channelId,storeId,wangwangID,operatorName,status,createDate,partnerName) values('" + customer.brideName + "','" + customer.brideContact + "','" + customer.memo + "'," + customer.channelId + "," + customer.storeId + ",'" + customer.wangwangID + "','" + customer.operatorName + "'," + customer.status + ",'" + DateTime.Today.ToShortDateString() + "','" + customer.partnerName + "')");
            sqls.Enqueue(sql);
            return shardDb.save(sqls);
        }
        private static Queue<Statement> generateOrderQueue(Order order, List<OrderDetail> orderDetails, OrderFlow orderFlow)
        {
            Queue<Statement> sqls = new Queue<Statement>();
            Statement sql;
            if (Sharevariables.EnableWorkFlow)
            {
                sql = new Statement("declare @flowId int; insert into [orderFlow] (statusId,changeReason,customizedPrice, expressNumberToStore, expressNumberToFactory, expressNumberToCustomer,parentId) values('" + orderFlow.statusId + "','" + ((orderFlow.changeReason == null) ? (object)DBNull.Value : orderFlow.changeReason) + "','" + orderFlow.customizedPrice + "','" + ((orderFlow.expressNumberToStore == null) ? (object)DBNull.Value : orderFlow.expressNumberToStore) + "','" + ((orderFlow.expressNumberToFactory == null) ? (object)DBNull.Value : orderFlow.expressNumberToFactory) + "', '" + ((orderFlow.expressNumberToCustomer == null) ? (object)DBNull.Value : orderFlow.expressNumberToCustomer) + "'," + orderFlow.parentId + "); set @flowId=SCOPE_IDENTITY(); select @flowId;");
                sql.ReturnValue = true;
                sqls.Enqueue(sql);
                sql = new Statement("declare @orderId int;insert into [order] (customerid, orderamountafter, depositamount,totalamount,deliveryType,getdate,returndate,address, memo,createdDate,flowId,storeId) values ('" + order.customerID + "', " + order.orderAmountafter.ToString() + "," + order.depositAmount.ToString() + ", " + order.totalAmount.ToString() + ",'" + order.deliveryType + "','" + order.getDate.ToShortDateString() + "','" + order.returnDate.ToShortDateString() + "','" + order.address + "','" + order.memo + "', '" + DateTime.Today.ToShortDateString() + "',@returnedValue,'" + Sharevariables.StoreId + "'); set @orderId=SCOPE_IDENTITY(); select @orderId");
                sql.ReturnValue = true;
                sql.UseReturnValue = true;
                sqls.Enqueue(sql);
            }
            else
            {
                sql = new Statement("declare @orderId int;insert into [order] (customerid, orderamountafter, depositamount,totalamount,deliveryType,getdate,returndate,address, memo,createdDate,storeId) values ('" + order.customerID + "', " + order.orderAmountafter.ToString() + "," + order.depositAmount.ToString() + ", " + order.totalAmount.ToString() + ",'" + order.deliveryType + "','" + order.getDate.ToShortDateString() + "','" + order.returnDate.ToShortDateString() + "','" + order.address + "','" + order.memo + "', '" + DateTime.Today.ToShortDateString() + "','" + Sharevariables.StoreId + "'); set @orderId=SCOPE_IDENTITY(); select @orderId");
                sql.ReturnValue = true;
                sql.UseReturnValue = true;
                sqls.Enqueue(sql);
            }

            foreach (OrderDetail orderDetail in orderDetails)
            {
                sql = new Statement();
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
                    sql = new Statement("update dress set wd_count=(select wd_count from dress where wd_id='" + orderDetail.wd_id + "' and wd_size='" + orderDetail.wd_size + "')-1 where wd_id='" + orderDetail.wd_id + "' and wd_size='" + orderDetail.wd_size + "' and storeId=" + Sharevariables.StoreId);
                    sqls.Enqueue(sql);
                }
            }
            sql = new Statement("update customers set accountpayable=" + (order.totalAmount - order.orderAmountafter).ToString() + " where id='" + order.customerID + "'");
            sqls.Enqueue(sql);
            return sqls;
        }
        public static bool insertOrder(Order order, List<OrderDetail> orderDetails, OrderFlow orderFlow)
        {
            Queue<Statement> sqls = generateOrderQueue(order, orderDetails, orderFlow);
            return shardDb.save(sqls);
        }
        public static bool updateOrderbyId(Order order, List<OrderDetail> orderDetails, List<OrderDetail> originalOrderDetails, OrderFlow orderFlow)
        {
            Queue<Statement> sqls = new Queue<Statement>();
            Statement sql = new Statement("delete from [order] where id=" + order.id);
            sqls.Enqueue(sql);
            sql = new Statement("delete from [orderdetail] where orderid=" + order.id);
            sqls.Enqueue(sql);
            foreach (OrderDetail orderDetail in originalOrderDetails)
            {
                if (orderDetail.orderType == "卖样衣")
                {
                    sql = new Statement("update dress set wd_count=(select wd_count from dress where wd_id='" + orderDetail.wd_id + "' and wd_size='" + ((orderDetail.wd_size == null) ? (Object)DBNull.Value : orderDetail.wd_size) + "' and storeId=" + Sharevariables.StoreId + ")+1 where wd_id='" + orderDetail.wd_id + "' and wd_size='" + ((orderDetail.wd_size == null) ? (Object)DBNull.Value : orderDetail.wd_size) + "' and storeId=" + Sharevariables.StoreId);
                    sqls.Enqueue(sql);
                }
            }
            Queue<Statement> sqlsNewOrder = generateOrderQueue(order, orderDetails, orderFlow);
            while (sqlsNewOrder.Count > 0)
            {
                sqls.Enqueue(sqlsNewOrder.Dequeue());
            }
            return shardDb.save(sqls);
        }
    }
}



