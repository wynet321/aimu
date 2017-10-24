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

            Customer customer = new Customer();
            customer.customerID = customerID.Text.Trim();
            customer.brideName = brideName.Text.Trim();
            customer.brideContact = brideContact.Text.Trim();
            customer.memo = memo.Text.Trim();
            customer.wangwangID = wangwangID.Text.Trim();
            customer.channelId = Convert.ToInt16(comboBoxChannel.SelectedValue);
            customer.storeId = Convert.ToInt16(comboBoxStore.SelectedValue);
            customer.status = 1;
            customer.partnerName = textBoxPartnerName.Text.Trim();
            customer.operatorName = Sharevariables.LoginOperatorName;
            bool result = SaveData.InsertCustomer(customer);
            if (result)
            {
                this.Close();
            }
        }

        private void CMAddCustomer_Load(object sender, EventArgs e)
        {
            comboBoxCity.DisplayMember = "name";
            comboBoxCity.ValueMember = "id";
            Data data= ReadData.getCities();
            if (!data.Success)
            {
                this.Close();
                return;
            }
            comboBoxCity.DataSource = data.DataTable;
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
            Data channels = ReadData.getCustomerChannels();
            if (!channels.Success)
            {
                this.Close();
                return;
            }
            comboBoxChannel.DisplayMember = "name";
            comboBoxChannel.ValueMember = "id";
            comboBoxChannel.DataSource = channels.DataTable;
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
            Data stores = ReadData.getStores(Convert.ToInt16(comboBoxCity.SelectedValue));
            if (!stores.Success)
            {
                this.Close();
                return;
            }
            comboBoxStore.DisplayMember = "name";
            comboBoxStore.ValueMember = "id";
            comboBoxStore.DataSource = stores.DataTable;
            
        }

    }
}
