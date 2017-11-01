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
    public partial class DressImageShow : Form
    {
        public DressImageShow()
        {
            InitializeComponent();
        }

        public DressImageShow(Image image)
        {
            InitializeComponent();
            pictureBox.Image = image;

        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
