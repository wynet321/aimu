﻿namespace aimu
{
    partial class CustomerAdd
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
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.brideName = new System.Windows.Forms.TextBox();
            this.brideContact = new System.Windows.Forms.TextBox();
            this.memo = new System.Windows.Forms.TextBox();
            this.comboBoxChannel = new System.Windows.Forms.ComboBox();
            this.label28 = new System.Windows.Forms.Label();
            this.comboBoxCity = new System.Windows.Forms.ComboBox();
            this.label32 = new System.Windows.Forms.Label();
            this.wangwangID = new System.Windows.Forms.TextBox();
            this.textBoxPartnerName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonAddChannel = new System.Windows.Forms.Button();
            this.comboBoxStore = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "新娘姓名：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "联系方式：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(235, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "渠道：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 171);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 7;
            this.label8.Text = "客服备注：";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(126, 272);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(72, 30);
            this.buttonSave.TabIndex = 8;
            this.buttonSave.Text = "确定";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(277, 272);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(72, 30);
            this.buttonClose.TabIndex = 9;
            this.buttonClose.Text = "关闭";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // brideName
            // 
            this.brideName.Location = new System.Drawing.Point(86, 55);
            this.brideName.Name = "brideName";
            this.brideName.Size = new System.Drawing.Size(141, 21);
            this.brideName.TabIndex = 2;
            // 
            // brideContact
            // 
            this.brideContact.Location = new System.Drawing.Point(86, 90);
            this.brideContact.Name = "brideContact";
            this.brideContact.Size = new System.Drawing.Size(141, 21);
            this.brideContact.TabIndex = 3;
            // 
            // memo
            // 
            this.memo.Location = new System.Drawing.Point(17, 193);
            this.memo.Multiline = true;
            this.memo.Name = "memo";
            this.memo.Size = new System.Drawing.Size(462, 57);
            this.memo.TabIndex = 13;
            // 
            // comboBoxChannel
            // 
            this.comboBoxChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxChannel.FormattingEnabled = true;
            this.comboBoxChannel.Location = new System.Drawing.Point(282, 55);
            this.comboBoxChannel.Name = "comboBoxChannel";
            this.comboBoxChannel.Size = new System.Drawing.Size(116, 20);
            this.comboBoxChannel.TabIndex = 7;
            this.comboBoxChannel.SelectedIndexChanged += new System.EventHandler(this.comboBoxChannel_SelectedIndexChanged);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(233, 124);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(41, 12);
            this.label28.TabIndex = 26;
            this.label28.Text = "城市：";
            // 
            // comboBoxCity
            // 
            this.comboBoxCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCity.FormattingEnabled = true;
            this.comboBoxCity.Location = new System.Drawing.Point(304, 121);
            this.comboBoxCity.Name = "comboBoxCity";
            this.comboBoxCity.Size = new System.Drawing.Size(110, 20);
            this.comboBoxCity.TabIndex = 8;
            this.comboBoxCity.SelectedIndexChanged += new System.EventHandler(this.cbCity_SelectedIndexChanged);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(15, 124);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(53, 12);
            this.label32.TabIndex = 87;
            this.label32.Text = "旺旺ID：";
            // 
            // wangwangID
            // 
            this.wangwangID.Location = new System.Drawing.Point(86, 121);
            this.wangwangID.Name = "wangwangID";
            this.wangwangID.Size = new System.Drawing.Size(141, 21);
            this.wangwangID.TabIndex = 86;
            // 
            // textBoxPartnerName
            // 
            this.textBoxPartnerName.Location = new System.Drawing.Point(306, 90);
            this.textBoxPartnerName.Name = "textBoxPartnerName";
            this.textBoxPartnerName.Size = new System.Drawing.Size(173, 21);
            this.textBoxPartnerName.TabIndex = 88;
            this.textBoxPartnerName.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(235, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 89;
            this.label3.Text = "合作企业：";
            this.label3.Visible = false;
            // 
            // buttonAddChannel
            // 
            this.buttonAddChannel.Font = new System.Drawing.Font("SimSun", 9F);
            this.buttonAddChannel.Location = new System.Drawing.Point(404, 55);
            this.buttonAddChannel.Name = "buttonAddChannel";
            this.buttonAddChannel.Size = new System.Drawing.Size(75, 20);
            this.buttonAddChannel.TabIndex = 90;
            this.buttonAddChannel.Text = "新增渠道";
            this.buttonAddChannel.UseVisualStyleBackColor = true;
            this.buttonAddChannel.Click += new System.EventHandler(this.buttonAddChannel_Click);
            // 
            // comboBoxStore
            // 
            this.comboBoxStore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStore.FormattingEnabled = true;
            this.comboBoxStore.Location = new System.Drawing.Point(304, 149);
            this.comboBoxStore.Name = "comboBoxStore";
            this.comboBoxStore.Size = new System.Drawing.Size(110, 20);
            this.comboBoxStore.TabIndex = 91;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(233, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 92;
            this.label5.Text = "预约店面：";
            // 
            // CustomerAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 322);
            this.Controls.Add(this.comboBoxStore);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonAddChannel);
            this.Controls.Add(this.textBoxPartnerName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxCity);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.wangwangID);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.comboBoxChannel);
            this.Controls.Add(this.memo);
            this.Controls.Add(this.brideContact);
            this.Controls.Add(this.brideName);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CustomerAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "新增客户";
            this.Load += new System.EventHandler(this.CMAddCustomer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.TextBox brideName;
        private System.Windows.Forms.TextBox brideContact;
        private System.Windows.Forms.TextBox memo;
        private System.Windows.Forms.ComboBox comboBoxChannel;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.ComboBox comboBoxCity;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TextBox wangwangID;
        private System.Windows.Forms.TextBox textBoxPartnerName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonAddChannel;
        private System.Windows.Forms.ComboBox comboBoxStore;
        private System.Windows.Forms.Label label5;
    }
}