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

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (brideName.Text == "")
            {
                MessageBox.Show("请输入新娘姓名！");
                return;
            }

            if (brideContact.Text == "")
            {
                MessageBox.Show("请输入联系方式！");
                return;
            }

            if (wangwangID.Text.Length == 0)
            {
                MessageBox.Show("请输入WangWangId！");
                return;
            }

            if (((DataRowView)comboBoxChannel.SelectedItem).Row["name"].ToString().Equals("异业合作"))
            {
                if (textBoxPartnerName.Text.Trim().Length == 0)
                {
                    MessageBox.Show("请输入合作企业！");
                    return;
                }
            }

            int status = 1;
            bool result = SaveData.InsertCustomer(customerID.Text.Trim(), brideName.Text, brideContact.Text, memo.Text.Trim(), Convert.ToInt16(comboBoxChannel.SelectedValue), Convert.ToInt16(comboBoxStore.SelectedValue), wangwangID.Text.Trim(), Sharevariables.LoginOperatorName, status);
            if (result)
            {
                this.Close();
            }
        }

        private void CMAddCustomer_Load(object sender, EventArgs e)
        {
            cbCity.DisplayMember = "name";
            cbCity.ValueMember = "id";
            cbCity.DataSource = ReadData.getCities();
            //this.cbCity.Text = /*Sharevariables*/.getUserCity();
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
                textBoxPartnerName.Visible = true;
            }
            else
            {
                label3.Visible = false;
                textBoxPartnerName.Visible = false;
            }
        }

        private void cbCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxStore.DataSource = ReadData.getStores(Convert.ToInt16(cbCity.SelectedValue));
            comboBoxStore.DisplayMember = "name";
            comboBoxStore.ValueMember = "id";
        }

    }
}
