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
    public partial class OMWeddingDressProperties : Form
    {
        public OMWeddingDressProperties()
        {
            InitializeComponent();
        }

        private void OMWeddingDressProperties_Load(object sender, EventArgs e)
        {
            this.tbComstomer.Text = Sharevariables.getCustomerName();
            this.txCustomerID.Text = Sharevariables.getCustomerID();

        }

        public OMWeddingDressProperties(string weddingDressID)
        {
            InitializeComponent();
            initTitle();
            loadProperties(weddingDressID);
            loadPropertiesSizeAndNumber(weddingDressID);
        }

        private void initTitle()
        {
            lvWeddingDressStock.Columns.Add("尺码", 80, HorizontalAlignment.Center);
            lvWeddingDressStock.Columns.Add("价格", 80, HorizontalAlignment.Center);
            lvWeddingDressStock.Columns.Add("货号", 80, HorizontalAlignment.Center);
            lvWeddingDressStock.Columns.Add("上市时间", 80, HorizontalAlignment.Center);
            lvWeddingDressStock.Columns.Add("数量", 80, HorizontalAlignment.Center);
            lvWeddingDressStock.Columns.Add("商家编码", 80, HorizontalAlignment.Center);
            lvWeddingDressStock.Columns.Add("条形码", 80, HorizontalAlignment.Center);


            lvWeddingDressOrder.Columns.Add("礼服编号", 80, HorizontalAlignment.Center);
            lvWeddingDressOrder.Columns.Add("尺码", 80, HorizontalAlignment.Center);
            lvWeddingDressOrder.Columns.Add("价格", 80, HorizontalAlignment.Center);
            lvWeddingDressOrder.Columns.Add("货号", 80, HorizontalAlignment.Center);
            lvWeddingDressOrder.Columns.Add("上市时间", 80, HorizontalAlignment.Center);
            lvWeddingDressOrder.Columns.Add("数量", 80, HorizontalAlignment.Center);
            lvWeddingDressOrder.Columns.Add("商家编码", 80, HorizontalAlignment.Center);
            lvWeddingDressOrder.Columns.Add("条形码", 80, HorizontalAlignment.Center);
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
            this.tb_is_renew.Text = wdp.is_renew;

        }

        private void loadPropertiesSizeAndNumber(String wd_id)
        {
            List<WeddingDressSizeAndCount> wdasn = ReadData.getWeddingDressPropertiesSizeAndNumber(wd_id);
  
            this.lvWeddingDressStock.BeginUpdate();   //数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度  

            for (int i = 0; i < wdasn.Count; i++)
            {
                
                ListViewItem item = new ListViewItem();
                item.SubItems.Clear();

                
                item.SubItems[0].Text = wdasn[i].wd_size.Trim();
                item.SubItems.Add(wdasn[i].wd_price.Trim());
                item.SubItems.Add(wdasn[i].wd_huohao.Trim());
                item.SubItems.Add(wdasn[i].wd_listing_date.Trim());
                item.SubItems.Add(wdasn[i].wd_count.Trim());
                item.SubItems.Add(wdasn[i].wd_merchant_code.Trim());
                item.SubItems.Add(wdasn[i].wd_barcode.Trim());
                lvWeddingDressStock.Items.Add(item);
            }


            this.lvWeddingDressStock.EndUpdate();  //结束数据处理，UI界面一次性绘制。  


        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txCustomerID.Text.Trim()=="")
            {
                MessageBox.Show("客户编号不能为空！");
                return;
            }


            if (lvWeddingDressStock.SelectedItems.Count > 0)
            {
                string stockCount = lvWeddingDressStock.SelectedItems[0].SubItems[4].Text;
                try
                {
                    if (Int32.Parse(stockCount) <= 0)
                    {
                        
                        DialogResult dialogResult = MessageBox.Show("库存不足，是否强制加入试穿列表？", "退出", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            int iCount = lvWeddingDressStock.SelectedItems[0].SubItems.Count;
                            ListViewItem item = new ListViewItem();
                            item.SubItems.Clear();
                            item.SubItems[0].Text = this.wd_id.Text.Trim();
                            for (int i = 0; i < iCount; i++)
                            {
                                item.SubItems.Add(lvWeddingDressStock.SelectedItems[0].SubItems[i].Text);
                            }
                            lvWeddingDressOrder.Items.Add(item);
                        }

                    }
                    else
                    {
                        int iCount = lvWeddingDressStock.SelectedItems[0].SubItems.Count;
                        ListViewItem item = new ListViewItem();
                        item.SubItems.Clear();
                        item.SubItems[0].Text = this.wd_id.Text.Trim();
                        for (int i = 0; i < iCount; i++)
                        {
                            item.SubItems.Add(lvWeddingDressStock.SelectedItems[0].SubItems[i].Text);
                        }
                        lvWeddingDressOrder.Items.Add(item);
                    }
                }
                catch (Exception ef)
                {
                    MessageBox.Show(ef.ToString());
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Sharevariables.setCustomerID("");
            Sharevariables.setCustomerName("");
            Form nc = new CMQueryCustormer(true);
            //Form nc = new CMCurrentCustomerBookList(true);
            nc.ShowDialog();
            this.txCustomerID.Text = Sharevariables.getCustomerID();
            this.tbComstomer.Text = Sharevariables.getCustomerName();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Sharevariables.getCustomerID()!="")
            {
                //TruncateTable.deleteByCustomerID(Sharevariables.getCustomerID());//先删除预约列表

                
                if (lvWeddingDressOrder.Items.Count>0)
                {
                    DateTime time = DateTime.Now;             // Use current time.
                    string format = "yyyyMMddhhmmss";

                    foreach (ListViewItem itemRow in this.lvWeddingDressOrder.Items)
                    {
                     // SaveData.InsertCustomerTryDressList(Sharevariables.getCustomerID(), itemRow.SubItems[0].Text, itemRow.SubItems[1].Text, time.ToString(format), "", itemRow.SubItems[2].Text);
                    }
                    MessageBox.Show("保存成功！");
                    this.Close();
                }

                
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (lvWeddingDressOrder.SelectedItems.Count > 0)
            {
                lvWeddingDressOrder.SelectedItems[0].Remove();
            }
        }
    }
}
