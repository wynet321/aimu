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
    public partial class CustomerAdd : Form
    {
        public CustomerAdd()
        {
            InitializeComponent();
            this.customerID.Text = Common.generateId();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (customerID.Text == "")
            {
                MessageBox.Show("客户编号不能为空！");
                return;
            }

            if (brideName.Text == "")
            {
                MessageBox.Show("新娘姓名不能为空！");
                return;
            }

            if (brideContact.Text == "")
            {
                MessageBox.Show("新娘联系方式不能为空！");
                return;
            }

            if (wangwangID.Text.Length == 0)
            {
                MessageBox.Show("WangWangId不能为空！");
                return;
            }

            string status = "A";
            //if (radioButtonReserveSucceed.Checked)
            //{
            //    status = "C";
            //}
            //string reservationCity = "";
            //string reservationDate = "";
            //string reservationTime = "";
            //string reservationTryDress = "";
            //if (panelReservation.Visible)
            //{
            //    reservationCity = cbCity.Text.Trim();
            //    reservationDate = reserveDate.Value.ToString("yyyy-MM-dd");
            //    reservationTime = reserveTime.Value.ToString("hh:mm:ss");
            //    reservationTryDress = tryDress.Text.Trim();
            //}

            bool result = SaveData.InsertCustomerPropertiesByOperator(cbCity.Text+"_"+customerID.Text.Trim(), brideName.Text, brideContact.Text, memo.Text.Trim(), infoChannel.Text,cbCity.Text.Trim(),wangwangID.Text.Trim(),Sharevariables.getLoginOperatorName(),status);

            if (result)
            {
                this.Close();
            }
        }

        private void CMAddCustomer_Load(object sender, EventArgs e)
        {
            this.cbCity.Text = Sharevariables.getUserCity();
        }

        //private void cbCity_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}

        //private void radioButtonReserveSucceed_CheckedChanged(object sender, EventArgs e)
        //{
        //    panelReservation.Visible = true;
        //    cbCity.SelectedIndex = 0;
        //    tryDress.SelectedIndex = 0;
        //}

        //private void radioButtonNewCustomer_CheckedChanged(object sender, EventArgs e)
        //{
        //    panelReservation.Visible = false;
        //}
    }
}
