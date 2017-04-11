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
    public partial class OMGetWeddingDress : Form
    {

        Boolean disableDoubleClient = false;
        public OMGetWeddingDress()
        {
            InitializeComponent();
        }


        public OMGetWeddingDress(Boolean ddc)
        {
            InitializeComponent();
            disableDoubleClient = ddc;
            // button1_Click(new object(), new EventArgs());
        }


        private void button1_Click(object sender, EventArgs e)
        {


            String filter = "";

            String customerID = textCustomerID.Text.Trim();
            String brideName = textBrideName.Text.Trim();
            String brideContact = textBrideContact.Text.Trim();
            String marryDay = dtMarryDay.Text.Trim();

            if (customerID != "")
            {
                filter += "customerID=\'" + customerID + "\' ";
            }

            if (brideName != "")
            {
                if (filter != "")
                {
                    filter += " and ";
                }
                filter += "brideName=\'" + brideName + "\' ";
            }

            if (brideContact != "")
            {
                if (filter != "")
                {
                    filter += " and ";
                }

                filter += "brideContact=\'" + brideContact + "\' ";
            }

            if (marryDay != "")
            {
                // filter += "marryDay=\"" + marryDay + "\" ";
            }

            if (filter != "")
            {
                filter = " where " + filter;
            }


            //DataTable dt = ReadData.fillDataTableForCustomers();
            //DataTable dt = ReadData.fillDataTableForCustomersAll();
            DataTable dt = ReadData.fillDataTableForCustomersWithFilter(filter);

            dataGridView1.DataSource = dt;
            changeDataGridView();

        }


        private void changeDataGridView()
        {
            if (dataGridView1.Columns["customerID"] != null)
                dataGridView1.Columns["customerID"].HeaderText = "客户编号";
            if (dataGridView1.Columns["brideName"] != null)
                dataGridView1.Columns["brideName"].HeaderText = "新娘姓名";
            if (dataGridView1.Columns["brideContact"] != null)
                dataGridView1.Columns["brideContact"].HeaderText = "新娘联系方式";
            if (dataGridView1.Columns["marryDay"] != null)
                dataGridView1.Columns["marryDay"].HeaderText = "婚期";
            if (dataGridView1.Columns["infoChannel"] != null)
                dataGridView1.Columns["infoChannel"].HeaderText = "渠道";
            if (dataGridView1.Columns["reserveDate"] != null)
                dataGridView1.Columns["reserveDate"].HeaderText = "预约到店日期";
            if (dataGridView1.Columns["reserveTime"] != null)
                dataGridView1.Columns["reserveTime"].HeaderText = "预约到店时间";
            if (dataGridView1.Columns["tryDress"] != null)
                dataGridView1.Columns["tryDress"].HeaderText = "是否试装";
            if (dataGridView1.Columns["memo"] != null)
                dataGridView1.Columns["memo"].HeaderText = "客户备注";
            if (dataGridView1.Columns["scsj_jsg"] != null)
                dataGridView1.Columns["scsj_jsg"].HeaderText = "净身高";
            if (dataGridView1.Columns["scsj_cxsg"] != null)
                dataGridView1.Columns["scsj_cxsg"].HeaderText = "穿鞋身高";
            if (dataGridView1.Columns["scsj_tz"] != null)
                dataGridView1.Columns["scsj_tz"].HeaderText = "体重";
            if (dataGridView1.Columns["scsj_xw"] != null)
                dataGridView1.Columns["scsj_xw"].HeaderText = "胸围";
            if (dataGridView1.Columns["scsj_xxw"] != null)
                dataGridView1.Columns["scsj_xxw"].HeaderText = "下胸围";
            if (dataGridView1.Columns["scsj_yw"] != null)
                dataGridView1.Columns["scsj_yw"].HeaderText = "腰围";
            if (dataGridView1.Columns["scsj_dqw"] != null)
                dataGridView1.Columns["scsj_dqw"].HeaderText = "肚脐围";
            if (dataGridView1.Columns["scsj_tw"] != null)
                dataGridView1.Columns["scsj_tw"].HeaderText = "臀围";
            if (dataGridView1.Columns["scsj_jk"] != null)
                dataGridView1.Columns["scsj_jk"].HeaderText = "肩宽";
            if (dataGridView1.Columns["scsj_jw"] != null)
                dataGridView1.Columns["scsj_jw"].HeaderText = "颈围";
            if (dataGridView1.Columns["scsj_dbw"] != null)
                dataGridView1.Columns["scsj_dbw"].HeaderText = "大臂围";
            if (dataGridView1.Columns["scsj_yddc"] != null)
                dataGridView1.Columns["scsj_yddc"].HeaderText = "腰到底长";
            if (dataGridView1.Columns["scsj_qyj"] != null)
                dataGridView1.Columns["scsj_qyj"].HeaderText = "前腰结";
            if (dataGridView1.Columns["scsj_bpjl"] != null)
                dataGridView1.Columns["scsj_bpjl"].HeaderText = "BP距离";
            if (dataGridView1.Columns["status"] != null)
                dataGridView1.Columns["status"].HeaderText = "客户状态";
            if (dataGridView1.Columns["reservetimes"] != null)
                dataGridView1.Columns["reservetimes"].HeaderText = "预约到店次数";
            if (dataGridView1.Columns["reason"] != null)
                dataGridView1.Columns["reason"].HeaderText = "客户原因";
            if (dataGridView1.Columns["hisreason"] != null)
                dataGridView1.Columns["hisreason"].HeaderText = "客户历史原因";
            if (dataGridView1.Columns["city"] != null)
                dataGridView1.Columns["city"].HeaderText = "预约城市";

            if (dataGridView1.Columns["city"] != null)
                dataGridView1.Columns["city"].HeaderText = "预约城市";

            if (dataGridView1.Columns["wangwangID"] != null)
                dataGridView1.Columns["wangwangID"].HeaderText = "客户旺旺";

            if (dataGridView1.Columns["operatorName"] != null)
                dataGridView1.Columns["operatorName"].HeaderText = "录入客服";

            if (dataGridView1.Columns["jdgw"] != null)
                dataGridView1.Columns["jdgw"].HeaderText = "接待顾问";

            if (dataGridView1.Columns["groomName"] != null)
                dataGridView1.Columns["groomName"].HeaderText = "新郎姓名";

            if (dataGridView1.Columns["groomContact"] != null)
                dataGridView1.Columns["groomContact"].HeaderText = "新郎联系方式";

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            /* try
             { 
                 DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                 //customerID,brideName,brideContact,memo,infoChannel,city,wangwangID,operatorName

                 Customers ct = new Customers();
                 ct.customerID = row.Cells["customerID"].Value.ToString();
                 ct.brideName = row.Cells["brideName"].Value.ToString();
                 ct.brideContact = row.Cells["brideContact"].Value.ToString();
                 ct.memo = row.Cells["memo"].Value.ToString();
                 ct.infoChannel = row.Cells["infoChannel"].Value.ToString();
                 ct.city= row.Cells["city"].Value.ToString();
                 ct.wangwangID = row.Cells["wangwangID"].Value.ToString();
                 ct.operatorName = row.Cells["operatorName"].Value.ToString();

                 // CMCustomerInfo
                 Form bt = new CMServiceRecordUpdate(ct);
                 bt.ShowDialog();
         }
             catch
             { }*/


            if (!disableDoubleClient) //查询客户详情
            {
                try
                {
                    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                    Customers cm = new Customers();

                    cm.customerID = row.Cells["customerID"].Value.ToString();
                    cm.brideName = row.Cells["brideName"].Value.ToString();
                    cm.brideContact = row.Cells["brideContact"].Value.ToString();
                    cm.groomName = row.Cells["groomName"].Value.ToString();
                    cm.groomContact = row.Cells["groomContact"].Value.ToString();
                    cm.marryDay = row.Cells["marryDay"].Value.ToString();
                    cm.infoChannel = row.Cells["infoChannel"].Value.ToString();
                    cm.city = row.Cells["city"].Value.ToString();
                    cm.reserveDate = row.Cells["reserveDate"].Value.ToString();
                    cm.reserveTime = row.Cells["reserveTime"].Value.ToString();
                    cm.tryDress = row.Cells["tryDress"].Value.ToString();
                    cm.memo = row.Cells["memo"].Value.ToString();
                    cm.reason = row.Cells["hisreason"].Value.ToString();
                    cm.scsj_jsg = row.Cells["scsj_jsg"].Value.ToString().Trim();
                    cm.scsj_cxsg = row.Cells["scsj_cxsg"].Value.ToString().Trim();
                    cm.scsj_tz = row.Cells["scsj_tz"].Value.ToString().Trim();
                    cm.scsj_xw = row.Cells["scsj_xw"].Value.ToString().Trim();
                    cm.scsj_xxw = row.Cells["scsj_xxw"].Value.ToString().Trim();
                    cm.scsj_yw = row.Cells["scsj_yw"].Value.ToString().Trim();
                    cm.scsj_dqw = row.Cells["scsj_dqw"].Value.ToString().Trim();
                    cm.scsj_tw = row.Cells["scsj_tw"].Value.ToString().Trim();
                    cm.scsj_jk = row.Cells["scsj_jk"].Value.ToString().Trim();
                    cm.scsj_jw = row.Cells["scsj_jw"].Value.ToString().Trim();
                    cm.scsj_dbw = row.Cells["scsj_dbw"].Value.ToString().Trim();
                    cm.scsj_yddc = row.Cells["scsj_yddc"].Value.ToString().Trim();
                    cm.scsj_qyj = row.Cells["scsj_qyj"].Value.ToString().Trim();
                    cm.scsj_bpjl = row.Cells["scsj_bpjl"].Value.ToString().Trim();
                    cm.wangwangID = row.Cells["wangwangID"].Value.ToString().Trim();
                    cm.jdgw = row.Cells["jdgw"].Value.ToString();
                    cm.address = row.Cells["address"].Value.ToString();

                    Form bt = new CMCustomerInfo(cm);
                    bt.ShowDialog();

                    button1_Click(sender, e);//更新完信息后自动刷新客户列表
                }
                catch (Exception ef)
                {
                    MessageBox.Show(ef.ToString());
                }
            }
            else //选定客户
            {
                //button5_Click(sender, e);//select custormer id
            }

        }

        private void dataGridView1_CellMouseDoubleClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {

            
        }

        //租赁取纱
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];

                string customerID = Convert.ToString(selectedRow.Cells["customerID"].Value);
                string customerName = Convert.ToString(selectedRow.Cells["brideName"].Value);


                Form nc = new OMOrderStatus(customerName, customerID, "门店已提交订单","客户已取纱");
                nc.ShowDialog();



            }
        }

       //购买取纱
        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];

                string customerID = Convert.ToString(selectedRow.Cells["customerID"].Value);
                string customerName = Convert.ToString(selectedRow.Cells["brideName"].Value);



                Form nc = new OMOrderStatus(customerName, customerID, "工厂已发货","客户已取纱");
                nc.ShowDialog();



            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
