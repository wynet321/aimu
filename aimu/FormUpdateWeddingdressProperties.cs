using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;



namespace aimu
{
    public partial class FormUpdateWeddingdressProperties : Form
    {
        public FormUpdateWeddingdressProperties()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form fop = new DressProperties(1);//1更新礼服
            fop.ShowDialog();
            if (Sharevariables.getWeddingDressID() != "" && Sharevariables.getWeddingDressID() != null)
            {
                wd_id.Text = Sharevariables.getWeddingDressID();
                loadProperties(wd_id.Text);
                loadPics(wd_id.Text);
                loadPropertiesSizeAndNumber(wd_id.Text);
            }
        }

        private void FormUpdateWeddingdressProperties_Load(object sender, EventArgs e)
        {

        }

        private void loadPropertiesSizeAndNumber(String wd_id)
        {
            List<WeddingDressSizeAndCount> wdasn = ReadData.getWeddingDressPropertiesSizeAndNumber(wd_id);


            for (int i = 0; i < wdasn.Count; i++)
            {

                if (wdasn[i].wd_size == "XS")
                {
                    tb_xs_jg.Text = wdasn[i].wd_price;
                    tb_xs_hh.Text = wdasn[i].wd_huohao;
                    dt_xs_sssj.Text = wdasn[i].wd_listing_date;
                    tb_xs_sl.Text = wdasn[i].wd_count;
                    tb_xs_sjbm.Text = wdasn[i].wd_merchant_code;
                    tb_xs_txm.Text = wdasn[i].wd_barcode;
                }


                if (wdasn[i].wd_size == "S")
                {
                    tb_s_jg.Text = wdasn[i].wd_price;
                    tb_s_hh.Text = wdasn[i].wd_huohao;
                    dt_s_sssj.Text = wdasn[i].wd_listing_date;
                    tb_s_sl.Text = wdasn[i].wd_count;
                    tb_s_sjbm.Text = wdasn[i].wd_merchant_code;
                    tb_s_txm.Text = wdasn[i].wd_barcode;
                }


                if (wdasn[i].wd_size == "M")
                {
                    tb_m_jg.Text = wdasn[i].wd_price;
                    tb_m_hh.Text = wdasn[i].wd_huohao;
                    dt_m_sssj.Text = wdasn[i].wd_listing_date;
                    tb_m_sl.Text = wdasn[i].wd_count;
                    tb_m_sjbm.Text = wdasn[i].wd_merchant_code;
                    tb_m_txm.Text = wdasn[i].wd_barcode;
                }


                if (wdasn[i].wd_size == "L")
                {
                    tb_l_jg.Text = wdasn[i].wd_price;
                    tb_l_hh.Text = wdasn[i].wd_huohao;
                    dt_l_sssj.Text = wdasn[i].wd_listing_date;
                    tb_l_sl.Text = wdasn[i].wd_count;
                    tb_l_sjbm.Text = wdasn[i].wd_merchant_code;
                    tb_l_txm.Text = wdasn[i].wd_barcode;
                }


                if (wdasn[i].wd_size == "XL")
                {
                    tb_xl_jg.Text = wdasn[i].wd_price;
                    tb_xl_hh.Text = wdasn[i].wd_huohao;
                    dt_xl_sssj.Text = wdasn[i].wd_listing_date;
                    tb_xl_sl.Text = wdasn[i].wd_count;
                    tb_xl_sjbm.Text = wdasn[i].wd_merchant_code;
                    tb_xl_txm.Text = wdasn[i].wd_barcode;
                }

                if (wdasn[i].wd_size == "XXL")
                {
                    tb_xxl_jg.Text = wdasn[i].wd_price;
                    tb_xxl_hh.Text = wdasn[i].wd_huohao;
                    dt_xxl_sssj.Text = wdasn[i].wd_listing_date;
                    tb_xxl_sl.Text = wdasn[i].wd_count;
                    tb_xxl_sjbm.Text = wdasn[i].wd_merchant_code;
                    tb_xxl_txm.Text = wdasn[i].wd_barcode;
                }


                if (wdasn[i].wd_size == "LSDZ")
                {
                    tb_lsdz_jg.Text = wdasn[i].wd_price;
                    tb_lsdz_hh.Text = wdasn[i].wd_huohao;
                    dt_lsdz_sssj.Text = wdasn[i].wd_listing_date;
                    tb_lsdz_sl.Text = wdasn[i].wd_count;
                    tb_lsdz_sjbm.Text = wdasn[i].wd_merchant_code;
                    tb_lsdz_txm.Text = wdasn[i].wd_barcode;
                }

            }


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
                    int currentIndex = int.Parse(picNameList[i].pic_id);

                    if (File.Exists(@fileName))
                    {
                        pb[currentIndex - 1].Image = new Bitmap(fileName);
                    }
                    else
                    {
                        ReadData.getPic(wd_id);
                        pb[currentIndex - 1].Image = new Bitmap(fileName);
                    }

                    //save picArray
                    if (currentIndex == 1)
                    {
                        picDataInfo.picPath1 = fileName;
                    }
                    if (currentIndex == 2)
                    {
                        picDataInfo.picPath2 = fileName;
                    }
                    if (currentIndex == 3)
                    {
                        picDataInfo.picPath3 = fileName;
                    }
                    if (currentIndex == 4)
                    {
                        picDataInfo.picPath4 = fileName;
                    }
                    if (currentIndex == 5)
                    {
                        picDataInfo.picPath5 = fileName;
                    }
                    if (currentIndex == 6)
                    {
                        picDataInfo.picPath6 = fileName;
                    }
                    if (currentIndex == 7)
                    {
                        picDataInfo.picPath7 = fileName;
                    }
                    if (currentIndex == 8)
                    {
                        picDataInfo.picPath8 = fileName;
                    }
                    if (currentIndex == 9)
                    {
                        picDataInfo.picPath9 = fileName;
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


        private void loadProperties(String wd_id)
        {
            WeddingDressProperties wdp = ReadData.getWeddingDressProperties(wd_id);

            this.wd_id.Text = wdp.wd_id.Trim();
            this.wd_date.Text = wdp.wd_date.Trim();
            this.wd_big_category.Text = wdp.wd_big_category.Trim();
            this.wd_litter_category.Text = wdp.wd_litter_category.Trim();
            this.wd_factory.Text = wdp.wd_factory.Trim();
            this.wd_color.Text = wdp.wd_color.Trim();

            this.cpml_ls.Checked = (wdp.cpml_ls.Trim().Equals("True") ? true : false);
            this.cpml_ws.Checked = (wdp.cpml_ws.Trim().Equals("True") ? true : false);
            this.cpml_duan.Checked = (wdp.cpml_duan.Trim().Equals("True") ? true : false);
            this.cpml_zs.Checked = (wdp.cpml_zs.Trim().Equals("True") ? true : false);
            this.cpml_other.Checked = (wdp.cpml_other.Trim().Equals("True") ? true : false);
            this.cpbx_yw.Checked = (wdp.cpbx_yw.Trim().Equals("True") ? true : false);
            this.cpbx_ppq.Checked = (wdp.cpbx_ppq.Trim().Equals("True") ? true : false);
            this.cpbx_ab.Checked = (wdp.cpbx_ab.Trim().Equals("True") ? true : false);
            this.cpbx_dq.Checked = (wdp.cpbx_dq.Trim().Equals("True") ? true : false);
            this.cpbx_qdhc.Checked = (wdp.cpbx_qdhc.Trim().Equals("True") ? true : false);
            this.bwcd_qd.Checked = (wdp.bwcd_qd.Trim().Equals("True") ? true : false);
            this.bwcd_xtw.Checked = (wdp.bwcd_xtw.Trim().Equals("True") ? true : false);
            this.bwcd_ztw.Checked = (wdp.bwcd_ztw.Trim().Equals("True") ? true : false);
            this.bwcd_ctw.Checked = (wdp.bwcd_ctw.Trim().Equals("True") ? true : false);
            this.bwcd_hhtw.Checked = (wdp.bwcd_hhtw.Trim().Equals("True") ? true : false);
            this.cplx_mx.Checked = (wdp.cplx_mx.Trim().Equals("True") ? true : false);
            this.cplx_sv.Checked = (wdp.cplx_sv.Trim().Equals("True") ? true : false);
            this.cplx_yzj.Checked = (wdp.cplx_yzj.Trim().Equals("True") ? true : false);
            this.cplx_dd.Checked = (wdp.cplx_dd.Trim().Equals("True") ? true : false);
            this.cplx_dj.Checked = (wdp.cplx_dj.Trim().Equals("True") ? true : false);
            this.cplx_gb.Checked = (wdp.cplx_gb.Trim().Equals("True") ? true : false);
            this.cplx_yl.Checked = (wdp.cplx_yl.Trim().Equals("True") ? true : false);
            this.cplx_ll.Checked = (wdp.cplx_ll.Trim().Equals("True") ? true : false);
            this.lxys_bd.Checked = (wdp.lxys_bd.Trim().Equals("True") ? true : false);
            this.lxys_ll.Checked = (wdp.lxys_ll.Trim().Equals("True") ? true : false);
            this.lxys_lb.Checked = (wdp.lxys_lb.Trim().Equals("True") ? true : false);
            this.memo.Text = wdp.memo.Trim();
            this.tb_emergency_period.Text = wdp.emergency_period;
            this.tb_normal_period.Text = wdp.normal_period;
            this.cb_is_renew.Text = wdp.is_renew;

        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //更新操作就是：先删在插入

            if (wd_id.Text.Trim() == "")
            {
                MessageBox.Show("礼服编号不能为空！");
                wd_id.Focus();
                return;
            }


            //删除
            try
            {
               TruncateTable.deleteWeddingDressByID(wd_id.Text.Trim());
               TruncateTable.deleteWeddingDressSizeAndNumberByID(wd_id.Text.Trim());
               TruncateTable.deleteTblImgDataByID(wd_id.Text.Trim());

            }
            catch (Exception ex)
            {
                MessageBox.Show("婚纱礼服删除失败，请重试！" + ex.ToString());
            }


            //插入
            try
            {
                bool bResult = SaveData.InsertWeddingDressProperties(wd_id.Text.Trim(), wd_date.Value.ToString("yyyy-MM-dd"), wd_big_category.Text.Trim(), wd_litter_category.Text.Trim(), wd_factory.Text.Trim(), wd_color.Text.Trim(), cpml_ls.Checked.ToString(), cpml_ws.Checked.ToString(), cpml_duan.Checked.ToString(), cpml_zs.Checked.ToString(), cpml_other.Checked.ToString(), cpbx_yw.Checked.ToString(), cpbx_ppq.Checked.ToString(), cpbx_ab.Checked.ToString(), cpbx_dq.Checked.ToString(), cpbx_qdhc.Checked.ToString(), bwcd_qd.Checked.ToString(), bwcd_xtw.Checked.ToString(), bwcd_ztw.Checked.ToString(), bwcd_ctw.Checked.ToString(), bwcd_hhtw.Checked.ToString(), cplx_mx.Checked.ToString(), cplx_sv.Checked.ToString(), cplx_yzj.Checked.ToString(), cplx_dd.Checked.ToString(), cplx_dj.Checked.ToString(), cplx_gb.Checked.ToString(), cplx_yl.Checked.ToString(), cplx_ll.Checked.ToString(), lxys_bd.Checked.ToString(), lxys_ll.Checked.ToString(), lxys_lb.Checked.ToString(), memo.Text.Trim(), tb_emergency_period.Text.Trim(), tb_normal_period.Text.Trim(), cb_is_renew.Text.Trim());

                if (bResult)
                {
                    bool bResult2 = saveSizeAndCount(wd_id.Text.Trim());
                    bool bResultPic = savePicAll();

                    if (bResult2 && bResultPic)
                    {
                        MessageBox.Show("婚纱礼服更新成功！");
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("婚纱礼服更新失败，请重试！" + ex.ToString());
            }

            //清理工作
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

        private bool savePicAll()
        {
            if (picDataInfo.picPath1 != "")
            {
                savePic(wd_id.Text.Trim(), "1", picDataInfo.picPath1);
            }
            if (picDataInfo.picPath2 != "")
            {
                savePic(wd_id.Text.Trim(), "2", picDataInfo.picPath2);
            }
            if (picDataInfo.picPath3 != "")
            {
                savePic(wd_id.Text.Trim(), "3", picDataInfo.picPath3);
            }
            if (picDataInfo.picPath4 != "")
            {
                savePic(wd_id.Text.Trim(), "4", picDataInfo.picPath4);
            }
            if (picDataInfo.picPath5 != "")
            {
                savePic(wd_id.Text.Trim(), "5", picDataInfo.picPath5);
            }
            if (picDataInfo.picPath6 != "")
            {
                savePic(wd_id.Text.Trim(), "6", picDataInfo.picPath6);
            }
            if (picDataInfo.picPath7 != "")
            {
                savePic(wd_id.Text.Trim(), "7", picDataInfo.picPath7);
            }
            if (picDataInfo.picPath8 != "")
            {
                savePic(wd_id.Text.Trim(), "8", picDataInfo.picPath8);
            }
            if (picDataInfo.picPath9 != "")
            {
                savePic(wd_id.Text.Trim(), "9", picDataInfo.picPath9);
            }

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

        private bool savePic(string wd_id, string picID, string picPath)
        {
            long m_lImageFileLength = 0;
            byte[] m_barrImg;
            FileInfo fiImage = new FileInfo(picPath);
            m_lImageFileLength = fiImage.Length;
            FileStream fs = new FileStream(picPath, FileMode.Open, FileAccess.Read, FileShare.Read);
            m_barrImg = new byte[Convert.ToInt32(m_lImageFileLength)];
            int iBytesRead = fs.Read(m_barrImg, 0, Convert.ToInt32(m_lImageFileLength));
            fs.Close();

            SaveData.InsertPicture(wd_id, picID, Path.GetFileName(picPath), m_barrImg);
            return true;
        }

        private bool saveSizeAndCount(string wd_id)
        {
            bool bResult = false;
          /*  SaveData.InsertWeddingDressSizeAndNumber(wd_id, "XS", tb_xs_jg.Text.Trim(), tb_xs_hh.Text.Trim(), dt_xs_sssj.Text.Trim(), Convert.ToInt32(tb_xs_sl.Text), tb_xs_sjbm.Text.Trim(), tb_xs_txm.Text.Trim());
            SaveData.InsertWeddingDressSizeAndNumber(wd_id, "S", tb_s_jg.Text.Trim(), tb_s_hh.Text.Trim(), dt_s_sssj.Text.Trim(), Convert.ToInt32(tb_s_sl.Text), tb_s_sjbm.Text.Trim(), tb_s_txm.Text.Trim());
            SaveData.InsertWeddingDressSizeAndNumber(wd_id, "M", tb_m_jg.Text.Trim(), tb_m_hh.Text.Trim(), dt_m_sssj.Text.Trim(), Convert.ToInt32(tb_m_sl.Text), tb_m_sjbm.Text.Trim(), tb_m_txm.Text.Trim());
            SaveData.InsertWeddingDressSizeAndNumber(wd_id, "L", tb_l_jg.Text.Trim(), tb_l_hh.Text.Trim(), dt_l_sssj.Text.Trim(), Convert.ToInt32(tb_l_sl.Text), tb_l_sjbm.Text.Trim(), tb_l_txm.Text.Trim());
            SaveData.InsertWeddingDressSizeAndNumber(wd_id, "XL", tb_xl_jg.Text.Trim(), tb_xl_hh.Text.Trim(), dt_xl_sssj.Text.Trim(), Convert.ToInt32(tb_xl_sl.Text), tb_xl_sjbm.Text.Trim(), tb_xl_txm.Text.Trim());
            SaveData.InsertWeddingDressSizeAndNumber(wd_id, "XXL", tb_xxl_jg.Text.Trim(), tb_xxl_hh.Text.Trim(), dt_xxl_sssj.Text.Trim(), Convert.ToInt32(tb_xxl_sl.Text), tb_xxl_sjbm.Text.Trim(), tb_xxl_txm.Text.Trim());
            bResult = SaveData.InsertWeddingDressSizeAndNumber(wd_id, "LSDZ", tb_lsdz_jg.Text.Trim(), tb_lsdz_hh.Text.Trim(), dt_lsdz_sssj.Text.Trim(), Convert.ToInt32(tb_lsdz_sl.Text), tb_lsdz_sjbm.Text.Trim(), tb_lsdz_txm.Text.Trim());
            */
            SaveData.InsertWeddingDressSizeAndNumber(wd_id, "XS", tb_xs_jg.Text.Trim(), tb_xs_hh.Text.Trim(), dt_xs_sssj.Value.ToString("yyyy-MM-dd"), Convert.ToInt32(tb_xs_sl.Text), tb_xs_sjbm.Text.Trim(), tb_xs_txm.Text.Trim(), Convert.ToInt32(tb_xs_sl.Text));
            SaveData.InsertWeddingDressSizeAndNumber(wd_id, "S", tb_s_jg.Text.Trim(), tb_s_hh.Text.Trim(), dt_s_sssj.Value.ToString("yyyy-MM-dd"), Convert.ToInt32(tb_s_sl.Text), tb_s_sjbm.Text.Trim(), tb_s_txm.Text.Trim(), Convert.ToInt32(tb_s_sl.Text));
            SaveData.InsertWeddingDressSizeAndNumber(wd_id, "M", tb_m_jg.Text.Trim(), tb_m_hh.Text.Trim(), dt_m_sssj.Value.ToString("yyyy-MM-dd"), Convert.ToInt32(tb_m_sl.Text), tb_m_sjbm.Text.Trim(), tb_m_txm.Text.Trim(), Convert.ToInt32(tb_m_sl.Text));
            SaveData.InsertWeddingDressSizeAndNumber(wd_id, "L", tb_l_jg.Text.Trim(), tb_l_hh.Text.Trim(), dt_l_sssj.Value.ToString("yyyy-MM-dd"), Convert.ToInt32(tb_l_sl.Text), tb_l_sjbm.Text.Trim(), tb_l_txm.Text.Trim(), Convert.ToInt32(tb_l_sl.Text));
            SaveData.InsertWeddingDressSizeAndNumber(wd_id, "XL", tb_xl_jg.Text.Trim(), tb_xl_hh.Text.Trim(), dt_xl_sssj.Value.ToString("yyyy-MM-dd"), Convert.ToInt32(tb_xl_sl.Text), tb_xl_sjbm.Text.Trim(), tb_xl_txm.Text.Trim(), Convert.ToInt32(tb_xl_sl.Text));
            SaveData.InsertWeddingDressSizeAndNumber(wd_id, "XXL", tb_xxl_jg.Text.Trim(), tb_xxl_hh.Text.Trim(), dt_xxl_sssj.Value.ToString("yyyy-MM-dd"), Convert.ToInt32(tb_xxl_sl.Text), tb_xxl_sjbm.Text.Trim(), tb_xxl_txm.Text.Trim(), Convert.ToInt32(tb_xxl_sl.Text));
            bResult = SaveData.InsertWeddingDressSizeAndNumber(wd_id, "LSDZ", tb_lsdz_jg.Text.Trim(), tb_lsdz_hh.Text.Trim(), dt_lsdz_sssj.Value.ToString("yyyy-MM-dd"), Convert.ToInt32(tb_lsdz_sl.Text), tb_lsdz_sjbm.Text.Trim(), tb_lsdz_txm.Text.Trim(), Convert.ToInt32(tb_lsdz_sl.Text));



            return bResult;
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

        private void wd_big_category_SelectedIndexChanged(object sender, EventArgs e)
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
                    //红色礼服、彩色礼服
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
                default:
                    wd_litter_category.Text = "其他";
                    wd_litter_category.Items.Add("其他");
                    break;
            }
        }

        private void wd_litter_category_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void wd_factory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void wd_color_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tb_xs_hh_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            tb_xs_jg.Text = textBox1.Text;
            tb_s_jg.Text = textBox1.Text;
            tb_m_jg.Text = textBox1.Text;
            tb_l_jg.Text = textBox1.Text;
            tb_xl_jg.Text = textBox1.Text;
            tb_xxl_jg.Text = textBox1.Text;
            tb_lsdz_jg.Text = textBox1.Text;
        }

        private void wd_id_TextChanged(object sender, EventArgs e)
        {
            tb_xs_hh.Text = wd_id.Text;
            tb_s_hh.Text = wd_id.Text;
            tb_m_hh.Text = wd_id.Text;
            tb_l_hh.Text = wd_id.Text;
            tb_xl_hh.Text = wd_id.Text;
            tb_xxl_hh.Text = wd_id.Text;
            tb_lsdz_hh.Text = wd_id.Text;


            tb_xs_sjbm.Text = wd_id.Text + "-XS";
            tb_s_sjbm.Text = wd_id.Text + "-S";
            tb_m_sjbm.Text = wd_id.Text + "-M";
            tb_l_sjbm.Text = wd_id.Text + "-L"; ;
            tb_xl_sjbm.Text = wd_id.Text + "-XL";
            tb_xxl_sjbm.Text = wd_id.Text + "-XXL";
            tb_lsdz_sjbm.Text = wd_id.Text + "-DZ";

            tb_xs_txm.Text = tb_xs_sjbm.Text;
            tb_s_txm.Text = tb_s_sjbm.Text;
            tb_m_txm.Text = tb_m_sjbm.Text;
            tb_l_txm.Text = tb_l_sjbm.Text;
            tb_xl_txm.Text = tb_xl_sjbm.Text;
            tb_xxl_txm.Text = tb_xxl_sjbm.Text;
            tb_lsdz_txm.Text = tb_lsdz_sjbm.Text;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            //更新操作就是：先删在插入
            if (wd_id.Text.Trim() == "")
            {
                MessageBox.Show("礼服编号不能为空！");
                wd_id.Focus();
                return;
            }
            //删除
            try
            {
                TruncateTable.deleteWeddingDressByID(wd_id.Text.Trim());
                TruncateTable.deleteWeddingDressSizeAndNumberByID(wd_id.Text.Trim());
                TruncateTable.deleteTblImgDataByID(wd_id.Text.Trim());
                MessageBox.Show("删除成功！");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("婚纱礼服删除失败，请重试！" + ex.ToString());
            }
        }
    }
}
