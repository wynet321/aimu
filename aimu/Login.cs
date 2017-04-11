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
            try
            {
                UAccountList ul = ReadData.getAccount();
                for (int i = 0; i < ul.Count; i++)
                {
                    if (ul[i].u_name == textBox1.Text && ul[i].u_password == textBox2.Text)
                    {
                        Sharevariables.setLoginOperatorName(ul[i].u_name);
                        Sharevariables.setUserLevel(ul[i].u_level);
                        Sharevariables.setUserCity(ul[i].u_city);
                        Sharevariables.setUserAddress(ul[i].u_address);
                        Sharevariables.setUserTel(ul[i].u_tel);


                        this.Hide();
                        Form mainForm = new MainForm();
                        mainForm.ShowDialog();
                        return;
                    }
                }

                MessageBox.Show("用户名或密码错误！");
                textBox2.Focus();
            }
            catch (Exception ef)
            { }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("确定要退出系统吗？", "退出", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }


        }
    }
}
