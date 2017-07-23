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
            labelVersion.Text = "Version " + System.Reflection.Assembly.GetExecutingAssembly()
                                           .GetName()
                                           .Version
                                           .ToString();
        }

        private void getOrderStatistic()
        {
            DataTable dt = ReadData.getOrderAmount(DateTime.Today);
            labelOrderStatistic.Text = "今日订单金额：" + (dt.Rows[0].ItemArray[0].ToString().Length == 0 ? "0" : dt.Rows[0].ItemArray[0].ToString()) + " 实收金额：" + (dt.Rows[0].ItemArray[1].ToString().Length == 0 ? "0" : dt.Rows[0].ItemArray[1].ToString());
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

        private void button2_Click(object sender, EventArgs e)
        {
            OrderQuery formOrder = new OrderQuery();
            formOrder.ShowDialog();
            //Form nc = new OrderManager();
            //nc.ShowDialog();
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

        private void Main_Load(object sender, EventArgs e)
        {
            Login login = new Login();
            login.ShowDialog();
            if (Sharevariables.getLoginOperatorName().Length == 0)
            {
                this.Close();
            }
            int ul = Sharevariables.getUserLevel();
            switch (ul)
            {
                case 1:
                    this.buttonDressManagement.Visible = true;
                    this.buttonOrderManagement.Visible = true;
                    break;
                case 2:
                    break;
                case 16:
                    this.buttonDressManagement.Visible = false;
                    this.buttonOrderManagement.Visible = false;
                    break;
                default:
                    buttonCustomerManagement.Visible = false;
                    this.buttonDressManagement.Visible = false;
                    break;
            }
            getOrderStatistic();
            getOrderStatuses();
            //buttonCustomerManagement.Visible = Common.isAuthorized(ul, 3);
            //buttonOrderManagement.Visible = Common.isAuthorized(ul, 15);
            //buttonDressManagement.Visible = Common.isAuthorized(ul, 3);
            this.Visible = true;
        }

        private void getOrderStatuses()
        {
            DataTable statuses=ReadData.getOrderStatuses();
            foreach(DataRow row in statuses.Rows)
            {
                OrderStatus orderStatus = new OrderStatus();
                orderStatus.id = int.Parse(row.ItemArray[0].ToString());
                orderStatus.name = row.ItemArray[1].ToString();
                orderStatus.userRole =int.Parse( row.ItemArray[2].ToString());
                orderStatus.preStatudId = int.Parse(row.ItemArray[3].ToString());
                Sharevariables.OrderStatuses.Add(orderStatus.id, orderStatus);
            }
        }
    }
}
