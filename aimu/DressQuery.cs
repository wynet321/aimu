using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Data;

namespace aimu
{
    public partial class DressQuery : Form
    {
        private Dictionary<int, byte[]> images;
        public DressQuery()
        {
            InitializeComponent();
            textBoxDressId.Focus();
        }

        private void loadCollisionPeriod(String wd_id)
        {
            Data collisionPeriod = ShardDb.getCollisionPeriod(wd_id);
            if (!collisionPeriod.Success)
            {
                this.Close();
                return;
            }
            dataGridViewOrders.DataSource = collisionPeriod.DataTable;
        }

        private void loadDress(String wd_id)
        {
            Data dressProperties = ShardDb.getDressById(wd_id);
            if (!dressProperties.Success)
            {
                this.Close();
                return;
            }
            dataGridViewDress.DataSource = dressProperties.DataTable;
            dataGridViewDress.Columns["wd_size"].HeaderText = "尺寸";
            dataGridViewDress.Columns["wd_price"].HeaderText = "吊牌价格";
            dataGridViewDress.Columns["wd_listing_date"].HeaderText = "上市日期";
            dataGridViewDress.Columns["wd_count"].HeaderText = "数量";
            dataGridViewDress.Columns["storeId"].Visible = false;
            dataGridViewDress.Columns["id"].Visible = false;
        }

        private void loadDressDefinition(String wd_id)
        {
            Data properties = ShardDb.getDressDefinitionById(wd_id);
            if (!properties.Success)
            {
                this.Close();
                return;
            }
            DressDefinition wdp = new DressDefinition();
            foreach (DataRow dr in properties.DataTable.Rows)
            {
                wdp.wd_id = wd_id;
                wdp.wd_date = dr[0] == null ? "" : dr[0].ToString();
                wdp.wd_big_category = dr[1] == null ? "" : dr[1].ToString();
                wdp.wd_litter_category = dr[2] == null ? "" : dr[2].ToString();
                wdp.wd_factory = dr[3] == null ? "" : dr[3].ToString();
                wdp.wd_color = dr[4] == null ? "" : dr[4].ToString();
                wdp.attribute = Convert.ToInt32(dr[5]);
                wdp.memo = dr[6] == null ? "" : dr[6].ToString();
                wdp.emergency_period = dr[7] == null ? "" : dr[7].ToString();
                wdp.normal_period = dr[8] == null ? "" : dr[8].ToString();
                wdp.is_renew = dr[9] == null ? "" : dr[9].ToString();
                wdp.settlementPrice = dr[10] == null || dr[10].ToString() == "" ? 0 : decimal.Parse(dr[10].ToString());
            }

            string tmpText = "";
            tmpText += "商品编号: " + wdp.wd_id.Trim() + Environment.NewLine;
            tmpText += "入库日期: " + wdp.wd_date.Trim() + Environment.NewLine;
            tmpText += "商品大类: " + wdp.wd_big_category.Trim() + Environment.NewLine;
            tmpText += "商品小类: " + wdp.wd_litter_category.Trim() + Environment.NewLine;
            tmpText += "厂家: " + wdp.wd_factory.Trim() + Environment.NewLine;
            tmpText += "颜色: " + wdp.wd_color.Trim() + Environment.NewLine;
            tmpText += "紧急工期: " + wdp.emergency_period.Trim() + "天"+ Environment.NewLine;
            tmpText += "正常工期: " + wdp.normal_period.Trim() + "天"+ Environment.NewLine;
            tmpText += "是否返单: " + wdp.is_renew.Trim() + Environment.NewLine;

            tmpText += "备注: " + wdp.memo.Trim() + Environment.NewLine;

            textBox1.Text = tmpText;
        }

        private void loadPics(String wd_id)
        {
            listViewImages.Items.Clear();
            Data imageData = ShardDb.getImagesByDressId(wd_id);
            if (!imageData.Success)
            {
                this.Close();
                return;
            }
            ImageList imageList = new ImageList();
            images = new Dictionary<int, byte[]>();
            foreach (DataRow dataRow in imageData.DataTable.Rows)
            {
                images.Add(Convert.ToInt16(dataRow.ItemArray[1]), (byte[])dataRow.ItemArray[2]);
                if (dataRow.ItemArray[3] != null)
                {
                    imageList.Images.Add(dataRow.ItemArray[1].ToString(), Image.FromStream(new MemoryStream((byte[])dataRow.ItemArray[3])));
                }
            }
            imageList.ImageSize = new Size(100, 100);
            listViewImages.LargeImageList = imageList;
            for (int j = 0; j < imageList.Images.Count; j++)
            {
                ListViewItem item = new ListViewItem();
                item.ImageKey = imageList.Images.Keys[j];
                this.listViewImages.Items.Add(item);
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            search();
        }

        private void search()
        {
            if (textBoxDressId.Text.Length > 0)
            {
                string wd_id = textBoxDressId.Text.Trim();
                Data dressIds = ShardDb.getWeddingDressIds(wd_id);
                if (!dressIds.Success)
                {
                    this.Close();
                    return;
                }
                listBoxIds.DisplayMember = "wd_id";
                listBoxIds.ValueMember = "wd_id";
                listBoxIds.DataSource = dressIds.DataTable;
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
                string wd_id = listBoxIds.SelectedValue.ToString();
                Sharevariables.WeddingDressID = wd_id;
                Sharevariables.WdSize = dataGridViewDress.Rows[dataGridViewDress.SelectedRows[0].Index].Cells[1].Value.ToString();
                this.DialogResult = DialogResult.OK;
                this.Close();
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
            string wd_id = listBoxIds.SelectedValue.ToString();
            textBox1.Text = "";
            loadPics(wd_id);
            loadDressDefinition(wd_id);
            loadDress(wd_id);
            loadCollisionPeriod(wd_id);
        }

        private void DressProperties_Load(object sender, EventArgs e)
        {
            
        }

        private void dataGridViewDress_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            buttonSelect_Click(sender, e);
        }

        private void listViewImages_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int selectedIndex = Convert.ToInt16(listViewImages.SelectedIndices[0])+1;
            if (images[selectedIndex] != null)
            {
                Form sbp = new DressImageShow(Image.FromStream(new MemoryStream((byte[])images[selectedIndex])));
                sbp.ShowDialog();
            }
        }
    }
}

