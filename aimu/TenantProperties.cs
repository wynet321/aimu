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
    public partial class TenantProperties : Form
    {
        public TenantProperties()
        {
            InitializeComponent();
            initial();
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
        }

        public TenantProperties(int id)
        {
            InitializeComponent();
            initial();
            Tenant tenant = GlobalDb.getTenantById(id);
            if (tenant.id == 0)
            {
                MessageBox.Show("未找到此租户ID=0");
                this.Close();
            }
            textBoxName.Text = tenant.name;
            textBoxDbName.Text = tenant.shareName;
            textBoxMail.Text = tenant.mail;
            dateTimePickerCreatedDate.Value = tenant.createdDate;
            comboBoxCategory.SelectedValue = tenant.categoryId;
            comboBoxStatus.SelectedValue = tenant.statusId;
        }

        private void TenantProperties_Load(object sender, EventArgs e)
        {

        }
    }
}
