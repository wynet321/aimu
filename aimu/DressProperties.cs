using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Data;

namespace aimu
{
    public partial class DressProperties : Form
    {

        public DressProperties()
        {
            InitializeComponent();
            initial();
        }

        public DressProperties(int selectWeddingDress)//1 更新礼服
        {
            InitializeComponent();
            initial();
            buttonSelect.Visible = true;
            buttonTryon.Visible = false;
        }

        public DressProperties(string wd_id)
        {
            InitializeComponent();
            initial();
            textBoxDressId.Text = wd_id;
            listBoxIds.Items.Add(wd_id);
            listBoxIds.SelectedIndex = 0;
            textBoxDressId.Enabled = false;
            listBoxIds.Enabled = false;
            buttonSearch.Enabled = false;
            buttonSelect.Enabled = false;
            buttonTryon.Enabled = false;
        }

        private void initial()
        {
            clearPics();
            textBoxDressId.Text = "";
            buttonSelect.Visible = false;
            buttonTryon.Visible = true;

        }

        private void loadCollisionPeriod(String wd_id)
        {
            //List<CollisionPeriodManager> wdasn = ReadData.getCollisionPeriodManager(wd_id);
            DataTable wdasn = ReadData.getCollisionPeriodManager(wd_id);
            dataGridViewOrders.DataSource = wdasn;
            //    string tmpText = String.Format("{0,-10}  {1,-10}  {2, -10}   {3,-10}  {4,-10}  {5,-10} \r\n", "编号", "尺码", "婚期", "新娘姓名", "新娘联系方式", "客户ID");



            //for (int i = 0; i < wdasn.Count; i++)
            //{
            //    tmpText += String.Format("{0,-10}  {1,-10}  {2, -10}   {3,-10}  {4,-10}  {5,-10}\r\n", wdasn[i].wd_id.Trim(), wdasn[i].wd_size.Trim(), wdasn[i].marryDay.Trim(), wdasn[i].brideName.Trim(), wdasn[i].brideContact.Trim(), wdasn[i].customerID.Trim());
            //}

            //textBox1.Text += tmpText;

        }

        private void loadPropertiesSizeAndNumber(String wd_id)
        {

            // List<WeddingDressSizeAndCount> wdasn = ReadData.getWeddingDressPropertiesSizeAndNumber(wd_id);
            DataTable wdasn = ReadData.getDressProperties(wd_id);
            dataGridViewDress.DataSource = wdasn;

            // string tmpText = String.Format("{0,-10}  {1,-10}  {2, -10}   {3,-10}  {4,-10}  {5,-10}  {6,-10}  {7,-10} \r\n", "编号", "尺码", "价格", "货号", "上市时间", "数量", "商家编码", "条形码");

            //// string tmpText = "ID" + "            " + "尺码" + "          " + "价格" + "          " + "货号" + "            " + "上市时间" + "      " + "数量" + "  " + "商家编码" + "     " + "条形码" + "\r\n";

            // for (int i=0;i<wdasn.Count;i++)
            // {
            //     tmpText += String.Format("{0,-10}  {1,-10}  {2, -10}   {3,-10}  {4,-10}  {5,-10}  {6,-10}  {7,-10} \r\n", wdasn[i].wd_id.Trim(), wdasn[i].wd_size.Trim() , wdasn[i].wd_price.Trim() , wdasn[i].wd_huohao.Trim() ,wdasn[i].wd_listing_date.Trim() , wdasn[i].wd_count.Trim() , wdasn[i].wd_merchant_code.Trim() , wdasn[i].wd_barcode.Trim());
            //     //tmpText += wdasn[i].wd_id.Trim() + "    " + wdasn[i].wd_size.Trim() + "    " + wdasn[i].wd_price.Trim() + "    " + wdasn[i].wd_huohao.Trim() + "    " + wdasn[i].wd_listing_date.Trim() + "    " + wdasn[i].wd_count.Trim() + "    " + wdasn[i].wd_merchant_code.Trim() + "    " + wdasn[i].wd_barcode.Trim() + "\r\n";
            // }

            // textBox1.Text += tmpText;

        }



