using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace aimu
{
    public partial class OMReturnWeddingAndReuturnReserved : Form
    {
        public OMReturnWeddingAndReuturnReserved()
        {
            InitializeComponent();
        }


        string theOrderStatus;
        string thecustomerName;
        string thecustomerId;
        string thePreOrderStatus;

        public OMReturnWeddingAndReuturnReserved(string customerName, string customerId, string preOrderStatus, string orderStatus)
        {
            InitializeComponent();
            thecustomerName = customerName;
            thecustomerId = customerId;
            theOrderStatus = orderStatus;
            thePreOrderStatus= preOrderStatus;

            DataTable dt = ReadData.fillCustomersOrderByID(customerId, preOrderStatus);
            dataGridView1.DataSource = dt;

            textBox1.Text = "客户名称：" + customerName + "，如果需要更改订单状态为：" + orderStatus + "，请输入押金退还金额然后点击确定按钮";

            textBox2.Text = dataGridView1.Rows[0].Cells["depositAmount"].Value.ToString();
            textBox3.Text = dataGridView1.Rows[0].Cells["depositAmount"].Value.ToString();

            changeDataGridView();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedCells.Count > 0)
                {

                    if (textBox2.Text.Trim() == "")
                    {
                        MessageBox.Show("押金金额不能为空，请联系店长或管理员确认押金金额。");
                        return;
                    }
                    if (textBox3.Text.Trim() == "")
                    {
                        MessageBox.Show("押金退还金额不能为空，请联系店长或管理员确认押金退还金额。");
                        return;
                    }
                    

                    int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                    string orderID = Convert.ToString(selectedRow.Cells["orderID"].Value);
                    string orderData = Convert.ToString(selectedRow.Cells["wdData"].Value);

                    DialogResult dialogResult = MessageBox.Show("请确定是否要把客户:" + thecustomerName + " 的订单：" + orderID + " 的状态更改为：" + theOrderStatus + "？其中押金："+textBox2.Text+" 元，退还押金："+textBox3.Text+" 元", "退出", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        UpdateDate.updateCustomerOrder(orderID, theOrderStatus, textBox3.Text.Trim());
                        MessageBox.Show("客户:" + thecustomerName + " 的订单：" + orderID + " 的状态更改为：" + theOrderStatus+ ",已交押金：" + textBox2.Text + " 元，现退还押金：" + textBox3.Text + " 元");
                       
                        //如果是租赁还纱则需要更新库存,租赁取纱的标志是：“门店已提交订单”
                        if (thePreOrderStatus == "客户已取纱")
                        {
                            string[] sArray = orderData.Split('~');
                            foreach (string iSArray in sArray)
                            {
                                if (iSArray.Trim() != "")
                                {
                                    String tmpSArray = Regex.Replace(iSArray, @"\s+", " ");
                                    string[] DataArray = tmpSArray.Split(' ');
                                    string wd_id = DataArray[0].Trim();
                                    string wd_size = DataArray[3].Trim();
                                    int wd_realtime_count = ReadData.getRealtimeCountForWeddingDressPropertiesSizeAndNumber(wd_id, wd_size);
                                    UpdateDate.updateRealtimeWeddingDressSizeAndNumberForReatGet(wd_id, wd_size, wd_realtime_count + 1);

                                }

                            }


                        }


                        //更新表格
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

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           
            try
            {
                if (dataGridView1.SelectedCells.Count > 0)
                {

                   int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                    string depositAmount = Convert.ToString(selectedRow.Cells["depositAmount"].Value);

                    textBox2.Text = depositAmount;

                }
            }
            catch (Exception ef)
            {
                MessageBox.Show(ef.ToString());
            }


        }
    }
}
