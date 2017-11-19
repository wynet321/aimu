using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Data;
using System.Threading;

namespace aimu
{
    public partial class DressList : Form
    {
        private Dictionary<string, byte[]> thumbnails = new Dictionary<string, byte[]>();
        public DressList()
        {
            InitializeComponent();
        }

        private void FormOutput_Load(object sender, EventArgs e)
        {
            setTreeList();
        }

        private void treeViewCategory_AfterSelect(object sender, TreeViewEventArgs e)
        {
            refreshListViewDress();
        }


        private void setTreeList()
        {
            TreeNode treeNode = new TreeNode("婚纱"); //node0
            treeViewCategory.Nodes.Add(treeNode);
            treeNode = new TreeNode("西式礼服"); //node1
            treeViewCategory.Nodes.Add(treeNode);
            treeNode = new TreeNode("中式礼服"); //node2
            treeViewCategory.Nodes.Add(treeNode);
            treeNode = new TreeNode("伴娘服"); //node3
            treeViewCategory.Nodes.Add(treeNode);
            treeNode = new TreeNode("男装"); //node4
            treeViewCategory.Nodes.Add(treeNode);
            treeNode = new TreeNode("饰品"); //node5
            treeViewCategory.Nodes.Add(treeNode);
            treeNode = new TreeNode("其他"); //node6
            treeViewCategory.Nodes.Add(treeNode);
            treeNode = new TreeNode("品牌"); //node7
            treeViewCategory.Nodes.Add(treeNode);
            treeNode = new TreeNode("美妆"); //node8
            treeViewCategory.Nodes.Add(treeNode);


            treeViewCategory.Nodes[0].Nodes.Add("齐地白纱");
            treeViewCategory.Nodes[0].Nodes.Add("小拖白纱");
            treeViewCategory.Nodes[0].Nodes.Add("大拖白纱");
            treeViewCategory.Nodes[0].Nodes.Add("鱼尾白纱");
            treeViewCategory.Nodes[0].Nodes.Add("彩纱");
            treeViewCategory.Nodes[0].Nodes.Add("前短后长");


            treeViewCategory.Nodes[1].Nodes.Add("红色礼服");
            treeViewCategory.Nodes[1].Nodes.Add("彩色礼服");


            treeViewCategory.Nodes[2].Nodes.Add("旗袍");
            treeViewCategory.Nodes[2].Nodes.Add("秀禾服");
            treeViewCategory.Nodes[2].Nodes.Add("龙凤褂");
            treeViewCategory.Nodes[2].Nodes.Add("中式其他");

            treeViewCategory.Nodes[3].Nodes.Add("长款伴娘服");
            treeViewCategory.Nodes[3].Nodes.Add("短款伴娘服");


            treeViewCategory.Nodes[4].Nodes.Add("衬衫");
            treeViewCategory.Nodes[4].Nodes.Add("领结");
            treeViewCategory.Nodes[4].Nodes.Add("领带");
            treeViewCategory.Nodes[4].Nodes.Add("西装");
            treeViewCategory.Nodes[4].Nodes.Add("袖扣");
            treeViewCategory.Nodes[4].Nodes.Add("鞋");

            treeViewCategory.Nodes[5].Nodes.Add("头饰");
            treeViewCategory.Nodes[5].Nodes.Add("首饰");
            treeViewCategory.Nodes[5].Nodes.Add("头纱");
            treeViewCategory.Nodes[5].Nodes.Add("肩链");
            treeViewCategory.Nodes[5].Nodes.Add("手套");
            treeViewCategory.Nodes[5].Nodes.Add("裙撑");
            treeViewCategory.Nodes[5].Nodes.Add("胸贴");

            treeViewCategory.Nodes[6].Nodes.Add("妈妈装");
            treeViewCategory.Nodes[6].Nodes.Add("花童");
            treeViewCategory.Nodes[6].Nodes.Add("来图定制");

            treeViewCategory.Nodes[7].Nodes.Add("艾慕");
            treeViewCategory.Nodes[7].Nodes.Add("简妃");
            treeViewCategory.Nodes[7].Nodes.Add("米卡");
            treeViewCategory.Nodes[7].Nodes.Add("慕姿");
            treeViewCategory.Nodes[7].Nodes.Add("圣利亚");
            treeViewCategory.Nodes[7].Nodes.Add("倒叙");
            treeViewCategory.Nodes[7].Nodes.Add("绝设");
            treeViewCategory.Nodes[7].Nodes.Add("兰斐");
            treeViewCategory.Nodes[7].Nodes.Add("露维娅");
            treeViewCategory.Nodes[7].Nodes.Add("奈特莉");
            treeViewCategory.Nodes[7].Nodes.Add("Hello魔镜");
            treeViewCategory.Nodes[7].Nodes.Add("Ella Sposa");

            treeViewCategory.Nodes[8].Nodes.Add("新娘跟妆");
            treeViewCategory.Nodes[8].Nodes.Add("化妆品");

            treeViewCategory.ExpandAll();
            treeViewCategory.SelectedNode = treeViewCategory.Nodes[0];
        }

        private static void showProcessing()
        {
            ProcessingWait fp = new ProcessingWait();
            fp.ShowDialog();
        }

        private void listViewDress_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listViewDress.SelectedItems.Count > 0)
            {
                ThreadStart ts = new ThreadStart(showProcessing);
                Thread wait = new Thread(ts);
                wait.Start();
                Form form = new DressProperties(listViewDress.SelectedItems[0].ImageKey);
                wait.Abort();
                form.ShowDialog();
                refreshListViewDress();
            }
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            Form form = new DressProperties();
            form.ShowDialog();
            refreshListViewDress();
        }

        private void refreshListViewDress()
        {
            listViewDress.Items.Clear();
            string fullPath = treeViewCategory.SelectedNode.FullPath.ToString();
            Data dressIds = ShardDb.getDressIdsByCondition(fullPath);
            if (!dressIds.Success)
            {
                this.Close();
                return;
            }
            if (dressIds.DataTable.Rows.Count > 0)
            {
                Data thumbnailData = ShardDb.getThumbnailsByIds(dressIds.DataTable);
                if (!thumbnailData.Success)
                {
                    this.Close();
                    return;
                }
                ImageList imageList = new ImageList();
                foreach (DataRow row in thumbnailData.DataTable.Rows)
                {
                    if (row.ItemArray[1] != DBNull.Value)
                    {
                        imageList.Images.Add(row.ItemArray[0].ToString(), Image.FromStream(new MemoryStream((byte[])row.ItemArray[1])));
                    }
                }
                imageList.ImageSize = new Size(100, 100);
                listViewDress.LargeImageList = imageList;

                for (int j = 0; j < imageList.Images.Count; j++)
                {
                    ListViewItem item = new ListViewItem();
                    item.ImageKey = imageList.Images.Keys[j];
                    this.listViewDress.Items.Add(item);
                }
            }
        }
        private void treeViewCategory_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
        }
    }
}

