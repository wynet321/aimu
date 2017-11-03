namespace aimu
{
    partial class DressQuery
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewOrders = new System.Windows.Forms.DataGridView();
            this.dataGridViewDress = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textBoxDressId = new System.Windows.Forms.TextBox();
            this.labelDressId = new System.Windows.Forms.Label();
            this.buttonSelect = new System.Windows.Forms.Button();
            this.listBoxIds = new System.Windows.Forms.ListBox();
            this.listViewImages = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDress)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewOrders
            // 
            this.dataGridViewOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrders.Location = new System.Drawing.Point(235, 305);
            this.dataGridViewOrders.Name = "dataGridViewOrders";
            this.dataGridViewOrders.ReadOnly = true;
            this.dataGridViewOrders.RowTemplate.Height = 23;
            this.dataGridViewOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewOrders.Size = new System.Drawing.Size(612, 134);
            this.dataGridViewOrders.TabIndex = 0;
            // 
            // dataGridViewDress
            // 
            this.dataGridViewDress.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDress.Location = new System.Drawing.Point(235, 138);
            this.dataGridViewDress.Name = "dataGridViewDress";
            this.dataGridViewDress.ReadOnly = true;
            this.dataGridViewDress.RowTemplate.Height = 23;
            this.dataGridViewDress.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDress.Size = new System.Drawing.Size(612, 161);
            this.dataGridViewDress.TabIndex = 0;
            this.dataGridViewDress.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewDress_MouseDoubleClick);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(14, 110);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(215, 329);
            this.textBox1.TabIndex = 0;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(154, 12);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 3;
            this.buttonSearch.Text = "查询";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // textBoxDressId
            // 
            this.textBoxDressId.Location = new System.Drawing.Point(40, 12);
            this.textBoxDressId.Name = "textBoxDressId";
            this.textBoxDressId.Size = new System.Drawing.Size(108, 21);
            this.textBoxDressId.TabIndex = 1;
            this.textBoxDressId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDressId_KeyPress);
            // 
            // labelDressId
            // 
            this.labelDressId.AutoSize = true;
            this.labelDressId.Location = new System.Drawing.Point(12, 17);
            this.labelDressId.Name = "labelDressId";
            this.labelDressId.Size = new System.Drawing.Size(29, 12);
            this.labelDressId.TabIndex = 5;
            this.labelDressId.Text = "货号";
            // 
            // buttonSelect
            // 
            this.buttonSelect.Location = new System.Drawing.Point(154, 40);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(75, 23);
            this.buttonSelect.TabIndex = 5;
            this.buttonSelect.Text = "选定";
            this.buttonSelect.UseVisualStyleBackColor = true;
            this.buttonSelect.Click += new System.EventHandler(this.buttonSelect_Click);
            // 
            // listBoxIds
            // 
            this.listBoxIds.FormattingEnabled = true;
            this.listBoxIds.ItemHeight = 12;
            this.listBoxIds.Location = new System.Drawing.Point(40, 40);
            this.listBoxIds.Name = "listBoxIds";
            this.listBoxIds.Size = new System.Drawing.Size(108, 64);
            this.listBoxIds.TabIndex = 2;
            this.listBoxIds.SelectedIndexChanged += new System.EventHandler(this.listBoxIds_SelectedIndexChanged);
            // 
            // listViewImages
            // 
            this.listViewImages.Location = new System.Drawing.Point(235, 12);
            this.listViewImages.Name = "listViewImages";
            this.listViewImages.Size = new System.Drawing.Size(612, 120);
            this.listViewImages.TabIndex = 6;
            this.listViewImages.UseCompatibleStateImageBehavior = false;
            this.listViewImages.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewImages_MouseDoubleClick);
            // 
            // DressQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 452);
            this.Controls.Add(this.listViewImages);
            this.Controls.Add(this.dataGridViewOrders);
            this.Controls.Add(this.dataGridViewDress);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.listBoxIds);
            this.Controls.Add(this.textBoxDressId);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.buttonSelect);
            this.Controls.Add(this.labelDressId);
            this.Name = "DressQuery";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "商品明细";
            this.Load += new System.EventHandler(this.DressProperties_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDress)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridViewDress;
        private System.Windows.Forms.DataGridView dataGridViewOrders;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.TextBox textBoxDressId;
        private System.Windows.Forms.Label labelDressId;
        private System.Windows.Forms.Button buttonSelect;
        private System.Windows.Forms.ListBox listBoxIds;
        private System.Windows.Forms.ListView listViewImages;
    }
}