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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            int ul = Sharevariables.getUserLevel();
            switch (ul)
            {
                case 1:
                    this.button1.Visible = true;
                    this.button2.Visible = true;
                    break;
                case 4:
                    this.button1.Visible = false;
                    this.button2.Visible = false;
                    break;
                default:
                    break;
            }
            

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(DateTime.Now.Date.ToString("yyyy-MM-dd"));
           
            DialogResult dialogResult = MessageBox.Show("确定要退出系统吗？", "退出", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }

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
            Form nc = new OrderManager();
            nc.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("功能开发中，敬请期待......");
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Form nc = new CMAddCustomer();
            nc.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form nc = new CustomerManager();
            nc.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            {
                Form nc = new WeddingManager();
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
    }
}
