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
    public partial class CMCurrentCustomerBookList : Form
    {
        Boolean disableDoubleClient = false;

        public CMCurrentCustomerBookList()
        {
            InitializeComponent();
            button1_Click(new object(),new EventArgs());
        }

        public CMCurrentCustomerBookList(Boolean ddc)
        {
            InitializeComponent();
            disableDoubleClient = ddc;
            button1_Click(new object(), new EventArgs());
        }

        private void button1_Click(object sender, EventArgs e)
        {

            String filter = "";

            String customerID = textCustomerID.Text.Trim();
            String brideName = textBrideName.Text.Trim();
            String brideContact = textBrideContact.Text.Trim();
            String reserveDate = dtReserveDate.Value.ToString("yyyy-MM-dd");
            //DateTime.Now.Date.ToString("yyyy-MM-dd")

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

            if (reserveDate != "")
            {
                 filter += "reserveDate=\'" + reserveDate + "\' ";
            }




            if (filter != "")
            {
                filter = " where " + filter;
            }


            DataTable dt = ReadData.fillDataTableWithFilter("customers", filter);
           

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
            if (dataGridView1.Columns["hisreason"] != null)
                dataGridView1.Columns["hisreason"].HeaderText = "客户原因";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!disableDoubleClient)
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
                }
                catch (Exception ef)
                {
                    MessageBox.Show(ef.ToString());
                }
            }
            else
            {
                button5_Click(sender, e);//select custormer id
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {

                DialogResult dialogResult = MessageBox.Show("客户编号：" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "，姓名：" + dataGridView1.CurrentRow.Cells[1].Value.ToString() + ",确定要选中该客户吗？", "退出", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Sharevariables.setCustomerID(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    Sharevariables.setCustomerName(dataGridView1.CurrentRow.Cells[1].Value.ToString());
                    this.Close();
                }

            }
            catch (Exception ef)
            {
                MessageBox.Show(ef.ToString());
            }
            
        }
    }
}
