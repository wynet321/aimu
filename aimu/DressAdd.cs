using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
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
        private Bitmap resizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        private Bitmap resizeImage(Image image, float percentage)
        {
            int width = (int)Math.Round(image.Width * percentage, MidpointRounding.AwayFromZero);
            int height = (int)Math.Round(image.Height * percentage, MidpointRounding.AwayFromZero);
            return resizeImage(image, width, height);
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.Title = "Open Image";
            dlg.Filter = "jpg files (*.jpg)|*.jpg";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image.Dispose();
                    pictureBox1.Image = null;
                }
                pictureBox1.Image = new Bitmap(dlg.OpenFile());
                picDataInfo.picPath1 = dlg.FileName;
                using (Bitmap bitmap = (Bitmap)Image.FromFile(picDataInfo.picPath1))
                {
                    float heightTimes = (float)bitmap.Size.Height / 600;
                    float widthTimes = (float)bitmap.Size.Width / 800;
                    Bitmap newBitmap = resizeImage(bitmap, heightTimes > widthTimes ? 1 / heightTimes : 1 / widthTimes);
                    newBitmap.Save("C:\\Users\\Dennis\\Pictures\\Lightroom\\a.jpg", ImageFormat.Jpeg);
                }
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
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form FIP = new DressProperties();
            FIP.ShowDialog();
            cleanPictureBox();
        }
    }
}
