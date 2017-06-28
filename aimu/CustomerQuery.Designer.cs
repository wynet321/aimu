namespace aimu
{
    partial class CustomerQuery
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBrideName = new System.Windows.Forms.TextBox();
            this.textBrideContact = new System.Windows.Forms.TextBox();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.textBoxOperator = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonInsertCustomer = new System.Windows.Forms.Button();
            this.comboBoxStatus = new System.Windows.Forms.ComboBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.labelConsultant = new System.Windows.Forms.Label();
            this.textBoxConsultant = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.checkBoxDate = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(901, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 25);
            this.button1.TabIndex = 3;
            this.button1.Text = "查询";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBrideName
            // 
            this.textBrideName.Location = new System.Drawing.Point(382, 11);
            this.textBrideName.Name = "textBrideName";
            this.textBrideName.Size = new System.Drawing.Size(85, 21);
            this.textBrideName.TabIndex = 8;
            // 
            // textBrideContact
            // 
            this.textBrideContact.Location = new System.Drawing.Point(509, 11);
            this.textBrideContact.Name = "textBrideContact";
            this.textBrideContact.Size = new System.Drawing.Size(104, 21);
            this.textBrideContact.TabIndex = 9;
            // 
            // dtDate
            // 
            this.dtDate.Enabled = false;
            this.dtDate.Location = new System.Drawing.Point(217, 11);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(124, 21);
            this.dtDate.TabIndex = 10;
            this.dtDate.Value = new System.DateTime(2017, 4, 17, 0, 0, 0, 0);
            this.dtDate.VisibleChanged += new System.EventHandler(this.dtDate_VisibleChanged);
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
            this.splitContainer1.Panel1.Controls.Add(this.checkBoxDate);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxOperator);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.dtDate);
            this.splitContainer1.Panel1.Controls.Add(this.buttonInsertCustomer);
            this.splitContainer1.Panel1.Controls.Add(this.comboBoxStatus);
            this.splitContainer1.Panel1.Controls.Add(this.labelStatus);
            this.splitContainer1.Panel1.Controls.Add(this.labelConsultant);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxConsultant);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.textBrideContact);
            this.splitContainer1.Panel1.Controls.Add(this.textBrideName);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(1084, 562);
            this.splitContainer1.SplitterDistance = 37;
            this.splitContainer1.TabIndex = 12;
            // 
            // textBoxOperator
            // 
            this.textBoxOperator.Location = new System.Drawing.Point(793, 11);
            this.textBoxOperator.Name = "textBoxOperator";
            this.textBoxOperator.Size = new System.Drawing.Size(86, 21);
            this.textBoxOperator.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(758, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 19;
            this.label3.Text = "客服";
            // 
            // buttonInsertCustomer
            // 
            this.buttonInsertCustomer.Location = new System.Drawing.Point(994, 7);
            this.buttonInsertCustomer.Name = "buttonInsertCustomer";
            this.buttonInsertCustomer.Size = new System.Drawing.Size(78, 25);
            this.buttonInsertCustomer.TabIndex = 18;
            this.buttonInsertCustomer.Text = "新增";
            this.buttonInsertCustomer.UseVisualStyleBackColor = true;
            this.buttonInsertCustomer.Click += new System.EventHandler(this.buttonInsertCustomer_Click);
            // 
            // comboBoxStatus
            // 
            this.comboBoxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStatus.FormattingEnabled = true;
            this.comboBoxStatus.Items.AddRange(new object[] {
            "全部",
            "新客户",
            "未预约到店",
            "预约成功",
            "客户流失",
            "到店未成交",
            "交定金未定款式",
            "交定金已定款式",
            "交全款未定款式",
            "交全款已定款式",
            "服务完成"});
            this.comboBoxStatus.Location = new System.Drawing.Point(45, 12);
            this.comboBoxStatus.Name = "comboBoxStatus";
            this.comboBoxStatus.Size = new System.Drawing.Size(116, 20);
            this.comboBoxStatus.TabIndex = 16;
            this.comboBoxStatus.SelectedIndexChanged += new System.EventHandler(this.comboBoxStatus_SelectedIndexChanged);
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
            this.labelConsultant.Text = "商品师";
            // 
            // textBoxConsultant
            // 
            this.textBoxConsultant.Location = new System.Drawing.Point(666, 12);
            this.textBoxConsultant.Name = "textBoxConsultant";
            this.textBoxConsultant.Size = new System.Drawing.Size(86, 21);
            this.textBoxConsultant.TabIndex = 14;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1084, 521);
            this.dataGridView1.TabIndex = 11;
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            // 
            // checkBoxDate
            // 
            this.checkBoxDate.AutoSize = true;
            this.checkBoxDate.Location = new System.Drawing.Point(167, 14);
            this.checkBoxDate.Name = "checkBoxDate";
            this.checkBoxDate.Size = new System.Drawing.Size(48, 16);
            this.checkBoxDate.TabIndex = 21;
            this.checkBoxDate.Text = "日期";
            this.checkBoxDate.UseVisualStyleBackColor = true;
            this.checkBoxDate.CheckedChanged += new System.EventHandler(this.checkBoxDate_CheckedChanged);
            // 
            // CMQueryCustormer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 562);
            this.Controls.Add(this.splitContainer1);
            this.Name = "CMQueryCustormer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "查询客户";
            this.Load += new System.EventHandler(this.CMQueryCustormer_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBrideName;
        private System.Windows.Forms.TextBox textBrideContact;
        private System.Windows.Forms.DateTimePicker dtDate;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox comboBoxStatus;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label labelConsultant;
        private System.Windows.Forms.TextBox textBoxConsultant;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonInsertCustomer;
        private System.Windows.Forms.TextBox textBoxOperator;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBoxDate;
    }
}