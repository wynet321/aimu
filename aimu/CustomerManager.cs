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
    public partial class CustomerManager : Form
    {
        public CustomerManager()
        {
            InitializeComponent();

            int ul = Sharevariables.getUserLevel();
            switch (ul)
            {
                case 1:
                    this.button1.Visible = false;
                    this.button2.Visible = false;
                    //this.button3.Visible = true;
                    //this.button4.Visible = true;
                    this.button5.Visible = true;
                    this.button6.Visible = true;
                    break;
                case 4:
                    this.button1.Visible = true;
                    this.button2.Visible = true;
                    //this.button3.Visible = false;
                    //this.button4.Visible = false;
                    this.button5.Visible = false;
                    this.button6.Visible = false;
                    break;
                default:
                    break;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string uuidStr = MemberNumberBuilder.NextBillNumber();
            Form nc = new CMServiceRecordcs(uuidStr);
            //CMServiceRecordcs

            nc.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form nc = new CMQueryCustormer();
            nc.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form nc = new CMCurrentBTypeCustomer();
            nc.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form nc = new CMCurrentCustomerBookList();
            nc.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string uuidStr = Sharevariables.getUserCity() +"_"+ MemberNumberBuilder.NextBillNumber();
            Form nc = new CMAddCustomer(uuidStr);
            nc.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form nc = new CMQueryCustormer();
            nc.ShowDialog();
        }
    }
}
