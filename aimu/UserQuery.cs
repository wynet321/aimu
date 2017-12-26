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
    public partial class UserQuery : Form
    {
        public UserQuery()
        {
            InitializeComponent();
            Data roles = GlobalDb.getRoles();
            if (!roles.Success)
            {
                this.Close();
                return;
            }
            comboBoxRoles.DisplayMember = "name";
            comboBoxRoles.ValueMember = "id";
            DataRow newRow = roles.DataTable.NewRow();
            newRow["id"] = 0;
            newRow["name"] = "全部";
            roles.DataTable.Rows.InsertAt(newRow, 0);
            comboBoxRoles.DataSource = roles.DataTable;
        }

        private bool validate()
        {
            if (textBoxCellPhone.Text.Trim().Length > 0 && !Regex.IsMatch(textBoxCellPhone.Text.Trim(), @"^[1]+\d{10}$"))
            {
                MessageBox.Show("手机号码有误!");
                textBoxCellPhone.Focus();
                return false;
            }
            return true;
        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (validate())
            {
                Data users = GlobalDb.getUsers(Sharevariables.TenantId,Convert.ToInt16(comboBoxRoles.SelectedValue), textBoxCellPhone.Text.Trim(), textBoxName.Text.Trim());
                if (!users.Success)
                {
                    this.Close();
                    return;
                }
                dataGridViewTenants.DataSource = users.DataTable;
                dataGridViewTenants.Columns["id"].Visible = false;
                dataGridViewTenants.Columns["cellphone"].HeaderText = "电话";
                dataGridViewTenants.Columns["name"].HeaderText = "姓名";
                dataGridViewTenants.Columns["password"].Visible = false;
                dataGridViewTenants.Columns["passwordSalt"].Visible = false;
                dataGridViewTenants.Columns["storeId"].Visible = false;
                dataGridViewTenants.Columns["roleId"].Visible = false;
                dataGridViewTenants.Columns["name1"].HeaderText = "类型";
                dataGridViewTenants.Columns["name2"].HeaderText = "城市";
                dataGridViewTenants.Columns["name3"].HeaderText = "店名";
                dataGridViewTenants.Columns["mail"].HeaderText = "邮件地址";
                dataGridViewTenants.Columns["memo"].HeaderText = "备注";
                dataGridViewTenants.Columns["active"].HeaderText = "状态";
            }
        }

        private void dataGridViewTenants_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Form form = new UserProperties(Convert.ToInt32(dataGridViewTenants.SelectedRows[0].Cells[0].Value));
            form.ShowDialog();
            buttonSearch_Click(sender, e);
        }

        private void buttonInsertTenant_Click(object sender, EventArgs e)
        {
            Form form = new UserProperties();
            form.ShowDialog();
            buttonSearch_Click(sender, e);
        }
    }
}
