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
    public partial class CMServiceRecordUpdate : Form
    {
        public CMServiceRecordUpdate()
        {
            InitializeComponent();
        }


        public CMServiceRecordUpdate(Customers ct)
        {
            InitializeComponent();
            this.customerID.Text = ct.customerID;
            this.brideName.Text = ct.brideName;
            this.brideContact.Text = ct.brideContact;

            this.infoChannel.Text = ct.infoChannel;
            this.tbTaoBaoWangWang.Text = ct.wangwangID;
            this.cbCity.Text = ct.city;
            this.memo.Text = ct.memo;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Customers ct=new Customers();

            ct.customerID = this.customerID.Text;
            ct.brideName = this.brideName.Text;
            ct.brideContact = this.brideContact.Text;
            ct.infoChannel = this.infoChannel.Text;
            ct.wangwangID = this.tbTaoBaoWangWang.Text;
            ct.city = this.cbCity.Text;
            ct.memo = this.memo.Text;

            if (UpdateDate.updateCustomerInfoByOperator(customerID.Text, ct))
            {
                MessageBox.Show("客户信息更新成功！");
            }




        }
    }
}
