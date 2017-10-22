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
            PropertyHandler.getEnvProperties();
            textBoxVersion.Text = "Version " + System.Reflection.Assembly.GetExecutingAssembly()
                                           .GetName()
                                           .Version
                                           .ToString();
        }

        private void getOrderStatistic()
        {
            Data orderStatistic = ReadData.getOrderAmount(DateTime.Today);
            if (!orderStatistic.Success)
            {
                this.Close();
                return;
            }
            DataTable dt = orderStatistic.DataTable;
            labelOrderStatistic.Text = "今日订单金额：" + (dt.Rows[0].ItemArray[0].ToString().Length == 0 ? "0" : dt.Rows[0].ItemArray[0].ToString()) + " 实收金额：" + (dt.Rows[0].ItemArray[1].ToString().Length == 0 ? "0" : dt.Rows[0].ItemArray[1].ToString());
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OrderQuery formOrder = new OrderQuery();
            formOrder.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form nc = new CustomerQuery();
            nc.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
                Form nc = new DressManager();
                nc.ShowDialog();
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
            if (Sharevariables.LoginOperatorName.Length == 0)
            {
                this.Close();
            }
            int ul = Sharevariables.UserLevel;
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
                    buttonDressManagement.Visible = true;
                    break;
            }
            //if (Sharevariables.StoreId == 0 && Sharevariables.UserLevel!=1)
            //{
            //    buttonDressManagement.Visible = false;
            //    buttonOrderManagement.Visible = false;
            //    buttonStatistic.Visible = false;
            //}
            if (Sharevariables.UserLevel == 1 && Sharevariables.StoreId == 0)
            {
                // all admin
                Form storeSelection = new StoreSelection();
                storeSelection.ShowDialog();
            }
            Data customerChannels = ReadData.getChannels();
            if (!customerChannels.Success)
            {
                this.Close();
                return;
            }
            foreach(DataRow row in customerChannels.DataTable.Rows)
            {
                Sharevariables.CustomerChannels.Add(Convert.ToInt16(row["id"]), row["name"].ToString());
            }

            Data customerStatuses = ReadData.getChannels();
            if (!customerStatuses.Success)
            {
                this.Close();
                return;
            }
            foreach (DataRow row in customerStatuses.DataTable.Rows)
            {
                Sharevariables.CustomerStatuses.Add(Convert.ToInt16(row["id"]), row["name"].ToString());
            }

            Data customerCities = ReadData.getChannels();
            if (!customerCities.Success)
            {
                this.Close();
                return;
            }
            foreach (DataRow row in customerCities.DataTable.Rows)
            {
                Sharevariables.CustomerCities.Add(Convert.ToInt16(row["id"]), row["name"].ToString());
            }

            getOrderStatistic();
            getOrderStatuses();
            this.Visible = true;
        }

        private void getOrderStatuses()
        {
            Data statuses = ReadData.getOrderStatuses();
            if (!statuses.Success)
            {
                this.Close();
                return;
            }
            foreach(DataRow row in statuses.DataTable.Rows)
            {
                OrderStatus orderStatus = new OrderStatus();
                orderStatus.id = int.Parse(row.ItemArray[0].ToString());
                orderStatus.name = row.ItemArray[1].ToString();
                orderStatus.userRole =int.Parse( row.ItemArray[2].ToString());
                orderStatus.preStatusId = int.Parse(row.ItemArray[3].ToString());
                Sharevariables.OrderStatuses.Add(orderStatus.id, orderStatus);
            }
        }

        private void buttonStatistic_Click(object sender, EventArgs e)
        {
            //StatisticSeller statistic = new StatisticSeller();
            StatisticManager manager = new StatisticManager();
            manager.ShowDialog();
        }

        private void buttonRelogin_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Sharevariables.reset();
            Main_Load(sender, e);
        }
    }
}
