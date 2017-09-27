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
            dateTimePickerStartDate.Value = DateTime.Today;
            dateTimePickerEndDate.Value = DateTime.Today;
            comboBoxChannel.DataSource = ReadData.getCustomerChannels();
            comboBoxChannel.DisplayMember = "name";
            comboBoxChannel.ValueMember = "id";
        }
        
        private void comboBoxChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((DataRowView)comboBoxChannel.SelectedItem).Row["name"].ToString().Equals("异业合作"))
            {
                label3.Visible = true;
                textBoxPartnerName.Visible = true;
            }
            else
            {
                label3.Visible = false;
                textBoxPartnerName.Visible = false;
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            dataGridViewCustomers.DataSource = ReadData.getStatistic(dateTimePickerStartDate.Value.ToShortDateString(), dateTimePickerEndDate.Value.ToShortDateString(), textBoxConsultant.Text.Trim(), Convert.ToInt16(((DataRowView)comboBoxChannel.SelectedItem).Row["id"]), textBoxPartnerName.Text.Trim());
        }
    }
}
