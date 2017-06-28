using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aimu
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

            int ul = Sharevariables.getUserLevel();
            switch (ul)
            {
                case 1:
                    this.buttonDressManagement.Visible = true;
                    this.buttonOrderManagement.Visible = true;
                    break;
                case 4:
                    this.buttonDressManagement.Visible = false;
                    this.buttonOrderManagement.Visible = false;
                    break;
                default:
                    break;
            }
            getOrderStatistic();
             }

        private void getOrderStatistic()
        {
            DataTable dt = ReadData.getOrderAmount(DateTime.Today);
            labelOrderStatistic.Text = "今日订单金额：" + dt.Rows[0].ItemArray[0].ToString() + " 实收金额：" + dt.Rows[0].ItemArray[1].ToString();
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Connection.Close();
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(DateTime.Now.Date.ToString("yyyy-MM-dd"));
           
            //DialogResult dialogResult = MessageBox.Show("确定要退出系统吗？", "退出", MessageBoxButtons.YesNo);
            //if (dialogResult == DialogResult.Yes)
            //{
                Application.Exit();
            //}

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("功能开发中，敬请期待......");
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OrderAddUpdate formOrder =new OrderAddUpdate();
            formOrder.ShowDialog();
            //Form nc = new OrderManager();
            //nc.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("功能开发中，敬请期待......");
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Form nc = new CustomerAdd();
            nc.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form nc = new CustomerQuery();
            nc.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            {
                Form nc = new DressManager();
                nc.ShowDialog();
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 缓存清理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try {
                System.IO.DirectoryInfo di = new DirectoryInfo("./images/");

                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }

                MessageBox.Show("缓存清理成功！");
            }
            catch (Exception ef)
            {
                MessageBox.Show(ef.ToString());
            }

        }

        private void buttonCustomerManagement_Resize(object sender, EventArgs e)
        {
           
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            buttonCustomerManagement.Left = this.Size.Width - 520;
            buttonCustomerManagement.Top = this.Size.Height - 120;
            buttonDressManagement.Left = buttonCustomerManagement.Right + 10;
            buttonDressManagement.Top = buttonCustomerManagement.Top;
            buttonOrderManagement.Left = buttonDressManagement.Right + 10;
            buttonOrderManagement.Top = buttonDressManagement.Top;
            buttonExit.Left = buttonOrderManagement.Right + 10;
            buttonExit.Top = buttonDressManagement.Top;
        }
        private void MainForm_Activated(object sender, EventArgs e)
        {
            getOrderStatistic();
        }
    }
}
