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
    public partial class StatisticManager : Form
    {
        public StatisticManager()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form formOutput = new StatisticDress();
            formOutput.ShowDialog();
        }
        
        private void WeddingManager_Load(object sender, EventArgs e)
        {
        }

        private void buttonDressList_Click(object sender, EventArgs e)
        {
            Form form = new StatisticSeller();
            form.ShowDialog();
        }
    }
}
