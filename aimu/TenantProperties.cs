﻿using System;
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
    public partial class TenantProperties : Form
    {
        private bool isCreating = false;
        public TenantProperties()
        {
            InitializeComponent();
            initial();
            isCreating = true;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void initial()
        {
            Data categories = GlobalDb.getCategories();
            if (!categories.Success)
            {
                this.Close();
                return;
            }
            comboBoxCategory.DataSource = categories.DataTable;
            comboBoxCategory.DisplayMember = "name";
            comboBoxCategory.ValueMember = "id";

            Data statuses = GlobalDb.getStatuses();
            if (!statuses.Success)
            {
                this.Close();
                return;
            }
            comboBoxStatus.DataSource = statuses.DataTable;
            comboBoxStatus.DisplayMember = "name";
            comboBoxStatus.ValueMember = "id";
            dateTimePickerCreatedDate.Value = DateTime.Today;
        }

        public TenantProperties(int id)
        {
            InitializeComponent();
            initial();
            isCreating = false;
            Tenant tenant = GlobalDb.getTenantById(id);
            if (tenant.id == 0)
            {
                MessageBox.Show("未找到此租户ID=0");
                this.Close();
            }
            textBoxName.Text = tenant.name;
            textBoxShardName.Text = tenant.shardName;
            dateTimePickerCreatedDate.Value = tenant.createdDate;
            comboBoxCategory.SelectedValue = tenant.categoryId;
            comboBoxStatus.SelectedValue = tenant.statusId;
        }

        private void TenantProperties_Load(object sender, EventArgs e)
        {

        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (validate())
            {
                if (isCreating)
                {
                    User user = new User();
                    user.cellPhone = Convert.ToUInt16(textBoxCellPhone.Text.Trim());
                    user.mail = textBoxMail.Text.Trim();
                    user.name = textBoxAdminName.Text.Trim();
                    user.roleId = 1;
                    user.storeId = 0;
                    user.memo = textBoxMemo.Text.Trim();
                    user.password = PasswordEncryption.generatePassword(textBoxPassword.Text.Trim(), user.passwordSalt);
                    user.passwordSalt = PasswordEncryption.generateSalt();

                    Tenant tenant = new Tenant();
                    tenant.enableWorkFlow = checkBoxEnableWorkFlow.Checked;
                    tenant.createdDate = dateTimePickerCreatedDate.Value;
                    tenant.categoryId = Convert.ToUInt16(comboBoxCategory.SelectedValue);
                    tenant.statusId = Convert.ToUInt16(comboBoxStatus.SelectedValue);
                    tenant.shardName = textBoxShardName.Text.Trim();
                    tenant.name = textBoxName.Text.Trim();

                    GlobalDb.createTenant(tenant,user);
                }
                else
                {

                }
            }
        }

        private bool validate()
        {
            if (textBoxPassword.Text.Trim() != textBoxPasswordConfirmation.Text.Trim())
            {
                MessageBox.Show("密码不匹配!");
                textBoxPassword.Focus();
                return false;
            }
            if (Regex.IsMatch(textBoxCellPhone.Text.Trim(), @"^[1]+[3,5]+\d{9}"))
            {
                MessageBox.Show("手机号码有误!");
                textBoxCellPhone.Focus();
                return false;
            }
            if (textBoxAdminName.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入姓名!");
                textBoxAdminName.Focus();
                return false;
            }
            if (textBoxName.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入公司名称!");
                textBoxName.Focus();
                return false;
            }
            if (textBoxShardName.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入数据库名!");
                textBoxAdminName.Focus();
                return false;
            }

            if (Regex.IsMatch(textBoxMail.Text.Trim(), @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
            {
                MessageBox.Show("邮件地址输入有误!");
                textBoxMail.Focus();
                return false;
            }

            return true;
        }
    }
}
