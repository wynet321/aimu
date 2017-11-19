using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace aimu
{
    public partial class CustomerProperties : Form
    {
        private int reserveTimes;
        private int lastStatus;
        private Customer customer;
        private Data customers;

        public CustomerProperties(int customerId)
        {
            InitializeComponent();
            customer = new Customer();
            customer.id = customerId;
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
                if (ShardDb.deleteByCustomerIDInClusterTable(tbCustomerID.Text.Trim()))
                {
                    MessageBox.Show("客户删除成功！");
                    Close();
                }
            }
        }

        private void CustomerProperties_Load(object sender, EventArgs e)
        {
            customers = ShardDb.getCustomersById(customer.id);
            if (!customers.Success)
            {
                this.Close();
                return;
            }
            customer = new Customer();
            foreach (DataRow dr in customers.DataTable.Rows)
            {
                customer.brideName = dr[0] == null ? "" : dr[0].ToString();
                customer.brideContact = dr[1] == null ? "" : dr[1].ToString();
                customer.marryDay = dr[2] == null ? "" : dr[2].ToString();
                customer.channelId = Convert.ToInt16(dr[3]);
                customer.reserveDate = dr[4] == null ? "" : dr[4].ToString();
                customer.reserveTime = dr[5] == null ? "" : dr[5].ToString();
                customer.tryDress = dr[6] == null ? "" : dr[6].ToString();
                customer.memo = dr[7] == null ? "" : dr[7].ToString();
                customer.scsj_jsg = dr[8] == null ? "" : dr[8].ToString();
                customer.scsj_cxsg = dr[9] == null ? "" : dr[9].ToString();
                customer.scsj_tz = dr[10] == null ? "" : dr[10].ToString();
                customer.scsj_xw = dr[11] == null ? "" : dr[11].ToString();
                customer.scsj_xxw = dr[12] == null ? "" : dr[12].ToString();
                customer.scsj_yw = dr[13] == null ? "" : dr[13].ToString();
                customer.scsj_dqw = dr[14] == null ? "" : dr[14].ToString();
                customer.scsj_tw = dr[15] == null ? "" : dr[15].ToString();
                customer.scsj_jk = dr[16] == null ? "" : dr[16].ToString();
                customer.scsj_jw = dr[17] == null ? "" : dr[17].ToString();
                customer.scsj_dbw = dr[18] == null ? "" : dr[18].ToString();
                customer.scsj_yddc = dr[19] == null ? "" : dr[19].ToString();
                customer.scsj_qyj = dr[20] == null ? "" : dr[20].ToString();
                customer.scsj_bpjl = dr[21] == null ? "" : dr[21].ToString();
                customer.status = Int16.Parse(dr[22].ToString());
                customer.jdgw = dr[23] == null ? "" : dr[23].ToString();
                customer.groomName = dr[24] == null ? "" : dr[24].ToString();
                customer.groomContact = dr[25] == null ? "" : dr[25].ToString();
                customer.wangwangID = dr[26] == null ? "" : dr[26].ToString();
                customer.id = Convert.ToInt16(dr[27]);
                customer.reservetimes = dr[28] == null ? "" : dr[28].ToString();
                customer.retailerMemo = dr[29] == null ? "" : dr[29].ToString();
                customer.hisreason = dr[30] == null ? "" : dr[30].ToString();
                customer.storeId = Convert.ToInt16(dr[31]);
                customer.accountPayable = dr[32].ToString();
                customer.refund = dr[33].ToString();
                customer.fine = dr[34].ToString();
                customer.partnerName = dr[35] == null ? "" : dr[35].ToString();
            }
            tbCustomerID.Text = customer.id.ToString();
            tbBrideName.Text = customer.brideName;
            tbBrideContact.Text = customer.brideContact;
            tbGroomName.Text = customer.groomName;
            tbGroomContact.Text = customer.groomContact;
            dtMarryDay.Text = customer.marryDay;

            comboBoxChannel.DisplayMember = "name";
            comboBoxChannel.ValueMember = "id";
            Data channels = ShardDb.getChannels();
            if (!channels.Success)
            {
                this.Close();
                return;
            }
            comboBoxChannel.DataSource = channels.DataTable;
            comboBoxChannel.SelectedValue = customer.channelId;
            combBoxCity.DisplayMember = "name";
            combBoxCity.ValueMember = "id";
            Data cities = ShardDb.getCities();
            if (!cities.Success)
            {
                this.Close();
                return;
            }
            combBoxCity.DataSource = cities.DataTable;
            Data city = ShardDb.getCityByStoreId(customer.storeId);
            if (!city.Success)
            {
                this.Close();
                return;
            }
            combBoxCity.SelectedValue = Convert.ToInt16(city.DataTable.Rows[0].ItemArray[0]);
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
            Data status = ShardDb.getCustomerStatus();
            if (!status.Success)
            {
                this.Close();
                return;
            }
            comboBoxStatus.DisplayMember = "name";
            comboBoxStatus.ValueMember = "id";
            comboBoxStatus.DataSource = status.DataTable;
            comboBoxStatus.SelectedValue = customer.status;

            fillTryDressList();
            fillOrderList();
            if (Sharevariables.UserLevel == 1)
            {
                buttonDelete.Enabled = true;
            }
            else
            {
                buttonDelete.Enabled = false;
            }

            if (Sharevariables.UserLevel == 4)
            {
                buttonSave.Enabled = false;
            }
            else
            {
                buttonSave.Enabled = true;
            }

            if (Sharevariables.UserLevel == 16)
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
            cm.id = customer.id;
            cm.brideName = tbBrideName.Text.Trim();
            cm.brideContact = tbBrideContact.Text.Trim();
            cm.groomName = tbGroomName.Text.Trim();
            cm.groomContact = tbGroomContact.Text.Trim();
            cm.marryDay = dtMarryDay.Value.ToString("yyyy-MM-dd");
            cm.channelId = Convert.ToInt16(comboBoxChannel.SelectedValue);
            cm.storeId = Convert.ToInt16(comboBoxStore.SelectedValue);
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
            cm.partnerName = textBoxPartner.Text.Trim();

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
            ShardDb.updateCustomerInfo(cm);
            this.Close();
        }

        private void fillTryDressList()
        {
            Data tryOnList = ShardDb.getTryOnListByCustomerId(tbCustomerID.Text);
            if (!tryOnList.Success)
            {
                this.Close();
                return;
            }
            dataGridViewTryOn.DataSource = tryOnList.DataTable;
            changeTryOnDataGridViewHeader();
            if (tryOnList.DataTable.Rows.Count > 0)
            {
                combBoxCity.Enabled = false;
                comboBoxStore.Enabled = false;
            }
        }

        private void fillOrderList()
        {
            Data orderList = ShardDb.getOrderListByCustomerId(tbCustomerID.Text);
            if (!orderList.Success)
            {
                this.Close();
                return;
            }
            dataGridViewOrder.DataSource = orderList.DataTable;
            dataGridViewOrder.Columns["id"].Visible = false;
            changeOrderDataGridViewHeader();
            if (orderList.DataTable.Rows.Count > 0)
            {
                combBoxCity.Enabled = false;
                comboBoxStore.Enabled = false;
            }
        }

        private void changeOrderDataGridViewHeader()
        {
            dataGridViewOrder.Columns["id"].HeaderText = "订单编号";
            dataGridViewOrder.Columns["totalAmount"].HeaderText = "订单金额";
            dataGridViewOrder.Columns["memo"].HeaderText = "备注";
            dataGridViewOrder.Columns["depositAmount"].HeaderText = "租赁押金";
            dataGridViewOrder.Columns["orderAmountafter"].HeaderText = "实付金额";
            dataGridViewOrder.Columns["createdDate"].HeaderText = "订单日期";
        }
        private void changeTryOnDataGridViewHeader()
        {
            dataGridViewTryOn.Columns["wd_id"].HeaderText = "婚纱编号";
            dataGridViewTryOn.Columns["wd_big_category"].HeaderText = "大类";
            dataGridViewTryOn.Columns["wd_litter_category"].HeaderText = "小类";
            dataGridViewTryOn.Columns["wdSize"].HeaderText = "尺寸";
            dataGridViewTryOn.Columns["wd_color"].HeaderText = "颜色";
            dataGridViewTryOn.Columns["id"].Visible = false;
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
            customers = ShardDb.getCustomersById(customer.id);
            if (!customers.Success)
            {
                this.Close();
                return;
            }
            customer = new Customer();
            foreach (DataRow dr in customers.DataTable.Rows)
            {
                customer.brideName = dr[0] == null ? "" : dr[0].ToString();
                customer.brideContact = dr[1] == null ? "" : dr[1].ToString();
                customer.marryDay = dr[2] == null ? "" : dr[2].ToString();
                customer.channelId = Convert.ToInt16(dr[3]);
                customer.reserveDate = dr[4] == null ? "" : dr[4].ToString();
                customer.reserveTime = dr[5] == null ? "" : dr[5].ToString();
                customer.tryDress = dr[6] == null ? "" : dr[6].ToString();
                customer.memo = dr[7] == null ? "" : dr[7].ToString();
                customer.scsj_jsg = dr[8] == null ? "" : dr[8].ToString();
                customer.scsj_cxsg = dr[9] == null ? "" : dr[9].ToString();
                customer.scsj_tz = dr[10] == null ? "" : dr[10].ToString();
                customer.scsj_xw = dr[11] == null ? "" : dr[11].ToString();
                customer.scsj_xxw = dr[12] == null ? "" : dr[12].ToString();
                customer.scsj_yw = dr[13] == null ? "" : dr[13].ToString();
                customer.scsj_dqw = dr[14] == null ? "" : dr[14].ToString();
                customer.scsj_tw = dr[15] == null ? "" : dr[15].ToString();
                customer.scsj_jk = dr[16] == null ? "" : dr[16].ToString();
                customer.scsj_jw = dr[17] == null ? "" : dr[17].ToString();
                customer.scsj_dbw = dr[18] == null ? "" : dr[18].ToString();
                customer.scsj_yddc = dr[19] == null ? "" : dr[19].ToString();
                customer.scsj_qyj = dr[20] == null ? "" : dr[20].ToString();
                customer.scsj_bpjl = dr[21] == null ? "" : dr[21].ToString();
                customer.status = Int16.Parse(dr[22].ToString());
                customer.jdgw = dr[23] == null ? "" : dr[23].ToString();
                customer.groomName = dr[24] == null ? "" : dr[24].ToString();
                customer.groomContact = dr[25] == null ? "" : dr[25].ToString();
                customer.wangwangID = dr[26] == null ? "" : dr[26].ToString();
                customer.id = Convert.ToInt16(dr[27]);
                customer.reservetimes = dr[28] == null ? "" : dr[28].ToString();
                customer.retailerMemo = dr[29] == null ? "" : dr[29].ToString();
                customer.hisreason = dr[30] == null ? "" : dr[30].ToString();
                customer.storeId = Convert.ToInt16(dr[31]);
                customer.accountPayable = dr[32].ToString();
                customer.refund = dr[33].ToString();
                customer.fine = dr[34].ToString();
                customer.partnerName = dr[35] == null ? "" : dr[35].ToString();
            }
            textBoxAccountPayable.Text = customer.accountPayable;
        }

        private void dataGridViewTryOn_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Sharevariables.WeddingDressID = "";
                Form dressProperties = new DressQuery();
                if (dressProperties.ShowDialog() == DialogResult.OK)
                {
                    ShardDb.InsertCustomerTryDressList(customer.id, Sharevariables.WeddingDressID, Sharevariables.WdSize, DateTime.Today.ToShortDateString());
                    fillTryDressList();
                }
            }
        }

        private void toolStripMenuItemDeletion_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewTryOn.SelectedRows)
            {
                ShardDb.deleteTryonById(row.Cells["id"].Value.ToString());
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

        private void comboBoxCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxStore.DisplayMember = "name";
            comboBoxStore.ValueMember = "id";
            Data stores = ShardDb.getStores(Convert.ToInt16(combBoxCity.SelectedValue));
            if (!stores.Success)
            {
                this.Close();
                return;
            }
            comboBoxStore.DataSource = stores.DataTable;
        }

        private void comboBoxChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt16(comboBoxChannel.SelectedValue) == 3)
            {
                labelPartner.Visible = true;
                textBoxPartner.Visible = true;
                textBoxPartner.Text = customer.partnerName;
            }
            else
            {
                labelPartner.Visible = false;
                textBoxPartner.Visible = false;
            }
        }
    }
}