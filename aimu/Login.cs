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
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (validate(textBoxUserName.Text.Trim(), textBoxPassword.Text.Trim()))
            {
                this.Close();
            }
            else
            {
                textBoxUserName.Focus();
            }
        }

        private bool validate(string username, string password)
        {
            //byte[] salt = PasswordEncryption.generateSalt();
            //byte[] passwordBinary = PasswordEncryption.createPassword(password, salt);
            User user = GlobalDb.getUserByCellPhone(textBoxUserName.Text);
            if (user.cellPhone != 0)
            {
                if (PasswordEncryption.validate(password, user.password, user.passwordSalt))
                {
                    Tenant tenant = GlobalDb.getTenantById(user.tenantId);
                    if (tenant.id != 0)
                    {
                        Sharevariables.ShardDbConnectionString = "server=" + PropertyHandler.HostName + ";uid=" + PropertyHandler.UserName + ";pwd=" + PropertyHandler.Password + ";database=" + tenant.shareName;
                        Sharevariables.UserName = user.cellPhone.ToString();
                        Sharevariables.UserLevel = user.roleId;
                        Sharevariables.StoreId = user.storeId;
                        Sharevariables.UserAddress = user.address;
                        Sharevariables.EnableWorkFlow = user.enableWorkFlow;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("此用户的数据不存在！");
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("用户名或密码错误！");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("用户名或者密码错误！");
                return false;
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
