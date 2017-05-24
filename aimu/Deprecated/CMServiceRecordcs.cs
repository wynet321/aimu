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
    public partial class CMServiceRecordcs : Form
    {
        string customerIDTemp;
        public CMServiceRecordcs()
        {
            InitializeComponent();
        }
        public CMServiceRecordcs(string uuidStr)
        {
            InitializeComponent();
            customerIDTemp = uuidStr;
            this.customerID.Text = uuidStr;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("确定要退出录入吗？", "退出", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (customerID.Text == "")
            {
                MessageBox.Show("客户编号不能为空！");
                return;
            }



            if (brideName.Text == "")
            {
                MessageBox.Show("客户姓名不能为空！");
                return;
            }


            if (brideContact.Text == "")
            {
                MessageBox.Show("客户联系方式不能为空！");
                return;
            }

            bool result = SaveData.InsertCustomerPropertiesByOperator(customerID.Text, brideName.Text, brideContact.Text, memo.Text, infoChannel.Text, cbCity.Text, tbTaoBaoWangWang.Text, Sharevariables.getLoginOperatorName(),"A");

            if (result)
            {
                MessageBox.Show("新增客户成功！");
            }

            this.Close();
        }

        private void CMServiceRecordcs_Load(object sender, EventArgs e)
        {

        }

        private void cbCity_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
        private void cbCity_TextChanged(object sender, EventArgs e)
        {
            this.customerID.Text = this.cbCity.Text.Trim() + "_" + customerIDTemp;
        }
    }
}
