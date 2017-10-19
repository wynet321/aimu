using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aimu
{
    public partial class CustomerProperties : Form
    {
        private int reserveTimes;
        private int lastStatus;
        private Customer customer;

        public CustomerProperties(string customerId)
        {
            InitializeComponent();
            customer = ReadData.getCustomersByID(customerId);
            tbCustomerID.Text = customer.customerID;
            tbBrideName.Text = customer.brideName;
            tbBrideContact.Text = customer.brideContact;
            tbGroomName.Text = customer.groomName;
            tbGroomContact.Text = customer.groomContact;
            dtMarryDay.Text = customer.marryDay;
            tbInfoChannel.Text = customer.infoChannel;
            cbCity.DisplayMember = "name";
            cbCity.ValueMember = "id";
            cbCity.DataSource = ReadData.getCities();
            DataTable city = ReadData.getCityByStoreId(customer.storeId);
            cbCity.SelectedValue = Convert.ToInt16(city.Rows[0].ItemArray[0]);
            comboBoxStore.SelectedValue = customer.storeId;
            dtReserveDate.Value = customer.reserveDate == "" ? DateTime.Today : DateTime.Parse(customer.reserveDate);
            dtReserveTime.Value = customer.reserveTime == "" ? DateTime.Now : DateTime.Parse(customer.reserveTime);
            if (customer.tryDress.Equals("是"))
            {
                radioButtonYes.Checked = true;
            }
            else
            {
                radioButtonNo.Checked = true;
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
            //tbAddress.Text = customer.address;
            reserveTimes = Int16.Parse(customer.reservetimes);
            lastStatus = customer.status;
            textBoxRetailerMemo.Text = customer.retailerMemo;
            textBoxAccountPayable.Text = customer.accountPayable;
            textBoxRefund.Text = customer.refund;
            textBoxFine.Text = customer.fine;
            comboBoxStatus.DataSource = ReadData.getCustomerStatus();
            comboBoxStatus.DisplayMember = "name";
            comboBoxStatus.ValueMember = "id";
            comboBoxStatus.SelectedValue = customer.status;
            fillTryDressList();
            fillOrderList();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        //删除客户 ，管理员操作
        private void buttonDelete_Click(object sender, EventArgs e)
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
            {
                buttonDelete.Enabled = true;
            }
            else
            {
                buttonDelete.Enabled = false;
            }

            if (Sharevariables.getUserLevel() == 4)
            {
                buttonSave.Enabled = false;
            }
            else
            {
                buttonSave.Enabled = true;
            }

            if(Sharevariables.getUserLevel() == 16)
            {
                dataGridViewOrder.Enabled = false;
                dataGridViewTryOn.Enabled = false;
            }
            else
            {
                dataGridViewOrder.Enabled = true;
                dataGridViewTryOn.Enabled = true;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Customer cm = new Customer();
            cm.brideName = tbBrideName.Text.Trim();
            cm.customerID = tbCustomerID.Text.Trim();
            cm.brideContact = tbBrideContact.Text.Trim();
            cm.groomName = tbGroomName.Text.Trim();
            cm.groomContact = tbGroomContact.Text.Trim();
            cm.marryDay = dtMarryDay.Value.ToString("yyyy-MM-dd");
            cm.infoChannel = tbInfoChannel.Text.Trim();
            cm.storeId =Convert.ToInt16(comboBoxStore.SelectedValue);
            cm.tryDress = radioButtonYes.Checked ? "是" : "否";
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
            cm.address = "";
            cm.reservetimes = reserveTimes.ToString();
            cm.retailerMemo = textBoxRetailerMemo.Text.Trim().Replace("'", "\'");
            cm.accountPayable = (textBoxAccountPayable.Text.Trim() == "" ? "0" : textBoxAccountPayable.Text.Trim());
            cm.refund = (textBoxRefund.Text.Trim() == "" ? "0" : textBoxRefund.Text.Trim());
            cm.fine = (textBoxFine.Text.Trim() == "" ? "0" : textBoxFine.Text.Trim());
            cm.status = Int16.Parse(comboBoxStatus.SelectedValue.ToString());

            //foreach (var radioButton in groupBoxIsTryDress.Controls)
            //{
            //    RadioButton radio = radioButton as RadioButton;

            //    if (radio != null && radio.Checked)
            //    {
            switch (cm.status)
            {
                case 1:

                    cm.reserveDate = "";
                    cm.reserveTime = "";
                    break;
                case 2:

                    cm.reserveDate = dtReserveDate.Value.ToString("yyyy-MM-dd");

                    cm.reserveTime = "";
                    break;
                case 3:

                    cm.reserveDate = dtReserveDate.Value.ToString("yyyy-MM-dd");
                    cm.reserveTime = dtReserveTime.Value.ToString("hh:mm:ss");
                    break;
                case 4:

                    cm.reserveDate = "";
                    cm.reserveTime = dtReserveTime.Value.ToString("hh:mm:ss");
                    break;
                case 5:

                    cm.reserveDate = dtReserveDate.Value.ToString("yyyy-MM-dd");
                    cm.reserveTime = "";
                    break;
                case 6:

                    cm.reserveDate = dtReserveDate.Value.ToString("yyyy-MM-dd");
                    cm.reserveTime = "";
                    break;
                case 7:

                    cm.reserveDate = dtReserveDate.Value.ToString("yyyy-MM-dd");
                    cm.reserveTime = "";
                    break;
                case 8:

                    cm.reserveDate = dtReserveDate.Value.ToString("yyyy-MM-dd");
                    cm.reserveTime = "";
                    break;
                case 9:

                    cm.reserveDate = dtReserveDate.Value.ToString("yyyy-MM-dd");
                    cm.reserveTime = dtReserveTime.Value.ToString("hh:mm:ss");
                    break;
                case 10:

                    cm.reserveDate = "";
                    cm.reserveTime = "";
                    break;
                case 11:

                    cm.reserveDate = "";
                    cm.reserveTime = "";
                    break;
            }


            if (cm.status != lastStatus)
            {
                if (cm.status >= 2 && cm.status <= 4)
                {
                    cm.reservetimes = (short.Parse(cm.reservetimes) + 1).ToString();
                }
                if (cm.status == 1)
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

        private void fillTryDressList()
        {
            DataTable dt = ReadData.fillDataTableForTryDress(tbCustomerID.Text);
            dataGridViewTryOn.DataSource = dt;
            changeTryOnDataGridViewHeader();
        }

        private void fillOrderList()
        {
            DataTable dt = ReadData.fillDataTableForOrder(tbCustomerID.Text);
            dataGridViewOrder.DataSource = dt;
            changeOrderDataGridViewHeader();
        }

        private void changeOrderDataGridViewHeader()
        {
            dataGridViewOrder.Columns["orderID"].HeaderText = "订单编号";
            //dataGridViewOrder.Columns["wd_size"].HeaderText = "尺寸";
            //dataGridViewOrder.Columns["orderType"].HeaderText = "订单类型";
            //dataGridViewOrder.Columns["orderStatus"].HeaderText = "订单状态";
            dataGridViewOrder.Columns["totalAmount"].HeaderText = "订单金额";
            dataGridViewOrder.Columns["memo"].HeaderText = "备注";
            dataGridViewOrder.Columns["depositAmount"].HeaderText = "租赁押金";
            dataGridViewOrder.Columns["orderAmountafter"].HeaderText = "实付金额";
        }
        private void changeTryOnDataGridViewHeader()
        {
            dataGridViewTryOn.Columns["wd_id"].HeaderText = "婚纱编号";
            dataGridViewTryOn.Columns["wd_big_category"].HeaderText = "大类";
            dataGridViewTryOn.Columns["wd_litter_category"].HeaderText = "小类";
            dataGridViewTryOn.Columns["wdSize"].HeaderText = "尺寸";
            dataGridViewTryOn.Columns["wd_color"].HeaderText = "颜色";
            dataGridViewTryOn.Columns["id"].Visible = false;
            //dataGridViewTryOn.Columns["wd_price"].HeaderText = "价格";
        }

        private static void showProcessing()
        {
            ProcessingWait fp = new ProcessingWait();
            fp.ShowDialog();
        }
        private void dataGridViewOrder_DoubleClick(object sender, EventArgs e)
        {
            ThreadStart ts = new ThreadStart(showProcessing);
            Thread wait = new Thread(ts);
            wait.Start();
            OrderStandard order = new OrderStandard(customer);
            wait.Abort();
            order.ShowDialog();
            fillOrderList();
            customer = ReadData.getCustomersByID(customer.customerID);
            textBoxAccountPayable.Text = customer.accountPayable;
        }

        private void dataGridViewTryOn_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Form dressProperties = new DressProperties();
                Sharevariables.setWeddingDressID("");
                if (dressProperties.ShowDialog() == DialogResult.OK)
                {
                    SaveData.InsertCustomerTryDressList(customer.customerID, Sharevariables.getWeddingDressID(), Sharevariables.WdSize, DateTime.Today.ToShortDateString());
                    fillTryDressList();
                }
            }
        }

        private void toolStripMenuItemDeletion_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewTryOn.SelectedRows)
            {
                SaveData.deleteTryonById(row.Cells["id"].Value.ToString());
            }
            fillTryDressList();
        }

        private void comboBoxStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxStatus.SelectedIndex == 4)
            {
                labelDate.Visible = false;
                dtReserveTime.Visible = false;
                dtReserveDate.Visible = false;
            }
            else
            {
                dtReserveTime.Visible = true;
                dtReserveDate.Visible = true;
            }


        }

        private void cbCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxStore.DisplayMember = "name";
            comboBoxStore.ValueMember = "id";
            comboBoxStore.DataSource = ReadData.getStores(Convert.ToInt16(cbCity.SelectedValue));
        }
    }
}