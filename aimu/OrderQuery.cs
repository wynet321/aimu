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
    public partial class OrderQuery : Form
    {
        public OrderQuery()
        {
            InitializeComponent();
        }

        private void changeDataGridView()
        {
            if (dataGridViewOrders.Columns["id"] != null)
                dataGridViewOrders.Columns["id"].HeaderText = "订单编号";
            if (dataGridViewOrders.Columns["orderamountafter"] != null)
                dataGridViewOrders.Columns["orderamountafter"].HeaderText = "已付金额";
            if (dataGridViewOrders.Columns["totalamount"] != null)
                dataGridViewOrders.Columns["totalamount"].HeaderText = "金额";
            if (dataGridViewOrders.Columns["depositamount"] != null)
                dataGridViewOrders.Columns["depositamount"].HeaderText = "租赁金额";
            if (dataGridViewOrders.Columns["deliverytype"] != null)
                dataGridViewOrders.Columns["deliverytype"].HeaderText = "发货方式";
            if (dataGridViewOrders.Columns["getdate"] != null)
                dataGridViewOrders.Columns["getdate"].HeaderText = "租赁日期";
            if (dataGridViewOrders.Columns["returndate"] != null)
                dataGridViewOrders.Columns["returndate"].HeaderText = "归还日期";
            if (dataGridViewOrders.Columns["address"] != null)
                dataGridViewOrders.Columns["address"].HeaderText = "地址";
            if (dataGridViewOrders.Columns["memo"] != null)
                dataGridViewOrders.Columns["memo"].HeaderText = "备注";
            if (dataGridViewOrders.Columns["bridename"] != null)
                dataGridViewOrders.Columns["bridename"].HeaderText = "姓名";
            if (dataGridViewOrders.Columns["bridecontact"] != null)
                dataGridViewOrders.Columns["bridecontact"].HeaderText = "联系方式";
        }

        private void dataGridViewOrders_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = this.dataGridViewOrders.Rows[e.RowIndex];
            Form bt = new OrderStandard(row.Cells["id"].Value.ToString());
            bt.ShowDialog();
            if (comboBoxStatus.Visible)
            {
                comboBoxStatus_SelectedIndexChanged(sender, e);//更新完信息后自动刷新客户列表
            }
            else
            {
                loadOrders();
            }
        }

        private void OrderQuery_Load(object sender, EventArgs e)
        {
            if (Sharevariables.EnableWorkFlow)
            {
                Data statuses = DataOperation.getOrderStatus(Sharevariables.UserLevel);
                if (!statuses.Success)
                {
                    this.Close();
                    return;
                }
                comboBoxStatus.DisplayMember = "name";
                comboBoxStatus.ValueMember = "id";
                comboBoxStatus.DataSource = statuses.DataTable;
                comboBoxStatus.SelectedIndex = 0;
            }
            else
            {
                labelStatus.Visible = false;
                comboBoxStatus.Visible = false;
                loadOrders();
            }
        }

        private void loadOrders()
        {
            Data orders = DataOperation.getOrders();
            if (!orders.Success)
            {
                this.Close();
                return;
            }
            dataGridViewOrders.DataSource = orders.DataTable;
            changeDataGridView();
        }
        private void dtDate_VisibleChanged(object sender, EventArgs e)
        {
            if (checkBoxDate.Enabled)
            {
                dtDate.Value = DateTime.Today;
            }
        }

        private void buttonInsertOrder_Click(object sender, EventArgs e)
        {
            Form orderProcess = new OrderStandard();
            orderProcess.ShowDialog();
            comboBoxStatus_SelectedIndexChanged(sender, e);
        }

        private void checkBoxDate_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDate.Checked)
            {
                dtDate.Visible = true;
            }
            else
            {
                dtDate.Visible = false;
            }
        }

        private void comboBoxStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            Data orders = DataOperation.getOrderByStatus(Convert.ToInt16(comboBoxStatus.SelectedValue));
            if (!orders.Success)
            {
                this.Close();
                return;
            }
            dataGridViewOrders.DataSource = orders.DataTable; 
            changeDataGridView();
        }


    }
}
