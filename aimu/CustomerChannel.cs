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
    public partial class CustomerChannel : Form
    {
        public CustomerChannel()
        {
            InitializeComponent();
        }

        public CustomerChannel(Point location)
        {
            InitializeComponent();
            this.Location = location;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            String channelName = textBoxChannel.Text.Trim();
            if (channelName.Length > 0)
            {
                SaveData.insertChannel(channelName);
                this.Close();
            }
            else
            {
                MessageBox.Show("请输入渠道名称");
                textBoxChannel.Focus();
            }

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
