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
    public partial class OrderManager : Form
    {
        public OrderManager()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Form nc = new OMBorrowInfo();
            //nc.ShowDialog();
            Form order = new OrderAddUpdate();
            order.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form nc = new OMStandardCode();
            nc.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form nc = new OMTailored();
            nc.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form nc = new OMGivePicCustomization();
            nc.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form co = new OMQueryOrder();
            co.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form form = new OMGetWeddingDress();
            form.ShowDialog();
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form form = new OMReturnWeddingDress();
            form.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form form = new OMChargebackWeddingDress();
            form.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MessageBox.Show("敬请期待！");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form nc = new OMUpdateOrder();
            nc.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form nc = new OMDeleteOperate();
            nc.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Form nc = new OMPayRetainage();
            nc.ShowDialog();
        }
    }
}
