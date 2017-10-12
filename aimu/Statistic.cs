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
            //if (dataGridViewCustomers.Columns["marryDay"] != null)
            dataGridViewCustomers.Columns["marryDay"].HeaderText = "婚期";
            //if (dataGridViewCustomers.Columns["brideName"] != null)
            dataGridViewCustomers.Columns["brideName"].HeaderText = "姓名";
            //if (dataGridViewCustomers.Columns["brideContact"] != null)
            dataGridViewCustomers.Columns["brideContact"].HeaderText = "联系方式";
            dataGridViewCustomers.Columns["jdgw"].HeaderText = "礼服师";
            dataGridViewCustomers.Columns["createdDate"].HeaderText = "订单日期";
            dataGridViewCustomers.Columns["totalAmount"].HeaderText = "应收金额";
            dataGridViewCustomers.Columns["orderAmountafter"].HeaderText = "实收金额";
            dataGridViewCustomers.Columns["orderType"].HeaderText = "订单类型";
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
                textBoxPartnerName.Text = "";
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            refreshDataGridViewCustomers();
        }

        private void refreshDataGridViewCustomers()
        {
            dataGridViewCustomers.DataSource = ReadData.getStatistic(dateTimePickerStartDate.Value.ToShortDateString(), dateTimePickerEndDate.Value.ToShortDateString(), textBoxConsultant.Text.Trim(), Convert.ToInt16(((DataRowView)comboBoxChannel.SelectedItem).Row["id"]), textBoxPartnerName.Text.Trim());
            dataGridViewCustomers.Columns["orderId"].Visible = false;
            dataGridViewCustomers.Columns["channelId"].Visible = false;
            changeDataGridView();
            if (dataGridViewCustomers.RowCount > 0)
            {
                textBoxAccountReceivable.Text = Decimal.Parse(((DataTable)dataGridViewCustomers.DataSource).Compute("Sum(totalAmount)", "True").ToString()).ToString("0.00");
                textBoxPaid.Text = Decimal.Parse(((DataTable)dataGridViewCustomers.DataSource).Compute("Sum(orderAmountafter)", "True").ToString()).ToString("0.00");
            }
        }
    }
}
