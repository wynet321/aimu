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
    public partial class DressAdd : Form
    {
        public DressAdd()
        {
            InitializeComponent();
            cleanPicPath();
        }


        private bool cleanPicPath()
        {
            picDataInfo.picPath1 = "";
            picDataInfo.picPath2 = "";
            picDataInfo.picPath3 = "";
            picDataInfo.picPath4 = "";
            picDataInfo.picPath5 = "";
            picDataInfo.picPath6 = "";
            picDataInfo.picPath7 = "";
            picDataInfo.picPath8 = "";
            picDataInfo.picPath9 = "";
            return true;
        }

        public void cleanPictureBox()
        {

            if (pictureBox1.Image != null)
            { 
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
            }

            if (pictureBox2.Image != null)
            {
                pictureBox2.Image.Dispose();
                pictureBox2.Image = null;
             }

            if (pictureBox3.Image != null)
            {
                pictureBox3.Image.Dispose();
                pictureBox3.Image = null;
             }

            if (pictureBox4.Image != null)
            {
                pictureBox4.Image.Dispose();
                pictureBox4.Image = null;
             }

            if (pictureBox5.Image != null)
            {
                pictureBox5.Image.Dispose();
                pictureBox5.Image = null;
            }

            if (pictureBox6.Image != null)
            {
                pictureBox6.Image.Dispose();
                pictureBox6.Image = null;
             }

            if (pictureBox7.Image != null)
            {
                pictureBox7.Image.Dispose();
                pictureBox7.Image = null;
            }

            if (pictureBox8.Image != null)
            {
                pictureBox8.Image.Dispose();
                pictureBox8.Image = null;
             }

            if (pictureBox9.Image != null)
            {
                pictureBox9.Image.Dispose();
                pictureBox9.Image = null;
             }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.Title = "Open Image";
            dlg.Filter = "jpg files (*.jpg)|*.jpg|png files (*.png)|*.png";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image.Dispose();
                    pictureBox1.Image = null;
                }
                pictureBox1.Image = new Bitmap(dlg.OpenFile());
                picDataInfo.picPath1 = dlg.FileName;
                //SaveData.InsertPicture("","",Path.GetFileName(dlg.FileName), m_barrImg);

            }

            dlg.Dispose();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.Title = "Open Image";
            dlg.Filter = "jpg files (*.jpg)|*.jpg|png files (*.png)|*.png";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (pictureBox2.Image != null)
                {
                    pictureBox2.Image.Dispose();
                    pictureBox2.Image = null;
                }
                pictureBox2.Image = new Bitmap(dlg.OpenFile());
                picDataInfo.picPath2 = dlg.FileName;
            }

            dlg.Dispose();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.Title = "Open Image";
            dlg.Filter = "jpg files (*.jpg)|*.jpg|png files (*.png)|*.png";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (pictureBox3.Image != null)
                {
                    pictureBox3.Image.Dispose();
                    pictureBox3.Image = null;
                }
                pictureBox3.Image = new Bitmap(dlg.OpenFile());
                picDataInfo.picPath3 = dlg.FileName;
            }

            dlg.Dispose();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.Title = "Open Image";
            dlg.Filter = "jpg files (*.jpg)|*.jpg|png files (*.png)|*.png";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (pictureBox4.Image != null)
                {
                    pictureBox4.Image.Dispose();
                    pictureBox4.Image = null;
                }
                pictureBox4.Image = new Bitmap(dlg.OpenFile());
                picDataInfo.picPath4 = dlg.FileName;
            }

            dlg.Dispose();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.Title = "Open Image";
            dlg.Filter = "jpg files (*.jpg)|*.jpg|png files (*.png)|*.png";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (pictureBox5.Image != null)
                {
                    pictureBox5.Image.Dispose();
                    pictureBox5.Image = null;
                }
                pictureBox5.Image = new Bitmap(dlg.OpenFile());
                picDataInfo.picPath5 = dlg.FileName;
            }

            dlg.Dispose();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.Title = "Open Image";
            dlg.Filter = "jpg files (*.jpg)|*.jpg|png files (*.png)|*.png";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (pictureBox6.Image != null)
                {
                    pictureBox6.Image.Dispose();
                    pictureBox6.Image = null;
                }
                pictureBox6.Image = new Bitmap(dlg.OpenFile());
                picDataInfo.picPath6 = dlg.FileName;
            }

            dlg.Dispose();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.Title = "Open Image";
            dlg.Filter = "jpg files (*.jpg)|*.jpg|png files (*.png)|*.png";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (pictureBox7.Image != null)
                {
                    pictureBox7.Image.Dispose();
                    pictureBox7.Image = null;
                }
                pictureBox7.Image = new Bitmap(dlg.OpenFile());
                picDataInfo.picPath7 = dlg.FileName;
            }

            dlg.Dispose();

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.Title = "Open Image";
            dlg.Filter = "jpg files (*.jpg)|*.jpg|png files (*.png)|*.png";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (pictureBox8.Image != null)
                {
                    pictureBox8.Image.Dispose();
                    pictureBox8.Image = null;
                }
                pictureBox8.Image = new Bitmap(dlg.OpenFile());
                picDataInfo.picPath8 = dlg.FileName;
            }

            dlg.Dispose();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.Title = "Open Image";
            dlg.Filter = "jpg files (*.jpg)|*.jpg|png files (*.png)|*.png";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (pictureBox9.Image != null)
                {
                    pictureBox9.Image.Dispose();
                    pictureBox9.Image = null;
                }
                pictureBox9.Image = new Bitmap(dlg.OpenFile());
                picDataInfo.picPath9 = dlg.FileName;
            }

            dlg.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("确定要取消吗？", "取消", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form FIP = new DressAddProperties();
            FIP.ShowDialog();
            cleanPictureBox();
        }

      

    }
}
