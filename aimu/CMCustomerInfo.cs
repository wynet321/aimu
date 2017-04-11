using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aimu
{
    public partial class CMCustomerInfo : Form
    {
        public CMCustomerInfo()
        {
            InitializeComponent();
        }


        public CMCustomerInfo(Customers ct)
        {
            InitializeComponent();
            this.tbCustomerID.Text = ct.customerID;
            this.tbBrideName.Text = ct.brideName;
            this.tbBrideContact.Text = ct.brideContact;
            this.tbGroomName.Text = ct.groomName;
            this.tbGroomContact.Text = ct.groomContact;
            this.dtMarryDay.Text = ct.marryDay;
            this.tbInfoChannel.Text = ct.infoChannel;
            this.cbCity.Text = ct.city;
            this.dtReserveDate.Text = ct.reserveDate;
            this.dtReserveTime.Text = ct.reserveTime;
            this.cbTryDress.Text = ct.tryDress;
            this.tbMemo.Text = ct.memo;
            this.tbHisReason.Text = ct.reason;
            this.scsj_jsg.Text = ct.scsj_jsg;
            this.scsj_cxsg.Text = ct.scsj_cxsg;
            this.scsj_tz.Text = ct.scsj_tz;
            this.scsj_xw.Text = ct.scsj_xw;
            this.scsj_xxw.Text = ct.scsj_xxw;
            this.scsj_yw.Text = ct.scsj_yw;
            this.scsj_dqw.Text = ct.scsj_dqw;
            this.scsj_tw.Text = ct.scsj_tw;
            this.scsj_jk.Text = ct.scsj_jk;
            this.scsj_jw.Text = ct.scsj_jw;
            this.scsj_dbw.Text = ct.scsj_dbw;
            this.scsj_yddc.Text = ct.scsj_yddc;
            this.scsj_qyj.Text = ct.scsj_qyj;
            this.scsj_bpjl.Text = ct.scsj_bpjl;
            this.wangwangID.Text = ct.wangwangID;
            this.jdgw.Text = ct.jdgw;
            this.tbAddress.Text = ct.address;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private string[] getUpdateInfo()
        {
            string[] info = new string[5];

            info[0]= dtMarryDay.Value.ToString("yyyy-MM-dd");
            info[1]= dtReserveDate.Value.ToString("yyyy-MM-dd");
            info[2]= dtReserveTime.Value.ToString("hh:mm:ss");
            info[3]= cbTryDress.Text.ToString();
            info[4] = tbReason.Text.ToString();

            return info;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int reservedtime;
            reservedtime = ReadData.getCustomerReservedTimes(tbCustomerID.Text);
            UpdateDate.updateCustomerStatus(tbCustomerID.Text, "C"); //C：成功预约
            UpdateDate.updateCustomerReservedTimes(tbCustomerID.Text, (++reservedtime)); // 更新客户预约次数 ++
            UpdateDate.updateCustomerInfo(tbCustomerID.Text, getUpdateInfo());

            MessageBox.Show("预约到店成功！");
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CMNotReservedConfirm cm = new CMNotReservedConfirm(this.tbCustomerID.Text);
            cm.ShowDialog();
            UpdateDate.updateCustomerInfo(tbCustomerID.Text, getUpdateInfo());
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int reservedtime;
            reservedtime = ReadData.getCustomerReservedTimes(tbCustomerID.Text);
            UpdateDate.updateCustomerReservedTimes(tbCustomerID.Text, (++reservedtime)); // 更新客户预约次数 ++
            UpdateDate.updateCustomerStatus(tbCustomerID.Text, "D"); //D:delete 客户已流失
            UpdateDate.updateCustomerInfo(tbCustomerID.Text, getUpdateInfo());
            DialogResult dialogResult = MessageBox.Show("确定该客户已流失吗？", "退出", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }


        }


        //删除客户 ，管理员操作
        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("警告：系统管理员将永久删除该客户信息并将不可恢复，是否确认删除？", "退出", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (TruncateTable.deleteByCustomerIDInClusterTable(tbCustomerID.Text.Trim()))
                {
                    MessageBox.Show("客户删除成功！");
                    this.Close();
                }
            }




            
        }

        private void CMCustomerInfo_Load(object sender, EventArgs e)
        {
            if (Sharevariables.getUserLevel() == 1)
            { this.btDelCustomer.Enabled = true; }



            if (Sharevariables.getUserLevel() == 4)
            {
                this.button1.Enabled = false;
                this.button2.Enabled = false;
                this.button3.Enabled = false;
                this.button5.Enabled = false;

            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("是否确认保存更新客户信息？", "退出", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Customers cm = new Customers();
                cm.customerID = this.tbCustomerID.Text.Trim();
                cm.brideContact = this.tbBrideContact.Text.Trim();
                cm.groomName = this.tbGroomName.Text.Trim();
                cm.groomContact = this.tbGroomContact.Text.Trim();
                cm.marryDay = this.dtMarryDay.Value.ToString("yyyy-MM-dd");
                cm.infoChannel = this.tbInfoChannel.Text.Trim();
                cm.city = this.cbCity.Text.Trim();
               // cm.reserveDate = this.dtReserveDate.Text.Trim();//reserveDate.Value.ToString("yyyy-MM-dd")
                cm.reserveDate = this.dtReserveDate.Value.ToString("yyyy-MM-dd");//reserveDate.Value.ToString("yyyy-MM-dd")
                cm.reserveTime = this.dtReserveTime.Value.ToString("hh:mm:ss");
                cm.tryDress = this.cbTryDress.Text.Trim();
                cm.reason = DateTime.Now.ToLongDateString()+":"+ this.tbReason.Text.Trim() + "\r\n" +tbHisReason.Text.Trim();
                cm.scsj_jsg = this.scsj_jsg.Text.Trim();
                cm.scsj_jsg = this.scsj_jsg.Text.Trim();
                cm.scsj_cxsg = this.scsj_cxsg.Text.Trim();
                cm.scsj_tz = this.scsj_tz.Text.Trim();
                cm.scsj_xw = this.scsj_xw.Text.Trim();
                cm.scsj_xxw = this.scsj_xxw.Text.Trim();
                cm.scsj_yw = this.scsj_yw.Text.Trim();
                cm.scsj_dqw = this.scsj_dqw.Text.Trim();
                cm.scsj_tw = this.scsj_tw.Text.Trim();
                cm.scsj_jk = this.scsj_jk.Text.Trim();
                cm.scsj_jw = this.scsj_jw.Text.Trim();
                cm.scsj_dbw = this.scsj_dbw.Text.Trim();
                cm.scsj_yddc = this.scsj_yddc.Text.Trim();
                cm.scsj_qyj = this.scsj_qyj.Text.Trim();
                cm.scsj_bpjl = this.scsj_bpjl.Text.Trim();
                cm.wangwangID = this.wangwangID.Text.Trim();
                cm.jdgw = this.jdgw.Text.Trim();
                cm.address = this.tbAddress.Text.Trim();

                if (UpdateDate.updateCustomerInfo(cm))
                {
                    MessageBox.Show("客户更新成功！");
                    this.Close();
                }
            }

        }
    }
}
