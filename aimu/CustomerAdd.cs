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
    public partial class CustomerAdd : Form
    {
        public CustomerAdd()
        {
            InitializeComponent();
            this.customerID.Text = Common.generateId();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (customerID.Text == "")
            {
                MessageBox.Show("客户编号不能为空！");
                return;
            }

            if (brideName.Text == "")
            {
                MessageBox.Show("新娘姓名不能为空！");
                return;
            }

            if (brideContact.Text == "")
            {
                MessageBox.Show("联系方式不能为空！");
                return;
            }

            if (wangwangID.Text.Length == 0)
            {
                MessageBox.Show("WangWangId不能为空！");
                return;
            }

            if (((DataRowView)comboBoxChannel.SelectedItem).Row["name"].ToString().Equals("异业合作"))
            {
                if (textBoxPartner.Text.Trim().Length == 0)
                {
                    MessageBox.Show("合作企业不能为空！");
                    return;
                }
            }

            string status = "A";
            bool result = SaveData.InsertCustomerPropertiesByOperator(cbCity.Text + "_" + customerID.Text.Trim(), brideName.Text, brideContact.Text, memo.Text.Trim(), Convert.ToInt16(comboBoxChannel.SelectedValue), cbCity.Text.Trim(), wangwangID.Text.Trim(), Sharevariables.getLoginOperatorName(), status);
            if (result)
            {
                this.Close();
            }
        }

        private void CMAddCustomer_Load(object sender, EventArgs e)
        {
            this.cbCity.Text = Sharevariables.getUserCity();
            refreshChannelList();
        }

        private void buttonAddChannel_Click(object sender, EventArgs e)
        {
            Form channel = new CustomerChannel(new Point(buttonAddChannel.PointToScreen(Point.Empty).X + buttonAddChannel.Width + 1, buttonAddChannel.PointToScreen(Point.Empty).Y));
            channel.ShowDialog();
            refreshChannelList();
        }

        private void refreshChannelList()
        {
            comboBoxChannel.DataSource = ReadData.getCustomerChannels();
            comboBoxChannel.DisplayMember = "name";
            comboBoxChannel.ValueMember = "id";
        }

        private void comboBoxChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((DataRowView)comboBoxChannel.SelectedItem).Row["name"].ToString().Equals("异业合作"))
            {
                label3.Visible = true;
                textBoxPartner.Visible = true;
            }
            else
            {
                label3.Visible = false;
                textBoxPartner.Visible = false;
            }
        }

        //private void cbCity_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}

        //private void radioButtonReserveSucceed_CheckedChanged(object sender, EventArgs e)
        //{
        //    panelReservation.Visible = true;
        //    cbCity.SelectedIndex = 0;
        //    tryDress.SelectedIndex = 0;
        //}

        //private void radioButtonNewCustomer_CheckedChanged(object sender, EventArgs e)
        //{
        //    panelReservation.Visible = false;
        //}
    }
}
