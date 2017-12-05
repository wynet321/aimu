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
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            Data tenants = GlobalDb.getTenants();
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

        private void dataGridViewTenants_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void buttonInsertTenant_Click(object sender, EventArgs e)
        {
            Form form = new TenantProperties();
            form.ShowDialog();
        }
    }
}
