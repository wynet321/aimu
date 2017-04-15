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
    public partial class CMQueryCustormer : Form
    {
        Boolean disableDoubleClient = false;
        public CMQueryCustormer()
        {
            InitializeComponent();
        }

        public CMQueryCustormer(Boolean ddc)
        {
            InitializeComponent();
            disableDoubleClient = ddc;
            // button1_Click(new object(), new EventArgs());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String filter = "";
            String brideName = textBrideName.Text.Trim();
            String brideContact = textBrideContact.Text.Trim();
            String reserveDate = dtDate.Value.ToString("yyyy-MM-dd");
            String status = comboBoxStatus.Text.Trim();
            string consultant = textBoxConsultant.Text.Trim();
            switch (status)
            {
                case "新客户":
                    status = "A";
                    reserveDate = "";
                    break;
                case "未预约到店":
                    status = "B";
                    break;
                case "预约成功":
                    status = "C";
                    break;
                case "客户流失":
                    status = "D";
                    reserveDate = "";
                    break;
                case "到店未成交":
                    status = "E";
                    break;
                case "交定金未定款式":
                    status = "F";
                    break;
                case "交定金已定款式":
                    status = "G";
                    break;
                case "交全款未定款式":
                    status = "H";
                    break;
                case "交全款已定款式":
                    status = "I";
                    break;
                case "服务完成":
                    status = "J";
                    break;
            }

            filter = "status='" + status + "'";
            if (reserveDate != "")
            {
                if (filter != "")
                {
                    filter += " and ";
                }
                if (status == "J")
                {
                    filter += "marryDay=\'" + reserveDate + "\' ";
                }
                else
                {
                    filter += "reserveDate=\'" + reserveDate + "\' ";
                }
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

            if (consultant != "")
            {
                if (filter != "")
                {
                    filter += " and ";
                }

                filter += "jdgw=\'" + consultant + "\' ";
            }

            if (filter != "")
            {
                filter = " where " + filter;
            }

            string field = "customerID,brideName,brideContact,status,reserveDate,reserveTime,jdgw";
            string orderBy = "order by customerID desc";
            DataTable dt = ReadData.fillDataTableForCustomersWithFilter(field, filter, orderBy);

            dataGridView1.DataSource = dt;
            changeDataGridView();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void changeDataGridView()
        {
            if (dataGridView1.Columns["customerID"] != null)
                dataGridView1.Columns["customerID"].HeaderText = "客户编号";
            if (dataGridView1.Columns["brideName"] != null)
                dataGridView1.Columns["brideName"].HeaderText = "新娘姓名";
            if (dataGridView1.Columns["brideContact"] != null)
                dataGridView1.Columns["brideContact"].HeaderText = "新娘联系方式";
            if (dataGridView1.Columns["status"] != null)
                dataGridView1.Columns["status"].HeaderText = "客户状态";
            if (dataGridView1.Columns["reserveDate"] != null)
                dataGridView1.Columns["reserveDate"].HeaderText = "预约到店日期";
            if (dataGridView1.Columns["reserveTime"] != null)
                dataGridView1.Columns["reserveTime"].HeaderText = "预约到店时间";
            if (dataGridView1.Columns["jdgw"] != null)
                dataGridView1.Columns["jdgw"].HeaderText = "接待顾问";


            //if (dataGridView1.Columns["marryDay"] != null)
            //    dataGridView1.Columns["marryDay"].HeaderText = "婚期";
            //if (dataGridView1.Columns["infoChannel"] != null)
            //    dataGridView1.Columns["infoChannel"].HeaderText = "渠道";

            //if (dataGridView1.Columns["tryDress"] != null)
            //    dataGridView1.Columns["tryDress"].HeaderText = "是否试装";
            //if (dataGridView1.Columns["memo"] != null)
            //    dataGridView1.Columns["memo"].HeaderText = "客户备注";
            //if (dataGridView1.Columns["scsj_jsg"] != null)
            //    dataGridView1.Columns["scsj_jsg"].HeaderText = "净身高";
            //if (dataGridView1.Columns["scsj_cxsg"] != null)
            //    dataGridView1.Columns["scsj_cxsg"].HeaderText = "穿鞋身高";
            //if (dataGridView1.Columns["scsj_tz"] != null)
            //    dataGridView1.Columns["scsj_tz"].HeaderText = "体重";
            //if (dataGridView1.Columns["scsj_xw"] != null)
            //    dataGridView1.Columns["scsj_xw"].HeaderText = "胸围";
            //if (dataGridView1.Columns["scsj_xxw"] != null)
            //    dataGridView1.Columns["scsj_xxw"].HeaderText = "下胸围";
            //if (dataGridView1.Columns["scsj_yw"] != null)
            //    dataGridView1.Columns["scsj_yw"].HeaderText = "腰围";
            //if (dataGridView1.Columns["scsj_dqw"] != null)
            //    dataGridView1.Columns["scsj_dqw"].HeaderText = "肚脐围";
            //if (dataGridView1.Columns["scsj_tw"] != null)
            //    dataGridView1.Columns["scsj_tw"].HeaderText = "臀围";
            //if (dataGridView1.Columns["scsj_jk"] != null)
            //    dataGridView1.Columns["scsj_jk"].HeaderText = "肩宽";
            //if (dataGridView1.Columns["scsj_jw"] != null)
            //    dataGridView1.Columns["scsj_jw"].HeaderText = "颈围";
            //if (dataGridView1.Columns["scsj_dbw"] != null)
            //    dataGridView1.Columns["scsj_dbw"].HeaderText = "大臂围";
            //if (dataGridView1.Columns["scsj_yddc"] != null)
            //    dataGridView1.Columns["scsj_yddc"].HeaderText = "腰到底长";
            //if (dataGridView1.Columns["scsj_qyj"] != null)
            //    dataGridView1.Columns["scsj_qyj"].HeaderText = "前腰结";
            //if (dataGridView1.Columns["scsj_bpjl"] != null)
            //    dataGridView1.Columns["scsj_bpjl"].HeaderText = "BP距离";

            //if (dataGridView1.Columns["reservetimes"] != null)
            //    dataGridView1.Columns["reservetimes"].HeaderText = "预约到店次数";
            //if (dataGridView1.Columns["reason"] != null)
            //    dataGridView1.Columns["reason"].HeaderText = "客户原因";
            //if (dataGridView1.Columns["hisreason"] != null)
            //    dataGridView1.Columns["hisreason"].HeaderText = "客户历史原因";
            //if (dataGridView1.Columns["city"] != null)
            //    dataGridView1.Columns["city"].HeaderText = "预约城市";

            //if (dataGridView1.Columns["city"] != null)
            //    dataGridView1.Columns["city"].HeaderText = "预约城市";

            //if (dataGridView1.Columns["wangwangID"] != null)
            //    dataGridView1.Columns["wangwangID"].HeaderText = "客户旺旺";

            //if (dataGridView1.Columns["operatorName"] != null)
            //    dataGridView1.Columns["operatorName"].HeaderText = "录入客服";



            //if (dataGridView1.Columns["groomName"] != null)
            //    dataGridView1.Columns["groomName"].HeaderText = "新郎姓名";

            //if (dataGridView1.Columns["groomContact"] != null)
            //    dataGridView1.Columns["groomContact"].HeaderText = "新郎联系方式";

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!disableDoubleClient) //查询客户详情
            {
                try
                {
                    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                    //Customers cm = new Customers();

                    //cm.customerID = row.Cells["customerID"].Value.ToString();
                    //cm.brideName = row.Cells["brideName"].Value.ToString();
                    //cm.brideContact = row.Cells["brideContact"].Value.ToString();
                    //cm.groomName = row.Cells["groomName"].Value.ToString();
                    //cm.groomContact = row.Cells["groomContact"].Value.ToString();
                    //cm.marryDay = row.Cells["marryDay"].Value.ToString();
                    //cm.infoChannel = row.Cells["infoChannel"].Value.ToString();
                    //cm.city = row.Cells["city"].Value.ToString();
                    //cm.reserveDate = row.Cells["reserveDate"].Value.ToString();
                    //cm.reserveTime = row.Cells["reserveTime"].Value.ToString();
                    //cm.tryDress = row.Cells["tryDress"].Value.ToString();
                    //cm.memo = row.Cells["memo"].Value.ToString();
                    //cm.reason = row.Cells["hisreason"].Value.ToString();
                    //cm.scsj_jsg = row.Cells["scsj_jsg"].Value.ToString().Trim();
                    //cm.scsj_cxsg = row.Cells["scsj_cxsg"].Value.ToString().Trim();
                    //cm.scsj_tz = row.Cells["scsj_tz"].Value.ToString().Trim();
                    //cm.scsj_xw = row.Cells["scsj_xw"].Value.ToString().Trim();
                    //cm.scsj_xxw = row.Cells["scsj_xxw"].Value.ToString().Trim();
                    //cm.scsj_yw = row.Cells["scsj_yw"].Value.ToString().Trim();
                    //cm.scsj_dqw = row.Cells["scsj_dqw"].Value.ToString().Trim();
                    //cm.scsj_tw = row.Cells["scsj_tw"].Value.ToString().Trim();
                    //cm.scsj_jk = row.Cells["scsj_jk"].Value.ToString().Trim();
                    //cm.scsj_jw = row.Cells["scsj_jw"].Value.ToString().Trim();
                    //cm.scsj_dbw = row.Cells["scsj_dbw"].Value.ToString().Trim();
                    //cm.scsj_yddc = row.Cells["scsj_yddc"].Value.ToString().Trim();
                    //cm.scsj_qyj = row.Cells["scsj_qyj"].Value.ToString().Trim();
                    //cm.scsj_bpjl = row.Cells["scsj_bpjl"].Value.ToString().Trim();
                    //cm.wangwangID = row.Cells["wangwangID"].Value.ToString().Trim();
                    //cm.jdgw = row.Cells["jdgw"].Value.ToString();
                    //cm.address = row.Cells["address"].Value.ToString();
                    //cm.status = row.Cells["status"].Value.ToString();
                    //cm.reservetimes = row.Cells["reservetimes"].Value.ToString();

                    Form bt = new CMCustomerInfo(row.Cells["customerID"].Value.ToString());
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

        private void comboBoxStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxStatus.Text.Trim())
            {
                case "新客户":
                    dtDate.Enabled = false;
                    labelDate.Text = "日期";
                    labelDate.Enabled = false;
                    break;
                case "未预约到店":
                    dtDate.Enabled = true;
                    labelDate.Text = "下次致电日期";
                    labelDate.Enabled = true;
                    break;
                case "预约成功":
                    dtDate.Enabled = true;
                    labelDate.Text = "预约到店日期";
                    labelDate.Enabled = true;
                    break;
                case "客户流失":
                    dtDate.Enabled = false;
                    labelDate.Text = "日期";
                    labelDate.Enabled = false;
                    break;
                case "到店未成交":
                    dtDate.Enabled = true;
                    labelDate.Text = "下次致电日期";
                    labelDate.Enabled = true;
                    break;
                case "交定金未定款式":
                    dtDate.Enabled = true;
                    labelDate.Text = "到店日期";
                    labelDate.Enabled = true;
                    break;
                case "交定金已定款式":
                    dtDate.Enabled = true;
                    labelDate.Text = "到店日期";
                    labelDate.Enabled = true;
                    break;
                case "交全款未定款式":
                    dtDate.Enabled = true;
                    labelDate.Text = "到店日期";
                    labelDate.Enabled = true;
                    break;
                case "交全款已定款式":
                    dtDate.Enabled = true;
                    labelDate.Text = "取纱日期";
                    labelDate.Enabled = true;
                    break;
                case "服务完成":
                    dtDate.Enabled = true;
                    labelDate.Text = "婚期";
                    labelDate.Enabled = true;
                    break;
            }
        }

        private void CMQueryCustormer_Load(object sender, EventArgs e)
        {
            comboBoxStatus.SelectedIndex = 0;
        }
    }
}
