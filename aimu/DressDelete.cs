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
    public partial class DressDelete : Form
    {
        public DressDelete()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form fop = new DressProperties(1);//1更新商品
            fop.ShowDialog();
            if (Sharevariables.getWeddingDressID() != "" && Sharevariables.getWeddingDressID() != null)
            {
                wd_id.Text = Sharevariables.getWeddingDressID();
                loadProperties(wd_id.Text);
                loadPics(wd_id.Text);
                loadPropertiesSizeAndNumber(wd_id.Text);
            }
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
                    if (File.Exists(@fileName))
                    {
                        pb[int.Parse(picNameList[i].pic_id) - 1].Image = new Bitmap(fileName);
                    }
                    else
                    {
                        ReadData.getPic(wd_id);
                        pb[int.Parse(picNameList[i].pic_id) - 1].Image = new Bitmap(fileName);
                    }

                    //save picArray
                    if (i == 0)
                    {
                        picDataInfo.picPath1 = fileName;
                    }
                    if (i == 1)
                    {
                        picDataInfo.picPath2 = fileName;
                    }
                    if (i == 2)
                    {
                        picDataInfo.picPath3 = fileName;
                    }
                    if (i == 3)
                    {
                        picDataInfo.picPath4 = fileName;
                    }
                    if (i == 4)
                    {
                        picDataInfo.picPath5 = fileName;
                    }
                    if (i == 5)
                    {
                        picDataInfo.picPath6 = fileName;
                    }
                    if (i == 6)
                    {
                        picDataInfo.picPath7 = fileName;
                    }
                    if (i == 7)
                    {
                        picDataInfo.picPath8 = fileName;
                    }
                    if (i == 8)
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

        private void button1_Click(object sender, EventArgs e)
        {

            //更新操作就是：先删在插入

            if (wd_id.Text.Trim() == "")
            {
                MessageBox.Show("商品编号不能为空！");
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
                MessageBox.Show("商品删除失败，请重试！" + ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
