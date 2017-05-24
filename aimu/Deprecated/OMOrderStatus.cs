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
    public partial class OMOrderStatus : Form
    {
        public OMOrderStatus()
        {
            InitializeComponent();
        }

        string theOrderStatus = "";
        string thePreOrderStatus = "";
        public OMOrderStatus(string customerName,string customerId, string preOrderStatus,string orderStatus)
        {
            InitializeComponent();
            theOrderStatus = orderStatus;
            thePreOrderStatus=preOrderStatus;
            DataTable dt = ReadData.fillCustomersOrderByID(customerId, preOrderStatus);
            dataGridView1.DataSource = dt;

            textBox1.Text = "客户名称："+customerName+"，如果需要更改订单状态为："+ orderStatus + "，请点击确定按钮";

            changeDataGridView();
        }

        public OMOrderStatus(string customerName, string customerId, string orderStatus)
        {
            InitializeComponent();
            theOrderStatus = orderStatus;
            DataTable dt = ReadData.fillCustomersOrderByID(customerId);
            dataGridView1.DataSource = dt;

            textBox1.Text = "客户名称：" + customerName + "，如果需要更改订单状态为：" + orderStatus + "，请点击确定按钮";

            changeDataGridView();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedCells.Count > 0)
                {
                    int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                    string orderID = Convert.ToString(selectedRow.Cells["orderID"].Value);
                    string orderData = Convert.ToString(selectedRow.Cells["wdData"].Value);

                    DialogResult dialogResult = MessageBox.Show("确定"+ theOrderStatus + "了吗？", "退出", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        UpdateDate.updateCustomerOrder(orderID, theOrderStatus);

                        //如果是租赁取纱则需要更新库存,租赁取纱的标志是：“门店已提交订单”
                        if (thePreOrderStatus== "门店已提交订单")
                        {
                            string[] sArray = orderData.Split('~');
                            foreach (string iSArray in sArray)
                            {
                                if (iSArray.Trim()!="")
                                {
                                    String tmpSArray = Regex.Replace(iSArray, @"\s+", " ");
                                    string[] DataArray = tmpSArray.Split(' ');
                                    string wd_id = DataArray[0].Trim();
                                    string wd_size = DataArray[3].Trim();
                                    //int wd_count = ReadData.getCountForWeddingDressPropertiesSizeAndNumber(wd_id, wd_size);
                                    int wd_realtime_count = ReadData.getRealtimeCountForWeddingDressPropertiesSizeAndNumber(wd_id, wd_size);
                                    

                                    if (wd_realtime_count <= 0)
                                    {
                                        DialogResult drNew = MessageBox.Show("库存为零，是否强制取纱？", "退出", MessageBoxButtons.YesNo);
                                        if (drNew == DialogResult.Yes)
                                        {
                                            UpdateDate.updateRealtimeWeddingDressSizeAndNumberForReatGet(wd_id, wd_size, wd_realtime_count - 1);
                                        }
                                    }
                                    else
                                    {
                                        UpdateDate.updateRealtimeWeddingDressSizeAndNumberForReatGet(wd_id, wd_size, wd_realtime_count - 1);
                                    }
                                }

                            }
                           

                        }

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

    }
}
