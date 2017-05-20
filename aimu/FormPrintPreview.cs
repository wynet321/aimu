using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aimu
{
    public partial class FormPrintPreview : Form
    {
        private bool isZoomed = false;
        public FormPrintPreview()
        {
            InitializeComponent();
        }
        public FormPrintPreview(PrintDocument document)
        {
            InitializeComponent();
            this.printPreviewControl1.Document = document;
        }

        private void printPreviewControl1_DoubleClick(object sender, EventArgs e)
        {
            if (isZoomed)
            {
                printPreviewControl1.Zoom = 1;
                isZoomed = false;
            }
            else
            {
                printPreviewControl1.Zoom = 1.5;
                isZoomed = true;
            }
        }
    }
}
