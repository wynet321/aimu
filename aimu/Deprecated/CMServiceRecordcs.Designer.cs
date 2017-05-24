namespace aimu
{
    partial class CMServiceRecordcs
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
            this.label28 = new System.Windows.Forms.Label();
            this.customerID = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.infoChannel = new System.Windows.Forms.ComboBox();
            this.cbCity = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.memo = new System.Windows.Forms.TextBox();
            this.brideContact = new System.Windows.Forms.TextBox();
            this.brideName = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbTaoBaoWangWang = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(64, 212);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(65, 12);
            this.label28.TabIndex = 52;
            this.label28.Text = "预约店面：";
            // 
            // customerID
            // 
            this.customerID.Location = new System.Drawing.Point(218, 18);
            this.customerID.Name = "customerID";
            this.customerID.ReadOnly = true;
            this.customerID.Size = new System.Drawing.Size(263, 21);
            this.customerID.TabIndex = 1;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(64, 24);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(65, 12);
            this.label26.TabIndex = 50;
            this.label26.Text = "新娘编号：";
            // 
            // infoChannel
            // 
            this.infoChannel.FormattingEnabled = true;
            this.infoChannel.Items.AddRange(new object[] {
            "淘宝",
            "大众点评",
            "老客户转介绍",
            "异业合作",
            "回客",
            "微博",
            "微信",
            "京东",
            "天猫",
            "婚博会",
            "其他"});
            this.infoChannel.Location = new System.Drawing.Point(218, 164);
            this.infoChannel.Name = "infoChannel";
            this.infoChannel.Size = new System.Drawing.Size(263, 20);
            this.infoChannel.TabIndex = 5;
            this.infoChannel.Text = "淘宝";
            // 
            // cbCity
            // 
            this.cbCity.FormattingEnabled = true;
            this.cbCity.Items.AddRange(new object[] {
            "北京",
            "天津",
            "沈阳",
            "成都",
            "乌鲁木齐",
            "西安",
            "重庆",
            "合肥",
            "武汉",
            "珠海",
            "哈尔滨",
            "昆明",
            "长沙",
            "郑州",
            "霸州",
            "齐齐哈尔",
            "包头",
            "宿州",
            "平顶山",
            "徐州",
            "焦作"});
            this.cbCity.Location = new System.Drawing.Point(218, 204);
            this.cbCity.Name = "cbCity";
            this.cbCity.Size = new System.Drawing.Size(263, 20);
            this.cbCity.TabIndex = 6;
            this.cbCity.Text = "北京";
            this.cbCity.SelectedIndexChanged += new System.EventHandler(this.cbCity_SelectedIndexChanged);
            this.cbCity.TextChanged += new System.EventHandler(this.cbCity_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(64, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 33;
            this.label4.Text = "渠道：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 12);
            this.label2.TabIndex = 30;
            this.label2.Text = "*新娘联系方式：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 28;
            this.label1.Text = "*新娘姓名：";
            // 
            // memo
            // 
            this.memo.Location = new System.Drawing.Point(218, 266);
            this.memo.Multiline = true;
            this.memo.Name = "memo";
            this.memo.Size = new System.Drawing.Size(263, 129);
            this.memo.TabIndex = 7;
            // 
            // brideContact
            // 
            this.brideContact.Location = new System.Drawing.Point(218, 96);
            this.brideContact.Name = "brideContact";
            this.brideContact.Size = new System.Drawing.Size(263, 21);
            this.brideContact.TabIndex = 3;
            // 
            // brideName
            // 
            this.brideName.Location = new System.Drawing.Point(218, 59);
            this.brideName.Name = "brideName";
            this.brideName.Size = new System.Drawing.Size(263, 21);
            this.brideName.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(409, 435);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(72, 59);
            this.button2.TabIndex = 46;
            this.button2.Text = "返回";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(218, 435);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 59);
            this.button1.TabIndex = 43;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(64, 269);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 42;
            this.label8.Text = "备注：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 54;
            this.label3.Text = "*旺旺名：";
            // 
            // tbTaoBaoWangWang
            // 
            this.tbTaoBaoWangWang.Location = new System.Drawing.Point(218, 132);
            this.tbTaoBaoWangWang.Name = "tbTaoBaoWangWang";
            this.tbTaoBaoWangWang.Size = new System.Drawing.Size(263, 21);
            this.tbTaoBaoWangWang.TabIndex = 4;
            // 
            // CMServiceRecordcs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 527);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbTaoBaoWangWang);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.customerID);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.infoChannel);
            this.Controls.Add(this.cbCity);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.memo);
            this.Controls.Add(this.brideContact);
            this.Controls.Add(this.brideName);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label8);
            this.Name = "CMServiceRecordcs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "艾慕客服-客户录入";
            this.Load += new System.EventHandler(this.CMServiceRecordcs_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox customerID;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.ComboBox infoChannel;
        private System.Windows.Forms.ComboBox cbCity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox memo;
        private System.Windows.Forms.TextBox brideContact;
        private System.Windows.Forms.TextBox brideName;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbTaoBaoWangWang;
    }
}