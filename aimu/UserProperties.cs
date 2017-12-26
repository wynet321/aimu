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
    public partial class UserProperties : Form
    {
        private bool isCreating = false;
        private int userId;
        public UserProperties()
        {
            InitializeComponent();
            initial();
            isCreating = true;
            buttonDelete.Visible = !isCreating;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void initial()
        {
            Data roles = GlobalDb.getRoles();
            if (!roles.Success)
            {
                this.Close();
                return;
            }
            comboBoxRole.DataSource = roles.DataTable;
            comboBoxRole.DisplayMember = "name";
            comboBoxRole.ValueMember = "id";

            Data cities = ShardDb.getCities();
            if (!cities.Success)
            {
                this.Close();
                return;
            }
            comboBoxCity.DisplayMember = "name";
            comboBoxCity.ValueMember = "id";
            comboBoxCity.DataSource = cities.DataTable;
        }

        public UserProperties(int id)
        {
            InitializeComponent();
            initial();
            isCreating = false;
            userId = id;
            User user = GlobalDb.getUser(id);
            if (user.id == 0)
            {
                MessageBox.Show("未找到此用户");
                this.Close();
            }
            textBoxName.Text = user.name;
            textBoxCellPhone.Text = user.cellPhone;
            Store store = ShardDb.getStore(user.storeId);
            if (store.id == 0)
            {
                MessageBox.Show("未找到店铺");
                this.Close();
            }
            comboBoxStore.SelectedValue = user.storeId;
            comboBoxCity.SelectedValue = store.cityId;
            comboBoxRole.SelectedValue = user.roleId;
            textBoxMemo.Text = user.memo;
            textBoxMail.Text = user.mail;
            checkBoxActive.Checked = user.active;
            buttonDelete.Visible = !isCreating;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (validate())
            {
                User user = new User();
                user.id = userId;
                user.cellPhone = textBoxCellPhone.Text.Trim();
                user.mail = textBoxMail.Text.Trim();
                user.name = textBoxName.Text.Trim();
                user.roleId = Convert.ToInt16(comboBoxRole.SelectedValue);
                user.storeId = Convert.ToInt16(comboBoxStore.SelectedValue);
                user.tenantId = Sharevariables.TenantId;
                user.memo = textBoxMemo.Text.Trim();
                user.passwordSalt = PasswordEncryption.generateSalt();
                user.password = PasswordEncryption.generatePassword(textBoxPassword.Text.Trim(), user.passwordSalt);
                user.active = checkBoxActive.Checked;

                if (isCreating)
                {
                    if (GlobalDb.createUser(user))
                    {
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("新建失败! 请联系管理员!");
                    }
                }
                else
                {
                    //update
                    if (GlobalDb.updateUser(user))
                    {
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("更新失败! 请联系管理员!");
                    }
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("", "", MessageBoxButtons.YesNo))
            {
                if (GlobalDb.deleteUser(userId))
                {
                    this.Close();
                }
            }
        }

        private bool validate()
        {
            if (!Regex.IsMatch(textBoxCellPhone.Text.Trim(), @"^[1]+\d{10}$"))
            {
                MessageBox.Show("手机号码有误!");
                textBoxCellPhone.Focus();
                return false;
            }
            if (textBoxPassword.Text.Trim().Length < 8)
            {
                MessageBox.Show("密码长度必须大于8!");
                textBoxPassword.Focus();
                return false;
            }
            if (textBoxPassword.Text.Trim() != textBoxPasswordConfirmation.Text.Trim())
            {
                MessageBox.Show("密码不匹配!");
                textBoxPassword.Focus();
                return false;
            }
            if (textBoxName.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入姓名!");
                textBoxName.Focus();
                return false;
            }
            if (!Regex.IsMatch(textBoxMail.Text.Trim(), @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
            {
                MessageBox.Show("邮件地址输入有误!");
                textBoxMail.Focus();
                return false;
            }
            return true;
        }

        private void buttonCreateStore_Click(object sender, EventArgs e)
        {
            Form form = new StoreAdd(new Point(buttonCreateStore.PointToScreen(Point.Empty).X + buttonCreateStore.Width + 1, buttonCreateStore.PointToScreen(Point.Empty).Y), Convert.ToInt16(comboBoxCity.SelectedValue));
            form.ShowDialog();
            refreshStoreList();
        }

        private void refreshStoreList()
        {
            Data store = ShardDb.getStores(Convert.ToInt16(comboBoxCity.SelectedValue));
            if (!store.Success)
            {
                this.Close();
                return;
            }
            comboBoxStore.DisplayMember = "name";
            comboBoxStore.ValueMember = "id";
            comboBoxStore.DataSource = store.DataTable;
        }

        private void comboBoxCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshStoreList();
        }
    }
}
