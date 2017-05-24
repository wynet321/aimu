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
    public partial class OMChargebackWeddingDressDialog : Form
    {
        public OMChargebackWeddingDressDialog()
        {
            InitializeComponent();
        }

        string theOrderStatus;
        string thecustomerName;
        string thecustomerId;
        public OMChargebackWeddingDressDialog(string customerName, string customerId)
        {
            InitializeComponent();
            thecustomerName = customerName;
            thecustomerId = customerId;


            DataTable dt = ReadData.fillCustomersOrderByID(customerId);
            dataGridView1.DataSource = dt;

            textBox1.Text = "客户名称：" + customerName + "，如果需要退单，请输入退还金额然后点击确定按钮";

            textBox2.Text = dataGridView1.Rows[0].Cells["totalAmount"].Value.ToString();
            textBox3.Text = dataGridView1.Rows[0].Cells["totalAmount"].Value.ToString();

            changeDataGridView();
        }




        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void changeDataGridView()
        {
            if (dataGridView1.Columns["orderID"] != null)
                dataGridView1.Columns["orderID"].HeaderText = "订单编号";
            if (dataGridView1.Columns["customerID"] != null)
                dataGridView1.Columns["customerID"].HeaderText = "客户编号";
            if (dataGridView1.Columns["wdData"] != null)
                dataGridView1.Columns["wdData"].HeaderText = "订单内容";
            if (dataGridView1.Columns["orderAmountPre"] != null)
                dataGridView1.Columns["orderAmountPre"].HeaderText = "订单折扣前金额";

            if (dataGridView1.Columns["orderAmountafter"] != null)
                dataGridView1.Columns["orderAmountafter"].HeaderText = "订单折扣后金额";
            if (dataGridView1.Columns["orderDiscountRate"] != null)
                dataGridView1.Columns["orderDiscountRate"].HeaderText = "折扣系数";
            if (dataGridView1.Columns["orderPaymentMethod"] != null)
                dataGridView1.Columns["orderPaymentMethod"].HeaderText = "订单付款方式";

            if (dataGridView1.Columns["reservedAmount"] != null)
                dataGridView1.Columns["reservedAmount"].HeaderText = "定金金额";
            if (dataGridView1.Columns["depositAmount"] != null)
                dataGridView1.Columns["depositAmount"].HeaderText = "押金金额";
            if (dataGridView1.Columns["depositPaymentMethod"] != null)
                dataGridView1.Columns["depositPaymentMethod"].HeaderText = "押金付款方式";
            if (dataGridView1.Columns["totalAmount"] != null)
                dataGridView1.Columns["totalAmount"].HeaderText = "实付金额";
            if (dataGridView1.Columns["returnAmount"] != null)
                dataGridView1.Columns["returnAmount"].HeaderText = "退款金额";
            if (dataGridView1.Columns["orderStatus"] != null)
                dataGridView1.Columns["orderStatus"].HeaderText = "订单状态";
            if (dataGridView1.Columns["orderType"] != null)
                dataGridView1.Columns["orderType"].HeaderText = "订单类型";

            if (dataGridView1.Columns["receptionConsultant"] != null)
                dataGridView1.Columns["receptionConsultant"].HeaderText = "接待顾问";
            if (dataGridView1.Columns["shenpiren"] != null)
                dataGridView1.Columns["shenpiren"].HeaderText = "审批人";
            if (dataGridView1.Columns["gongfei"] != null)
                dataGridView1.Columns["gongfei"].HeaderText = "工费";
            if (dataGridView1.Columns["jiajifei"] != null)
                dataGridView1.Columns["jiajifei"].HeaderText = "加急费";
            if (dataGridView1.Columns["jiachangfei"] != null)
                dataGridView1.Columns["jiachangfei"].HeaderText = "加长费";
            if (dataGridView1.Columns["jiakuanfei"] != null)
                dataGridView1.Columns["jiakuanfei"].HeaderText = "加宽费";

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedCells.Count > 0)
                {

                    if (textBox2.Text.Trim() == "")
                    {
                        MessageBox.Show("实交金额不能为空，请联系店长或管理员确认实交金额。");
                        return;
                    }
                    if (textBox3.Text.Trim() == "")
                    {
                        MessageBox.Show("退还金额不能为空，请联系店长或管理员确认退还金额。");
                        return;
                    }


                    int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                    string orderID = Convert.ToString(selectedRow.Cells["orderID"].Value);

                    DialogResult dialogResult = MessageBox.Show("请确定是否要把客户:" + thecustomerName + " 的订单：" + orderID + " 退单？其中实付金额：" + textBox2.Text + " 元，退还金额：" + textBox3.Text + " 元", "退出", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        UpdateDate.updateCustomerOrderCancelOrder(orderID, textBox3.Text.Trim());
                        MessageBox.Show("客户:" + thecustomerName + " 的订单：" + orderID + " 已经退单,实交金额：" + textBox2.Text + " 元，现退还金额：" + textBox3.Text + " 元");
                        DataTable dt = ReadData.fillCustomersOrderByID(thecustomerId);
                        dataGridView1.DataSource = dt;
                        changeDataGridView();
                    }
                }
            }
            catch (Exception ef)
            {
                MessageBox.Show(ef.ToString());
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
