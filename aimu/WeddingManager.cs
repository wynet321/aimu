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
    public partial class WeddingManager : Form
    {
        public WeddingManager()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form formOutput = new FormOutput();
            formOutput.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form formInput = new FormInput();
            formInput.ShowDialog();
        }

        private void WeddingManager_Load(object sender, EventArgs e)
        {
            int ul = Sharevariables.getUserLevel();
            if (ul <= 2)
            {
                this.bt_update_weddingdress.Enabled = true;
            }
        }

        private void bt_update_weddingdress_Click(object sender, EventArgs e)
        {
            Form fu = new FormUpdateWeddingdressProperties();
            fu.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form fu = new FormDeleteWeddingDress();
            fu.ShowDialog();
        }
    }
}
