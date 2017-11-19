namespace aimu
{
    partial class TenantQuery
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBrideContact = new System.Windows.Forms.TextBox();
            this.textBrideName = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.buttonInsertCustomer = new System.Windows.Forms.Button();
            this.comboBoxStatus = new System.Windows.Forms.ComboBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.labelConsultant = new System.Windows.Forms.Label();
            this.textBoxConsultant = new System.Windows.Forms.TextBox();
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
            this.dataGridViewTenants.Size = new System.Drawing.Size(1081, 486);
            this.dataGridViewTenants.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(347, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "姓名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(474, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "电话";
            // 
            // textBrideContact
            // 
            this.textBrideContact.Location = new System.Drawing.Point(509, 11);
            this.textBrideContact.Name = "textBrideContact";
            this.textBrideContact.Size = new System.Drawing.Size(104, 21);
            this.textBrideContact.TabIndex = 9;
            // 
            // textBrideName
            // 
            this.textBrideName.Location = new System.Drawing.Point(382, 11);
            this.textBrideName.Name = "textBrideName";
            this.textBrideName.Size = new System.Drawing.Size(85, 21);
            this.textBrideName.TabIndex = 8;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(901, 7);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(78, 25);
            this.buttonSearch.TabIndex = 3;
            this.buttonSearch.Text = "查询";
            this.buttonSearch.UseVisualStyleBackColor = true;
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
            this.splitContainer1.Panel1.Controls.Add(this.buttonInsertCustomer);
            this.splitContainer1.Panel1.Controls.Add(this.comboBoxStatus);
            this.splitContainer1.Panel1.Controls.Add(this.labelStatus);
            this.splitContainer1.Panel1.Controls.Add(this.labelConsultant);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxConsultant);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.textBrideContact);
            this.splitContainer1.Panel1.Controls.Add(this.textBrideName);
            this.splitContainer1.Panel1.Controls.Add(this.buttonSearch);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridViewTenants);
            this.splitContainer1.Size = new System.Drawing.Size(1081, 527);
            this.splitContainer1.SplitterDistance = 37;
            this.splitContainer1.TabIndex = 13;
            // 
            // buttonInsertCustomer
            // 
            this.buttonInsertCustomer.Location = new System.Drawing.Point(994, 7);
            this.buttonInsertCustomer.Name = "buttonInsertCustomer";
            this.buttonInsertCustomer.Size = new System.Drawing.Size(78, 25);
            this.buttonInsertCustomer.TabIndex = 18;
            this.buttonInsertCustomer.Text = "新增";
            this.buttonInsertCustomer.UseVisualStyleBackColor = true;
            // 
            // comboBoxStatus
            // 
            this.comboBoxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStatus.FormattingEnabled = true;
            this.comboBoxStatus.Location = new System.Drawing.Point(45, 12);
            this.comboBoxStatus.Name = "comboBoxStatus";
            this.comboBoxStatus.Size = new System.Drawing.Size(116, 20);
            this.comboBoxStatus.TabIndex = 16;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(10, 15);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(29, 12);
            this.labelStatus.TabIndex = 15;
            this.labelStatus.Text = "状态";
            // 
            // labelConsultant
            // 
            this.labelConsultant.AutoSize = true;
            this.labelConsultant.Location = new System.Drawing.Point(619, 14);
            this.labelConsultant.Name = "labelConsultant";
            this.labelConsultant.Size = new System.Drawing.Size(41, 12);
            this.labelConsultant.TabIndex = 13;
            this.labelConsultant.Text = "礼服师";
            // 
            // textBoxConsultant
            // 
            this.textBoxConsultant.Location = new System.Drawing.Point(666, 12);
            this.textBoxConsultant.Name = "textBoxConsultant";
            this.textBoxConsultant.Size = new System.Drawing.Size(86, 21);
            this.textBoxConsultant.TabIndex = 14;
            // 
            // TenantQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 527);
            this.Controls.Add(this.splitContainer1);
            this.Name = "TenantQuery";
            this.Text = "TenantQuery";
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBrideContact;
        private System.Windows.Forms.TextBox textBrideName;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button buttonInsertCustomer;
        private System.Windows.Forms.ComboBox comboBoxStatus;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label labelConsultant;
        private System.Windows.Forms.TextBox textBoxConsultant;
    }
}