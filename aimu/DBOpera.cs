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
        //private static string IP = "127.0.0.1,2433";
        private static string Usr = "sa";
        private static string Pwd = "liu@879698";
        //private static string DBn = "aimu_hefei";
        //private static string DBn = "aimu_center";
        private static string DBn = "aimu_test";
        private static SqlConnection m_envconn = null;


        private static void getIni()
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
        public static SqlConnection GetEnvConn()
        {
            if (m_envconn == null)
            {
                getIni();
                m_envconn = GetConn(IP, Usr, Pwd, DBn);
            }
            return m_envconn;
        }
        //close connection
        public static void Close()
        {
            if (m_envconn != null)
            {
                m_envconn.Close();
            }
        }

        private static SqlConnection GetConn(string IP, string Uid, string Pwd, string DbName)
        {
            try
            {
                string cnStr = "server=" + IP + ";uid=" + Uid + ";pwd=" + Pwd + ";database=" + DbName;
                SqlConnection m_conn = new SqlConnection(cnStr);

                m_conn.Open();
                // 上网上查一下，判断是否连接成功！！
                if (m_conn.State != ConnectionState.Open)
                {
                    m_conn = null;
                }
                return m_conn;
            }
            catch (Exception ef)
            {
                MessageBox.Show(ef.ToString());
                //SqlConnection m_envconnNull = null;
                //return m_envconnNull;
                return null;
            }
        }
        //private static SqlConnection m_envconn = null;
    }





    public static class ReadData
    {

        //查询客户所有订单
        public static DataTable fillCustomersOrderByID(string cid)
        {
            string sql = "SELECT * FROM [dbo].[Order] where [customerID]='" + cid + "' order by orderID desc";
            SqlConnection m_envconn = Connection.GetEnvConn();
            SqlCommand cmd = new SqlCommand(sql, m_envconn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static Order getOrderByCustomerId(string customerId)
        {
            String sql = "select orderId, orderamountafter, totalamount, depositamount, deliverytype,getdate,returndate,address,memo from [dbo].[Order] where [customerID]='" + customerId + "' order by orderID desc";
            SqlConnection m_envconn = Connection.GetEnvConn();
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
                order.orderAmountafter = dr.ItemArray[1].ToString();
                order.totalAmount = dr.ItemArray[2].ToString();
                order.depositAmount = dr.ItemArray[3].ToString();
                order.deliveryType = dr.ItemArray[4].ToString();
                order.getDate = (DateTime)dr.ItemArray[5];
                order.returnDate = (DateTime)dr.ItemArray[6];
                order.address = dr.ItemArray[7].ToString();
                order.memo = dr.ItemArray[8].ToString();
            }
            return order;
        }

        //租赁：定金（没交完全款的都叫定金），押金是婚纱价格，定金和租金是婚纱价格的一半
        //查询客户：已交定金的订单，已取纱的订单，财务已审核，工厂已接单，工厂已
        public static DataTable fillCustomersOrderByID(string cid, string orderStatusInput)
        {
            string sql = "SELECT [orderID] ,[customerID] ,[wdData] ,[orderAmountPre] ,[orderAmountafter] ,[orderDiscountRate] ,[orderPaymentMethod] ,[reservedAmount] ,[depositAmount] ,[depositPaymentMethod] ,[totalAmount] ,[returnAmount] ,[orderStatus] ,[orderType] ,[receptionConsultant] FROM [customerOrder] where [customerID]='" + cid + "' and [orderStatus] ='" + orderStatusInput + "' order by orderID desc";
            SqlConnection m_envconn = Connection.GetEnvConn();
            SqlCommand cmd = new SqlCommand(sql, m_envconn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        //public static Order getCustomersOrderByID(String cid)
        //{
        //    try
        //    {
        //        Order co = new Order();
        //        string sql = "SELECT [orderID] ,[customerID] ,[wdData] ,[orderAmountPre] ,[orderAmountafter] ,[orderDiscountRate] ,[orderPaymentMethod] ,[reservedAmount] ,[depositAmount] ,[depositPaymentMethod] ,[totalAmount] ,[returnAmount] ,[orderStatus] ,[orderType] ,[receptionConsultant] FROM [customerOrder] where [customerID]='" + cid + "' order by orderID desc";
        //        DataSet ds = GetDataSet(sql, "Customers");
        //        foreach (DataRow dr in ds.Tables["Customers"].Rows)
        //        {
        //            co.orderID = dr[0] == null ? "" : dr[0].ToString();
        //            co.customerID = dr[1] == null ? "" : dr[0].ToString();
        //            co.wdData = dr[2] == null ? "" : dr[0].ToString();
        //            co.orderAmountPre = dr[3] == null ? "" : dr[0].ToString();
        //            co.orderAmountafter = dr[4] == null ? "" : dr[0].ToString();
        //            co.orderDiscountRate = dr[5] == null ? "" : dr[0].ToString();
        //            co.orderPaymentMethod = dr[6] == null ? "" : dr[0].ToString();
        //            co.reservedAmount = dr[7] == null ? "" : dr[0].ToString();
        //            co.depositAmount = dr[8] == null ? "" : dr[0].ToString();
        //            co.depositPaymentMethod = dr[9] == null ? "" : dr[0].ToString();
        //            co.totalAmount = dr[10] == null ? "" : dr[0].ToString();
        //            co.returnAmount = dr[11] == null ? "" : dr[0].ToString();
        //            co.orderStatus = dr[12] == null ? "" : dr[0].ToString();
        //            co.orderType = dr[13] == null ? "" : dr[0].ToString();
        //            co.receptionConsultant = dr[14] == null ? "" : dr[0].ToString();


        //        }
        //        return co;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        return null;

        //    }

        //}

        public static List<OrderDetail> getOrderDetailsById(String orderId)
        {
            List<OrderDetail> orderDetails = new List<OrderDetail>();
            string sql = "select o.orderId, o.ordertype,o.wd_id,o.wd_color,o.wd_size, o.wd_image, s.wd_price from orderdetail o left join weddingdresssizeandnumber s on o.wd_id=s.wd_id and o.wd_size=s.wd_size where o.orderid='" + orderId + "'";
            DataSet ds = GetDataSet(sql, "OrderDetails");
            foreach (DataRow dr in ds.Tables["OrderDetails"].Rows)
            {
                OrderDetail orderDetail = new OrderDetail();
                orderDetail.orderID = dr.ItemArray[0].ToString();
                orderDetail.wd_id = dr.ItemArray[2].ToString();
                orderDetail.wd_size = dr.ItemArray[4].ToString();
                orderDetail.wd_color = dr.ItemArray[3].ToString();
                orderDetail.wd_price = dr.ItemArray[6].ToString();
                orderDetail.orderType = dr.ItemArray[1].ToString();
                if (dr.ItemArray[5] != DBNull.Value)
                {
                    orderDetail.wd_image = (byte[])dr.ItemArray[5];
                }
                orderDetails.Add(orderDetail);
            }
            return orderDetails;
        }

        public static String getPriceByWdId(String wdId)
        {
            string sql = "select wd_price from weddingdresssizeandnumber where wd_id='" + wdId + "'";
            DataSet ds = GetDataSet(sql, "price");
            if (ds.Tables["price"].Rows.Count > 0)
            {
                return ds.Tables["price"].Rows[0].ItemArray[0].ToString();
            }
            return "";
        }
        public static List<String> getSizesByWdId(String WdId)
        {
            List<String> sizes = new List<String>();
            string sql = "select wd_size from weddingdresssizeandnumber where wd_id='" + WdId + "' and wd_count>0 order by wd_size asc";
            DataSet ds = GetDataSet(sql, "sizes");
            foreach (DataRow dr in ds.Tables["sizes"].Rows)
            {
                sizes.Add(dr.ItemArray[0].ToString());
            }
            return sizes;
        }

        public static List<String> getColorsByWdId(String wdId)
        {
            List<String> colors = new List<String>();
            string sql = "select wd_color from weddingdressproperties where wd_id='" + wdId + "' order by wd_color asc";
            DataSet ds = GetDataSet(sql, "colors");
            foreach (DataRow dr in ds.Tables["colors"].Rows)
            {
                colors.Add(dr.ItemArray[0].ToString());
            }
            return colors;
        }

        //public static List<String> getTypes()
        //{
        //    List<String> types = new List<String>();
        //    string sql = "select distinct ordertype from customerorder order by ordertype asc";
        //    DataSet ds = GetDataSet(sql, "ordertype");
        //    foreach (DataRow dr in ds.Tables["ordertype"].Rows)
        //    {
        //        types.Add(dr.ItemArray[0].ToString());
        //    }
        //    return types;
        //}
        //public static List<CollisionPeriodManager> getCollisionPeriodManager(String wd_id)
        //{
        //    try
        //    {
        //        List<CollisionPeriodManager> cpmList = new List<CollisionPeriodManager>();

        //        string sql2 = "select A.wd_id,A.wd_size,B.marryDay,B.brideName,B.brideContact,B.customerID from customerOrderDetails A,customers B where B.customerID=A.memo and A.wd_id='" + wd_id + "' order by B.marryDay";
        //        DataSet ds2 = GetDataSet(sql2, "lastestOneMonthCustomers");
        //        foreach (DataRow dr in ds2.Tables["lastestOneMonthCustomers"].Rows)
        //        {
        //            CollisionPeriodManager cpm = new CollisionPeriodManager();
        //            cpm.wd_id = dr[0] == null ? "" : dr[0].ToString();
        //            cpm.wd_size = dr[1] == null ? "" : dr[1].ToString();
        //            cpm.marryDay = dr[2] == null ? "" : dr[2].ToString();
        //            cpm.brideName = dr[3] == null ? "" : dr[3].ToString();
        //            cpm.brideContact = dr[4] == null ? "" : dr[4].ToString();
        //            cpm.customerID = dr[5] == null ? "" : dr[5].ToString();


        //            cpmList.Add(cpm);
        //        }
        //        return cpmList;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        return null;

        //    }

        //}

        //public static DataTable getWeddingDress(string wd_big_category, string wd_litter_category)
        //{
        //    string sql = "select wd_id,wd_date,wd_color from weddingdressproperties where wd_big_category='" + wd_big_category + "' and wd_litter_category = '" + wd_litter_category + "' order by wd_id";
        //    SqlConnection m_envconn = Connection.GetEnvConn();
        //    SqlCommand cmd = new SqlCommand(sql, m_envconn);
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    return dt;
        //}

        public static DataTable getCollisionPeriodManager(String wd_id)
        {
            string sql = "select o.orderid as 订单编号 ,d.wd_id as 货号,d.wd_size as 尺寸 , d.wd_color as 颜色, d.orderType as 订单类别, c.marryDay as 婚期,c.brideName as 新娘姓名,c.brideContact as 联系方式,o.customerID as 客户编号 from [order] o left join OrderDetail d on o.orderid=d.orderid left join customers c on o.customerid=c.customerid where d.wd_id='" + wd_id + "' order by c.marryDay";
            SqlConnection m_envconn = Connection.GetEnvConn();
            SqlCommand cmd = new SqlCommand(sql, m_envconn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static UAccountList getAccount()
        {
            UAccountList lstSensor = new UAccountList();
            try
            {
                string sql = "";
                sql += "SELECT [u_id],[u_name],[u_password],[u_level],[u_memo],[u_city],[u_address],[u_tel] FROM [user]";
                DataSet ds = GetDataSet(sql, "user");
                foreach (DataRow dr in ds.Tables["user"].Rows)
                {
                    UAccount ssr = new UAccount();
                    ssr.u_id = (int)dr[0];
                    ssr.u_name = dr[1] == null ? "" : dr[1].ToString();
                    ssr.u_password = dr[2] == null ? "" : dr[2].ToString();
                    ssr.u_level = (int)dr[3];
                    ssr.u_memo = dr[4] == null ? "" : dr[4].ToString();
                    ssr.u_city = dr[5] == null ? "" : dr[5].ToString();
                    ssr.u_address = dr[6] == null ? "" : dr[6].ToString();
                    ssr.u_tel = dr[7] == null ? "" : dr[7].ToString();
                    lstSensor.Add(ssr);
                }
                return lstSensor;
            }
            catch (Exception ef)
            {
                return null;
            }
        }

        public static List<Customer> getCurrentBTypeCustomerList()
        {
            List<Customer> comstomers = new List<Customer>();

            string sql2 = "SELECT [customerID],[reserveDate],[reserveTime],[status],[reservetimes] FROM [lastestOneMonthCustomers] where status='B'";
            DataSet ds2 = GetDataSet(sql2, "lastestOneMonthCustomers");
            foreach (DataRow dr2 in ds2.Tables["lastestOneMonthCustomers"].Rows)
            {
                Customer ct = new Customer();
                ct.customerID = dr2[0] == null ? "" : dr2[0].ToString();
                ct.reserveDate = dr2[1] == null ? "" : dr2[1].ToString();
                ct.reserveTime = dr2[2] == null ? "" : dr2[2].ToString();
                ct.status = dr2[3] == null ? "" : dr2[3].ToString();
                ct.reservetimes = Convert.ToString((int)dr2[4]);


                comstomers.Add(ct);
            }
            return comstomers;
        }

        public static int getCustomerReservedTimes(String wd_id)
        {
            int times = 0;

            string sql2 = "SELECT [reservetimes]   FROM [customers] where [customerID]='" + wd_id + "'";
            DataSet ds2 = GetDataSet(sql2, "customers");
            foreach (DataRow dr2 in ds2.Tables["customers"].Rows)
            {
                times = (int)dr2[0];
            }
            return times;
        }


        public static DataTable getWeddingID(string queryCondition)
        {
            string[] queryArr = queryCondition.Split('\\');
            if (queryArr.Length == 2)
            {
                string sql;
                if (queryArr[0] == "品牌")
                {
                    sql = "SELECT [wd_id] as 货号 FROM [weddingDressProperties] where wd_factory='" + queryArr[1] + "'  order by wd_date desc";
                }
                else
                {
                    sql = "SELECT [wd_id] as 货号 FROM [weddingDressProperties] where wd_big_category='" + queryArr[0] + "' and wd_litter_category='" + queryArr[1] + "' order by wd_date desc";
                }

                SqlConnection m_envconn = Connection.GetEnvConn();
                SqlCommand cmd = new SqlCommand(sql, m_envconn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            else
            {
                return null;
            }
        }


        //public static int getCountForWeddingDressPropertiesSizeAndNumber(String wd_id, String wd_size)
        //{
        //    int wd_count = 0;
        //    string sql2 = "SELECT [wd_count] FROM [weddingDressSizeAndNumber] where wd_id='" + wd_id + "' and wd_size='" + wd_size + "'";
        //    DataSet ds2 = GetDataSet(sql2, "weddingDressSizeAndNumber");
        //    foreach (DataRow dr2 in ds2.Tables["weddingDressSizeAndNumber"].Rows)
        //    {
        //        Int32.TryParse(dr2[0] == null ? "" : dr2[0].ToString(), out wd_count);
        //    }
        //    return wd_count;
        //}

        public static int getRealtimeCountForWeddingDressPropertiesSizeAndNumber(String wd_id, String wd_size)
        {
            int wd_realtime_count = 0;
            string sql2 = "SELECT [wd_realtime_count] FROM [weddingDressSizeAndNumber] where wd_id='" + wd_id + "' and wd_size='" + wd_size + "'";
            DataSet ds2 = GetDataSet(sql2, "weddingDressSizeAndNumber");
            foreach (DataRow dr2 in ds2.Tables["weddingDressSizeAndNumber"].Rows)
            {
                Int32.TryParse(dr2[0] == null ? "" : dr2[0].ToString(), out wd_realtime_count);
            }
            return wd_realtime_count;
        }

        public static List<string> getWeddingDressIds(string wd_id)
        {
            List<string> ids = new List<string>();
            string sql = "SELECT [wd_id] FROM [weddingDressproperties] where wd_id like '%" + wd_id + "%'";
            DataSet ds2 = GetDataSet(sql, "weddingDressIds");
            foreach (DataRow dr2 in ds2.Tables["weddingDressIds"].Rows)
            {
                ids.Add(dr2[0].ToString());
            }
            return ids;
        }

        public static DataTable getDressProperties(String wd_id)
        {
            //List<WeddingDressSizeAndCount> wdsc = new List<WeddingDressSizeAndCount>();
            string sql = "SELECT [wd_size] as 尺寸 ,[wd_price] as 价格,[wd_huohao] as 货号 ,[wd_listing_date] as 上市日期,[wd_count] as 数量,[wd_merchant_code] as 商家编码,[wd_barcode] as 条形码 FROM [weddingDressSizeAndNumber] where wd_id='" + wd_id + "'";
            SqlConnection m_envconn = Connection.GetEnvConn();
            SqlCommand cmd = new SqlCommand(sql, m_envconn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
            //DataSet ds2 = GetDataSet(sql2, "weddingDressSizeAndNumber");
            //foreach (DataRow dr2 in ds2.Tables["weddingDressSizeAndNumber"].Rows)
            //{
            //    WeddingDressSizeAndCount wdsa = new WeddingDressSizeAndCount();
            //    wdsa.wd_id = wd_id;
            //    wdsa.wd_size = dr2[0] == null ? "" : dr2[0].ToString();
            //    wdsa.wd_price = dr2[1] == null ? "" : dr2[1].ToString();
            //    wdsa.wd_huohao = dr2[2] == null ? "" : dr2[2].ToString();
            //    wdsa.wd_listing_date = dr2[3] == null ? "" : dr2[3].ToString();
            //    wdsa.wd_count = dr2[4] == null ? "" : dr2[4].ToString();
            //    wdsa.wd_merchant_code = dr2[5] == null ? "" : dr2[5].ToString();
            //    wdsa.wd_barcode = dr2[6] == null ? "" : dr2[6].ToString();
            //    wdsc.Add(wdsa);
            //}
            //return wdsc;
        }

        public static List<WeddingDressSizeAndCount> getWeddingDressPropertiesSizeAndNumber(String wd_id)
        {
            List<WeddingDressSizeAndCount> wdsc = new List<WeddingDressSizeAndCount>();
            string sql2 = "SELECT [wd_size] ,[wd_price] ,[wd_huohao] ,[wd_listing_date] ,[wd_count] ,[wd_merchant_code] ,[wd_barcode] FROM [weddingDressSizeAndNumber] where wd_id='" + wd_id + "'";
            DataSet ds2 = GetDataSet(sql2, "weddingDressSizeAndNumber");
            foreach (DataRow dr2 in ds2.Tables["weddingDressSizeAndNumber"].Rows)
            {
                WeddingDressSizeAndCount wdsa = new WeddingDressSizeAndCount();
                wdsa.wd_id = wd_id;
                wdsa.wd_size = dr2[0] == null ? "" : dr2[0].ToString();
                wdsa.wd_price = dr2[1] == null ? "" : dr2[1].ToString();
                wdsa.wd_huohao = dr2[2] == null ? "" : dr2[2].ToString();
                wdsa.wd_listing_date = dr2[3] == null ? "" : dr2[3].ToString();
                wdsa.wd_count = dr2[4] == null ? "" : dr2[4].ToString();
                wdsa.wd_merchant_code = dr2[5] == null ? "" : dr2[5].ToString();
                wdsa.wd_barcode = dr2[6] == null ? "" : dr2[6].ToString();
                wdsc.Add(wdsa);
            }
            return wdsc;
        }

        public static WeddingDressProperties getWeddingDressProperties(String wd_id)
        {
            try
            {
                WeddingDressProperties wdp = new WeddingDressProperties();
                string sql = "SELECT [wd_id] ,[wd_date] ,[wd_big_category] ,[wd_litter_category] ,[wd_factory] ,[wd_color] ,[cpml_ls] ,[cpml_ws] ,[cpml_duan] ,[cpml_zs] ,[cpml_other] ,[cpbx_yw] ,[cpbx_ppq] ,[cpbx_ab] ,[cpbx_dq] ,[cpbx_qdhc] ,[bwcd_qd] ,[bwcd_xtw] ,[bwcd_ztw] ,[bwcd_ctw] ,[bwcd_hhtw] ,[cplx_mx] ,[cplx_sv] ,[cplx_yzj] ,[cplx_dd] ,[cplx_dj] ,[cplx_gb] ,[cplx_yl] ,[cplx_ll] ,[lxys_bd] ,[lxys_ll] ,[lxys_lb] ,[memo] ,[emergency_period],[normal_period],[is_renew] FROM [weddingDressProperties] where wd_id='" + wd_id + "'";
                DataSet ds = GetDataSet(sql, "weddingDressProperties");
                foreach (DataRow dr in ds.Tables["weddingDressProperties"].Rows)
                {
                    wdp.wd_id = dr[0] == null ? "" : dr[0].ToString();
                    wdp.wd_date = dr[1] == null ? "" : dr[1].ToString();
                    wdp.wd_big_category = dr[2] == null ? "" : dr[2].ToString();
                    wdp.wd_litter_category = dr[3] == null ? "" : dr[3].ToString();
                    wdp.wd_factory = dr[4] == null ? "" : dr[4].ToString();
                    wdp.wd_color = dr[5] == null ? "" : dr[5].ToString();
                    wdp.cpml_ls = dr[6] == null ? "" : dr[6].ToString();
                    wdp.cpml_ws = dr[7] == null ? "" : dr[7].ToString();
                    wdp.cpml_duan = dr[8] == null ? "" : dr[8].ToString();
                    wdp.cpml_zs = dr[9] == null ? "" : dr[9].ToString();
                    wdp.cpml_other = dr[10] == null ? "" : dr[10].ToString();
                    wdp.cpbx_yw = dr[11] == null ? "" : dr[11].ToString();
                    wdp.cpbx_ppq = dr[12] == null ? "" : dr[12].ToString();
                    wdp.cpbx_ab = dr[13] == null ? "" : dr[13].ToString();
                    wdp.cpbx_dq = dr[14] == null ? "" : dr[14].ToString();
                    wdp.cpbx_qdhc = dr[15] == null ? "" : dr[15].ToString();
                    wdp.bwcd_qd = dr[16] == null ? "" : dr[16].ToString();
                    wdp.bwcd_xtw = dr[17] == null ? "" : dr[17].ToString();
                    wdp.bwcd_ztw = dr[18] == null ? "" : dr[18].ToString();
                    wdp.bwcd_ctw = dr[19] == null ? "" : dr[19].ToString();
                    wdp.bwcd_hhtw = dr[20] == null ? "" : dr[20].ToString();
                    wdp.cplx_mx = dr[21] == null ? "" : dr[21].ToString();
                    wdp.cplx_sv = dr[22] == null ? "" : dr[22].ToString();
                    wdp.cplx_yzj = dr[23] == null ? "" : dr[23].ToString();
                    wdp.cplx_dd = dr[24] == null ? "" : dr[24].ToString();
                    wdp.cplx_dj = dr[25] == null ? "" : dr[25].ToString();
                    wdp.cplx_gb = dr[26] == null ? "" : dr[26].ToString();
                    wdp.cplx_yl = dr[27] == null ? "" : dr[27].ToString();
                    wdp.cplx_ll = dr[28] == null ? "" : dr[28].ToString();
                    wdp.lxys_bd = dr[29] == null ? "" : dr[29].ToString();
                    wdp.lxys_ll = dr[30] == null ? "" : dr[30].ToString();
                    wdp.lxys_lb = dr[31] == null ? "" : dr[31].ToString();
                    wdp.memo = dr[32] == null ? "" : dr[32].ToString();
                    wdp.emergency_period = dr[33] == null ? "" : dr[33].ToString();
                    wdp.normal_period = dr[34] == null ? "" : dr[34].ToString();
                    wdp.is_renew = dr[35] == null ? "" : dr[35].ToString();

                }
                return wdp;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public static int getCount(string wd_id, string wd_size)
        {
            string sql = "select wd_count from weddingdresssizeandnumber where wd_id='" + wd_id + "' and wd_size='" + wd_size + "'";
            DataSet ds = GetDataSet(sql, "count");
            if (ds.Tables["count"].Rows.Count > 0)
            {
                return int.Parse(ds.Tables["count"].Rows[0].ItemArray[0].ToString());
            }
            return 0;
        }
        /*
        客户信息信息
        */
        public static Customer getCustomerByName(String name)
        {
            Customer customer = new Customer();
            string sql = "SELECT [customerID],[brideName],[brideContact] FROM [customers] where [brideName]='" + name + "'";
            DataSet ds = GetDataSet(sql, "Customer");
            if (ds.Tables["Customer"].Rows.Count > 0)
            {
                customer.customerID = ds.Tables["Customer"].Rows[0].ItemArray[0].ToString();
                customer.brideName = ds.Tables["Customer"].Rows[0].ItemArray[1].ToString();
                customer.brideContact = ds.Tables["Customer"].Rows[0].ItemArray[2].ToString();
            }
            return customer;
        }

        public static Customer getCustomerByTel(String tel)
        {
            Customer customer = new Customer();
            string sql = "SELECT [customerID],[brideName],[brideContact] FROM [customers] where [brideContact]='" + tel + "'";
            DataSet ds = GetDataSet(sql, "Customer");
            if (ds.Tables["Customer"].Rows.Count > 0)
            {
                customer.customerID = ds.Tables["Customer"].Rows[0].ItemArray[0].ToString();
                customer.brideName = ds.Tables["Customer"].Rows[0].ItemArray[1].ToString();
                customer.brideContact = ds.Tables["Customer"].Rows[0].ItemArray[2].ToString();
            }
            return customer;
        }

        public static Customer getCustomersByID(String cid)
        {
            try
            {
                Customer cust = new Customer();
                string sql = "SELECT [brideName],[brideContact],[marryDay],[infoChannel],[reserveDate],[reserveTime],[tryDress],[memo],[scsj_jsg],[scsj_cxsg],[scsj_tz],[scsj_xw],[scsj_xxw],[scsj_yw],[scsj_dqw],[scsj_tw],[scsj_jk],[scsj_jw],[scsj_dbw],[scsj_yddc],[scsj_qyj],[scsj_bpjl],[status],[jdgw],[groomName],[groomContact] ,[wangwangID],[customerID], [reservetimes], [retailerMemo],[hisreason],[city] FROM [customers] where [customerID]='" + cid + "'";
                DataSet ds = GetDataSet(sql, "Customer");
                foreach (DataRow dr in ds.Tables["Customer"].Rows)
                {
                    cust.brideName = dr[0] == null ? "" : dr[0].ToString();
                    cust.brideContact = dr[1] == null ? "" : dr[1].ToString();
                    cust.marryDay = dr[2] == null ? "" : dr[2].ToString();
                    cust.infoChannel = dr[3] == null ? "" : dr[3].ToString();
                    cust.reserveDate = dr[4] == null ? "" : dr[4].ToString();
                    cust.reserveTime = dr[5] == null ? "" : dr[5].ToString();
                    cust.tryDress = dr[6] == null ? "" : dr[6].ToString();
                    cust.memo = dr[7] == null ? "" : dr[7].ToString();
                    cust.scsj_jsg = dr[8] == null ? "" : dr[8].ToString();
                    cust.scsj_cxsg = dr[9] == null ? "" : dr[9].ToString();
                    cust.scsj_tz = dr[10] == null ? "" : dr[10].ToString();
                    cust.scsj_xw = dr[11] == null ? "" : dr[11].ToString();
                    cust.scsj_xxw = dr[12] == null ? "" : dr[12].ToString();
                    cust.scsj_yw = dr[13] == null ? "" : dr[13].ToString();
                    cust.scsj_dqw = dr[14] == null ? "" : dr[14].ToString();
                    cust.scsj_tw = dr[15] == null ? "" : dr[15].ToString();
                    cust.scsj_jk = dr[16] == null ? "" : dr[16].ToString();
                    cust.scsj_jw = dr[17] == null ? "" : dr[17].ToString();
                    cust.scsj_dbw = dr[18] == null ? "" : dr[18].ToString();
                    cust.scsj_yddc = dr[19] == null ? "" : dr[19].ToString();
                    cust.scsj_qyj = dr[20] == null ? "" : dr[20].ToString();
                    cust.scsj_bpjl = dr[21] == null ? "" : dr[21].ToString();
                    cust.status = dr[22] == null ? "" : dr[22].ToString();
                    cust.jdgw = dr[23] == null ? "" : dr[23].ToString();
                    cust.groomName = dr[24] == null ? "" : dr[24].ToString();
                    cust.groomContact = dr[25] == null ? "" : dr[25].ToString();
                    cust.wangwangID = dr[26] == null ? "" : dr[26].ToString();
                    cust.customerID = dr[27] == null ? "" : dr[27].ToString();
                    cust.reservetimes = dr[28] == null ? "" : dr[28].ToString();
                    cust.retailerMemo = dr[29] == null ? "" : dr[29].ToString();
                    cust.hisreason = dr[30] == null ? "" : dr[30].ToString();
                    cust.city = dr[31] == null ? "" : dr[31].ToString();
                }
                return cust;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;

            }

        }

        public static void getPic(String wd_id)
        {
            try
            {
                string sql = "SELECT [wd_id] ,[pic_id] ,[pic_name] ,[pic_img] FROM [tblImgData] where wd_id='" + wd_id + "'";
                DataSet ds = GetDataSet(sql, "user");
                foreach (DataRow dr in ds.Tables["user"].Rows)
                {
                    byte[] barrImg = (byte[])dr[3];
                    string strfn = "./images/" + ((String)dr[0]).Trim() + "_" + ((String)dr[1]).Trim() + "_" + ((String)dr[2]).Trim();

                    if (!File.Exists(@strfn))
                    {
                        FileStream fs = new FileStream(strfn, FileMode.Create, FileAccess.Write);
                        fs.Write(barrImg, 0, barrImg.Length);
                        fs.Flush();
                        fs.Close();
                    }


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public static List<PicName> getPicName(String wd_id)
        {
            try
            {
                string sql = "SELECT [wd_id] ,[pic_id] ,[pic_name] FROM [tblImgData] where wd_id='" + wd_id + "'";
                DataSet ds = GetDataSet(sql, "user");
                List<PicName> tmpList = new List<PicName>();
                foreach (DataRow dr in ds.Tables["user"].Rows)
                {
                    PicName pn = new PicName();
                    pn.wd_id = dr[0] == null ? "" : dr[0].ToString();
                    pn.pic_id = dr[1] == null ? "" : dr[1].ToString();
                    pn.pic_name = dr[2] == null ? "" : dr[2].ToString();
                    tmpList.Add(pn);
                }
                return tmpList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }

        }


        public static DataTable fillDataTableForTrackingCustomers()
        {
            string query = "SELECT a.customerID,brideName,brideContact,reservetimes,status,marryDay,infoChannel,reserveDate,reserveTime,tryDress,hisreason,memo FROM trackingbtypecustomers a,customers b where a.customerID=b.customerID";
            SqlConnection m_envconn = Connection.GetEnvConn();
            SqlCommand cmd = new SqlCommand(query, m_envconn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            //m_envconn.Close();
            return dt;
        }

        //public static DataTable fillDataTableForCustomers()
        //{
        //    string query = "SELECT customerID,brideName,brideContact,city,wangwangID,operatorName,reservetimes,status,marryDay,infoChannel,reserveDate,reserveTime,tryDress,hisreason,memo ,address FROM customers";
        //    SqlConnection m_envconn = Connection.GetEnvConn();
        //    SqlCommand cmd = new SqlCommand(query, m_envconn);
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    //m_envconn.Close();
        //    return dt;
        //}



        //public static DataTable fillDataTableForCustomersAll()
        //{
        //    string query = "SELECT * FROM customers";
        //    SqlConnection m_envconn = Connection.GetEnvConn();
        //    SqlCommand cmd = new SqlCommand(query, m_envconn);
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    //m_envconn.Close();
        //    return dt;
        //}

        public static DataTable fillDataTableForCustomersWithFilter(string filter)
        {
            string query = "SELECT * FROM customers " + filter;
            SqlConnection m_envconn = Connection.GetEnvConn();
            SqlCommand cmd = new SqlCommand(query, m_envconn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            //m_envconn.Close();
            return dt;
        }

        public static DataTable fillDataTableForCustomersWithFilter(string field, string filter, string orderBy)
        {
            string query = "SELECT " + field + " FROM customers " + filter + " " + orderBy;
            SqlConnection m_envconn = Connection.GetEnvConn();
            SqlCommand cmd = new SqlCommand(query, m_envconn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                switch (row.Field<string>("status"))
                {
                    case "A":
                        row.SetField("status", "新客户");
                        break;
                    case "B":
                        row.SetField("status", "未预约到店");
                        break;
                    case "C":
                        row.SetField("status", "预约成功");
                        break;
                    case "D":
                        row.SetField("status", "客户流失");
                        break;
                    case "E":
                        row.SetField("status", "到店未成交");
                        break;
                    case "F":
                        row.SetField("status", "交定金未定款式");
                        break;
                    case "G":
                        row.SetField("status", "交定金已定款式");
                        break;
                    case "H":
                        row.SetField("status", "交全款未定款式");
                        break;
                    case "I":
                        row.SetField("status", "交全款已定款式");
                        break;
                }

            }
            //m_envconn.Close();
            return dt;
        }

        //public static DataTable fillDataTable(string table)
        //{
        //    string query = "SELECT * FROM " + table;
        //    SqlConnection m_envconn = Connection.GetEnvConn();
        //    SqlCommand cmd = new SqlCommand(query, m_envconn);
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    //m_envconn.Close();
        //    return dt;
        //}


        public static DataTable fillDataTableForTryDress(string customerID)
        {
            string query = "select A.wd_id,A.wd_big_category,A.wd_litter_category,B.wdSize,A.wd_color from (SELECT [wd_id] ,[wd_big_category] ,[wd_litter_category] ,[wd_color] FROM [weddingDressProperties]) A,(SELECT [customerID] ,[wdId] ,[wdSize]  FROM [customerTryDressList] where customerID='" + customerID + "') B where A.wd_id=B.wdId";
            SqlConnection m_envconn = Connection.GetEnvConn();
            SqlCommand cmd = new SqlCommand(query, m_envconn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static DataTable fillDataTableForOrder(string customerID)
        {
            //string query = "SELECT     A.orderID, A.wd_big_category, A.wd_litter_category, A.wd_size, B.orderType, B.orderStatus, B.totalAmount, B.returnAmount, B.ifarrears, B.memo FROM(SELECT     orderID, wd_big_category, wd_litter_category, wd_size                   FROM          customerOrderDetails) AS A INNER JOIN                          (SELECT customerID, orderID, orderType, orderStatus, totalAmount, returnAmount, ifarrears, memo                            FROM          customerOrder                            WHERE      (customerID = '" + customerID + "')) AS B ON A.orderID = B.orderID";
            string query = "select orderid,totalamount,orderAmountafter, depositamount,memo from [order] where customerid='" + customerID + "'";
            SqlConnection m_envconn = Connection.GetEnvConn();
            SqlCommand cmd = new SqlCommand(query, m_envconn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static DataTable fillDataTableWithFilter(string table, string filter, string orderBy)
        {
            string query = "SELECT * FROM " + table + filter + orderBy;
            SqlConnection m_envconn = Connection.GetEnvConn();
            SqlCommand cmd = new SqlCommand(query, m_envconn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            //m_envconn.Close();
            return dt;
        }

        public static DataSet GetDataSet(string SQL, string temp_table)
        {
            SqlConnection m_envconn = Connection.GetEnvConn();
            if (m_envconn != null)
            {
                SqlDataAdapter adapter = new SqlDataAdapter(SQL, m_envconn);
                DataSet dtDataSet = new DataSet();
                adapter.Fill(dtDataSet, temp_table);
                return dtDataSet;
            }
            else
            {
                return null;
            }
        }
    }

    public static class TruncateTable
    {
        public static bool truncate(string tableName)
        {
            try
            {
                SqlConnection conn = Connection.GetEnvConn();
                if (conn != null)
                {
                    string sql = "delete from " + tableName + " where 1=1";

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


        public static bool deleteCustomerOrderByOrderID(string orderID)
        {
            try
            {
                SqlConnection conn = Connection.GetEnvConn();
                if (conn != null)
                {
                    string sql = "delete from customerOrder  where orderID='" + orderID + "'";

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


        //public static bool deleteByCustomerID(string cid)
        //{
        //    try
        //    {
        //        SqlConnection conn = Connection.GetEnvConn();
        //        if (conn != null)
        //        {
        //            string sql = "delete from customerTryDressList  where customerID='" + cid + "'";

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


        public static bool deleteByCustomerIDInClusterTable(string cid)
        {
            try
            {
                SqlConnection conn = Connection.GetEnvConn();
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
                SqlConnection conn = Connection.GetEnvConn();
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
                SqlConnection conn = Connection.GetEnvConn();
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
                SqlConnection conn = Connection.GetEnvConn();
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
        //A:新登记客户
        //B:待预约到店客户
        //C:已成交客户，成交
        //D:已流失客户，delete



        public static bool updateCustomerInfo(Customer ci)
        {
            try
            {
                SqlConnection conn = Connection.GetEnvConn();
                if (conn != null)
                {
                    string sql = "update customers set brideName='" + ci.brideName + "', reservetimes=" + ci.reservetimes + ", status='" + ci.status + "',brideContact='" + ci.brideContact + "',groomName='" + ci.groomName + "',groomContact='" + ci.groomContact + "',marryDay='" + ci.marryDay + "',infoChannel='" + ci.infoChannel + "',city='" + ci.city + "',reserveDate='" + ci.reserveDate + "',reserveTime='" + ci.reserveTime + "',tryDress='" + ci.tryDress + "',hisreason='" + ci.reason + "',scsj_jsg='" + ci.scsj_jsg + "',scsj_cxsg='" + ci.scsj_cxsg + "',scsj_tz='" + ci.scsj_tz + "',scsj_xw='" + ci.scsj_xw + "',scsj_xxw='" + ci.scsj_xxw + "',scsj_yw='" + ci.scsj_yw + "',scsj_dqw='" + ci.scsj_dqw + "',scsj_tw='" + ci.scsj_tw + "',scsj_jk='" + ci.scsj_jk + "',scsj_jw='" + ci.scsj_jw + "',scsj_dbw='" + ci.scsj_dbw + "',scsj_yddc='" + ci.scsj_yddc + "',scsj_qyj='" + ci.scsj_qyj + "',scsj_bpjl='" + ci.scsj_bpjl + "',wangwangID='" + ci.wangwangID + "',jdgw='" + ci.jdgw + "',address='" + ci.address + "',retailerMemo='" + ci.retailerMemo + "' where customerID='" + ci.customerID + "'";
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
        public static bool updateCustomerOrder(string orderID, string TmporderStatus)
        {
            try
            {
                SqlConnection conn = Connection.GetEnvConn();
                if (conn != null)
                {
                    string sql = "update customerOrder  set orderStatus='" + TmporderStatus + "' where orderID='" + orderID + "'";

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


        public static bool updateCustomerOrder(string orderID, string TmporderStatus, string returnAmount)
        {
            try
            {
                SqlConnection conn = Connection.GetEnvConn();
                if (conn != null)
                {
                    string sql = "update customerOrder  set orderStatus='" + TmporderStatus + "',returnAmount='" + returnAmount + "' where orderID='" + orderID + "'";

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

        //退单处理
        public static bool updateCustomerOrderCancelOrder(string orderID, string returnAmount)
        {
            try
            {
                SqlConnection conn = Connection.GetEnvConn();
                if (conn != null)
                {
                    string sql = "update customerOrder  set orderStatus='取消订单',returnAmount='" + returnAmount + "' where orderID='" + orderID + "'";

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


        //租赁取纱，更新库存
        public static bool updateWeddingDressSizeAndNumberForReatGet(string wd_id, string wd_size, int wd_count)
        {
            try
            {
                SqlConnection conn = Connection.GetEnvConn();
                if (conn != null)
                {
                    string sql = "update weddingDressSizeAndNumber  set wd_count=" + wd_count + " where wd_id='" + wd_id + "'  and wd_size='" + wd_size + "'";

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

        //更新婚纱实时库存
        public static bool updateRealtimeWeddingDressSizeAndNumberForReatGet(string wd_id, string wd_size, int wd_realtime_count)
        {
            try
            {
                SqlConnection conn = Connection.GetEnvConn();
                if (conn != null)
                {
                    string sql = "update weddingDressSizeAndNumber  set wd_realtime_count=" + wd_realtime_count + " where wd_id='" + wd_id + "'  and wd_size='" + wd_size + "'";

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

        //补交订单尾款
        public static bool updateCustomerOrderForArrears(string orderID, string orderAmountafter, string totalAmount, string ifarrears)
        {
            try
            {
                SqlConnection conn = Connection.GetEnvConn();
                if (conn != null)
                {
                    string sql = "update customerOrder  set orderAmountafter='" + orderAmountafter + "',totalAmount='" + totalAmount + "',ifarrears='" + ifarrears + "',updatetime='" + DateTime.Now.ToLongDateString() + "' where orderID='" + orderID + "'";

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

        public static bool updateCustomerStatus(string customerID, string status)
        {
            try
            {
                SqlConnection conn = Connection.GetEnvConn();
                if (conn != null)
                {
                    string sql = "update customers  set status ='" + status.Trim() + "' where customerID='" + customerID.Trim() + "'";

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


        public static bool updateCustomerReservedTimes(string customerID, int reservedTimes)
        {
            try
            {
                SqlConnection conn = Connection.GetEnvConn();
                if (conn != null)
                {
                    string sql = "update customers  set reservetimes ='" + reservedTimes + "' where customerID='" + customerID.Trim() + "'";

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



        public static bool updateCustomerInfo(string customerID, string[] customerInfos)
        {
            try
            {
                SqlConnection conn = Connection.GetEnvConn();
                if (conn != null)
                {
                    string sql = "update [customers]  set marryDay ='" + customerInfos[0] + "' , reserveDate ='" + customerInfos[1] + "' , reserveTime ='" + customerInfos[2] + "' , tryDress ='" + customerInfos[3] + "',  hisreason =hisreason+'" + customerInfos[4] + "' where customerID='" + customerID.Trim() + "'";

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




        public static bool updateCustomerInfoByOperator(string customerID, Customer customerInfos)
        {
            try
            {

                SqlConnection conn = Connection.GetEnvConn();
                if (conn != null)
                {
                    string sql = "update [customers]  set brideName ='" + customerInfos.brideName + "' , brideContact ='" + customerInfos.brideContact + "' , memo ='" + customerInfos.memo + "' , infoChannel ='" + customerInfos.infoChannel + "', city ='" + customerInfos.city + "',wangwangID ='" + customerInfos.wangwangID + "' where customerID='" + customerID.Trim() + "'";

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

    public static class SaveData
    {


        public static bool InsertCustomerOrder(Order co)
        {
            try
            {
                SqlConnection conn = Connection.GetEnvConn();
                if (conn != null && co != null)
                {
                    String sql = "insert into customerOrder(orderID,customerID,wdData,orderAmountPre,orderAmountafter,orderDiscountRate,orderPaymentMethod,reservedAmount,depositAmount,depositPaymentMethod,totalAmount,returnAmount,orderStatus,orderType,receptionConsultant,ifarrears,memo,address) values(@orderID,@customerID,@wdData,@orderAmountPre,@orderAmountafter,@orderDiscountRate,@orderPaymentMethod,@reservedAmount,@depositAmount,@depositPaymentMethod,@totalAmount,@returnAmount,@orderStatus,@orderType,@receptionConsultant,@ifarrears,@memo,@address)";

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@orderID", co.orderID);
                    cmd.Parameters.AddWithValue("@customerID", co.customerID);
                    cmd.Parameters.AddWithValue("@wdData", co.wdData);
                    cmd.Parameters.AddWithValue("@orderAmountPre", co.orderAmountPre);
                    cmd.Parameters.AddWithValue("@orderAmountafter", co.orderAmountafter);
                    cmd.Parameters.AddWithValue("@orderDiscountRate", co.orderDiscountRate);
                    cmd.Parameters.AddWithValue("@orderPaymentMethod", co.orderPaymentMethod);
                    cmd.Parameters.AddWithValue("@reservedAmount", co.reservedAmount);
                    cmd.Parameters.AddWithValue("@depositAmount", co.depositAmount);
                    cmd.Parameters.AddWithValue("@depositPaymentMethod", co.depositPaymentMethod);
                    cmd.Parameters.AddWithValue("@totalAmount", co.totalAmount);
                    cmd.Parameters.AddWithValue("@returnAmount", co.returnAmount);
                    cmd.Parameters.AddWithValue("@orderStatus", co.orderStatus);
                    cmd.Parameters.AddWithValue("@orderType", co.orderType);
                    cmd.Parameters.AddWithValue("@receptionConsultant", co.receptionConsultant);
                    cmd.Parameters.AddWithValue("@ifarrears", co.ifarrears);
                    cmd.Parameters.AddWithValue("@memo", co.memo);
                    cmd.Parameters.AddWithValue("@address", co.address);
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


        public static bool InsertCustomerOrderFull(Order co)
        {
            try
            {
                SqlConnection conn = Connection.GetEnvConn();
                if (conn != null && co != null)
                {
                    String sql = "insert into customerOrder(orderID,customerID,wdData,orderAmountPre,orderAmountafter,orderDiscountRate,orderPaymentMethod,reservedAmount,depositAmount,depositPaymentMethod,totalAmount,returnAmount,orderStatus,orderType,receptionConsultant,shenpiren,gongfei,jiajifei,jiachangfei,jiakuanfei) values(@orderID,@customerID,@wdData,@orderAmountPre,@orderAmountafter,@orderDiscountRate,@orderPaymentMethod,@reservedAmount,@depositAmount,@depositPaymentMethod,@totalAmount,@returnAmount,@orderStatus,@orderType,@receptionConsultant,@shenpiren,@gongfei,@jiajifei,@jiachangfei,@jiakuanfei)";

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@orderID", co.orderID);
                    cmd.Parameters.AddWithValue("@customerID", co.customerID);
                    cmd.Parameters.AddWithValue("@wdData", co.wdData);
                    cmd.Parameters.AddWithValue("@orderAmountPre", co.orderAmountPre);
                    cmd.Parameters.AddWithValue("@orderAmountafter", co.orderAmountafter);
                    cmd.Parameters.AddWithValue("@orderDiscountRate", co.orderDiscountRate);
                    cmd.Parameters.AddWithValue("@orderPaymentMethod", co.orderPaymentMethod);
                    cmd.Parameters.AddWithValue("@reservedAmount", co.reservedAmount);
                    cmd.Parameters.AddWithValue("@depositAmount", co.depositAmount);
                    cmd.Parameters.AddWithValue("@depositPaymentMethod", co.depositPaymentMethod);
                    cmd.Parameters.AddWithValue("@totalAmount", co.totalAmount);
                    cmd.Parameters.AddWithValue("@returnAmount", co.returnAmount);
                    cmd.Parameters.AddWithValue("@orderStatus", co.orderStatus);
                    cmd.Parameters.AddWithValue("@orderType", co.orderType);
                    cmd.Parameters.AddWithValue("@receptionConsultant", co.receptionConsultant);

                    cmd.Parameters.AddWithValue("@shenpiren", co.shenpiren);
                    cmd.Parameters.AddWithValue("@gongfei", co.gongfei);
                    cmd.Parameters.AddWithValue("@jiajifei", co.jiajifei);
                    cmd.Parameters.AddWithValue("@jiachangfei", co.jiachangfei);
                    cmd.Parameters.AddWithValue("@jiakuanfei", co.jiakuanfei);

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


        public static bool InsertCustomerOrderDetails(OrderDetail cod)
        {
            try
            {
                SqlConnection conn = Connection.GetEnvConn();
                if (conn != null && cod != null)
                {
                    String sql = "insert into customerOrderDetails(orderID,wd_id,wd_size,wd_big_category,wd_litter_category,memo) values(@orderID,@wd_id,@wd_size,@wd_big_category,@wd_litter_category,@memo)";

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@orderID", cod.orderID);
                    cmd.Parameters.AddWithValue("@wd_id", cod.wd_id);
                    cmd.Parameters.AddWithValue("@wd_size", cod.wd_size);
                    cmd.Parameters.AddWithValue("@wd_big_category", cod.wd_big_category);
                    cmd.Parameters.AddWithValue("@wd_litter_category", cod.wd_litter_category);
                    cmd.Parameters.AddWithValue("@memo", cod.memo);

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

        public static bool InsertCustomerOrderDetails(List<OrderDetail> coDetailsList)
        {
            try
            {
                SqlConnection conn = Connection.GetEnvConn();
                if (conn != null && coDetailsList != null)
                {
                    foreach (OrderDetail cod in coDetailsList)
                    {
                        String sql = "insert into customerOrderDetails(orderID,wd_id,wd_size,wd_big_category,wd_litter_category,memo) values(@orderID,@wd_id,@wd_size,@wd_big_category,@wd_litter_category,@memo)";

                        SqlCommand cmd = new SqlCommand(sql, conn);

                        cmd.Parameters.AddWithValue("@orderID", cod.orderID);
                        cmd.Parameters.AddWithValue("@wd_id", cod.wd_id);
                        cmd.Parameters.AddWithValue("@wd_size", cod.wd_size);
                        cmd.Parameters.AddWithValue("@wd_big_category", cod.wd_big_category);
                        cmd.Parameters.AddWithValue("@wd_litter_category", cod.wd_litter_category);
                        cmd.Parameters.AddWithValue("@memo", cod.memo);

                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                            return false;
                        }
                    }

                    return true;
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

        public static bool InsertCustomerTryDressList(string customerID, string wdId, string wdSize, string tryDressDate)
        {
            try
            {
                SqlConnection conn = Connection.GetEnvConn();
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

        public static void InsertCurrentBTypeCustomerList()
        {
            DateTime now = DateTime.Now;

            List<Customer> cts = ReadData.getCurrentBTypeCustomerList();

            for (int i = 0; i < cts.Count; i++)
            {
                DateTime dt = Convert.ToDateTime(cts[i].reserveDate);
                string grade = cts[i].reservetimes;

                switch (grade)
                {
                    case "1":
                        if (dt.AddDays(2).Date == now.Date)
                        {
                            InsertBTypeCurrentDayListAction(cts[i].customerID, now.Date.ToString("yyyy-MM-dd"));
                        }

                        break;
                    case "2":
                        if (dt.AddDays(2).Date == now.Date)
                        {
                            InsertBTypeCurrentDayListAction(cts[i].customerID, now.Date.ToString("yyyy-MM-dd"));
                        }
                        break;
                    case "3":
                        if (dt.AddDays(2).Date == now.Date)
                        {
                            InsertBTypeCurrentDayListAction(cts[i].customerID, now.Date.ToString("yyyy-MM-dd"));
                        }
                        break;
                    case "4":
                        if (dt.AddDays(2).Date == now.Date)
                        {
                            InsertBTypeCurrentDayListAction(cts[i].customerID, now.Date.ToString("yyyy-MM-dd"));
                        }
                        break;
                    case "5":
                        if (dt.AddDays(8).Date == now.Date)
                        {
                            InsertBTypeCurrentDayListAction(cts[i].customerID, now.Date.ToString("yyyy-MM-dd"));
                        }
                        break;

                    default:

                        break;
                }

            }


        }



        public static bool InsertBTypeCurrentDayListAction(string customerID, String checkdate)
        {
            try
            {
                SqlConnection conn = Connection.GetEnvConn();
                if (conn != null)
                {
                    String sql = "insert into trackingBTypeCustomers(customerID,checkdate) values(@customerID,@checkdate)";

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@customerID", customerID);
                    cmd.Parameters.AddWithValue("@checkdate", checkdate);
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


        public static bool InsertWeddingDressProperties(string wd_id, string wd_date, string wd_big_category, string wd_litter_category, string wd_factory, string wd_color, string cpml_ls, string cpml_ws, string cpml_duan, string cpml_zs, string cpml_other, string cpbx_yw, string cpbx_ppq, string cpbx_ab, string cpbx_dq, string cpbx_qdhc, string bwcd_qd, string bwcd_xtw, string bwcd_ztw, string bwcd_ctw, string bwcd_hhtw, string cplx_mx, string cplx_sv, string cplx_yzj, string cplx_dd, string cplx_dj, string cplx_gb, string cplx_yl, string cplx_ll, string lxys_bd, string lxys_ll, string lxys_lb, string memo, string emergency_period, string normal_period, string is_renew)
        {
            try
            {
                SqlConnection conn = Connection.GetEnvConn();
                if (conn != null)
                {
                    String sql = "insert into weddingDressProperties(wd_id,wd_date,wd_big_category,wd_litter_category,wd_factory,wd_color,cpml_ls,cpml_ws,cpml_duan,cpml_zs,cpml_other,cpbx_yw,cpbx_ppq,cpbx_ab,cpbx_dq,cpbx_qdhc,bwcd_qd,bwcd_xtw,bwcd_ztw,bwcd_ctw,bwcd_hhtw,cplx_mx,cplx_sv,cplx_yzj,cplx_dd,cplx_dj,cplx_gb,cplx_yl,cplx_ll,lxys_bd,lxys_ll,lxys_lb,memo,emergency_period,normal_period,is_renew) values(@wd_id,@wd_date,@wd_big_category,@wd_litter_category,@wd_factory,@wd_color,@cpml_ls,@cpml_ws,@cpml_duan,@cpml_zs,@cpml_other,@cpbx_yw,@cpbx_ppq,@cpbx_ab,@cpbx_dq,@cpbx_qdhc,@bwcd_qd,@bwcd_xtw,@bwcd_ztw,@bwcd_ctw,@bwcd_hhtw,@cplx_mx,@cplx_sv,@cplx_yzj,@cplx_dd,@cplx_dj,@cplx_gb,@cplx_yl,@cplx_ll,@lxys_bd,@lxys_ll,@lxys_lb,@memo,@emergency_period,@normal_period,@is_renew)";

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



                    try
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("礼服编号已存在，请重新输入！" + ex.ToString());

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
                SqlConnection conn = Connection.GetEnvConn();
                if (conn != null)
                {
                    String sql = "insert into weddingDressSizeAndNumber(wd_id,wd_size,wd_price,wd_huohao,wd_listing_date,wd_count,wd_merchant_code,wd_barcode,wd_realtime_count) values ('" + wd_id.Trim() + "','" + wd_size.Trim() + "','" + wd_price.Trim() + "','" + wd_huohao.Trim() + "','" + wd_listing_date.Trim() + "'," + wd_count + ",'" + wd_merchant_code.Trim() + "','" + wd_barcode.Trim() + "'," + wd_realtime_count + ")";

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

                SqlConnection conn = Connection.GetEnvConn();
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
        public static bool InsertCustomerProperties(string customerID, string brideName, string brideContact, string marryDay, string infoChannel, string reserveDate, string reserveTime, string tryDress, string memo, string scsj_jsg, string scsj_cxsg, string scsj_tz, string scsj_xw, string scsj_xxw, string scsj_yw, string scsj_dqw, string scsj_tw, string scsj_jk, string scsj_jw, string scsj_dbw, string scsj_yddc, string scsj_qyj, string scsj_bpjl, string status, string hisreason, string reservetimes, string city, string groomName, string groomContact, string wangwangID, string jdgw, string address)
        {
            try
            {
                SqlConnection conn = Connection.GetEnvConn();
                if (conn != null)
                {
                    String sql = "insert into customers(customerID,brideName,brideContact,marryDay,infoChannel,reserveDate,reserveTime,tryDress,memo,scsj_jsg,scsj_cxsg,scsj_tz,scsj_xw,scsj_xxw,scsj_yw,scsj_dqw,scsj_tw,scsj_jk,scsj_jw,scsj_dbw,scsj_yddc,scsj_qyj,scsj_bpjl,status,hisreason,reservetimes,city,groomName,groomContact,wangwangID,jdgw,address) values(@customerID,@brideName,@brideContact,@marryDay,@infoChannel,@reserveDate,@reserveTime,@tryDress,@memo,@scsj_jsg,@scsj_cxsg,@scsj_tz,@scsj_xw,@scsj_xxw,@scsj_yw,@scsj_dqw,@scsj_tw,@scsj_jk,@scsj_jw,@scsj_dbw,@scsj_yddc,@scsj_qyj,@scsj_bpjl,@status,@hisreason,@reservetimes,@city,@groomName,@groomContact,@wangwangID,@jdgw,@address)";

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@customerID", customerID);
                    cmd.Parameters.AddWithValue("@brideName", brideName);
                    cmd.Parameters.AddWithValue("@brideContact", brideContact);
                    cmd.Parameters.AddWithValue("@marryDay", marryDay);
                    cmd.Parameters.AddWithValue("@infoChannel", infoChannel);
                    cmd.Parameters.AddWithValue("@reserveDate", reserveDate);
                    cmd.Parameters.AddWithValue("@reserveTime", reserveTime);
                    cmd.Parameters.AddWithValue("@tryDress", tryDress);
                    cmd.Parameters.AddWithValue("@memo", memo);
                    cmd.Parameters.AddWithValue("@scsj_jsg", scsj_jsg);
                    cmd.Parameters.AddWithValue("@scsj_cxsg", scsj_cxsg);
                    cmd.Parameters.AddWithValue("@scsj_tz", scsj_tz);
                    cmd.Parameters.AddWithValue("@scsj_xw", scsj_xw);
                    cmd.Parameters.AddWithValue("@scsj_xxw", scsj_xxw);
                    cmd.Parameters.AddWithValue("@scsj_yw", scsj_yw);
                    cmd.Parameters.AddWithValue("@scsj_dqw", scsj_dqw);
                    cmd.Parameters.AddWithValue("@scsj_tw", scsj_tw);
                    cmd.Parameters.AddWithValue("@scsj_jk", scsj_jk);
                    cmd.Parameters.AddWithValue("@scsj_jw", scsj_jw);
                    cmd.Parameters.AddWithValue("@scsj_dbw", scsj_dbw);
                    cmd.Parameters.AddWithValue("@scsj_yddc", scsj_yddc);
                    cmd.Parameters.AddWithValue("@scsj_qyj", scsj_qyj);
                    cmd.Parameters.AddWithValue("@scsj_bpjl", scsj_bpjl);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@hisreason", hisreason);
                    cmd.Parameters.AddWithValue("@reservetimes", reservetimes);
                    cmd.Parameters.AddWithValue("@city", city);
                    cmd.Parameters.AddWithValue("@groomName", groomName);
                    cmd.Parameters.AddWithValue("@groomContact", groomContact);
                    cmd.Parameters.AddWithValue("@wangwangID", wangwangID);
                    cmd.Parameters.AddWithValue("@jdgw", jdgw);
                    cmd.Parameters.AddWithValue("@address", address);


                    try
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("客户编号已存在，请重新输入！");
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



        //insert customer
        public static bool InsertCustomerPropertiesByOperator(string customerID, string brideName, string brideContact, string memo, string infoChannel, string city, string wangwangID, string operatorName, string status)
        {
            try
            {
                SqlConnection conn = Connection.GetEnvConn();
                if (conn != null)
                {
                    String sql = "insert into customers(customerID,brideName,brideContact,memo,infoChannel,city,wangwangID,operatorName,status) values(@customerID,@brideName,@brideContact,@memo,@infoChannel,@city,@wangwangID,@operatorName,@status)";

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@customerID", customerID);
                    cmd.Parameters.AddWithValue("@brideName", brideName);
                    cmd.Parameters.AddWithValue("@brideContact", brideContact);
                    cmd.Parameters.AddWithValue("@infoChannel", infoChannel);
                    cmd.Parameters.AddWithValue("@memo", memo);
                    cmd.Parameters.AddWithValue("@city", city);
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

        public static bool insertOrder(Order order, List<OrderDetail> orderDetails)
        {
            SqlConnection conn = Connection.GetEnvConn();
            if (conn == null)
            {
                MessageBox.Show("数据库连接异常！");
                return false;
            }
            SqlTransaction tranx = conn.BeginTransaction();
            try
            {
                String sql = "insert into [order] (orderid,customerid, orderamountafter, depositamount,totalamount,deliveryType,getdate,returndate,address, memo) values (@orderid,@customerid, @orderamountafter,@depositamount, @totalamount,@deliveryType,@getdate,@returndate,@address, @memo)";
                SqlCommand cmd = new SqlCommand(sql, conn, tranx);
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
                    if (orderDetail.orderType == "标准码" || orderDetail.orderType == "量身定制")
                    {
                        sql = "update weddingdresssizeandnumber set wd_count=(select wd_count from weddingdresssizeandnumber where wd_id='" + orderDetail.wd_id + "' and wd_size='" + orderDetail.wd_size + "')-1 where wd_id='" + orderDetail.wd_id + "' and wd_size='" + orderDetail.wd_size + "'";
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

        public static bool updateOrderbyId(Order order, List<OrderDetail> orderDetails, List<OrderDetail> originalOrderDetails)
        {
            SqlConnection conn = Connection.GetEnvConn();
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
                sql = "update weddingDressSizeAndNumber set wd_count=(select wd_count from weddingDressSizeAndNumber where wd_id=@wd_id and wd_size=@wd_size)+1 where wd_id=@wd_id and wd_size=@wd_size";
                foreach (OrderDetail orderDetail in originalOrderDetails)
                {
                    if (orderDetail.orderType == "标准码" || orderDetail.orderType == "量身定制")
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

                sql = "insert into [order] (orderid,customerid, orderamountafter, depositamount,totalamount,deliveryType,getdate,returndate,address, memo) values (@orderid,@customerid, @orderamountafter,@depositamount, @totalamount,@deliveryType,@getdate,@returndate,@address, @memo)";
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
                    if (orderDetail.orderType == "标准码" || orderDetail.orderType == "量身定制")
                    {
                        sql = "update weddingdresssizeandnumber set wd_count=(select wd_count from weddingdresssizeandnumber where wd_id='" + orderDetail.wd_id + "' and wd_size='" + orderDetail.wd_size + "')-1 where wd_id='" + orderDetail.wd_id + "' and wd_size='" + orderDetail.wd_size + "'";
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
