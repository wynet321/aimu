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
    public partial class Statistic : Form
    {
        public Statistic()
        {
            InitializeComponent();
        }

        private void changeDataGridView()
        {
            if (dataGridViewCustomers.Columns["orderId"] != null)
                dataGridViewCustomers.Columns["orderId"].HeaderText = "订单编号";
            if (dataGridViewCustomers.Columns["memo"] != null)
                dataGridViewCustomers.Columns["memo"].HeaderText = "备注";
            if (dataGridViewCustomers.Columns["bridename"] != null)
                dataGridViewCustomers.Columns["bridename"].HeaderText = "姓名";
            if (dataGridViewCustomers.Columns["bridecontact"] != null)
                dataGridViewCustomers.Columns["bridecontact"].HeaderText = "联系方式";
        }

        private void dataGridViewCustomers_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = this.dataGridViewCustomers.Rows[e.RowIndex];
            Form bt = new OrderStandard(row.Cells["orderId"].Value.ToString());
            bt.ShowDialog();
        }

        private void Statistic_Load(object sender, EventArgs e)
        {
            //comboBoxChannel.DataSource = ReadData.getOrderStatus(Sharevariables.getUserLevel()).DefaultView;
            //comboBoxChannel.DisplayMember = "name";
            //comboBoxChannel.SelectedIndex = 0;
        }
        
        private void comboBoxChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = ReadData.getOrderByStatus(int.Parse(((DataView)comboBoxChannel.DataSource).Table.Rows[comboBoxChannel.SelectedIndex].ItemArray[0].ToString()));
            dataGridViewCustomers.DataSource = dt;
            changeDataGridView();
        }


    }
}
