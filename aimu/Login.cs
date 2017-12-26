using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            string userName = textBoxUserName.Text.Trim();
            string password = textBoxPassword.Text.Trim();

            if (!Regex.IsMatch(userName, @"^[1]+\d{10}$"))
            {
                MessageBox.Show("用户手机号码输入有误！");
                textBoxUserName.SelectAll();
                textBoxUserName.Focus();
                return;
            }
            if (password.Length == 0)
            {
                MessageBox.Show("请输入密码！");
                textBoxPassword.Focus();
                return;
            }
            if (validate(textBoxUserName.Text.Trim(), textBoxPassword.Text.Trim()))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                textBoxUserName.Focus();
            }
        }

        private bool validate(string username, string password)
        {
            User user = GlobalDb.getUserByCellPhone(textBoxUserName.Text);
            if (user.cellPhone.Length > 0)
            {
                if (PasswordEncryption.validate(password, user.password, user.passwordSalt))
                {
                    if (user.tenantId == 1)
                    {
                        //administrator of all tenants
                        Sharevariables.IsTenantAdministrator = true;
                        return true;
                    }
                    Tenant tenant = GlobalDb.getTenantById(user.tenantId);
                    if (tenant.id != 0)
                    {
                        Sharevariables.EnableWorkFlow = tenant.enableWorkFlow;
                        Sharevariables.ShardDbConnectionString = "server=" + PropertyHandler.HostName + ";uid=" + PropertyHandler.UserName + ";pwd=" + PropertyHandler.Password + ";database=" + tenant.shardName;
                        Sharevariables.UserName = user.cellPhone.ToString();
                        Sharevariables.UserLevel = user.roleId;
                        Sharevariables.StoreId = user.storeId;
                        Sharevariables.UserAddress = user.mail;
                        Sharevariables.TenantId = user.tenantId;
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
    }
}
