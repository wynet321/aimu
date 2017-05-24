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
    public partial class OMPayRetainageAccount : Form
    {
        public OMPayRetainageAccount()
        {
            InitializeComponent();
        }


        string theOrderID;
        string theOrderAmountafter;
        string theIfarrears;
        string thetotalAmount;

        public OMPayRetainageAccount(string orderID, string customerID, string orderAmountafter,string totalAmount ,string ifarrears)
        {
            InitializeComponent();
            theOrderID = orderID;
            theOrderAmountafter = orderAmountafter;
            theIfarrears = ifarrears;
            thetotalAmount = totalAmount;
            textBox1.Text = "客户姓名："+customerID+",订单编号:"+ orderID+",尚欠尾款："+ ifarrears;
        }



        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("确认客户已补交：￥"+ textBox2.Text, "退出", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                float aa = 0.0f;//之前实付金额，不包括定金
                float bb = 0.0f;//本次付的尾款
                float cc = 0.0f;//实际欠的尾款
                float dd = 0.0f;//之前全部已交钱数 

                float.TryParse(theOrderAmountafter, out aa);
                float.TryParse(textBox2.Text.Trim(), out bb);
                float.TryParse(theIfarrears, out cc);
                float.TryParse(thetotalAmount, out dd);
                

                if (bb >= cc)
                {
                    UpdateDate.updateCustomerOrderForArrears(theOrderID, (aa + bb).ToString(),(dd+bb).ToString(), "0");
                    MessageBox.Show("尾款补交成功！");
                    this.Close();
                }
                else
                {
                    UpdateDate.updateCustomerOrderForArrears(theOrderID, (aa + bb).ToString(), (dd + bb).ToString(),(cc-bb).ToString());
                    MessageBox.Show("部分尾款补交成功，还欠：￥"+ (cc - bb).ToString());
                    this.Close();
                }
              

            }
        }
    }
}
