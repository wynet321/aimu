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
    public partial class OMChargebackWeddingDress : Form
    {


        Boolean disableDoubleClient = false;
        public OMChargebackWeddingDress()
        {
            InitializeComponent();
        }


        public OMChargebackWeddingDress(Boolean ddc)
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];

                string customerID = Convert.ToString(selectedRow.Cells["customerID"].Value);
                string customerName = Convert.ToString(selectedRow.Cells["brideName"].Value);

                Form nc = new OMChargebackWeddingDressDialog(customerName, customerID);
                nc.ShowDialog();
            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];

                string customerID = Convert.ToString(selectedRow.Cells["customerID"].Value);
                string customerName = Convert.ToString(selectedRow.Cells["brideName"].Value);

                Form nc = new OMChargebackWeddingDressDialog(customerName, customerID);
                nc.ShowDialog();
            }
        }
    }
}
