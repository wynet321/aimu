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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aimu
{

    public partial class DressProperties : Form
    {
        private Dictionary<int, PictureBox> pictureBoxes = new Dictionary<int, PictureBox>();
        private Dictionary<int, CheckBox> attributes = new Dictionary<int, CheckBox>();
        private TextBox[] prices = new TextBox[7];
        private DateTimePicker[] publishDates = new DateTimePicker[7];
        private TextBox[] counts = new TextBox[7];
        private bool isLeftClick = false;
        private PictureBox selectedPictureBox;
        private DressDefinition dress;
        private bool isUpdate = false;
        public DressProperties()
        {
            initial();
        }

        public DressProperties(string wd_id)
        {
            initial();
            isUpdate = true;
            buttonDelete.Visible = true;
            textBoxId.Enabled = false;
            retrieve(wd_id);
        }

        private void retrieve(string wd_id)
        {
            Data dressProperties = DataOperation.getDressPropertiesById(wd_id);
            if (!dressProperties.Success)
            {
                this.Close();
                return;
            }
            DataRow row = dressProperties.DataTable.Rows[0];
            dress.wd_id = wd_id;
            dress.wd_date = row.ItemArray[0].ToString();
            dress.wd_big_category = row.ItemArray[1].ToString();
            dress.wd_litter_category = row.ItemArray[2].ToString();
            dress.wd_factory = row.ItemArray[3].ToString();
            dress.wd_color = row.ItemArray[4].ToString();
            dress.attribute = Convert.ToInt32(row.ItemArray[5]);
            dress.memo = row.ItemArray[6].ToString();
            dress.emergency_period = row.ItemArray[7].ToString();
            dress.normal_period = row.ItemArray[8].ToString();
            dress.is_renew = row.ItemArray[9].ToString();
            dress.settlementPrice = (row.ItemArray[10] == DBNull.Value) ? 0 : decimal.Parse(row.ItemArray[10].ToString());

            Data dressSizeAndNumbers = DataOperation.getDressById(wd_id);
            if (!dressProperties.Success)
            {
                this.Close();
                return;
            }
            WeddingDressSizeAndCount[] wdscs = new WeddingDressSizeAndCount[7];
            DataRowCollection rows = dressSizeAndNumbers.DataTable.Rows;
            for (int i = 0; i < 7; i++)
            {
                WeddingDressSizeAndCount wdsc = new WeddingDressSizeAndCount();
                wdsc.wd_id = wd_id;
                wdsc.id = rows[i].ItemArray[0].ToString();
                wdsc.wd_size = rows[i].ItemArray[1].ToString();
                wdsc.wd_price = decimal.Parse(rows[i].ItemArray[2].ToString());
                wdsc.wd_listing_date = rows[i].ItemArray[3].ToString();
                wdsc.wd_count = Convert.ToInt16(rows[i].ItemArray[4]);
                wdsc.store_id = Convert.ToInt16(rows[i].ItemArray[5]);
                wdscs[i] = wdsc;
            }
            dress.wdscs = wdscs;

            Data imagedata = DataOperation.getImagesByDressId(wd_id);
            if (!dressProperties.Success)
            {
                this.Close();
                return;
            }
            Dictionary<int, byte[]> pictures = new Dictionary<int, byte[]>();
            Dictionary<int, byte[]> thumbnails = new Dictionary<int, byte[]>();
            foreach (DataRow dataRow in imagedata.DataTable.Rows)
            {
                pictures.Add(Convert.ToInt16(dataRow.ItemArray[1]), (byte[])dataRow.ItemArray[2]);
                thumbnails.Add(Convert.ToInt16(dataRow.ItemArray[1]), (byte[])dataRow.ItemArray[3]);
            }
            dress.pictures = pictures;
            dress.thumbnails = thumbnails;

            //show to controls
            textBoxId.Text = dress.wd_id;
            wd_date.Value = DateTime.Parse(dress.wd_date);
            wd_color.SelectedItem = dress.wd_color;
            wd_factory.SelectedItem = dress.wd_factory;
            wd_big_category.SelectedItem = dress.wd_big_category;
            wd_litter_category.SelectedItem = dress.wd_litter_category;
            cb_is_renew.SelectedItem = dress.is_renew;
            tb_normal_period.Text = dress.normal_period;
            tb_emergency_period.Text = dress.emergency_period;
            memo.Text = dress.memo;
            textBoxSettlementPrice.Text = dress.settlementPrice.ToString();
            textBoxPrice.Text = "";
            foreach (int key in attributes.Keys)
            {
                if ((key & dress.attribute) != 0)
                {
                    attributes[key].Checked = true;
                }
            }
            for (int i = 0; i < 7; i++)
            {
                WeddingDressSizeAndCount dressInstance = dress.wdscs[i];
                prices[i].Text = dressInstance.wd_price.ToString();
                publishDates[i].Value = DateTime.Parse(dressInstance.wd_listing_date);
                counts[i].Text = dressInstance.wd_count.ToString();
            }

            showThumbnail();
        }

        private void initial()
        {
            InitializeComponent();
            dress = new DressDefinition();
            dress.pictures = new Dictionary<int, byte[]>();
            dress.thumbnails = new Dictionary<int, byte[]>();
            dress.wdscs = new WeddingDressSizeAndCount[7];
            pictureBoxes.Add(1, pictureBox1);
            pictureBoxes.Add(2, pictureBox2);
            pictureBoxes.Add(3, pictureBox3);
            pictureBoxes.Add(4, pictureBox4);
            pictureBoxes.Add(5, pictureBox5);
            pictureBoxes.Add(6, pictureBox6);
            pictureBoxes.Add(7, pictureBox7);
            pictureBoxes.Add(8, pictureBox8);
            attributes.Add(33554432, cpml_ls);
            attributes.Add(16777216, cpml_ws);
            attributes.Add(8388608, cpml_duan);
            attributes.Add(4194304, cpml_zs);
            attributes.Add(2097152, cpml_other);

            attributes.Add(1048576, cpbx_yw);
            attributes.Add(524288, cpbx_ppq);
            attributes.Add(262144, cpbx_ab);
            attributes.Add(131072, cpbx_dq);
            attributes.Add(65536, cpbx_qdhc);

            attributes.Add(32768, bwcd_qd);
            attributes.Add(16384, bwcd_xtw);
            attributes.Add(8192, bwcd_ztw);
            attributes.Add(4096, bwcd_ctw);
            attributes.Add(2048, bwcd_hhtw);

            attributes.Add(1024, cplx_mx);
            attributes.Add(512, cplx_sv);
            attributes.Add(256, cplx_yzj);
            attributes.Add(128, cplx_dd);
            attributes.Add(64, cplx_dj);
            attributes.Add(32, cplx_gb);
            attributes.Add(16, cplx_yl);
            attributes.Add(8, cplx_ll);

            attributes.Add(4, lxys_bd);
            attributes.Add(2, lxys_ll);
            attributes.Add(1, lxys_lb);

            prices[0] = tb_xs_jg;
            prices[1] = tb_s_jg;
            prices[2] = tb_m_jg;
            prices[3] = tb_l_jg;
            prices[4] = tb_xl_jg;
            prices[5] = tb_xxl_jg;
            prices[6] = tb_lsdz_jg;

            publishDates[0] = dt_xs_sssj;
            publishDates[1] = dt_s_sssj;
            publishDates[2] = dt_m_sssj;
            publishDates[3] = dt_l_sssj;
            publishDates[4] = dt_xl_sssj;
            publishDates[5] = dt_xxl_sssj;
            publishDates[6] = dt_lsdz_sssj;

            counts[0] = tb_xs_sl;
            counts[1] = tb_s_sl;
            counts[2] = tb_m_sl;
            counts[3] = tb_l_sl;
            counts[4] = tb_xl_sl;
            counts[5] = tb_xxl_sl;
            counts[6] = tb_lsdz_sl;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool validate()
        {
            if (textBoxId.Text.Trim().Length == 0)
            {
                MessageBox.Show("商品编号不能为空！");
                textBoxId.Focus();
                return false;
            }
            if (!isUpdate)
            {
                Data dressIds = DataOperation.getWeddingDressIds(textBoxId.Text.Trim());
                if (dressIds.DataTable.Rows.Count > 0)
                {
                    MessageBox.Show("商品编号已存在,请输入新编号！");
                    textBoxId.Focus();
                    return false;
                }
            }
            decimal price = 0;
            foreach (TextBox textBox in prices)
            {
                if (!decimal.TryParse(textBox.Text.Trim(), out price))
                {
                    MessageBox.Show("商品价格格式错误！");
                    textBox.Focus();
                    return false;
                }
            }
            decimal settlementPrice = 0;
            if (!decimal.TryParse(textBoxSettlementPrice.Text.Trim(), out settlementPrice))
            {
                MessageBox.Show("商品结算价格格式错误！");
                textBoxPrice.Focus();
                return false;
            }
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("请至少加入一张图片！");
                pictureBox1.Focus();
                return false;
            }
            dress.wd_id = textBoxId.Text.Trim();
            dress.wd_big_category = wd_big_category.Text.Trim();
            dress.wd_litter_category = wd_litter_category.Text.Trim();
            dress.wd_date = wd_date.Text.Trim();
            dress.wd_factory = wd_factory.Text.Trim();
            dress.is_renew = cb_is_renew.Text.Trim();
            dress.emergency_period = tb_emergency_period.Text.Trim();
            dress.memo = memo.Text.Trim();
            dress.normal_period = tb_normal_period.Text.Trim();
            dress.settlementPrice = settlementPrice;
            dress.attribute = 0;
            foreach (int key in attributes.Keys)
            {
                if (attributes[key].Checked)
                {
                    dress.attribute += key;
                }
            }

            WeddingDressSizeAndCount[] dressInstances = new WeddingDressSizeAndCount[7];
            WeddingDressSizeAndCount dressInstance = new WeddingDressSizeAndCount();
            dressInstance.wd_id = dress.wd_id;
            dressInstance.wd_size = "XS";
            dressInstance.wd_count = Convert.ToInt16(tb_xs_sl.Text.Trim());
            dressInstance.wd_price = decimal.Parse(tb_xs_jg.Text.Trim());
            dressInstance.wd_listing_date = dt_xs_sssj.Text.Trim();
            dressInstances[0] = dressInstance;

            dressInstance = new WeddingDressSizeAndCount();
            dressInstance.wd_id = dress.wd_id;
            dressInstance.wd_size = "S";
            dressInstance.wd_count = Convert.ToInt16(tb_s_sl.Text.Trim());
            dressInstance.wd_price = decimal.Parse(tb_s_jg.Text.Trim());
            dressInstance.wd_listing_date = dt_s_sssj.Text.Trim();
            dressInstances[1] = dressInstance;

            dressInstance = new WeddingDressSizeAndCount();
            dressInstance.wd_id = dress.wd_id;
            dressInstance.wd_size = "M";
            dressInstance.wd_count = Convert.ToInt16(tb_m_sl.Text.Trim());
            dressInstance.wd_price = decimal.Parse(tb_m_jg.Text.Trim());
            dressInstance.wd_listing_date = dt_m_sssj.Text.Trim();
            dressInstances[2] = dressInstance;

            dressInstance = new WeddingDressSizeAndCount();
            dressInstance.wd_id = dress.wd_id;
            dressInstance.wd_size = "L";
            dressInstance.wd_count = Convert.ToInt16(tb_l_sl.Text.Trim());
            dressInstance.wd_price = decimal.Parse(tb_l_jg.Text.Trim());
            dressInstance.wd_listing_date = dt_l_sssj.Text.Trim();
            dressInstances[3] = dressInstance;

            dressInstance = new WeddingDressSizeAndCount();
            dressInstance.wd_id = dress.wd_id;
            dressInstance.wd_size = "XL";
            dressInstance.wd_count = Convert.ToInt16(tb_xl_sl.Text.Trim());
            dressInstance.wd_price = decimal.Parse(tb_xl_jg.Text.Trim());
            dressInstance.wd_listing_date = dt_xl_sssj.Text.Trim();
            dressInstances[4] = dressInstance;

            dressInstance = new WeddingDressSizeAndCount();
            dressInstance.wd_id = dress.wd_id;
            dressInstance.wd_size = "XXL";
            dressInstance.wd_count = Convert.ToInt16(tb_xxl_sl.Text.Trim());
            dressInstance.wd_price = decimal.Parse(tb_xxl_jg.Text.Trim());
            dressInstance.wd_listing_date = dt_xxl_sssj.Text.Trim();
            dressInstances[5] = dressInstance;

            dressInstance = new WeddingDressSizeAndCount();
            dressInstance.wd_id = dress.wd_id;
            dressInstance.wd_size = "LSDZ";
            dressInstance.wd_count = Convert.ToInt16(tb_lsdz_sl.Text.Trim());
            dressInstance.wd_price = decimal.Parse(tb_lsdz_jg.Text.Trim());
            dressInstance.wd_listing_date = dt_lsdz_sssj.Text.Trim();
            dressInstances[6] = dressInstance;

            dress.wdscs = dressInstances;

            return true;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (validate())
            {
                if (isUpdate)
                {
                    if (DataOperation.UpdateWeddingDress(dress))
                    {
                        this.Close();
                    }
                }
                else
                {
                    if (DataOperation.InsertWeddingDress(dress))
                    {
                        this.Close();
                    }
                }

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = wd_big_category.Text.Trim();
            wd_litter_category.Items.Clear();
            switch (value)
            {
                case "婚纱":
                    //齐地白纱、小拖白纱、大拖白纱、鱼尾白纱、彩纱
                    wd_litter_category.Text = "齐地白纱";
                    wd_litter_category.Items.Add("齐地白纱");
                    wd_litter_category.Items.Add("小拖白纱");
                    wd_litter_category.Items.Add("大拖白纱");
                    wd_litter_category.Items.Add("鱼尾白纱");
                    wd_litter_category.Items.Add("彩纱");
                    break;
                case "西式礼服":
                    //红色商品、彩色商品
                    wd_litter_category.Text = "红色礼服";
                    wd_litter_category.Items.Add("红色礼服");
                    wd_litter_category.Items.Add("彩色礼服");
                    break;
                case "中式礼服":
                    //旗袍、秀禾服、龙凤挂、中式其他
                    wd_litter_category.Text = "旗袍";
                    wd_litter_category.Items.Add("旗袍");
                    wd_litter_category.Items.Add("秀禾服");
                    wd_litter_category.Items.Add("龙凤挂");
                    wd_litter_category.Items.Add("中式其他");
                    break;
                case "伴娘服":
                    //长款伴娘服、短款伴娘服
                    wd_litter_category.Text = "长款伴娘服";
                    wd_litter_category.Items.Add("长款伴娘服");
                    wd_litter_category.Items.Add("短款伴娘服");
                    break;
                case "男装":
                    //衬衫、领结、领带、西装、袖扣、鞋
                    wd_litter_category.Text = "衬衫";
                    wd_litter_category.Items.Add("衬衫");
                    wd_litter_category.Items.Add("领结");
                    wd_litter_category.Items.Add("领带");
                    wd_litter_category.Items.Add("西装");
                    wd_litter_category.Items.Add("袖扣");
                    wd_litter_category.Items.Add("鞋");
                    break;
                case "饰品":
                    //头饰、首饰、头纱、肩链
                    wd_litter_category.Text = "头饰";
                    wd_litter_category.Items.Add("头饰");
                    wd_litter_category.Items.Add("首饰");
                    wd_litter_category.Items.Add("头纱");
                    wd_litter_category.Items.Add("肩链");
                    break;
                case "其他":
                    //妈妈装、花童
                    wd_litter_category.Text = "妈妈装";
                    wd_litter_category.Items.Add("妈妈装");
                    wd_litter_category.Items.Add("花童");
                    wd_litter_category.Items.Add("来图定制");
                    break;
                case "美妆":
                    wd_litter_category.Text = "美妆";
                    wd_litter_category.Items.Add("新娘跟妆");
                    wd_litter_category.Items.Add("化妆品");
                    break;
                default:
                    wd_litter_category.Text = "其他";
                    wd_litter_category.Items.Add("其他");
                    break;
            }


        }

        private void wd_id_TextChanged(object sender, EventArgs e)
        {
            tb_xs_sjbm.Text = textBoxId.Text + "-XS";
            tb_s_sjbm.Text = textBoxId.Text + "-S";
            tb_m_sjbm.Text = textBoxId.Text + "-M";
            tb_l_sjbm.Text = textBoxId.Text + "-L"; ;
            tb_xl_sjbm.Text = textBoxId.Text + "-XL";
            tb_xxl_sjbm.Text = textBoxId.Text + "-XXL";
            tb_lsdz_sjbm.Text = textBoxId.Text + "-DZ";
        }

        private void textBoxPrice_TextChanged(object sender, EventArgs e)
        {
            tb_xs_jg.Text = textBoxPrice.Text;
            tb_s_jg.Text = textBoxPrice.Text;
            tb_m_jg.Text = textBoxPrice.Text;
            tb_l_jg.Text = textBoxPrice.Text;
            tb_xl_jg.Text = textBoxPrice.Text;
            tb_xxl_jg.Text = textBoxPrice.Text;
            tb_lsdz_jg.Text = textBoxPrice.Text;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "打开图片";
            dlg.Filter = "jpg files (*.jpg)|*.jpg";
            dlg.Multiselect = true;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                foreach (string fileName in dlg.FileNames)
                {
                    //resize file to normal and thumbnail
                    using (Bitmap bitmap = (Bitmap)Image.FromFile(fileName))
                    {
                        dress.pictures.Add(dress.pictures.Count + 1, getImage(bitmap, 800, 600));
                        dress.thumbnails.Add(dress.thumbnails.Count + 1, getImage(bitmap, 100, 100));
                    }
                    if (dress.pictures.Count > 7) { break; }
                }
                showThumbnail();
            }
        }

        private void showThumbnail()
        {
            for (int i = 1; i < 9; i++)
            {
                if (dress.thumbnails.Count >= i)
                {
                    pictureBoxes[i].Image = new Bitmap(new MemoryStream(dress.thumbnails[i]));
                }
                else
                {
                    pictureBoxes[i].Image = null;
                }
            }
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

        private void pictureBox_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isLeftClick = true;
            }
            if (e.Button == MouseButtons.Right)
            {
                isLeftClick = false;
            }
            selectedPictureBox = (PictureBox)sender;
            timerImage.Start();
        }


        private void pictureBox_DoubleClick(object sender, MouseEventArgs e)
        {
            timerImage.Stop();
            if (e.Button == MouseButtons.Left)
            {
                int index = pictureBoxes.FirstOrDefault(q => q.Value == (PictureBox)sender).Key;
                Form dressImageShow = new DressImageShow(new Bitmap(new MemoryStream(dress.pictures[index])));
                dressImageShow.ShowDialog();
            }
        }

        private void timerImage_Tick(object sender, EventArgs e)
        {
            timerImage.Stop();
            if (selectedPictureBox.Image != null)
            {
                int index = pictureBoxes.FirstOrDefault(q => q.Value == selectedPictureBox).Key;
                if (isLeftClick)
                {
                    byte[] image = dress.pictures[index];
                    dress.pictures[index] = dress.pictures[1];
                    dress.pictures[1] = image;
                    image = dress.thumbnails[index];
                    dress.thumbnails[index] = dress.thumbnails[1];
                    dress.thumbnails[1] = image;
                }
                else
                {
                    for (int i = index; i < dress.pictures.Count; i++)
                    {
                        dress.pictures[i] = dress.pictures[i + 1];
                        dress.thumbnails[i] = dress.thumbnails[i + 1];
                    }
                    dress.pictures.Remove(dress.pictures.Count);
                    dress.thumbnails.Remove(dress.thumbnails.Count);
                }
                showThumbnail();
            }
        }
    }
}
