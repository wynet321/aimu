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
    public partial class TenantQuery : Form
    {
        public TenantQuery()
        {
            InitializeComponent();
            Data categories = GlobalDb.getCategories();
            if (!categories.Success)
            {
                this.Close();
                return;
            }
            comboBoxCategory.DisplayMember = "name";
            comboBoxCategory.ValueMember = "id";
            DataRow newRow = categories.DataTable.NewRow();
            newRow["id"] = 0;
            newRow["name"] = "全部";
            categories.DataTable.Rows.InsertAt(newRow, 0);
            comboBoxCategory.DataSource = categories.DataTable;
            Data statuses = GlobalDb.getStatuses();

            if (!statuses.Success)
            {
                this.Close();
                return;
            }
            comboBoxStatus.DisplayMember = "name";
            comboBoxStatus.ValueMember = "id";
            DataRow row = statuses.DataTable.NewRow();
            row["id"] = 0;
            row["name"] = "全部";
            statuses.DataTable.Rows.InsertAt(row, 0);
            comboBoxStatus.DataSource = statuses.DataTable;
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
                long cellphone = (textBoxCellPhone.Text.Trim().Length == 0) ? 0L : Convert.ToInt64(textBoxCellPhone.Text.Trim());
                Data tenants = GlobalDb.getTenants(Convert.ToInt16(comboBoxStatus.SelectedValue), Convert.ToInt16(comboBoxCategory.SelectedValue),cellphone , textBoxName.Text.Trim());
                if (!tenants.Success)
                {
                    this.Close();
                    return;
                }
                dataGridViewTenants.DataSource = tenants.DataTable;
                dataGridViewTenants.Columns["id"].Visible = false;
                dataGridViewTenants.Columns["name"].HeaderText = "名称";
                dataGridViewTenants.Columns["shardName"].HeaderText = "数据库名";
                dataGridViewTenants.Columns["statusid"].Visible = false;
                dataGridViewTenants.Columns["categoryId"].Visible = false;
                dataGridViewTenants.Columns["name1"].HeaderText = "状态";
                dataGridViewTenants.Columns["name2"].HeaderText = "类型";
                dataGridViewTenants.Columns["createdDate"].HeaderText = "创建日期";
                dataGridViewTenants.Columns["enableWorkFlow"].HeaderText = "开启流程";
            }
        }

        private void dataGridViewTenants_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void buttonInsertTenant_Click(object sender, EventArgs e)
        {
            Form form = new TenantProperties();
            form.ShowDialog();
            buttonSearch_Click(sender, e);
        }
    }
}
