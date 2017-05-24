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
    public partial class CMNotReservedConfirm : Form
    {
        string tbCustomerID;
        int reservedtime;

        public CMNotReservedConfirm()
        {
            InitializeComponent();
        }

        public CMNotReservedConfirm(string tbCustomerID)
        {
            InitializeComponent();
            try
            {
                this.tbCustomerID = tbCustomerID;
                reservedtime = ReadData.getCustomerReservedTimes(tbCustomerID);
                tbReservedTimes.Text = reservedtime.ToString();
            }
            catch (Exception ef)
            {
                MessageBox.Show(ef.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //UpdateDate.updateCustomerStatus(tbCustomerID, "B"); //B：未预约成功
            //UpdateDate.updateCustomerReservedTimes(tbCustomerID, (++reservedtime)); // 更新客户预约次数 ++
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
