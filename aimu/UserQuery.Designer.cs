namespace aimu
{
    partial class UserQuery
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
            this.dataGridViewTenants = new System.Windows.Forms.DataGridView();
            this.labelName = new System.Windows.Forms.Label();
            this.labelCellPhone = new System.Windows.Forms.Label();
            this.textBoxCellPhone = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.comboBoxRoles = new System.Windows.Forms.ComboBox();
            this.labelRoles = new System.Windows.Forms.Label();
            this.buttonInsertTenant = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTenants)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewTenants
            // 
            this.dataGridViewTenants.AllowUserToAddRows = false;
            this.dataGridViewTenants.AllowUserToDeleteRows = false;
            this.dataGridViewTenants.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewTenants.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTenants.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTenants.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewTenants.Name = "dataGridViewTenants";
            this.dataGridViewTenants.ReadOnly = true;
            this.dataGridViewTenants.RowTemplate.Height = 23;
            this.dataGridViewTenants.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTenants.Size = new System.Drawing.Size(802, 486);
            this.dataGridViewTenants.TabIndex = 11;
            this.dataGridViewTenants.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewTenants_CellMouseDoubleClick);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(310, 15);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(29, 12);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "姓名";
            // 
            // labelCellPhone
            // 
            this.labelCellPhone.AutoSize = true;
            this.labelCellPhone.Location = new System.Drawing.Point(165, 15);
            this.labelCellPhone.Name = "labelCellPhone";
            this.labelCellPhone.Size = new System.Drawing.Size(29, 12);
            this.labelCellPhone.TabIndex = 1;
            this.labelCellPhone.Text = "电话";
            // 
            // textBoxCellPhone
            // 
            this.textBoxCellPhone.Location = new System.Drawing.Point(200, 11);
            this.textBoxCellPhone.Name = "textBoxCellPhone";
            this.textBoxCellPhone.Size = new System.Drawing.Size(104, 21);
            this.textBoxCellPhone.TabIndex = 9;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(345, 11);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(85, 21);
            this.textBoxName.TabIndex = 8;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(619, 9);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(78, 25);
            this.buttonSearch.TabIndex = 3;
            this.buttonSearch.Text = "查询";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.comboBoxRoles);
            this.splitContainer1.Panel1.Controls.Add(this.labelRoles);
            this.splitContainer1.Panel1.Controls.Add(this.buttonInsertTenant);
            this.splitContainer1.Panel1.Controls.Add(this.labelName);
            this.splitContainer1.Panel1.Controls.Add(this.labelCellPhone);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxCellPhone);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxName);
            this.splitContainer1.Panel1.Controls.Add(this.buttonSearch);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridViewTenants);
            this.splitContainer1.Size = new System.Drawing.Size(802, 527);
            this.splitContainer1.SplitterDistance = 37;
            this.splitContainer1.TabIndex = 13;
            // 
            // comboBoxRoles
            // 
            this.comboBoxRoles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRoles.FormattingEnabled = true;
            this.comboBoxRoles.Location = new System.Drawing.Point(43, 12);
            this.comboBoxRoles.Name = "comboBoxRoles";
            this.comboBoxRoles.Size = new System.Drawing.Size(116, 20);
            this.comboBoxRoles.TabIndex = 20;
            // 
            // labelRoles
            // 
            this.labelRoles.AutoSize = true;
            this.labelRoles.Location = new System.Drawing.Point(8, 15);
            this.labelRoles.Name = "labelRoles";
            this.labelRoles.Size = new System.Drawing.Size(29, 12);
            this.labelRoles.TabIndex = 19;
            this.labelRoles.Text = "类别";
            // 
            // buttonInsertTenant
            // 
            this.buttonInsertTenant.Location = new System.Drawing.Point(712, 9);
            this.buttonInsertTenant.Name = "buttonInsertTenant";
            this.buttonInsertTenant.Size = new System.Drawing.Size(78, 25);
            this.buttonInsertTenant.TabIndex = 18;
            this.buttonInsertTenant.Text = "新增";
            this.buttonInsertTenant.UseVisualStyleBackColor = true;
            this.buttonInsertTenant.Click += new System.EventHandler(this.buttonInsertTenant_Click);
            // 
            // UserQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 527);
            this.Controls.Add(this.splitContainer1);
            this.Name = "UserQuery";
            this.Text = "用户管理";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTenants)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewTenants;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelCellPhone;
        private System.Windows.Forms.TextBox textBoxCellPhone;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button buttonInsertTenant;
        private System.Windows.Forms.ComboBox comboBoxRoles;
        private System.Windows.Forms.Label labelRoles;
    }
}