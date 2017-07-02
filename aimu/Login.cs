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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dt = ReadData.getAccount(textBox1.Text, textBox2.Text);
            if (dt.Rows.Count > 0)
            {
                Sharevariables.setLoginOperatorName(dt.Rows[0].ItemArray[1].ToString());
                Sharevariables.setUserLevel(int.Parse(dt.Rows[0].ItemArray[3].ToString()));
                Sharevariables.setUserCity(dt.Rows[0].ItemArray[5].ToString());
                Sharevariables.setUserAddress(dt.Rows[0].ItemArray[6].ToString());
                Sharevariables.setUserTel(dt.Rows[0].ItemArray[7].ToString());
                this.Close();
            }
            else
            {
                MessageBox.Show("用户名或密码错误！");
                textBox2.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
