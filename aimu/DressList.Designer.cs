namespace aimu
{
    partial class DressList
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
            this.splitContainer10 = new System.Windows.Forms.SplitContainer();
            this.treeViewCategory = new System.Windows.Forms.TreeView();
            this.listViewDress = new System.Windows.Forms.ListView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.buttonInsert = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer10)).BeginInit();
            this.splitContainer10.Panel1.SuspendLayout();
            this.splitContainer10.Panel2.SuspendLayout();
            this.splitContainer10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer10
            // 
            this.splitContainer10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer10.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer10.Location = new System.Drawing.Point(0, 0);
            this.splitContainer10.Name = "splitContainer10";
            this.splitContainer10.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer10.Panel1
            // 
            this.splitContainer10.Panel1.Controls.Add(this.buttonInsert);
            // 
            // splitContainer10.Panel2
            // 
            this.splitContainer10.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer10.Size = new System.Drawing.Size(984, 662);
            this.splitContainer10.SplitterDistance = 34;
            this.splitContainer10.TabIndex = 2;
            // 
            // treeViewCategory
            // 
            this.treeViewCategory.BackColor = System.Drawing.SystemColors.Menu;
            this.treeViewCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewCategory.Location = new System.Drawing.Point(0, 0);
            this.treeViewCategory.Name = "treeViewCategory";
            this.treeViewCategory.Size = new System.Drawing.Size(188, 622);
            this.treeViewCategory.TabIndex = 0;
            this.treeViewCategory.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewCategory_AfterSelect);
            this.treeViewCategory.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewCategory_NodeMouseClick);
            // 
            // listViewDress
            // 
            this.listViewDress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewDress.Location = new System.Drawing.Point(0, 0);
            this.listViewDress.Name = "listViewDress";
            this.listViewDress.Size = new System.Drawing.Size(790, 622);
            this.listViewDress.TabIndex = 1;
            this.listViewDress.UseCompatibleStateImageBehavior = false;
            this.listViewDress.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewDress_MouseDoubleClick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeViewCategory);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listViewDress);
            this.splitContainer1.Size = new System.Drawing.Size(982, 622);
            this.splitContainer1.SplitterDistance = 188;
            this.splitContainer1.TabIndex = 2;
            // 
            // buttonInsert
            // 
            this.buttonInsert.Location = new System.Drawing.Point(896, 6);
            this.buttonInsert.Name = "buttonInsert";
            this.buttonInsert.Size = new System.Drawing.Size(75, 23);
            this.buttonInsert.TabIndex = 0;
            this.buttonInsert.Text = "添加";
            this.buttonInsert.UseVisualStyleBackColor = true;
            this.buttonInsert.Click += new System.EventHandler(this.buttonInsert_Click);
            // 
            // DressList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 662);
            this.Controls.Add(this.splitContainer10);
            this.Name = "DressList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "浏览查看";
            this.Load += new System.EventHandler(this.FormOutput_Load);
            this.splitContainer10.Panel1.ResumeLayout(false);
            this.splitContainer10.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer10)).EndInit();
            this.splitContainer10.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer10;
        private System.Windows.Forms.TreeView treeViewCategory;
        private System.Windows.Forms.ListView listViewDress;
        private System.Windows.Forms.Button buttonInsert;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}