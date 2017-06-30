using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aimu
{
    public partial class DressAddProperties : Form
    {
        public DressAddProperties()
        {
            InitializeComponent();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            DialogResult dialogResult = MessageBox.Show("确定要取消吗？", "取消", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            if (wd_id.Text.Trim()=="")
            {
                MessageBox.Show("商品编号不能为空！");
                wd_id.Focus();
                return;
            }

            try
            {
                bool bResult=SaveData.InsertWeddingDressProperties(wd_id.Text.Trim(), wd_date.Value.ToString("yyyy-MM-dd"), wd_big_category.Text.Trim(), wd_litter_category.Text.Trim(), wd_factory.Text.Trim(), wd_color.Text.Trim(), cpml_ls.Checked.ToString(), cpml_ws.Checked.ToString(), cpml_duan.Checked.ToString(), cpml_zs.Checked.ToString(), cpml_other.Checked.ToString(), cpbx_yw.Checked.ToString(), cpbx_ppq.Checked.ToString(), cpbx_ab.Checked.ToString(), cpbx_dq.Checked.ToString(), cpbx_qdhc.Checked.ToString(), bwcd_qd.Checked.ToString(), bwcd_xtw.Checked.ToString(), bwcd_ztw.Checked.ToString(), bwcd_ctw.Checked.ToString(), bwcd_hhtw.Checked.ToString(), cplx_mx.Checked.ToString(), cplx_sv.Checked.ToString(), cplx_yzj.Checked.ToString(), cplx_dd.Checked.ToString(), cplx_dj.Checked.ToString(), cplx_gb.Checked.ToString(), cplx_yl.Checked.ToString(), cplx_ll.Checked.ToString(), lxys_bd.Checked.ToString(), lxys_ll.Checked.ToString(), lxys_lb.Checked.ToString(), memo.Text.Trim(), tb_emergency_period.Text.Trim(), tb_normal_period.Text.Trim(), cb_is_renew.Text.Trim());
                
                if (bResult)
                {
                    bool bResult2 = saveSizeAndCount(wd_id.Text.Trim());
                    bool bResultPic = savePicAll();

                    if (bResult2 && bResultPic)
                    {
                        MessageBox.Show("保存成功,请继续录入商品！");
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("婚纱商品插入失败，请重试！"+ex.ToString());
            }
        }


        private bool savePicAll()
        {
            if (picDataInfo.picPath1!="")
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

        private bool savePic(string wd_id,string picID,string picPath)
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
            SaveData.InsertWeddingDressSizeAndNumber(wd_id,"XS", tb_xs_jg.Text.Trim(), tb_xs_hh.Text.Trim(), dt_xs_sssj.Value.ToString("yyyy-MM-dd"), Convert.ToInt32(tb_xs_sl.Text), tb_xs_sjbm.Text.Trim(), tb_xs_txm.Text.Trim(), Convert.ToInt32(tb_xs_sl.Text));
            SaveData.InsertWeddingDressSizeAndNumber(wd_id, "S", tb_s_jg.Text.Trim(), tb_s_hh.Text.Trim(), dt_s_sssj.Value.ToString("yyyy-MM-dd"), Convert.ToInt32(tb_s_sl.Text), tb_s_sjbm.Text.Trim(), tb_s_txm.Text.Trim(), Convert.ToInt32(tb_s_sl.Text));
            SaveData.InsertWeddingDressSizeAndNumber(wd_id, "M", tb_m_jg.Text.Trim(), tb_m_hh.Text.Trim(), dt_m_sssj.Value.ToString("yyyy-MM-dd"), Convert.ToInt32(tb_m_sl.Text), tb_m_sjbm.Text.Trim(), tb_m_txm.Text.Trim(), Convert.ToInt32(tb_m_sl.Text));
            SaveData.InsertWeddingDressSizeAndNumber(wd_id, "L", tb_l_jg.Text.Trim(), tb_l_hh.Text.Trim(), dt_l_sssj.Value.ToString("yyyy-MM-dd"), Convert.ToInt32(tb_l_sl.Text), tb_l_sjbm.Text.Trim(), tb_l_txm.Text.Trim(), Convert.ToInt32(tb_l_sl.Text));
            SaveData.InsertWeddingDressSizeAndNumber(wd_id, "XL", tb_xl_jg.Text.Trim(), tb_xl_hh.Text.Trim(), dt_xl_sssj.Value.ToString("yyyy-MM-dd"), Convert.ToInt32(tb_xl_sl.Text), tb_xl_sjbm.Text.Trim(), tb_xl_txm.Text.Trim(), Convert.ToInt32(tb_xl_sl.Text));
            SaveData.InsertWeddingDressSizeAndNumber(wd_id, "XXL", tb_xxl_jg.Text.Trim(), tb_xxl_hh.Text.Trim(), dt_xxl_sssj.Value.ToString("yyyy-MM-dd"), Convert.ToInt32(tb_xxl_sl.Text), tb_xxl_sjbm.Text.Trim(), tb_xxl_txm.Text.Trim(), Convert.ToInt32(tb_xxl_sl.Text));
            bResult=SaveData.InsertWeddingDressSizeAndNumber(wd_id, "LSDZ", tb_lsdz_jg.Text.Trim(), tb_lsdz_hh.Text.Trim(), dt_lsdz_sssj.Value.ToString("yyyy-MM-dd"), Convert.ToInt32(tb_lsdz_sl.Text), tb_lsdz_sjbm.Text.Trim(), tb_lsdz_txm.Text.Trim(), Convert.ToInt32(tb_lsdz_sl.Text));


            return bResult;
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = wd_big_category.Text.Trim();
            wd_litter_category.Items.Clear();
            switch (value)
            {
                case "婚纱":
                    //齐地白纱、小拖白纱、大拖白纱、鱼尾白纱、彩纱
                    wd_litter_category.Text="齐地白纱";
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

        private void tb_xs_hh_TextChanged(object sender, EventArgs e)
        {

        }

        private void tb_xs_sjbm_TextChanged(object sender, EventArgs e)
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
    }
}
