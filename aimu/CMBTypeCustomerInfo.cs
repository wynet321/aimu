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
    public partial class CMBTypeCustomerInfo : Form
    {
        public CMBTypeCustomerInfo()
        {
            InitializeComponent();
        }

        public CMBTypeCustomerInfo(Customers ct)
        {
            InitializeComponent();
            this.tbCustomerID.Text = ct.customerID;
            this.tbBrideName.Text = ct.brideName;
            this.tbBrideContact.Text = ct.brideContact;
            this.dtMarryDay.Text = ct.marryDay;
            this.tbInfoChannel.Text = ct.infoChannel;
            this.dtReserveDate.Text = ct.reserveDate;
            this.dtReserveTime.Text = ct.reserveTime;
            this.cbTryDress.Text = ct.tryDress;
            this.tbReason.Text = ct.reason;
            this.tbMemo.Text = ct.memo;


        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            CMNotReservedConfirm cm = new CMNotReservedConfirm(this.tbCustomerID.Text);
            cm.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
