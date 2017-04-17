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
        private int reserveTimes;
        private String lastStatus;
        public CMCustomerInfo()
        {
            InitializeComponent();
        }

        public CMCustomerInfo(string customerId)
        {
            InitializeComponent();
            Customers customer = ReadData.getCustomersByID(customerId);
            tbCustomerID.Text = customer.customerID;
            tbBrideName.Text = customer.brideName;
            tbBrideContact.Text = customer.brideContact;
            tbGroomName.Text = customer.groomName;
            tbGroomContact.Text = customer.groomContact;
            dtMarryDay.Text = customer.marryDay;
            tbInfoChannel.Text = customer.infoChannel;
            if (customer.city != "")
            {
                cbCity.SelectedIndex = cbCity.Items.IndexOf(customer.city);
            }
            dtReserveDate.Text = customer.reserveDate;
            dtReserveTime.Text = customer.reserveTime;
            if (customer.tryDress != "")
            {
                cbTryDress.SelectedIndex = cbTryDress.Items.IndexOf(customer.tryDress);
            }
            tbMemo.Text = customer.memo;
            tbHisReason.Text = customer.hisreason;
            scsj_jsg.Text = customer.scsj_jsg;
            scsj_cxsg.Text = customer.scsj_cxsg;
            scsj_tz.Text = customer.scsj_tz;
            scsj_xw.Text = customer.scsj_xw;
            scsj_xxw.Text = customer.scsj_xxw;
            scsj_yw.Text = customer.scsj_yw;
            scsj_dqw.Text = customer.scsj_dqw;
            scsj_tw.Text = customer.scsj_tw;
            scsj_jk.Text = customer.scsj_jk;
            scsj_jw.Text = customer.scsj_jw;
            scsj_dbw.Text = customer.scsj_dbw;
            scsj_yddc.Text = customer.scsj_yddc;
            scsj_qyj.Text = customer.scsj_qyj;
            scsj_bpjl.Text = customer.scsj_bpjl;
            wangwangID.Text = customer.wangwangID;
            jdgw.Text = customer.jdgw;
            tbAddress.Text = customer.address;
            reserveTimes = Int16.Parse(customer.reservetimes);
            lastStatus = customer.status;
            textBoxRetailerMemo.Text = customer.retailerMemo;
            /*   
            A：淘宝新客户，淘宝客服已经联系但是前台还未联系的客人 (reservetimes:0)
            B：已联系客户但未成功预约到店时间 (reservetimes+1)
            C：已联系客户并预约到店时间 (reservetimes+1)
            D：客户已流失 (reservetimes+1)
            E：到店未成交
            F：客户交定金，衣服款式未定
            G：客户已完款，衣服款式未定
            H：客户交定金，衣服款式已定
            I：客户已完款，衣服款式已定 
            */
            switch (customer.status)
            {
                case "A":
                    radioButtonNewCustomer.Checked = true;
                    break;
                case "B":
                    radioButtonReserveFail.Checked = true;
                    break;
                case "C":
                    radioButtonReserveSucceed.Checked = true;
                    break;
                case "D":
                    radioButtonLost.Checked = true;
                    break;
                case "E":
                    radioButtonDealFail.Checked = true;
                    break;
                case "F":
                    radioButtonPrepaidWithoutSelection.Checked = true;
                    break;
                case "G":
                    radioButtonPaidWithoutSelection.Checked = true;
                    break;
                case "H":
                    radioButtonPrepaidWithSelection.Checked = true;
                    break;
                case "I":
                    radioButtonPaidWithSelection.Checked = true;
                    break;
            }
            fillTryDressList();
        }

        //public CMCustomerInfo(Customers ct)
        //{
        //    InitializeComponent();
        //    tbCustomerID.Text = ct.customerID;
        //    tbBrideName.Text = ct.brideName;
        //    tbBrideContact.Text = ct.brideContact;
        //    tbGroomName.Text = ct.groomName;
        //    tbGroomContact.Text = ct.groomContact;
        //    dtMarryDay.Text = ct.marryDay;
        //    tbInfoChannel.Text = ct.infoChannel;
        //    cbCity.Text = ct.city;
        //    dtReserveDate.Text = ct.reserveDate;
        //    dtReserveTime.Text = ct.reserveTime;
        //    cbTryDress.Text = ct.tryDress;
        //    tbMemo.Text = ct.memo;
        //    tbHisReason.Text = ct.reason;
        //    scsj_jsg.Text = ct.scsj_jsg;
        //    scsj_cxsg.Text = ct.scsj_cxsg;
        //    scsj_tz.Text = ct.scsj_tz;
        //    scsj_xw.Text = ct.scsj_xw;
        //    scsj_xxw.Text = ct.scsj_xxw;
        //    scsj_yw.Text = ct.scsj_yw;
        //    scsj_dqw.Text = ct.scsj_dqw;
        //    scsj_tw.Text = ct.scsj_tw;
        //    scsj_jk.Text = ct.scsj_jk;
        //    scsj_jw.Text = ct.scsj_jw;
        //    scsj_dbw.Text = ct.scsj_dbw;
        //    scsj_yddc.Text = ct.scsj_yddc;
        //    scsj_qyj.Text = ct.scsj_qyj;
        //    scsj_bpjl.Text = ct.scsj_bpjl;
        //    wangwangID.Text = ct.wangwangID;
        //    jdgw.Text = ct.jdgw;
        //    tbAddress.Text = ct.address;
        //    reserveTimes = Int16.Parse(ct.reservetimes);
        //    lastStatus = ct.status;
        //    /*   
        //    A：淘宝新客户，淘宝客服已经联系但是前台还未联系的客人 (reservetimes:0)
        //    B：已联系客户但未成功预约到店时间 (reservetimes+1)
        //    C：已联系客户并预约到店时间 (reservetimes+1)
        //    D：客户已流失 (reservetimes+1)
        //    E：到店未成交
        //    F：客户交定金，衣服款式未定
        //    G：客户已完款，衣服款式未定
        //    H：客户交定金，衣服款式已定
        //    I：客户已完款，衣服款式已定 
        //    */
        //    switch (ct.status)
        //    {
        //        case "A":
        //            radioButtonNewCustomer.Checked = true;
        //            break;
        //        case "B":
        //            radioButtonReserveFail.Checked = true;
        //            break;
        //        case "C":
        //            radioButtonReserveSucceed.Checked = true;
        //            break;
        //        case "D":
        //            radioButtonLost.Checked = true;
        //            break;
        //        case "E":
        //            radioButtonDealFail.Checked = true;
        //            break;
        //        case "F":
        //            radioButtonPrepaidWithoutSelection.Checked = true;
        //            break;
        //        case "G":
        //            radioButtonPaidWithoutSelection.Checked = true;
        //            break;
        //        case "H":
        //            radioButtonPrepaidWithSelection.Checked = true;
        //            break;
        //        case "I":
        //            radioButtonPaidWithSelection.Checked = true;
        //            break;
        //    }
        //    fillTryDressList();
        //}

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }


        private string[] getUpdateInfo()
        {
            string[] info = new string[5];

            info[0] = dtMarryDay.Value.ToString("yyyy-MM-dd");
            info[1] = dtReserveDate.Value.ToString("yyyy-MM-dd");
            info[2] = dtReserveTime.Value.ToString("hh:mm:ss");
            info[3] = cbTryDress.Text.ToString();
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
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CMNotReservedConfirm cm = new CMNotReservedConfirm(tbCustomerID.Text);
            cm.ShowDialog();
            UpdateDate.updateCustomerInfo(tbCustomerID.Text, getUpdateInfo());
            Close();
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
                Close();
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
                    Close();
                }
            }
        }

        private void CMCustomerInfo_Load(object sender, EventArgs e)
        {
            if (Sharevariables.getUserLevel() == 1)
            { btDelCustomer.Enabled = true; }

            if (Sharevariables.getUserLevel() == 4)
            {
                button5.Enabled = false;
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (radioButtonLost.Checked || radioButtonReserveFail.Checked || radioButtonDealFail.Checked)
            {
                if (tbReason.Text.Trim().Length == 0)
                {
                    MessageBox.Show("请输入原因");
                    tbReason.Focus();
                    return;
                }
            }
            Customers cm = new Customers();
            cm.brideName = tbBrideName.Text.Trim();
            cm.customerID = tbCustomerID.Text.Trim();
            cm.brideContact = tbBrideContact.Text.Trim();
            cm.groomName = tbGroomName.Text.Trim();
            cm.groomContact = tbGroomContact.Text.Trim();
            cm.marryDay = dtMarryDay.Value.ToString("yyyy-MM-dd");
            cm.infoChannel = tbInfoChannel.Text.Trim();
            cm.city = cbCity.Text.Trim();
            cm.tryDress = cbTryDress.Text.Trim();
            if (tbReason.Text.Trim().Length == 0)
            {
                cm.reason = tbHisReason.Text.Trim().Replace("'", "\'");
            }
            else
            {
                cm.reason = DateTime.Now.ToLongDateString() + ":" + tbReason.Text.Trim().Replace("'", "\'") + "\r\n" + tbHisReason.Text.Trim().Replace("'", "\'");
            }
            cm.scsj_jsg = scsj_jsg.Text.Trim();
            cm.scsj_jsg = scsj_jsg.Text.Trim();
            cm.scsj_cxsg = scsj_cxsg.Text.Trim();
            cm.scsj_tz = scsj_tz.Text.Trim();
            cm.scsj_xw = scsj_xw.Text.Trim();
            cm.scsj_xxw = scsj_xxw.Text.Trim();
            cm.scsj_yw = scsj_yw.Text.Trim();
            cm.scsj_dqw = scsj_dqw.Text.Trim();
            cm.scsj_tw = scsj_tw.Text.Trim();
            cm.scsj_jk = scsj_jk.Text.Trim();
            cm.scsj_jw = scsj_jw.Text.Trim();
            cm.scsj_dbw = scsj_dbw.Text.Trim();
            cm.scsj_yddc = scsj_yddc.Text.Trim();
            cm.scsj_qyj = scsj_qyj.Text.Trim();
            cm.scsj_bpjl = scsj_bpjl.Text.Trim();
            cm.wangwangID = wangwangID.Text.Trim();
            cm.jdgw = jdgw.Text.Trim();
            cm.address = tbAddress.Text.Trim();
            cm.reservetimes = reserveTimes.ToString();
            cm.retailerMemo = textBoxRetailerMemo.Text.Trim().Replace("'", "\'");
            foreach (var radioButton in groupBoxStatus.Controls)
            {
                RadioButton radio = radioButton as RadioButton;

                if (radio != null && radio.Checked)
                {
                    switch (radio.Name)
                    {
                        case "radioButtonNewCustomer":
                            cm.status = "A";
                            cm.reserveDate = "";
                            cm.reserveTime = "";
                            break;
                        case "radioButtonReserveFail":
                            cm.status = "B";
                            cm.reserveDate = dtReserveDate.Value.ToString("yyyy-MM-dd");
                            //if (cm.reserveDate == "1900-01-01")
                            //{
                            //    cm.reserveDate = "";
                            //}
                            cm.reserveTime = "";
                            break;
                        case "radioButtonReserveSucceed":
                            cm.status = "C";
                            cm.reserveDate = dtReserveDate.Value.ToString("yyyy-MM-dd");
                            cm.reserveTime = dtReserveTime.Value.ToString("hh:mm:ss");
                            break;
                        case "radioButtonLost":
                            cm.status = "D";
                            cm.reserveDate = "";
                            cm.reserveTime = dtReserveTime.Value.ToString("hh:mm:ss");
                            break;
                        case "radioButtonDealFail":
                            cm.status = "E";
                            cm.reserveDate = dtReserveDate.Value.ToString("yyyy-MM-dd");
                            //if (cm.reserveDate == "1900-01-01")
                            //{
                            //    cm.reserveDate = "";
                            //}
                            cm.reserveTime = "";
                            break;
                        case "radioButtonPrepaidWithoutSelection":
                            cm.status = "F";
                            cm.reserveDate = dtReserveDate.Value.ToString("yyyy-MM-dd");
                            cm.reserveTime = "";
                            break;
                        case "radioButtonPaidWithoutSelection":
                            cm.status = "G";
                            cm.reserveDate = dtReserveDate.Value.ToString("yyyy-MM-dd");
                            cm.reserveTime = "";
                            break;
                        case "radioButtonPrepaidWithSelection":
                            cm.status = "H";
                            cm.reserveDate = dtReserveDate.Value.ToString("yyyy-MM-dd");
                            cm.reserveTime = "";
                            break;
                        case "radioButtonPaidWithSelection":
                            cm.status = "I";
                            cm.reserveDate = "";
                            cm.reserveTime = "";
                            break;
                        case "radioButtonComplete":
                            cm.status = "J";
                            cm.reserveDate = "";
                            cm.reserveTime = "";
                            break;
                    }
                }
            }
            if (cm.status != lastStatus)
            {
                if (cm.status == "B" || cm.status == "C" || cm.status == "D")
                {
                    cm.reservetimes = (short.Parse(cm.reservetimes) + 1).ToString();
                }
                if (cm.status == "A")
                {
                    cm.reservetimes = "0";
                }
            }

            if (!UpdateDate.updateCustomerInfo(cm))
            {
                MessageBox.Show("客户更新失败！");
            }
            else
            {
                Close();
            }
        }

        private void radioButtonReserveFail_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxStatusChanged();
        }

        private void radioButtonDealFail_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxStatusChanged();
        }

        private void radioButtonReserveSucceed_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxStatusChanged();
        }

        private void radioButtonLost_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxStatusChanged();
        }

        private void radioButtonComplete_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxStatusChanged();
        }

        private void radioButtonNewCustomer_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxStatusChanged();
        }

        private void radioButtonPrepaidWithoutSelection_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxStatusChanged();
        }

        private void radioButtonPrepaidWithSelection_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxStatusChanged();
        }

        private void radioButtonPaidWithoutSelection_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxStatusChanged();
        }

        private void radioButtonPaidWithSelection_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxStatusChanged();
        }

        private void groupBoxStatusChanged()
        {
            if (radioButtonPrepaidWithSelection.Checked || radioButtonPaidWithoutSelection.Checked || radioButtonPrepaidWithoutSelection.Checked)
            {
                panelDate.Visible = true;
                panelTime.Visible = true;
                labelDate.Text = "下次到店日期:";
                labelTime.Text = "下次到店时间:";
            }

            if (radioButtonLost.Checked || radioButtonComplete.Checked || radioButtonNewCustomer.Checked || radioButtonPaidWithSelection.Checked)
            {
                panelDate.Visible = false;
                panelTime.Visible = false;
            }
            if (radioButtonReserveFail.Checked || radioButtonDealFail.Checked)
            {
                panelDate.Visible = true;
                panelTime.Visible = false;
                labelDate.Text = "下次预约日期:";
            }

            if (radioButtonReserveSucceed.Checked)
            {
                panelDate.Visible = true;
                panelTime.Visible = true;
                labelDate.Text = "预约到店日期:";
            }
        }

        private void fillTryDressList()
        {
            DataTable dt = ReadData.fillDataTableForTryDress(tbCustomerID.Text);
            dataGridViewTryOn.DataSource = dt;
            dt = ReadData.fillDataTableForOrder(tbCustomerID.Text);
            dataGridViewOrder.DataSource = dt;
            changeDataGridViewHeader();
        }

        private void changeDataGridViewHeader()
        {
            dataGridViewTryOn.Columns["wd_id"].HeaderText = "婚纱编号";
            dataGridViewTryOn.Columns["wd_big_category"].HeaderText = "大类";
            dataGridViewTryOn.Columns["wd_litter_category"].HeaderText = "小类";
            dataGridViewTryOn.Columns["wdSize"].HeaderText = "尺寸";
            dataGridViewTryOn.Columns["wd_color"].HeaderText = "颜色";
            dataGridViewTryOn.Columns["wd_price"].HeaderText = "价格";

            dataGridViewOrder.Columns["orderID"].HeaderText = "订单编号";
            dataGridViewOrder.Columns["wd_big_category"].HeaderText = "大类";
            dataGridViewOrder.Columns["wd_litter_category"].HeaderText = "小类";
            dataGridViewOrder.Columns["wd_size"].HeaderText = "尺寸";
            dataGridViewOrder.Columns["orderType"].HeaderText = "订单类型";
            dataGridViewOrder.Columns["orderStatus"].HeaderText = "订单状态";
            dataGridViewOrder.Columns["totalAmount"].HeaderText = "订单金额";
            dataGridViewOrder.Columns["returnAmount"].HeaderText = "退款金额";
            dataGridViewOrder.Columns["ifarrears"].HeaderText = "尾款金额";
            dataGridViewOrder.Columns["memo"].HeaderText = "备注";
        }
    }
}