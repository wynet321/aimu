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
            cbCity.DisplayMember = "name";
            cbCity.ValueMember = "id";
            cbCity.DataSource = ReadData.getCities();
        }

        private void cbCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxStore.DataSource = ReadData.getStores(Convert.ToInt16(cbCity.SelectedValue));
            comboBoxStore.DisplayMember = "name";
            comboBoxStore.ValueMember = "id";
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Sharevariables.setUserStoreId(Convert.ToInt16(comboBoxStore.SelectedValue));
            this.Close();
        }
    }
}
