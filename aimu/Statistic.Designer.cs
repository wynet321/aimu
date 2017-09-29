namespace aimu
{
    partial class Statistic
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
            this.buttonSearch = new System.Windows.Forms.Button();
            this.dateTimePickerStartDate = new System.Windows.Forms.DateTimePicker();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.textBoxPaid = new System.Windows.Forms.TextBox();
            this.textBoxAccountReceivable = new System.Windows.Forms.TextBox();
            this.labelPaid = new System.Windows.Forms.Label();
            this.labelAccountReceivable = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerEndDate = new System.Windows.Forms.DateTimePicker();
            this.textBoxPartnerName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxChannel = new System.Windows.Forms.ComboBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.labelConsultant = new System.Windows.Forms.Label();
            this.textBoxConsultant = new System.Windows.Forms.TextBox();
            this.dataGridViewCustomers = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCustomers)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(223, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "终止日期";
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(424, 7);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(78, 54);
            this.buttonSearch.TabIndex = 6;
            this.buttonSearch.Text = "查询";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // dateTimePickerStartDate
            // 
            this.dateTimePickerStartDate.Location = new System.Drawing.Point(71, 9);
            this.dateTimePickerStartDate.Name = "dateTimePickerStartDate";
            this.dateTimePickerStartDate.Size = new System.Drawing.Size(146, 21);
            this.dateTimePickerStartDate.TabIndex = 1;
            this.dateTimePickerStartDate.Value = new System.DateTime(2017, 4, 17, 0, 0, 0, 0);
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
            this.splitContainer1.Panel1.Controls.Add(this.textBoxPaid);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxAccountReceivable);
            this.splitContainer1.Panel1.Controls.Add(this.labelPaid);
            this.splitContainer1.Panel1.Controls.Add(this.labelAccountReceivable);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.dateTimePickerEndDate);
            this.splitContainer1.Panel1.Controls.Add(this.buttonSearch);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxPartnerName);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.dateTimePickerStartDate);
            this.splitContainer1.Panel1.Controls.Add(this.comboBoxChannel);
            this.splitContainer1.Panel1.Controls.Add(this.labelStatus);
            this.splitContainer1.Panel1.Controls.Add(this.labelConsultant);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxConsultant);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridViewCustomers);
            this.splitContainer1.Size = new System.Drawing.Size(736, 444);
            this.splitContainer1.SplitterDistance = 68;
            this.splitContainer1.TabIndex = 12;
            // 
            // textBoxPaid
            // 
            this.textBoxPaid.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBoxPaid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPaid.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxPaid.ForeColor = System.Drawing.Color.Navy;
            this.textBoxPaid.Location = new System.Drawing.Point(567, 40);
            this.textBoxPaid.Name = "textBoxPaid";
            this.textBoxPaid.ReadOnly = true;
            this.textBoxPaid.Size = new System.Drawing.Size(157, 21);
            this.textBoxPaid.TabIndex = 28;
            // 
            // textBoxAccountReceivable
            // 
            this.textBoxAccountReceivable.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBoxAccountReceivable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxAccountReceivable.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxAccountReceivable.ForeColor = System.Drawing.Color.Navy;
            this.textBoxAccountReceivable.Location = new System.Drawing.Point(567, 9);
            this.textBoxAccountReceivable.Name = "textBoxAccountReceivable";
            this.textBoxAccountReceivable.ReadOnly = true;
            this.textBoxAccountReceivable.Size = new System.Drawing.Size(157, 21);
            this.textBoxAccountReceivable.TabIndex = 27;
            // 
            // labelPaid
            // 
            this.labelPaid.AutoSize = true;
            this.labelPaid.Location = new System.Drawing.Point(508, 43);
            this.labelPaid.Name = "labelPaid";
            this.labelPaid.Size = new System.Drawing.Size(53, 12);
            this.labelPaid.TabIndex = 26;
            this.labelPaid.Text = "实收业绩";
            // 
            // labelAccountReceivable
            // 
            this.labelAccountReceivable.AutoSize = true;
            this.labelAccountReceivable.Location = new System.Drawing.Point(508, 13);
            this.labelAccountReceivable.Name = "labelAccountReceivable";
            this.labelAccountReceivable.Size = new System.Drawing.Size(53, 12);
            this.labelAccountReceivable.TabIndex = 24;
            this.labelAccountReceivable.Text = "应收业绩";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 23;
            this.label2.Text = "起始日期";
            // 
            // dateTimePickerEndDate
            // 
            this.dateTimePickerEndDate.Location = new System.Drawing.Point(282, 9);
            this.dateTimePickerEndDate.Name = "dateTimePickerEndDate";
            this.dateTimePickerEndDate.Size = new System.Drawing.Size(136, 21);
            this.dateTimePickerEndDate.TabIndex = 2;
            this.dateTimePickerEndDate.Value = new System.DateTime(2017, 4, 17, 0, 0, 0, 0);
            // 
            // textBoxPartnerName
            // 
            this.textBoxPartnerName.Location = new System.Drawing.Point(327, 35);
            this.textBoxPartnerName.Name = "textBoxPartnerName";
            this.textBoxPartnerName.Size = new System.Drawing.Size(91, 21);
            this.textBoxPartnerName.TabIndex = 5;
            this.textBoxPartnerName.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(268, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 19;
            this.label3.Text = "合作企业";
            this.label3.Visible = false;
            // 
            // comboBoxChannel
            // 
            this.comboBoxChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxChannel.FormattingEnabled = true;
            this.comboBoxChannel.Location = new System.Drawing.Point(167, 35);
            this.comboBoxChannel.Name = "comboBoxChannel";
            this.comboBoxChannel.Size = new System.Drawing.Size(95, 20);
            this.comboBoxChannel.TabIndex = 4;
            this.comboBoxChannel.SelectedIndexChanged += new System.EventHandler(this.comboBoxChannel_SelectedIndexChanged);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(132, 39);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(29, 12);
            this.labelStatus.TabIndex = 15;
            this.labelStatus.Text = "渠道";
            // 
            // labelConsultant
            // 
            this.labelConsultant.AutoSize = true;
            this.labelConsultant.Location = new System.Drawing.Point(12, 39);
            this.labelConsultant.Name = "labelConsultant";
            this.labelConsultant.Size = new System.Drawing.Size(41, 12);
            this.labelConsultant.TabIndex = 13;
            this.labelConsultant.Text = "礼服师";
            // 
            // textBoxConsultant
            // 
            this.textBoxConsultant.Location = new System.Drawing.Point(59, 35);
            this.textBoxConsultant.Name = "textBoxConsultant";
            this.textBoxConsultant.Size = new System.Drawing.Size(67, 21);
            this.textBoxConsultant.TabIndex = 3;
            // 
            // dataGridViewCustomers
            // 
            this.dataGridViewCustomers.AllowUserToAddRows = false;
            this.dataGridViewCustomers.AllowUserToDeleteRows = false;
            this.dataGridViewCustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewCustomers.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewCustomers.MultiSelect = false;
            this.dataGridViewCustomers.Name = "dataGridViewCustomers";
            this.dataGridViewCustomers.ReadOnly = true;
            this.dataGridViewCustomers.RowTemplate.Height = 23;
            this.dataGridViewCustomers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCustomers.Size = new System.Drawing.Size(736, 372);
            this.dataGridViewCustomers.TabIndex = 11;
            this.dataGridViewCustomers.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewCustomers_CellMouseDoubleClick);
            // 
            // Statistic
            // 
            this.AcceptButton = this.buttonSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 444);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Statistic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "统计";
            this.Load += new System.EventHandler(this.Statistic_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCustomers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.DateTimePicker dateTimePickerStartDate;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox comboBoxChannel;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label labelConsultant;
        private System.Windows.Forms.TextBox textBoxConsultant;
        private System.Windows.Forms.DataGridView dataGridViewCustomers;
        private System.Windows.Forms.TextBox textBoxPartnerName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerEndDate;
        private System.Windows.Forms.TextBox textBoxPaid;
        private System.Windows.Forms.TextBox textBoxAccountReceivable;
        private System.Windows.Forms.Label labelPaid;
        private System.Windows.Forms.Label labelAccountReceivable;
    }
}