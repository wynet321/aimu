using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;

namespace aimu
{
    public class SenDat
    {
        public long id;         //id	bigint	Unchecked
        public int equid;       //equid	int	Checked
        public long tstp;       //tstp	bigint	Checked
        public double tem;      //tem	float	Checked
        public double hum;      //hum	float	Checked
        public double co2;      //co2	float	Checked
        public double o2;      //o2	float	Checked
        public double pm25;     //pm25	float	Checked
        public double pm10;     //pm10	float	Checked
    }
    public class SenDatList : List<SenDat> { }
    public class Sensor
    {
        public int id;         //id	int	Unchecked
        public int equid;      //equid	int	Checked
        public int type;       //type	int	Checked
        public int senid;      //senid	int	Checked
        public double lon;      //lon	float	Checked
        public double lat;      //lat	float	Checked
        public double alt;      //alt	float	Checked
        public string simid;   //simid	varchar(20)	Checked
        public string address; //address	varchar(100)	Checked
        public string cont;    //cont	varchar(10)	Checked
        public string phone;   //phone	varchar(20)	Checked
        public Bitmap envpic;  //envpic	image	Checked
    }

    public class UAccount
    {
        public int u_id; 
        public String u_name; 
        public String u_password;
        public int u_level; 
        public String u_memo;
        public String u_city;
        public String u_address;
        public String u_tel;



    }

    public class SensorList : List<Sensor> { }

    public class UAccountList : List<UAccount> { }

    public class WeddingIDList : List<string> { }

    public class SenFrm
    {
        public long id;     //id	numeric(18, 0)	Unchecked
        public int equid;
        public long tstp;   //time	timestamp	Checked
        public string frm;  //frm	varchar(50)	Checked
    }
    public class SenFrmList : List<SenFrm> { }

    public class PicName
    {
        public string wd_id;
        public string pic_id;   
        public string pic_name; 
    }


    public class WeddingDressProperties
    {
        public string wd_id;
        public string wd_date;
        public string wd_big_category;
        public string wd_litter_category;
        public string wd_factory;
        public string wd_color;
        public string cpml_ls;
        public string cpml_ws;
        public string cpml_duan;
        public string cpml_zs;
        public string cpml_other;
        public string cpbx_yw;
        public string cpbx_ppq;
        public string cpbx_ab;
        public string cpbx_dq;
        public string cpbx_qdhc;
        public string bwcd_qd;
        public string bwcd_xtw;
        public string bwcd_ztw;
        public string bwcd_ctw;
        public string bwcd_hhtw;
        public string cplx_mx;
        public string cplx_sv;
        public string cplx_yzj;
        public string cplx_dd;
        public string cplx_dj;
        public string cplx_gb;
        public string cplx_yl;
        public string cplx_ll;
        public string lxys_bd;
        public string lxys_ll;
        public string lxys_lb;
        public string memo;
        public string emergency_period;//紧急工期
        public string normal_period;//正常工期
        public string is_renew;//是否返单(即样品拿回工厂重新做)


        //public List<WeddingDressSizeAndCount> wdsc;
    }

    public class WeddingDressSizeAndCount
    {
        public string wd_id;
        public string wd_size;
        public string wd_price;
        public string wd_huohao;
        public string wd_listing_date;
        public string wd_count;
        public string wd_merchant_code;
        public string wd_barcode;

    }

    public class Customers
    {
        public string customerID;
        public string brideName;
        public string brideContact;
        public string marryDay;
        public string infoChannel;
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
        public string status;
        public string reason;
        public string hisreason;
        public string reservetimes;
        public string city;
        public string wangwangID;
        public string operatorName;//录入人员
        public string jdgw;//接待顾问
        public string groomName;//新郎姓名
        public string groomContact;//新郎联系电话
        public string dueDate;//成交日期=付款日期=交了一部分定金的日期
        public string getDressDate;//取纱日期
        public string returnDressDate;//还纱日期

        public List<string> listBorrowHSLFSJ = new List<string>();//租赁婚纱礼服数据
        public List<string> listBuyHSLFSJ = new List<string>();//购买婚纱礼服数据

        public string address;

    }

    public class CustomerOrder
    {
        public string orderID;
        public string customerID;
        public string wdData;
        public string orderAmountPre;
        public string orderAmountafter;
        public string orderDiscountRate;
        public string orderPaymentMethod;
        public string reservedAmount;
        public string depositAmount;
        public string depositPaymentMethod;
        public string totalAmount;
        public string returnAmount;
        public string orderStatus;
        public string orderType;
        public string receptionConsultant;

        public string shenpiren;//审批人
        public string gongfei;//工费
        public string jiajifei;//加急费
        public string jiachangfei;//加长费
        public string jiakuanfei;//加宽费
        public string ifarrears;//是否欠微款

    }

    public class CustomerOrderDetails
    {
        public string orderID;
        public string wd_id;
        public string wd_size;
        public string wd_big_category;
        public string wd_litter_category;
        public string memo;

    }

    //撞期管理
    public class CollisionPeriodManager
    {
        public string wd_id;
        public string wd_size;
        public string marryDay;
        public string brideName;
        public string brideContact;
        public string customerID;

    }


}
