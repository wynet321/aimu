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
    public partial class StoreSelection : Form
    {
        public StoreSelection()
        {
            InitializeComponent();
        }

        private void StoreSelection_Load(object sender, EventArgs e)
        {
            comboBoxCity.DisplayMember = "name";
            comboBoxCity.ValueMember = "id";
            Data cities = ReadData.getCities();
            if (!cities.Success)
            {
                this.Close();
                return;
            }
            comboBoxCity.DataSource = cities.DataTable;
        }

        private void comboBoxCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            Data stores = ReadData.getStores(Convert.ToInt16(comboBoxCity.SelectedValue));
            if (!stores.Success)
            {
                this.Close();
                return;
            }
            comboBoxStore.DisplayMember = "name";
            comboBoxStore.ValueMember = "id";
            comboBoxStore.DataSource = stores.DataTable;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Sharevariables.StoreId = Convert.ToInt16(comboBoxStore.SelectedValue);
            this.Close();
        }
    }
}
