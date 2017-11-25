using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;

namespace aimu
{
    public enum LogLevel { INFO, WARN, ERROR, FATAL };
    public class Data : IDisposable 
    {
        bool success;
        DataTable dataTable;

        public bool Success
        {
            get
            {
                return success;
            }

            set
            {
                success = value;
            }
        }

        public DataTable DataTable
        {
            get
            {
                return dataTable;
            }

            set
            {
                dataTable = value;
            }
        }

        public void Dispose()
        {
            dataTable = null;
        }
    }
    
    public class SQL
    {
        string sql;
        List<SqlParameter> parameters;
        bool returnValue = false;
        bool useReturnValue=false;

        public SQL()
        {

        }
        public SQL(string sql)
        {
            this.sql = sql;
            this.parameters = new List<SqlParameter>();
        }
        public string Sql
        {
            get
            {
                return sql;
            }

            set
            {
                sql = value;
            }
        }

        public List<SqlParameter> Paremeters
        {
            get
            {
                return parameters;
            }

            set
            {
                parameters = value;
            }
        }

        public bool ReturnValue
        {
            get
            {
                return returnValue;
            }

            set
            {
                returnValue = value;
            }
        }

        public bool UseReturnValue
        {
            get
            {
                return useReturnValue;
            }

            set
            {
                useReturnValue = value;
            }
        }
    }
    public class Picture:IDisposable
    {
        public string wd_id;
        public int pic_id;   
        public byte[] pic_image;
        public byte[] thumbnail;

        public void Dispose()
        {
            wd_id = null;
            pic_image = null;
            thumbnail = null;
        }
    }

    public class DressDefinition
    {
        public string wd_id;
        public string wd_date;
        public string wd_big_category;
        public string wd_litter_category;
        public string wd_factory;
        public string wd_color;
        public int attribute;
        public string memo;
        public string emergency_period;//紧急工期
        public string normal_period;//正常工期
        public string is_renew;//是否返单(即样品拿回工厂重新做)
        public decimal settlementPrice;
        public WeddingDressSizeAndCount[] wdscs;
        public Dictionary<int, byte[]> pictures;
        public Dictionary<int, byte[]> thumbnails;
    }

    public class WeddingDressSizeAndCount
    {
        public string id;
        public string wd_id;
        public string wd_size;
        public decimal wd_price;
        public string wd_listing_date;
        public int wd_count;
        public int store_id;
        //public int wd_realtime_count;
        //public string wd_merchant_code;
    }

    public class Customer
    {
        public int id;
        public string brideName;
        public string brideContact;
        public string marryDay;
        public int channelId;
        public string reserveDate;
        public string reserveTime;
        public string tryDress;
        public string memo;
        public string scsj_jsg;
        public string scsj_cxsg;
        public string scsj_tz;
        public string scsj_xw;
        public string scsj_xxw;
        public string scsj_yw;
        public string scsj_dqw;
        public string scsj_tw;
        public string scsj_jk;
        public string scsj_jw;
        public string scsj_dbw;
        public string scsj_yddc;
        public string scsj_qyj;
        public string scsj_bpjl;
        public int status;
        public string reason;
        public string hisreason;
        public string reservetimes;
        public int storeId;
        public string wangwangID;
        public string operatorName;//录入人员
        public string jdgw;//接待顾问
        public string groomName;//新郎姓名
        public string groomContact;//新郎联系电话
        public string dueDate;//成交日期=付款日期=交了一部分定金的日期
        public string getDressDate;//取纱日期
        public string returnDressDate;//还纱日期
        public string retailerMemo;
        public string address;
        public string accountPayable;
        public string refund;
        public string fine;
        public string partnerName;
    }

    public class Order
    {
        public int id;
        public int customerID;
        public decimal orderAmountafter;
        public decimal depositAmount;
        public decimal totalAmount;
        public string memo;
        public string address;
        public DateTime getDate;
        public DateTime returnDate;
        public string deliveryType;
        public int flowId;
        public int storeId;
    }

    public class OrderFlow
    {
        public int id;
        public int statusId;
        public decimal customizedPrice;
        public string expressNumberToStore;
        public string expressNumberToCustomer;
        public string expressNumberToFactory;
        public string changeReason;
        public int parentId;
    }

    public class OrderDetail
    {
        public int orderID;
        public string wd_id;
        public string wd_size;
        public string wd_big_category;
        public string wd_litter_category;
        public string memo;
        public string wd_color;
        public string wd_price;
        public string wd_huohao;
        public string orderType;
        public byte[] wd_image;
    }

    public class OrderStatus
    {
        public int id;
        public string name;
        public int userRole;
        public int preStatusId;
    }

    public class User
    {
        public Int64 cellPhone;
        public string name;
        public byte[] password;
        public byte[] passwordSalt;
        public int tenantId;
        public int roleId;
        public int storeId;
        public string mail;
        public string memo;
    }

    public class Tenant
    {
        public int id;
        public string name;
        public string shardName;
        public int statusId;
        public int categoryId;
        public DateTime createdDate;
        public bool enableWorkFlow;
    }
}
