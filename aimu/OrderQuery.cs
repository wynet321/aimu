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
            //if (dataGridView1.Columns["customerID"] != null)
            //    dataGridView1.Columns["customerID"].HeaderText = "客户编号";
           
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
                    DataGridViewRow row = this.dataGridViewOrders.Rows[e.RowIndex];
                    Form bt = new OrderProcess(row.Cells["orderId"].Value.ToString());
                    bt.ShowDialog();
                    comboBoxStatus_SelectedIndexChanged(sender, e);//更新完信息后自动刷新客户列表
        }

        private void OrderQuery_Load(object sender, EventArgs e)
        {
            comboBoxStatus.DataSource = ReadData.getOrderStatus(Sharevariables.getUserLevel()).DefaultView;
            comboBoxStatus.DisplayMember = "name";
            comboBoxStatus.SelectedIndex = 0;
            //checkBoxDate.Enabled = true;
            //checkBoxDate.Checked = false;
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
            if (checkBoxDate.Enabled)
            {
                dtDate.Value = DateTime.Today;
            }
        }

        private void buttonOrderProcess_Click(object sender, EventArgs e)
        {
            Form orderProcess = new OrderProcess();
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
            DataTable dt = ReadData.getOrderByStatus(((DataView)comboBoxStatus.DataSource).Table.Rows[comboBoxStatus.SelectedIndex].ItemArray[0].ToString());
            dataGridViewOrders.DataSource = dt;
            changeDataGridView();
        }

        
    }
}
