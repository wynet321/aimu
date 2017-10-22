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
            //if (Sharevariables.DefaultStoreId == 0)
            //{
            //    filter = (filter.Length != 0) ? " where " + filter : "";
            //}
            //else
            //{
                filter = (filter.Length != 0) ? " where storeId=" + Sharevariables.StoreId + " and " + filter : " where storeId=" + Sharevariables.StoreId;
            //}

            string orderBy = "order by createDate desc";
            Data stores = ReadData.getCustomers(field, filter, orderBy);
            if (!stores.Success)
            {
                this.Close();
                return;
            }
            dataGridViewCustomers.DataSource = stores.DataTable;
            changeDataGridViewTitle();
            dataGridViewCustomers.Columns["customerID"].Visible = false;
        }

        private void changeDataGridViewTitle()
        {
            
                dataGridViewCustomers.Columns["customerID"].HeaderText = "客户编号";
            
            
                dataGridViewCustomers.Columns["brideName"].HeaderText = "姓名";
            
                dataGridViewCustomers.Columns["brideContact"].HeaderText = "电话";
            
                dataGridViewCustomers.Columns["name"].HeaderText = "状态";
            
                dataGridViewCustomers.Columns["reserveDate"].HeaderText = "预约到店日期";
            
                dataGridViewCustomers.Columns["reserveTime"].HeaderText = "预约到店时间";
            
                dataGridViewCustomers.Columns["jdgw"].HeaderText = "礼服师";
            
                dataGridViewCustomers.Columns["marryDay"].HeaderText = "婚期";
            
                dataGridViewCustomers.Columns["infoChannel"].HeaderText = "来源";

            
                dataGridViewCustomers.Columns["wangwangID"].HeaderText = "旺旺ID";

            
                dataGridViewCustomers.Columns["operatorName"].HeaderText = "客服";


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
            Data status = ReadData.getCustomerStatus();
            if (!status.Success)
            {
                this.Close();
                return;
            }
            DataTable customerStatus = status.DataTable;
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
                dtDate.Value = DateTime.Today;
            }
            else
            {
                dtDate.Enabled = false;
            }
        }
    }
}
