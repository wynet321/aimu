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
    public partial class CMCurrentBTypeCustomer : Form
    {
        public CMCurrentBTypeCustomer()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form nc = new CMBTypeCustomerInfo();
            nc.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //TruncateTable 清空当日B类客户列表

            TruncateTable.truncate("trackingBTypeCustomers");

            //计算当日B类客户列表

            SaveData.InsertCurrentBTypeCustomerList();


            //////

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


            //DataTable dt = ReadData.fillDataTableWithFilter("trackingcustomers", filter);
            //DataTable dt = ReadData.fillDataTableForCustomersWithFilter(filter);
            DataTable dt = ReadData.fillDataTableForTrackingCustomers();

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
                dataGridView1.Columns["brideContact"].HeaderText = "联系方式";
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


        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show("asdf");
        }



        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                Customers ct = new Customers();
                ct.customerID = row.Cells["customerID"].Value.ToString();
                ct.brideName = row.Cells["brideName"].Value.ToString();
                ct.brideContact = row.Cells["brideContact"].Value.ToString();
                ct.marryDay = row.Cells["marryDay"].Value.ToString();
                ct.infoChannel = row.Cells["infoChannel"].Value.ToString();
                ct.reserveDate = row.Cells["reserveDate"].Value.ToString();
                ct.reserveTime = row.Cells["reserveTime"].Value.ToString();
                ct.tryDress = row.Cells["tryDress"].Value.ToString();
                ct.hisreason = row.Cells["hisreason"].Value.ToString();
                ct.memo = row.Cells["memo"].Value.ToString();


                //Form bt = new CMCustomerInfo(ct);
                //bt.ShowDialog();
            }
            catch(Exception ef)
            {
                MessageBox.Show(ef.ToString());
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
