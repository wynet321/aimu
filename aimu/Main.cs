using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aimu
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            textBoxVersion.Text = "Version " + System.Reflection.Assembly.GetExecutingAssembly()
                                           .GetName()
                                           .Version
                                           .ToString();
        }

        private void getOrderStatistic()
        {
            Data orderStatistic = ShardDb.getOrderAmount(DateTime.Today);
            if (!orderStatistic.Success)
            {
                this.Close();
                return;
            }
            DataTable dt = orderStatistic.DataTable;
            labelOrderStatistic.Text = "今日订单金额：" + (dt.Rows[0].ItemArray[0].ToString().Length == 0 ? "0" : dt.Rows[0].ItemArray[0].ToString()) + " 实收金额：" + (dt.Rows[0].ItemArray[1].ToString().Length == 0 ? "0" : dt.Rows[0].ItemArray[1].ToString());
        }
        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Logger.getLogger().close();
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OrderQuery formOrder = new OrderQuery();
            formOrder.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form nc = new CustomerQuery();
            nc.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form nc = new DressList();
            nc.ShowDialog();
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            buttonCustomerManagement.Left = this.Size.Width - 520;
            buttonCustomerManagement.Top = this.Size.Height - 120;
            buttonDressManagement.Left = buttonCustomerManagement.Right + 10;
            buttonDressManagement.Top = buttonCustomerManagement.Top;
            buttonOrderManagement.Left = buttonDressManagement.Right + 10;
            buttonOrderManagement.Top = buttonDressManagement.Top;
            buttonExit.Left = buttonOrderManagement.Right + 10;
            buttonExit.Top = buttonDressManagement.Top;
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            getOrderStatistic();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Login login = new Login();
            login.ShowDialog();
            if (Sharevariables.IsTenantAdministrator)
            {
                buttonTenantManager.Visible = true;
                buttonDressManagement.Visible = false;
                buttonCustomerManagement.Visible = false;
                buttonStatistic.Visible = false;
                buttonOrderManagement.Visible = false;
            }
            else
            {
                if (Sharevariables.UserName.Length == 0)
                {
                    this.Close();
                }
                int ul = Sharevariables.UserLevel;
                switch (ul)
                {
                    case 1:
                        this.buttonDressManagement.Visible = true;
                        this.buttonOrderManagement.Visible = true;
                        this.buttonTenantManager.Visible = false;
                        break;
                    case 2:
                        break;
                    case 16:
                        this.buttonDressManagement.Visible = false;
                        this.buttonOrderManagement.Visible = false;
                        this.buttonTenantManager.Visible = false;
                        break;
                    default:
                        buttonCustomerManagement.Visible = false;
                        buttonDressManagement.Visible = true;
                        this.buttonTenantManager.Visible = false;
                        break;
                }
                if (Sharevariables.UserLevel == 1 && Sharevariables.StoreId == 0)
                {
                    // all admin
                    Form storeSelection = new StoreSelection();
                    storeSelection.ShowDialog();
                }
                Data customerChannels = ShardDb.getChannels();
                if (!customerChannels.Success)
                {
                    this.Close();
                    return;
                }
                foreach (DataRow row in customerChannels.DataTable.Rows)
                {
                    Sharevariables.CustomerChannels.Add(Convert.ToInt16(row["id"]), row["name"].ToString());
                }

                Data customerStatuses = ShardDb.getChannels();
                if (!customerStatuses.Success)
                {
                    this.Close();
                    return;
                }
                foreach (DataRow row in customerStatuses.DataTable.Rows)
                {
                    Sharevariables.CustomerStatuses.Add(Convert.ToInt16(row["id"]), row["name"].ToString());
                }

                Data customerCities = ShardDb.getChannels();
                if (!customerCities.Success)
                {
                    this.Close();
                    return;
                }
                foreach (DataRow row in customerCities.DataTable.Rows)
                {
                    Sharevariables.CustomerCities.Add(Convert.ToInt16(row["id"]), row["name"].ToString());
                }

                getOrderStatistic();
                getOrderStatuses();
            }
            
            Logger.getLogger().info("Program started.");
            this.Visible = true;
        }

        private void getOrderStatuses()
        {
            Data statuses = ShardDb.getOrderStatuses();
            if (!statuses.Success)
            {
                this.Close();
                return;
            }
            foreach (DataRow row in statuses.DataTable.Rows)
            {
                OrderStatus orderStatus = new OrderStatus();
                orderStatus.id = int.Parse(row.ItemArray[0].ToString());
                orderStatus.name = row.ItemArray[1].ToString();
                orderStatus.userRole = int.Parse(row.ItemArray[2].ToString());
                orderStatus.preStatusId = int.Parse(row.ItemArray[3].ToString());
                Sharevariables.OrderStatuses.Add(orderStatus.id, orderStatus);
            }
        }

        private void buttonStatistic_Click(object sender, EventArgs e)
        {
            StatisticManager manager = new StatisticManager();
            manager.ShowDialog();
        }

        private void buttonRelogin_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Sharevariables.reset();
            Main_Load(sender, e);
        }

        private void buttonResizeImage_Click(object sender, EventArgs e)
        {
            progressBar.Visible = true;
            int count = 0;
            using (Data countData = ShardDb.getImageCount())
            {
                if (!countData.Success)
                {
                    return;
                }
                count = Convert.ToInt16(countData.DataTable.Rows[0].ItemArray[0]);
            }
            MessageBox.Show("Total " + count + " images need to be resized.");
            int cursor = 0;
            while (cursor < count)
            {
                int end = 0;
                if ((count - cursor) > 50)
                {
                    end = cursor + 50;
                }
                else
                {
                    end = count;
                }
                using (Data imageData = ShardDb.getImages(cursor, end))
                {
                    if (!imageData.Success)
                    {
                        return;
                    }
                    Picture[] pictures = new Picture[imageData.DataTable.Rows.Count];
                    for (int i = 0; i < imageData.DataTable.Rows.Count; i++)
                    {
                        DataRow row = imageData.DataTable.Rows[i];
                        if (row.ItemArray[2] != DBNull.Value)
                        {
                            //resize file to normal and thumbnail
                            using (Bitmap bitmap = (Bitmap)Image.FromStream(new MemoryStream((byte[])row.ItemArray[2])))
                            {
                                Picture picture = new Picture();
                                picture.pic_image = getImage(bitmap, 800, 600);
                                picture.thumbnail = getImage(bitmap, 100, 100);
                                picture.pic_id = Convert.ToInt16(row.ItemArray[1]);
                                picture.wd_id = row.ItemArray[0].ToString();
                                pictures[i] = picture;
                            }
                        }
                    }
                    if (ShardDb.updatePictures(pictures))
                    {
                        cursor = end;
                        progressBar.Value = cursor * 100 / count;
                    }
                    pictures = null;
                    GC.Collect();
                }
            }
            MessageBox.Show("Image resize completed.");
            progressBar.Visible = false;
        }

        private byte[] getImage(Bitmap bitmap, int maxWidth, int maxHeight)
        {
            float heightTimes = (float)bitmap.Size.Height / maxHeight;
            float widthTimes = (float)bitmap.Size.Width / maxWidth;
            Bitmap newBitmap = resizeImage(bitmap, heightTimes > widthTimes ? 1 / heightTimes : 1 / widthTimes);
            Stream bitmapSteam = new MemoryStream();
            newBitmap.Save(bitmapSteam, ImageFormat.Jpeg);
            byte[] image = new byte[bitmapSteam.Length];
            bitmapSteam.Seek(0, SeekOrigin.Begin);
            bitmapSteam.Read(image, 0, Convert.ToInt32(bitmapSteam.Length));
            bitmapSteam.Close();
            return image;
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

        private void buttonTenantManager_Click(object sender, EventArgs e)
        {
            Form form = new TenantQuery();
            form.ShowDialog();
        }
    }
}
