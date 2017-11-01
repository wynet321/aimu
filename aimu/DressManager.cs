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
    public partial class DressManager : Form
    {
        public DressManager()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form formOutput = new DressQuery(3);
            formOutput.ShowDialog(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Form formInput = new DressAdd();
            Form formInput = new DressProperties();
            formInput.ShowDialog();
        }

        private void WeddingManager_Load(object sender, EventArgs e)
        {
            int ul = Sharevariables.UserLevel;
            if (ul <= 2)
            {
                button2.Enabled = true;
                bt_update_weddingdress.Enabled = true;
            }
        }

        private void bt_update_weddingdress_Click(object sender, EventArgs e)
        {
            //Form fu = new DressUpdate();
            //fu.ShowDialog();
        }

        //private void button3_Click(object sender, EventArgs e)
        //{
        //    Form fu = new DressDelete();
        //    fu.ShowDialog();
        //}

        private void buttonDressList_Click(object sender, EventArgs e)
        {
            Form form = new DressList();
            form.ShowDialog();
        }
    }
}
