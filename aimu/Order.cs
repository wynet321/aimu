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
    public partial class Order : Form
    {
        private List<Control> textBoxSns,textBoxPrices;
        //private List<Control> panelButtonContainers;
        private List<Control> buttonDeletes;
        private List<Control> buttonAdds;
        private List<Control> comboBoxSizes, comboBoxColors, comboBoxCategories;
        private List<List<Control>> controls;
        public Order()
        {
            InitializeComponent();
            textBoxSns = new List<Control>();
            //panelButtonContainers = new List<Control>();
            buttonDeletes = new List<Control>();
            textBoxPrices = new List<Control>();
            comboBoxColors = new List<Control>();
            comboBoxSizes = new List<Control>();
            buttonAdds = new List<Control>();
            comboBoxCategories = new List<Control>();
            controls = new List<List<Control>>();
            controls.Add(textBoxSns);
            controls.Add(textBoxPrices);
           // controls.Add(panelButtonContainers);
            controls.Add(buttonAdds);
            controls.Add(buttonDeletes);
            controls.Add(comboBoxCategories);
            controls.Add(comboBoxColors);
            controls.Add(comboBoxSizes);
            
            generateOrderRow(33);
            buttonDeletes.ElementAt(0).Click -= new EventHandler(buttonDelete_Click);

        }
        private object CloneObject(object o)
        {
            Type t = o.GetType();
            System.Reflection.PropertyInfo[] properties = t.GetProperties();
            
            Object p = t.InvokeMember("", System.Reflection.BindingFlags.CreateInstance, null, o, null);

            foreach (System.Reflection.PropertyInfo pi in properties)
            {
                if (pi.CanWrite)
                {
                    pi.SetValue(p, pi.GetValue(o));
                }
            }

            return p;
        }
        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            pictureBoxLeft.ImageLocation = getPicturePath();
        }

        private void buttonBrowseRight_Click(object sender, EventArgs e)
        {
            pictureBoxRight.ImageLocation = getPicturePath();
        }

        private String getPicturePath()
        {
            DialogResult result = openFileDialog.ShowDialog();
            String picturePath=null;
            if (result == DialogResult.OK)
            {
                picturePath = openFileDialog.FileName;
            }
            return picturePath;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxSns.Count == buttonAdds.IndexOf(sender as Button) + 1)
            {
                generateOrderRow((sender as Button).Bottom + 2);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int index = buttonDeletes.IndexOf(sender as Button);
            foreach(List<Control> list in controls){
                list.ElementAt(index).Dispose();
                list.RemoveAt(index);
                for(int i= index; i < list.Count; i++)
                {
                    list.ElementAt(i).Top -= 25;
                }
            }
        }

        private void textBoxSn_Leave(object sender, EventArgs e)
        {
            //MessageBox.Show((sender as TextBox).Text + " " + textBoxSns.IndexOf(sender as TextBox));
            textBoxSns.ElementAt(textBoxSns.IndexOf(sender as TextBox)).Text = textBoxSns.IndexOf(sender as TextBox).ToString();
        }

        private void generateOrderRow(int top)
        {
            
            TextBox textBoxSn = new TextBox();
            panelList.Controls.Add(textBoxSn);
            textBoxSn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBoxSn.Size = new System.Drawing.Size(80, 21);
            textBoxSn.TabIndex = 6;
            textBoxSn.Location = new Point(4, top);
            textBoxSn.Name = "textBoxSn"+textBoxSns.Count;
            textBoxSn.Leave += new System.EventHandler(textBoxSn_Leave);
            textBoxSn.Focus();
            textBoxSns.Add(textBoxSn);

            // 
            // comboBoxSize
            // 
            ComboBox comboBoxSize = new ComboBox();
           comboBoxSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
           comboBoxSize.FormattingEnabled = true;
           comboBoxSize.Location = new System.Drawing.Point(84,top);
           comboBoxSize.Margin = new System.Windows.Forms.Padding(0);
           comboBoxSize.Name = "comboBoxSize"+comboBoxSizes.Count;
           comboBoxSize.Size = new System.Drawing.Size(80, 20);
           comboBoxSize.TabIndex = 7;
            panelList.Controls.Add(comboBoxSize);
            comboBoxSizes.Add(comboBoxSize);
            // 
            // comboBoxCategory
            // 
            ComboBox comboBoxCategory = new ComboBox();
            comboBoxCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxCategory.FormattingEnabled = true;
            comboBoxCategory.Location = new System.Drawing.Point(224,top);
            comboBoxCategory.Margin = new System.Windows.Forms.Padding(0);
            comboBoxCategory.Name = "comboBoxCategory"+comboBoxCategories.Count;
            comboBoxCategory.Size = new System.Drawing.Size(80, 20);
            comboBoxCategory.TabIndex = 8;
            panelList.Controls.Add(comboBoxCategory);
            comboBoxCategories.Add(comboBoxCategory);

            // 
            // comboBoxColor
            // 
            ComboBox comboBoxColor = new ComboBox();
            comboBoxColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxColor.FormattingEnabled = true;
            comboBoxColor.Location = new System.Drawing.Point(164, top);
            comboBoxColor.Margin = new System.Windows.Forms.Padding(0);
            comboBoxColor.Name = "comboBoxSize"+comboBoxColors.Count;
            comboBoxColor.Size = new System.Drawing.Size(60, 20);
            comboBoxColor.TabIndex = 7;
            panelList.Controls.Add(comboBoxColor);
            comboBoxColors.Add(comboBoxColor);
            // 
            // textBoxPrice
            // 
            TextBox textBoxPrice = new TextBox();
            textBoxPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBoxPrice.Location = new System.Drawing.Point(304, top);
            textBoxPrice.Name = "textBoxPrice"+textBoxPrices.Count;
            textBoxPrice.Size = new System.Drawing.Size(60, 21);
            textBoxPrice.TabIndex = 10;
            panelList.Controls.Add(textBoxPrice);
            textBoxPrices.Add(textBoxPrice);
            // 
            // buttonAdd
            // 
            Button buttonAdd = new Button();
            buttonAdd.FlatAppearance.BorderSize = 0;
            buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonAdd.Location = new System.Drawing.Point(368, top);
            buttonAdd.Name = "buttonAdd"+buttonAdds.Count;
            buttonAdd.Size = new System.Drawing.Size(30, 23);
            buttonAdd.TabIndex = 11;
            buttonAdd.Text = "Add";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += new System.EventHandler(buttonAdd_Click);
            buttonAdds.Add(buttonAdd);
            panelList.Controls.Add(buttonAdd);
            // 
            // buttonDelete
            // 
            Button buttonDelete = new Button();
            buttonDelete.FlatAppearance.BorderSize = 0;
            buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonDelete.Location = new System.Drawing.Point(400, top);
            buttonDelete.Name = "buttonDelete"+buttonDeletes.Count;
            buttonDelete.Size = new System.Drawing.Size(30, 23);
            buttonDelete.TabIndex = 12;
            buttonDelete.Text = "Del";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += new EventHandler(buttonDelete_Click);
            buttonDeletes.Add(buttonDelete);
            panelList.Controls.Add(buttonDelete);
            // 
            // panelButtonContainer
            // 
            //Panel panelButtonContainer = new Panel();
            //panelButtonContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            //panelButtonContainer.Controls.Add(buttonAdd);
            //panelButtonContainer.Controls.Add(buttonDelete);
            //panelButtonContainer.Location = new System.Drawing.Point(364, top);
            //panelButtonContainer.Name = "panelButtonContainer"+panelButtonContainers.Count;
            //panelButtonContainer.Size = new System.Drawing.Size(80, 21);
            //panelButtonContainer.TabIndex = 13;
            //panelList.Controls.Add(panelButtonContainer);
            //panelButtonContainers.Add(panelButtonContainer);
        }
    }
}
