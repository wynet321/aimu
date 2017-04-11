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
    public partial class ShowBigPics : Form
    {
        public ShowBigPics()
        {
            InitializeComponent();
        }

        public ShowBigPics(Image bp)
        {
            InitializeComponent();
            pictureBox1.Image = bp;

        }
    }
}