        private void loadProperties(String wd_id)
        {
            WeddingDressProperties wdp = ReadData.getWeddingDressProperties(wd_id);

            string tmpText = "";
            tmpText += "礼服编号: " + wdp.wd_id.Trim() + "\r\n";
            tmpText += "入库日期: " + wdp.wd_date.Trim() + "\r\n";
            tmpText += "礼服大类: " + wdp.wd_big_category.Trim() + "\r\n";
            tmpText += "礼服小类: " + wdp.wd_litter_category.Trim() + "\r\n";
            tmpText += "厂家: " + wdp.wd_factory.Trim() + "\r\n";
            tmpText += "颜色: " + wdp.wd_color.Trim() + "\r\n";
            tmpText += "紧急工期: " + wdp.emergency_period.Trim() + "天\r\n";
            tmpText += "正常工期: " + wdp.normal_period.Trim() + "天\r\n";
            tmpText += "是否返单: " + wdp.is_renew.Trim() + "\r\n";

            /*
            tmpText += "面料-蕾丝: " + (wdp.cpml_ls.Trim().Equals("True") ? "√" : "×") + "\r\n";
            tmpText += "面料-网纱: " + (wdp.cpml_ws.Trim().Equals("True") ? "√" : "×") + "\r\n";
            tmpText += "面料-缎: " + (wdp.cpml_duan.Trim().Equals("True") ? "√" : "×") + "\r\n";
            tmpText += "面料-真丝: " + (wdp.cpml_zs.Trim().Equals("True") ? "√" : "×") + "\r\n";
            tmpText += "面料-其他: " + (wdp.cpml_other.Trim().Equals("True") ? "√" : "×") + "\r\n";
            tmpText += "产品摆型-鱼尾: " + (wdp.cpbx_yw.Trim().Equals("True") ? "√" : "×") + "\r\n";
            tmpText += "产品摆型-蓬蓬裙: " + (wdp.cpbx_ppq.Trim().Equals("True") ? "√" : "×") + "\r\n";
            tmpText += "产品摆型-A摆: " + (wdp.cpbx_ab.Trim().Equals("True") ? "√" : "×") + "\r\n";
            tmpText += "产品摆型-短裙: " + (wdp.cpbx_dq.Trim().Equals("True") ? "√" : "×") + "\r\n";
            tmpText += "产品摆型-前短后长: " + (wdp.cpbx_qdhc.Trim().Equals("True") ? "√" : "×") + "\r\n";
            tmpText += "摆尾长度-齐地: " + (wdp.bwcd_qd.Trim().Equals("True") ? "√" : "×") + "\r\n";
            tmpText += "摆尾长度-小拖尾: " + (wdp.bwcd_xtw.Trim().Equals("True") ? "√" : "×") + "\r\n";
            tmpText += "摆尾长度-中拖尾: " + (wdp.bwcd_ztw.Trim().Equals("True") ? "√" : "×") + "\r\n";
            tmpText += "摆尾长度-长拖尾: " + (wdp.bwcd_ctw.Trim().Equals("True") ? "√" : "×") + "\r\n";
            tmpText += "摆尾长度-豪华拖尾: " + (wdp.bwcd_hhtw.Trim().Equals("True") ? "√" : "×") + "\r\n";
            tmpText += "产品领型-抹胸: " + (wdp.cplx_mx.Trim().Equals("True") ? "√" : "×") + "\r\n";
            tmpText += "产品领型-深V: " + (wdp.cplx_sv.Trim().Equals("True") ? "√" : "×") + "\r\n";
            tmpText += "产品领型-一字肩: " + (wdp.cplx_yzj.Trim().Equals("True") ? "√" : "×") + "\r\n";
            tmpText += "产品领型-吊带: " + (wdp.cplx_dd.Trim().Equals("True") ? "√" : "×") + "\r\n";
            tmpText += "产品领型-单肩: " + (wdp.cplx_dj.Trim().Equals("True") ? "√" : "×") + "\r\n";
            tmpText += "产品领型-挂脖: " + (wdp.cplx_gb.Trim().Equals("True") ? "√" : "×") + "\r\n";
            tmpText += "产品领型-圆领: " + (wdp.cplx_yl.Trim().Equals("True") ? "√" : "×") + "\r\n";
            tmpText += "产品领型-立领: " + (wdp.cplx_ll.Trim().Equals("True") ? "√" : "×") + "\r\n";
            tmpText += "流行元素-绑带: " + (wdp.lxys_bd.Trim().Equals("True") ? "√" : "×") + "\r\n";
            tmpText += "流行元素-拉链: " + (wdp.lxys_ll.Trim().Equals("True") ? "√" : "×") + "\r\n";
            tmpText += "流行元素-露背: " + (wdp.lxys_lb.Trim().Equals("True") ? "√" : "×") + "\r\n";
            */


            if (wdp.cpml_ls.Trim().Equals("True"))
            {
                tmpText += "面料-蕾丝: √\r\n";
            }
            if (wdp.cpml_ws.Trim().Equals("True"))
            {
                tmpText += "面料-网纱: √\r\n";
            }
            if (wdp.cpml_duan.Trim().Equals("True"))
            {
                tmpText += "面料-缎: √\r\n";
            }
            if (wdp.cpml_zs.Trim().Equals("True"))
            {
                tmpText += "面料-真丝: √\r\n";
            }
            if (wdp.cpml_other.Trim().Equals("True"))
            {
                tmpText += "面料-其他: √\r\n";
            }
            if (wdp.cpbx_yw.Trim().Equals("True"))
            {
                tmpText += "产品摆型-鱼尾: √\r\n";
            }
            if (wdp.cpbx_ppq.Trim().Equals("True"))
            {
                tmpText += "产品摆型-蓬蓬裙: √\r\n";
            }
            if (wdp.cpbx_ab.Trim().Equals("True"))
            {
                tmpText += "产品摆型-A摆: √\r\n";
            }
            if (wdp.cpbx_dq.Trim().Equals("True"))
            {
                tmpText += "产品摆型-短裙: √\r\n";
            }
            if (wdp.cpbx_qdhc.Trim().Equals("True"))
            {
                tmpText += "产品摆型-前短后长: √\r\n";
            }
            if (wdp.bwcd_qd.Trim().Equals("True"))
            {
                tmpText += "摆尾长度-齐地: √\r\n";
            }
            if (wdp.bwcd_xtw.Trim().Equals("True"))
            {
                tmpText += "摆尾长度-小拖尾: √\r\n";
            }
            if (wdp.bwcd_ztw.Trim().Equals("True"))
            {
                tmpText += "摆尾长度-中拖尾: √\r\n";
            }

            if (wdp.bwcd_ctw.Trim().Equals("True"))
            {
                tmpText += "摆尾长度-长拖尾: √\r\n";
            }
            if (wdp.bwcd_hhtw.Trim().Equals("True"))
            {
                tmpText += "摆尾长度-豪华拖尾: √\r\n";
            }
            if (wdp.cplx_mx.Trim().Equals("True"))
            {
                tmpText += "产品领型-抹胸: √\r\n";
            }
            if (wdp.cplx_sv.Trim().Equals("True"))
            {
                tmpText += "产品领型-深V: √\r\n";
            }
            if (wdp.cplx_yzj.Trim().Equals("True"))
            {
                tmpText += "产品领型-一字肩:√\r\n";
            }
            if (wdp.cplx_dd.Trim().Equals("True"))
            {
                tmpText += "产品领型-吊带: √\r\n";
            }
            if (wdp.cplx_dj.Trim().Equals("True"))
            {
                tmpText += "产品领型-单肩: √\r\n";
            }
            if (wdp.cplx_gb.Trim().Equals("True"))
            {
                tmpText += "产品领型-挂脖: √\r\n";
            }
            if (wdp.cplx_yl.Trim().Equals("True"))
            {
                tmpText += "产品领型-圆领: √\r\n";
            }
            if (wdp.cplx_ll.Trim().Equals("True"))
            {
                tmpText += "产品领型-立领: √\r\n";
            }
            if (wdp.lxys_bd.Trim().Equals("True"))
            {
                tmpText += "流行元素-绑带: √\r\n";
            }
            if (wdp.lxys_ll.Trim().Equals("True"))
            {
                tmpText += "流行元素-拉链: √\r\n";
            }
            if (wdp.lxys_lb.Trim().Equals("True"))
            {
                tmpText += "流行元素-露背: √\r\n";
            }


            tmpText += "备注: " + wdp.memo.Trim() + "\r\n";

            textBox1.Text = tmpText;
        }

