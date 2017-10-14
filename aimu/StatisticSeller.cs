﻿using System;
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
    public partial class StatisticSeller : Form
    {
        public StatisticSeller()
        {
            InitializeComponent();
        }

        private void changeDataGridViewColumnTitle()
        {
            dataGridViewCustomers.Columns["marryDay"].HeaderText = "婚期";
            dataGridViewCustomers.Columns["brideName"].HeaderText = "姓名";
            dataGridViewCustomers.Columns["brideContact"].HeaderText = "联系方式";
            dataGridViewCustomers.Columns["jdgw"].HeaderText = "礼服师";
            dataGridViewCustomers.Columns["createdDate"].HeaderText = "订单日期";
            dataGridViewCustomers.Columns["totalAmount"].HeaderText = "应收金额";
            dataGridViewCustomers.Columns["orderAmountafter"].HeaderText = "实收金额";
            dataGridViewCustomers.Columns["orderType"].HeaderText = "订单类型";
            dataGridViewCustomers.Columns["status"].HeaderText = "状态";
            dataGridViewCustomers.Columns["partnerName"].HeaderText = "合作企业";
        }

        private void dataGridViewCustomers_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = this.dataGridViewCustomers.Rows[e.RowIndex];
            Form customer = new CustomerProperties(row.Cells["customerId"].Value.ToString());
            customer.ShowDialog();
        }

        private void Statistic_Load(object sender, EventArgs e)
        {
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
            int channelId = Convert.ToInt16(((DataRowView)comboBoxChannel.SelectedItem).Row["id"]);
            dataGridViewCustomers.DataSource = ReadData.getSellerStatistic(dateTimePickerStartDate.Value.ToShortDateString(), dateTimePickerEndDate.Value.ToShortDateString(), textBoxConsultant.Text.Trim(), channelId, textBoxPartnerName.Text.Trim());
            dataGridViewCustomers.Columns["orderId"].Visible = false;
            dataGridViewCustomers.Columns["channelId"].Visible = false;
            dataGridViewCustomers.Columns["customerId"].Visible = false;
            if (channelId != 3 && channelId !=0)
            {
                dataGridViewCustomers.Columns["partnerName"].Visible = false;
            }
            else
            {
                dataGridViewCustomers.Columns["partnerName"].Visible = true;
            }
            changeDataGridViewColumnTitle();
            if (dataGridViewCustomers.RowCount > 0)
            {
                /*   
            A：新客户，淘宝客服已经联系但是前台还未联系的客人 (reservetimes:0)
            B：已联系客户但未成功预约到店时间 (reservetimes+1)
            C：已联系客户并预约到店时间 (reservetimes+1)
            D：客户已流失 (reservetimes+1)
            E：到店未成交
            F：客户交定金，衣服款式未定
            G：客户已完款，衣服款式未定
            H：客户交定金，衣服款式已定
            I：客户已完款，衣服款式已定 
            */
                foreach(DataRow row in ((DataTable)dataGridViewCustomers.DataSource).Rows)
                {
                    switch(row["status"].ToString()){
                        case "A": row["status"] = "新客户"; break;
                        case "B": row["status"] = "未成功预约"; break;
                        case "C": row["status"] = "成功预约"; break;
                        case "D": row["status"] = "已流失"; break;
                        case "E": row["status"] = "到店未成交"; break;
                        case "F": row["status"] = "交定金款式未定"; break;
                        case "G": row["status"] = "交完款款式未定"; break;
                        case "H": row["status"] = "交定金款式已定"; break;
                        case "I": row["status"] = "交完款款式已定"; break;
                    }
                }
                textBoxAccountReceivable.Text = Decimal.Parse(((DataTable)dataGridViewCustomers.DataSource).Compute("Sum(totalAmount)", "True").ToString()).ToString("0.00");
                textBoxPaid.Text = Decimal.Parse(((DataTable)dataGridViewCustomers.DataSource).Compute("Sum(orderAmountafter)", "True").ToString()).ToString("0.00");
                int totalCount = int.Parse(((DataTable)dataGridViewCustomers.DataSource).Compute("count(brideName)", "").ToString());
                int ABCount = int.Parse(((DataTable)dataGridViewCustomers.DataSource).Compute("count(status)", "status='A' or  status='B'").ToString());
                int ABCCount = int.Parse(((DataTable)dataGridViewCustomers.DataSource).Compute("count(status)", "status='A' or  status='B' or status='C'").ToString());
                int FGHICount = int.Parse(((DataTable)dataGridViewCustomers.DataSource).Compute("count(status)", "status='F' or  status='G' or status='H' or status='I'").ToString());
                int invitationRate = 0;
                int toShopRate = 0;
                int transferRate = 0;
                Decimal perCustomerPayment = 0;
                if (totalCount > 0)
                {
                    invitationRate = (totalCount - ABCount) * 100 / totalCount;
                }
                if ((totalCount - ABCount) > 0)
                {
                    toShopRate = (totalCount - ABCCount) * 100 / (totalCount - ABCount);
                }
                if ((totalCount - ABCCount) > 0)
                {
                    transferRate = FGHICount * 100 / (totalCount - ABCCount);
                }
                if (FGHICount > 0)
                {
                    perCustomerPayment = Decimal.Parse(textBoxPaid.Text) / FGHICount;
                }
                textBoxInvitationRate.Text = invitationRate.ToString()+"%";
                textBoxToShopRate.Text = toShopRate.ToString() + "%";
                textBoxTransferRate.Text = transferRate.ToString() + "%";
                textBoxPerCustomerPayment.Text = perCustomerPayment.ToString("0.00");
            }
        }
    }
}