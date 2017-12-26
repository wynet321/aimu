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
    public partial class StoreAdd : Form
    {
        private int cityId;
        //public StoreAdd()
        //{
        //    InitializeComponent();
        //}

        public StoreAdd(Point location,int cityId)
        {
            InitializeComponent();
            this.Location = location;
            this.cityId = cityId;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Store store = new Store();
            store.name = textBoxStoreName.Text.Trim();
            store.cityId = cityId;
            if (store.name.Length > 0)
            {
                ShardDb.insertStore(store);
                this.Close();
            }
            else
            {
                MessageBox.Show("请输入店铺名称");
                textBoxStoreName.Focus();
            }

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