        private void loadPics(String wd_id)
        {
            clearPics();
            List<PicName> picNameList = ReadData.getPicName(wd_id);
            if (picNameList.Count == 0)
            {
                return;
            }

            PictureBox[] pb = getPicArray();

            for (int i = 0; i < picNameList.Count; i++)
            {
                try
                {
                    string fileName = "./images/" + picNameList[i].wd_id.Trim() + "_" + picNameList[i].pic_id.Trim() + "_" + picNameList[i].pic_name.Trim();
                    if (File.Exists(@fileName))
                    {
                        pb[int.Parse(picNameList[i].pic_id) - 1].Image = new Bitmap(fileName);
                    }
                    else
                    {
                        ReadData.getPic(wd_id);
                        pb[int.Parse(picNameList[i].pic_id) - 1].Image = new Bitmap(fileName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }


        }

        private PictureBox[] getPicArray()
        {
            PictureBox[] pb = new PictureBox[9];
            pb[0] = pictureBox1;
            pb[1] = pictureBox2;
            pb[2] = pictureBox3;
            pb[3] = pictureBox4;
            pb[4] = pictureBox5;
            pb[5] = pictureBox6;
            pb[6] = pictureBox7;
            pb[7] = pictureBox8;
            pb[8] = pictureBox9;
            return pb;
        }


        private void clearPics()
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
            if (pictureBox1.Image == null)
            {
                return;
            }

            Form sbp = new ShowBigPics(pictureBox1.Image);
            sbp.ShowDialog();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image == null)
            {
                return;
            }

            Form sbp = new ShowBigPics(pictureBox2.Image);
            sbp.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (pictureBox3.Image == null)
            {
                return;
            }

            Form sbp = new ShowBigPics(pictureBox3.Image);
            sbp.ShowDialog();

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (pictureBox4.Image == null)
            {
                return;
            }

            Form sbp = new ShowBigPics(pictureBox4.Image);
            sbp.ShowDialog();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (pictureBox5.Image == null)
            {
                return;
            }

            Form sbp = new ShowBigPics(pictureBox5.Image);
            sbp.ShowDialog();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (pictureBox6.Image == null)
            {
                return;
            }

            Form sbp = new ShowBigPics(pictureBox6.Image);
            sbp.ShowDialog();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            if (pictureBox7.Image == null)
            {
                return;
            }

            Form sbp = new ShowBigPics(pictureBox7.Image);
            sbp.ShowDialog();

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (pictureBox8.Image == null)
            {
                return;
            }

            Form sbp = new ShowBigPics(pictureBox8.Image);
            sbp.ShowDialog();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            if (pictureBox9.Image == null)
            {
                return;
            }

            Form sbp = new ShowBigPics(pictureBox9.Image);
            sbp.ShowDialog();
        }

        //private void treeView2_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        //{
        //    String wd_id = treeView2.SelectedNode.FullPath.ToString();
        //    OMWeddingDressProperties omdp = new OMWeddingDressProperties(wd_id);
        //    omdp.ShowDialog();

        //}

        private void FormOutput_FormClosing(object sender, FormClosingEventArgs e)
        {
            clearPics();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (textBoxDressId.Text.Length > 0)
            {
                string wd_id = textBoxDressId.Text.Trim();
                listBoxIds.DataSource = ReadData.getWeddingDressIds(wd_id);
            }
        }

        private void buttonTryon_Click(object sender, EventArgs e)
        {
            if (listBoxIds.SelectedItem == null)
            {
                MessageBox.Show("请选择货号！");
                listBoxIds.Focus();
            }
            else
            {
                string wd_id = listBoxIds.SelectedItem.ToString();
                OMWeddingDressProperties omdp = new OMWeddingDressProperties(wd_id);
                omdp.ShowDialog();
            }
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            if (listBoxIds.SelectedItem == null)
            {
                MessageBox.Show("请选择货号！");
                listBoxIds.Focus();
            }
            else
            {
                string wd_id = listBoxIds.SelectedItem.ToString();
                Sharevariables.setWeddingDressID(wd_id);
                this.Close();
                //MessageBox.Show("选定婚纱礼服编号：" + Sharevariables.getWeddingDressID());
            }
        }

        private void textBoxDressId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                buttonSearch_Click(sender, e);
            }
        }

        private void listBoxIds_SelectedIndexChanged(object sender, EventArgs e)
        {
            string wd_id = listBoxIds.SelectedItem.ToString();
            textBox1.Text = "";
            loadPics(wd_id);
            loadProperties(wd_id);
            loadPropertiesSizeAndNumber(wd_id);
            loadCollisionPeriod(wd_id);
        }

        private void DressProperties_Load(object sender, EventArgs e)
        {
            textBoxDressId.Focus();
        }
    }
}

