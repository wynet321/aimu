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
    public partial class CMAddCustomer : Form
    {
        public CMAddCustomer()
        {
            InitializeComponent();
            this.customerID.Text = Sharevariables.getUserCity() + "_" + MemberNumberBuilder.NextBillNumber();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
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

            string status = "A";
            if (radioButtonReserveSucceed.Checked)
            {
                status = "C";
            }
            string reservationCity = "";
            string reservationDate = "";
            string reservationTime = "";
            string reservationTryDress = "";
            if (panelReservation.Visible)
            {
                reservationCity = cbCity.Text.Trim();
                reservationDate = reserveDate.Value.ToString("yyyy-MM-dd");
                reservationTime = reserveTime.Value.ToString("hh:mm:ss");
                reservationTryDress = tryDress.Text.Trim();
            }

            bool result = SaveData.InsertCustomerProperties(customerID.Text, brideName.Text, brideContact.Text, marryDay.Value.ToString("yyyy-MM-dd"), infoChannel.Text, reservationDate, reservationTime, reservationTryDress, memo.Text, scsj_jsg.Text, scsj_cxsg.Text, scsj_tz.Text, scsj_xw.Text, scsj_xxw.Text, scsj_yw.Text, scsj_dqw.Text, scsj_tw.Text, scsj_jk.Text, scsj_jw.Text, scsj_dbw.Text, scsj_yddc.Text, scsj_qyj.Text, scsj_bpjl.Text, status, "", "1", reservationCity, tbGroomName.Text.Trim(), tbGroomContact.Text.Trim(), this.wangwangID.Text.Trim(), this.jdgw.Text.Trim(), this.tbAddress.Text.Trim());

            if (result)
            {
                MessageBox.Show("新增客户成功！");
            }

            this.Close();

        }

        private void CMAddCustomer_Load(object sender, EventArgs e)
        {
            this.cbCity.Text = Sharevariables.getUserCity();
        }

        private void cbCity_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioButtonReserveSucceed_CheckedChanged(object sender, EventArgs e)
        {
            panelReservation.Visible = true;
            cbCity.SelectedIndex = 0;
            tryDress.SelectedIndex = 0;
        }

        private void radioButtonNewCustomer_CheckedChanged(object sender, EventArgs e)
        {
            panelReservation.Visible = false;
        }
    }
}
