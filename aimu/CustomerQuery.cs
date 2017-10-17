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
    public partial class CustomerQuery : Form
    {
        //Boolean disableDoubleClient = false;
        public CustomerQuery()
        {
            InitializeComponent();
        }

        //public CustomerQuery(Boolean ddc)
        //{
        //    InitializeComponent();
        //    disableDoubleClient = ddc;
        //}

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            String filter = "";
            String brideName = textBrideName.Text.Trim();
            String brideContact = textBrideContact.Text.Trim();

            int status = comboBoxStatus.SelectedIndex;
            String consultant = textBoxConsultant.Text.Trim();
            String operatorName = textBoxOperator.Text.Trim();
            string field = "customerID,brideName,brideContact,customerStatus.name,jdgw,reserveDate,reserveTime,marryDay,infoChannel,wangwangId,operatorName";
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
            //switch (status)
            //{
            //    case "新客户":
            //        status = "A";
            //        //field= "customerID,brideName,brideContact,status";
            //        break;
            //    case "未预约到店":
            //        status = "B";
            //       // field = "customerID,brideName,brideContact,status,reserveDate,jdgw";
            //        break;
            //    case "预约成功":
            //        status = "C";
            //       // field = "customerID,brideName,brideContact,status,reserveDate,reserveTime";
            //        break;
            //    case "客户流失":
            //        status = "D";
            //       // field = "customerID,brideName,brideContact,status,jdgw";
            //        break;
            //    case "到店未成交":
            //        status = "E";
            //        //field = "customerID,brideName,brideContact,status,reserveDate,jdgw";
            //        break;
            //    case "交定金未定款式":
            //        status = "F";
            //       // field = "customerID,brideName,brideContact,status,reserveDate,reserveTime,jdgw";
            //        break;
            //    case "交全款未定款式":
            //        status = "G";
            //      //  field = "customerID,brideName,brideContact,status,reserveDate,reserveTime,jdgw";
            //        break;
            //    case "交定金已定款式":
            //        status = "H";
            //        //field = "customerID,brideName,brideContact,status,reserveDate,reserveTime,jdgw";
            //        break;
            //    case "交全款已定款式":
            //        status = "I";
            //        //field = "customerID,brideName,brideContact,status,reserveDate,reserveTime,jdgw";
            //        break;
            //    case "服务完成":
            //        status = "J";
            //        //field = "customerID,brideName,brideContact,status,marryDay,jdgw";
            //        break;
            //    case "全部":
            //        status = "";
            //        //field = "customerID,brideName,brideContact,status,marryDay,reserveDate,reserveTime,jdgw";
            //        break;
            //}
            String reserveDate = dtDate.Enabled ? dtDate.Value.ToString("yyyy-MM-dd") : "";
            if (status != 0)
            {
                filter = "status=" + status + "";
            }
            if (reserveDate.Length != 0)
            {
                filter += (filter.Length != 0) ? " and " : "";
                filter += status == 10 ? "marryDay=\'" + reserveDate + "\' " : "reserveDate=\'" + reserveDate + "\' ";
            }

            if (brideName.Length != 0)
            {
                filter += (filter.Length != 0) ? " and " : "";
                filter += "brideName=\'" + brideName + "\' ";
            }

            if (brideContact.Length != 0)
            {
                filter += (filter.Length != 0) ? " and " : "";
                filter += "brideContact=\'" + brideContact + "\' ";
            }

            if (consultant.Length != 0)
            {
                filter += (filter.Length != 0) ? " and " : "";
                filter += "jdgw=\'" + consultant + "\' ";
            }

            if (operatorName.Length != 0)
            {
                filter += (filter.Length != 0) ? " and " : "";
                filter += "operatorName=\'" + operatorName + "\' ";
            }

            filter = (filter.Length != 0) ? " where " + filter : "";


            string orderBy = "order by createDate desc";
            DataTable dt = ReadData.fillDataTableForCustomersWithFilter(field, filter, orderBy);

            dataGridViewCustomers.DataSource = dt;
            changeDataGridView();
        }

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    this.Close();
        //}


        private void changeDataGridView()
        {
            if (dataGridViewCustomers.Columns["customerID"] != null)
                dataGridViewCustomers.Columns["customerID"].HeaderText = "客户编号";
            dataGridViewCustomers.Columns["customerID"].Visible = false;
            if (dataGridViewCustomers.Columns["brideName"] != null)
                dataGridViewCustomers.Columns["brideName"].HeaderText = "姓名";
            if (dataGridViewCustomers.Columns["brideContact"] != null)
                dataGridViewCustomers.Columns["brideContact"].HeaderText = "电话";
            if (dataGridViewCustomers.Columns["name"] != null)
                dataGridViewCustomers.Columns["name"].HeaderText = "状态";
            if (dataGridViewCustomers.Columns["reserveDate"] != null)
                dataGridViewCustomers.Columns["reserveDate"].HeaderText = "预约到店日期";
            if (dataGridViewCustomers.Columns["reserveTime"] != null)
                dataGridViewCustomers.Columns["reserveTime"].HeaderText = "预约到店时间";
            if (dataGridViewCustomers.Columns["jdgw"] != null)
                dataGridViewCustomers.Columns["jdgw"].HeaderText = "礼服师";
            if (dataGridViewCustomers.Columns["marryDay"] != null)
                dataGridViewCustomers.Columns["marryDay"].HeaderText = "婚期";
            if (dataGridViewCustomers.Columns["infoChannel"] != null)
                dataGridViewCustomers.Columns["infoChannel"].HeaderText = "来源";

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

            if (dataGridViewCustomers.Columns["wangwangID"] != null)
                dataGridViewCustomers.Columns["wangwangID"].HeaderText = "旺旺ID";

            if (dataGridViewCustomers.Columns["operatorName"] != null)
                dataGridViewCustomers.Columns["operatorName"].HeaderText = "客服";



            //if (dataGridView1.Columns["groomName"] != null)
            //    dataGridView1.Columns["groomName"].HeaderText = "新郎姓名";

            //if (dataGridView1.Columns["groomContact"] != null)
            //    dataGridView1.Columns["groomContact"].HeaderText = "新郎联系方式";

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (!disableDoubleClient) //查询客户详情
            //{
            try
            {
                DataGridViewRow row = this.dataGridViewCustomers.Rows[e.RowIndex];
                Form bt = new CustomerProperties(row.Cells["customerID"].Value.ToString());
                bt.ShowDialog();
                buttonSearch_Click(sender, e);//更新完信息后自动刷新客户列表
            }
            catch (Exception ef)
            {
                MessageBox.Show(ef.ToString());
            }
            //}
            //else //选定客户
            //{
            //    button5_Click(sender, e);//select custormer id
            //}

        }


        //private void button5_Click(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        DialogResult dialogResult = MessageBox.Show("客户编号：" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "，姓名：" + dataGridView1.CurrentRow.Cells[1].Value.ToString() + ",确定要选中该客户吗？", "退出", MessageBoxButtons.YesNo);
        //        if (dialogResult == DialogResult.Yes)
        //        {
        //            Sharevariables.setCustomerID(dataGridView1.CurrentRow.Cells[0].Value.ToString());
        //            Sharevariables.setCustomerName(dataGridView1.CurrentRow.Cells[1].Value.ToString());
        //            this.Close();
        //        }

        //    }
        //    catch (Exception ef)
        //    {
        //        MessageBox.Show(ef.ToString());
        //    }

        //}

        private void comboBoxStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            //checkBoxDate.Visible = true;
            //checkBoxDate.Enabled = false;
            //checkBoxDate.Checked = true;
            switch (comboBoxStatus.SelectedIndex)
            {
                case 1:
                    //dtDate.Enabled = false;
                    //labelDate.Text = "日期";
                    //labelDate.Visible = false;
                    checkBoxDate.Enabled = false;
                    checkBoxDate.Checked = false;
                    break;
                case 2:
                    //dtDate.Enabled = true;
                    //labelDate.Text = "下次致电日期";
                    //labelDate.Visible = true;
                    checkBoxDate.Enabled = true;
                    checkBoxDate.Checked = false;
                    break;
                case 3:
                    //labelDate.Text = "预约到店日期";
                    //labelDate.Visible = true;
                    checkBoxDate.Enabled = true;
                    checkBoxDate.Checked = false;
                    break;
                case 4:
                    //labelDate.Text = "日期";
                    //labelDate.Visible = false;
                    checkBoxDate.Enabled = false;
                    checkBoxDate.Checked = false;
                    break;
                case 5:
                    // dtDate.Enabled = true;
                    //labelDate.Text = "下次致电日期";
                    //labelDate.Visible = true;
                    checkBoxDate.Enabled = true;
                    checkBoxDate.Checked = false;
                    break;
                case 6:
                    //dtDate.Enabled = true;
                    //labelDate.Text = "到店日期";
                    //labelDate.Visible = true;
                    checkBoxDate.Enabled = true;
                    checkBoxDate.Checked = false;
                    break;
                case 7:
                    //dtDate.Enabled = true;
                    //labelDate.Text = "到店日期";
                    //labelDate.Visible = true;
                    checkBoxDate.Enabled = true;
                    checkBoxDate.Checked = false;
                    break;
                case 8:
                    //dtDate.Enabled = true;
                    //labelDate.Text = "到店日期";
                    //labelDate.Visible = true;
                    checkBoxDate.Enabled = true;
                    checkBoxDate.Checked = false;
                    break;
                case 9:
                    // dtDate.Enabled = true;
                    //labelDate.Text = "取纱日期";
                    //labelDate.Visible = true;
                    checkBoxDate.Enabled = true;
                    checkBoxDate.Checked = false;
                    break;
                case 10:
                    //dtDate.Enabled = true;
                    //labelDate.Text = "婚期";
                    //labelDate.Visible = true;
                    checkBoxDate.Enabled = true;
                    checkBoxDate.Checked = false;
                    break;
                case 0:
                    //dtDate.Enabled = false;
                    //labelDate.Visible = false;
                    checkBoxDate.Enabled = true;
                    checkBoxDate.Checked = false;
                    break;
                case 11:
                    checkBoxDate.Enabled = true;
                    checkBoxDate.Checked = false;
                    break;
            }
        }

        private void CMQueryCustormer_Load(object sender, EventArgs e)
        {
            DataTable customerStatus = ReadData.getCustomerStatus();
            DataRow newRow = customerStatus.NewRow();
            newRow["id"] = 0;
            newRow["name"] = "全部";
            customerStatus.Rows.InsertAt(newRow, 0);
            comboBoxStatus.DataSource = customerStatus;
            comboBoxStatus.DisplayMember = "name";
            comboBoxStatus.ValueMember = "id";
            comboBoxStatus.SelectedIndex = 0;
            checkBoxDate.Enabled = true;
            checkBoxDate.Checked = false;
            buttonSearch_Click(sender, e);
        }

        //private void checkBoxDate_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (checkBoxDate.Checked)
        //    {
        //        dtDate.Enabled = true;
        //        //labelDate.Visible = true;
        //    }
        //    else
        //    {
        //        dtDate.Enabled = false;
        //        //labelDate.Visible = false;
        //    }
        //}

        private void dtDate_VisibleChanged(object sender, EventArgs e)
        {
            if (dtDate.Enabled)
            {
                dtDate.Value = DateTime.Today;
            }
        }

        private void buttonInsertCustomer_Click(object sender, EventArgs e)
        {

            Form CustomerInsertion = new CustomerAdd();
            CustomerInsertion.ShowDialog();
            buttonSearch_Click(sender, e);
        }

        private void checkBoxDate_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDate.Checked)
            {
                dtDate.Enabled = true;
            }
            else
            {
                dtDate.Enabled = false;
            }
        }
    }
}
