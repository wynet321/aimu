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
    public partial class DressUpdate : Form
    {
        public DressUpdate()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form fop = new DressProperties(2);
            fop.ShowDialog();
            if (Sharevariables.WeddingDressID != "" && Sharevariables.WeddingDressID != null)
            {
                textBoxId.Text = Sharevariables.WeddingDressID;
                loadProperties(textBoxId.Text);
                loadPics(textBoxId.Text);
                loadPropertiesSizeAndNumber(textBoxId.Text);
            }
        }

        private void FormUpdateWeddingdressProperties_Load(object sender, EventArgs e)
        {

        }

        private void loadPropertiesSizeAndNumber(String wd_id)
        {
            Data dressSizeAndCount = ReadData.getWeddingDressPropertiesSizeAndNumber(wd_id);
            if (!dressSizeAndCount.Success)
            {
                this.Close();
                return;
            }
            List<WeddingDressSizeAndCount> wdsc = new List<WeddingDressSizeAndCount>();
            foreach (DataRow row in dressSizeAndCount.DataTable.Rows)
            {
                WeddingDressSizeAndCount wdsa = new WeddingDressSizeAndCount();
                wdsa.wd_id = wd_id;
                wdsa.wd_size = row[0] == null ? "" : row[0].ToString();
                wdsa.wd_price = row[1] == null ? "" : row[1].ToString();
                wdsa.wd_huohao = row[2] == null ? "" : row[2].ToString();
                wdsa.wd_listing_date = row[3] == null ? "" : row[3].ToString();
                wdsa.wd_count = row[4] == null ? "" : row[4].ToString();
                wdsa.wd_merchant_code = row[5] == null ? "" : row[5].ToString();
                wdsa.wd_barcode = row[6] == null ? "" : row[6].ToString();
                wdsc.Add(wdsa);
            }
            List<WeddingDressSizeAndCount> wdasn = wdsc;

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
            Data picNames = ReadData.getPicName(wd_id);
            if (!picNames.Success)
            {
                this.Close();
                return;
            }
            if (picNames.DataTable.Rows.Count == 0)
            {
                return;
            }

            PictureBox[] pb = getPicArray();

            for (int i = 0; i < picNames.DataTable.Rows.Count; i++)
            {
                try
                {
                    string fileName = "./images/" + picNames.DataTable.Rows[i].ItemArray[0].ToString() + "_" + picNames.DataTable.Rows[i].ItemArray[1].ToString() + "_" + picNames.DataTable.Rows[i].ItemArray[2].ToString();
                    int currentIndex = int.Parse(picNames.DataTable.Rows[i].ItemArray[1].ToString());

                    if (File.Exists(@fileName))
                    {
                        pb[currentIndex - 1].Image = new Bitmap(fileName);
                    }
                    else
                    {
                        Data pics = ReadData.getPic(wd_id);
                        if (!pics.Success)
                        {
                            this.Close();
                            return;
                        }
                        try
                        {
                            foreach (DataRow dr in pics.DataTable.Rows)
                            {
                                byte[] barrImg = (byte[])dr[3];
                                string strfn = "./images/" + ((String)dr[0]).Trim() + "_" + ((String)dr[1]).Trim() + "_" + ((String)dr[2]).Trim();
                                if (!File.Exists(@strfn))
                                {
                                    FileStream fs = new FileStream(strfn, FileMode.Create, FileAccess.Write);
                                    fs.Write(barrImg, 0, barrImg.Length);
                                    fs.Flush();
                                    fs.Close();
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            //TODO log
                            MessageBox.Show("操作失败，窗口将关闭，请发送当前文件夹下的error.log给管理员！");
                            this.Close();
                            return;
                        }
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
            Data properties = ReadData.getWeddingDressProperties(wd_id);
            if (!properties.Success)
            {
                this.Close();
                return;
            }
            WeddingDressProperties wdp = new WeddingDressProperties();
            foreach (DataRow dr in properties.DataTable.Rows)
            {
                wdp.wd_id = dr[0] == null ? "" : dr[0].ToString();
                wdp.wd_date = dr[1] == null ? "" : dr[1].ToString();
                wdp.wd_big_category = dr[2] == null ? "" : dr[2].ToString();
                wdp.wd_litter_category = dr[3] == null ? "" : dr[3].ToString();
                wdp.wd_factory = dr[4] == null ? "" : dr[4].ToString();
                wdp.wd_color = dr[5] == null ? "" : dr[5].ToString();
                wdp.cpml_ls = dr[6] == null ? "" : dr[6].ToString();
                wdp.cpml_ws = dr[7] == null ? "" : dr[7].ToString();
                wdp.cpml_duan = dr[8] == null ? "" : dr[8].ToString();
                wdp.cpml_zs = dr[9] == null ? "" : dr[9].ToString();
                wdp.cpml_other = dr[10] == null ? "" : dr[10].ToString();
                wdp.cpbx_yw = dr[11] == null ? "" : dr[11].ToString();
                wdp.cpbx_ppq = dr[12] == null ? "" : dr[12].ToString();
                wdp.cpbx_ab = dr[13] == null ? "" : dr[13].ToString();
                wdp.cpbx_dq = dr[14] == null ? "" : dr[14].ToString();
                wdp.cpbx_qdhc = dr[15] == null ? "" : dr[15].ToString();
                wdp.bwcd_qd = dr[16] == null ? "" : dr[16].ToString();
                wdp.bwcd_xtw = dr[17] == null ? "" : dr[17].ToString();
                wdp.bwcd_ztw = dr[18] == null ? "" : dr[18].ToString();
                wdp.bwcd_ctw = dr[19] == null ? "" : dr[19].ToString();
                wdp.bwcd_hhtw = dr[20] == null ? "" : dr[20].ToString();
                wdp.cplx_mx = dr[21] == null ? "" : dr[21].ToString();
                wdp.cplx_sv = dr[22] == null ? "" : dr[22].ToString();
                wdp.cplx_yzj = dr[23] == null ? "" : dr[23].ToString();
                wdp.cplx_dd = dr[24] == null ? "" : dr[24].ToString();
                wdp.cplx_dj = dr[25] == null ? "" : dr[25].ToString();
                wdp.cplx_gb = dr[26] == null ? "" : dr[26].ToString();
                wdp.cplx_yl = dr[27] == null ? "" : dr[27].ToString();
                wdp.cplx_ll = dr[28] == null ? "" : dr[28].ToString();
                wdp.lxys_bd = dr[29] == null ? "" : dr[29].ToString();
                wdp.lxys_ll = dr[30] == null ? "" : dr[30].ToString();
                wdp.lxys_lb = dr[31] == null ? "" : dr[31].ToString();
                wdp.memo = dr[32] == null ? "" : dr[32].ToString();
                wdp.emergency_period = dr[33] == null ? "" : dr[33].ToString();
                wdp.normal_period = dr[34] == null ? "" : dr[34].ToString();
                wdp.is_renew = dr[35] == null ? "" : dr[35].ToString();
                wdp.settlementPrice = decimal.Parse(dr[36].ToString());
            }
            
            this.textBoxId.Text = wdp.wd_id.Trim();
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
            textBoxSettlementPrice.Text = wdp.settlementPrice.ToString();

        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //更新操作就是：先删在插入

            if (textBoxId.Text.Trim() == "")
            {
                MessageBox.Show("商品编号不能为空！");
                textBoxId.Focus();
                return;
            }


            //删除
            try
            {
               TruncateTable.deleteWeddingDressByID(textBoxId.Text.Trim());
               TruncateTable.deleteWeddingDressSizeAndNumberByID(textBoxId.Text.Trim());
               TruncateTable.deleteTblImgDataByID(textBoxId.Text.Trim());

            }
            catch (Exception ex)
            {
                MessageBox.Show("商品删除失败，请重试！" + ex.ToString());
            }


            //插入
            try
            {
                bool bResult = SaveData.InsertWeddingDressProperties(textBoxId.Text.Trim(), wd_date.Value.ToString("yyyy-MM-dd"), wd_big_category.Text.Trim(), wd_litter_category.Text.Trim(), wd_factory.Text.Trim(), wd_color.Text.Trim(), cpml_ls.Checked.ToString(), cpml_ws.Checked.ToString(), cpml_duan.Checked.ToString(), cpml_zs.Checked.ToString(), cpml_other.Checked.ToString(), cpbx_yw.Checked.ToString(), cpbx_ppq.Checked.ToString(), cpbx_ab.Checked.ToString(), cpbx_dq.Checked.ToString(), cpbx_qdhc.Checked.ToString(), bwcd_qd.Checked.ToString(), bwcd_xtw.Checked.ToString(), bwcd_ztw.Checked.ToString(), bwcd_ctw.Checked.ToString(), bwcd_hhtw.Checked.ToString(), cplx_mx.Checked.ToString(), cplx_sv.Checked.ToString(), cplx_yzj.Checked.ToString(), cplx_dd.Checked.ToString(), cplx_dj.Checked.ToString(), cplx_gb.Checked.ToString(), cplx_yl.Checked.ToString(), cplx_ll.Checked.ToString(), lxys_bd.Checked.ToString(), lxys_ll.Checked.ToString(), lxys_lb.Checked.ToString(), memo.Text.Trim(), tb_emergency_period.Text.Trim(), tb_normal_period.Text.Trim(), cb_is_renew.Text.Trim(),decimal.Parse(textBoxSettlementPrice.Text.Trim()));

                if (bResult)
                {
                    bool bResult2 = saveSizeAndCount(textBoxId.Text.Trim());
                    bool bResultPic = savePicAll();

                    if (bResult2 && bResultPic)
                    {
                        MessageBox.Show("商品更新成功！");
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("商品更新失败，请重试！" + ex.ToString());
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
                savePic(textBoxId.Text.Trim(), "1", picDataInfo.picPath1);
            }
            if (picDataInfo.picPath2 != "")
            {
                savePic(textBoxId.Text.Trim(), "2", picDataInfo.picPath2);
            }
            if (picDataInfo.picPath3 != "")
            {
                savePic(textBoxId.Text.Trim(), "3", picDataInfo.picPath3);
            }
            if (picDataInfo.picPath4 != "")
            {
                savePic(textBoxId.Text.Trim(), "4", picDataInfo.picPath4);
            }
            if (picDataInfo.picPath5 != "")
            {
                savePic(textBoxId.Text.Trim(), "5", picDataInfo.picPath5);
            }
            if (picDataInfo.picPath6 != "")
            {
                savePic(textBoxId.Text.Trim(), "6", picDataInfo.picPath6);
            }
            if (picDataInfo.picPath7 != "")
            {
                savePic(textBoxId.Text.Trim(), "7", picDataInfo.picPath7);
            }
            if (picDataInfo.picPath8 != "")
            {
                savePic(textBoxId.Text.Trim(), "8", picDataInfo.picPath8);
            }
            if (picDataInfo.picPath9 != "")
            {
                savePic(textBoxId.Text.Trim(), "9", picDataInfo.picPath9);
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
            tb_xs_hh.Text = textBoxId.Text;
            tb_s_hh.Text = textBoxId.Text;
            tb_m_hh.Text = textBoxId.Text;
            tb_l_hh.Text = textBoxId.Text;
            tb_xl_hh.Text = textBoxId.Text;
            tb_xxl_hh.Text = textBoxId.Text;
            tb_lsdz_hh.Text = textBoxId.Text;


            tb_xs_sjbm.Text = textBoxId.Text + "-XS";
            tb_s_sjbm.Text = textBoxId.Text + "-S";
            tb_m_sjbm.Text = textBoxId.Text + "-M";
            tb_l_sjbm.Text = textBoxId.Text + "-L"; ;
            tb_xl_sjbm.Text = textBoxId.Text + "-XL";
            tb_xxl_sjbm.Text = textBoxId.Text + "-XXL";
            tb_lsdz_sjbm.Text = textBoxId.Text + "-DZ";

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
            if (textBoxId.Text.Trim() == "")
            {
                MessageBox.Show("商品编号不能为空！");
                textBoxId.Focus();
                return;
            }
            //删除
            try
            {
                TruncateTable.deleteWeddingDressByID(textBoxId.Text.Trim());
                TruncateTable.deleteWeddingDressSizeAndNumberByID(textBoxId.Text.Trim());
                TruncateTable.deleteTblImgDataByID(textBoxId.Text.Trim());
                MessageBox.Show("删除成功！");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("婚纱商品删除失败，请重试！" + ex.ToString());
            }
        }

        private void textBoxId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Data properties = ReadData.getWeddingDressProperties(textBoxId.Text.Trim());
                if (!properties.Success)
                {
                    this.Close();
                    return;
                }
                WeddingDressProperties wdp = new WeddingDressProperties();
                foreach (DataRow dr in properties.DataTable.Rows)
                {
                    wdp.wd_id = dr[0] == null ? "" : dr[0].ToString();
                    wdp.wd_date = dr[1] == null ? "" : dr[1].ToString();
                    wdp.wd_big_category = dr[2] == null ? "" : dr[2].ToString();
                    wdp.wd_litter_category = dr[3] == null ? "" : dr[3].ToString();
                    wdp.wd_factory = dr[4] == null ? "" : dr[4].ToString();
                    wdp.wd_color = dr[5] == null ? "" : dr[5].ToString();
                    wdp.cpml_ls = dr[6] == null ? "" : dr[6].ToString();
                    wdp.cpml_ws = dr[7] == null ? "" : dr[7].ToString();
                    wdp.cpml_duan = dr[8] == null ? "" : dr[8].ToString();
                    wdp.cpml_zs = dr[9] == null ? "" : dr[9].ToString();
                    wdp.cpml_other = dr[10] == null ? "" : dr[10].ToString();
                    wdp.cpbx_yw = dr[11] == null ? "" : dr[11].ToString();
                    wdp.cpbx_ppq = dr[12] == null ? "" : dr[12].ToString();
                    wdp.cpbx_ab = dr[13] == null ? "" : dr[13].ToString();
                    wdp.cpbx_dq = dr[14] == null ? "" : dr[14].ToString();
                    wdp.cpbx_qdhc = dr[15] == null ? "" : dr[15].ToString();
                    wdp.bwcd_qd = dr[16] == null ? "" : dr[16].ToString();
                    wdp.bwcd_xtw = dr[17] == null ? "" : dr[17].ToString();
                    wdp.bwcd_ztw = dr[18] == null ? "" : dr[18].ToString();
                    wdp.bwcd_ctw = dr[19] == null ? "" : dr[19].ToString();
                    wdp.bwcd_hhtw = dr[20] == null ? "" : dr[20].ToString();
                    wdp.cplx_mx = dr[21] == null ? "" : dr[21].ToString();
                    wdp.cplx_sv = dr[22] == null ? "" : dr[22].ToString();
                    wdp.cplx_yzj = dr[23] == null ? "" : dr[23].ToString();
                    wdp.cplx_dd = dr[24] == null ? "" : dr[24].ToString();
                    wdp.cplx_dj = dr[25] == null ? "" : dr[25].ToString();
                    wdp.cplx_gb = dr[26] == null ? "" : dr[26].ToString();
                    wdp.cplx_yl = dr[27] == null ? "" : dr[27].ToString();
                    wdp.cplx_ll = dr[28] == null ? "" : dr[28].ToString();
                    wdp.lxys_bd = dr[29] == null ? "" : dr[29].ToString();
                    wdp.lxys_ll = dr[30] == null ? "" : dr[30].ToString();
                    wdp.lxys_lb = dr[31] == null ? "" : dr[31].ToString();
                    wdp.memo = dr[32] == null ? "" : dr[32].ToString();
                    wdp.emergency_period = dr[33] == null ? "" : dr[33].ToString();
                    wdp.normal_period = dr[34] == null ? "" : dr[34].ToString();
                    wdp.is_renew = dr[35] == null ? "" : dr[35].ToString();
                    wdp.settlementPrice = decimal.Parse(dr[36].ToString());
                }
                
                if (wdp.wd_id!=null)
                {
                    textBoxId.Text = wdp.wd_id;
                    loadProperties(wdp.wd_id);
                    loadPics(wdp.wd_id);
                    loadPropertiesSizeAndNumber(wdp.wd_id);
                }
                else
                {
                    MessageBox.Show("无此货号！");
                    textBoxId.Focus();
                    textBoxId.SelectAll();
                }
            }
        }
    }
}
