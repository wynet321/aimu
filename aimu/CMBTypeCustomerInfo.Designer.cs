namespace aimu
{
    partial class CMBTypeCustomerInfo
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
            this.cbTryDress = new System.Windows.Forms.ComboBox();
            this.dtReserveTime = new System.Windows.Forms.DateTimePicker();
            this.dtReserveDate = new System.Windows.Forms.DateTimePicker();
            this.dtMarryDay = new System.Windows.Forms.DateTimePicker();
            this.tbMemo = new System.Windows.Forms.TextBox();
            this.tbInfoChannel = new System.Windows.Forms.TextBox();
            this.tbBrideContact = new System.Windows.Forms.TextBox();
            this.tbBrideName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbHisReason = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.tbCustomerID = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbReason = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbTryDress
            // 
            this.cbTryDress.FormattingEnabled = true;
            this.cbTryDress.Items.AddRange(new object[] {
            "是",
            "否"});
            this.cbTryDress.Location = new System.Drawing.Point(134, 277);
            this.cbTryDress.Name = "cbTryDress";
            this.cbTryDress.Size = new System.Drawing.Size(219, 20);
            this.cbTryDress.TabIndex = 34;
            this.cbTryDress.Text = "是";
            // 
            // dtReserveTime
            // 
            this.dtReserveTime.CustomFormat = "HH:mm:ss";
            this.dtReserveTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtReserveTime.Location = new System.Drawing.Point(134, 242);
            this.dtReserveTime.Name = "dtReserveTime";
            this.dtReserveTime.ShowUpDown = true;
            this.dtReserveTime.Size = new System.Drawing.Size(219, 21);
            this.dtReserveTime.TabIndex = 33;
            // 
            // dtReserveDate
            // 
            this.dtReserveDate.Location = new System.Drawing.Point(134, 200);
            this.dtReserveDate.Name = "dtReserveDate";
            this.dtReserveDate.Size = new System.Drawing.Size(219, 21);
            this.dtReserveDate.TabIndex = 32;
            // 
            // dtMarryDay
            // 
            this.dtMarryDay.Location = new System.Drawing.Point(134, 120);
            this.dtMarryDay.Name = "dtMarryDay";
            this.dtMarryDay.Size = new System.Drawing.Size(219, 21);
            this.dtMarryDay.TabIndex = 31;
            // 
            // tbMemo
            // 
            this.tbMemo.Location = new System.Drawing.Point(134, 319);
            this.tbMemo.Multiline = true;
            this.tbMemo.Name = "tbMemo";
            this.tbMemo.ReadOnly = true;
            this.tbMemo.Size = new System.Drawing.Size(228, 65);
            this.tbMemo.TabIndex = 30;
            // 
            // tbInfoChannel
            // 
            this.tbInfoChannel.Location = new System.Drawing.Point(134, 159);
            this.tbInfoChannel.Name = "tbInfoChannel";
            this.tbInfoChannel.Size = new System.Drawing.Size(219, 21);
            this.tbInfoChannel.TabIndex = 29;
            // 
            // tbBrideContact
            // 
            this.tbBrideContact.Location = new System.Drawing.Point(134, 90);
            this.tbBrideContact.Name = "tbBrideContact";
            this.tbBrideContact.Size = new System.Drawing.Size(219, 21);
            this.tbBrideContact.TabIndex = 28;
            // 
            // tbBrideName
            // 
            this.tbBrideName.Location = new System.Drawing.Point(134, 55);
            this.tbBrideName.Name = "tbBrideName";
            this.tbBrideName.Size = new System.Drawing.Size(219, 21);
            this.tbBrideName.TabIndex = 27;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 322);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 26;
            this.label8.Text = "备注：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 277);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 25;
            this.label7.Text = "是否试妆：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 242);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 12);
            this.label6.TabIndex = 24;
            this.label6.Text = "预约到店时间：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 206);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 23;
            this.label5.Text = "预约到店日期：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 22;
            this.label4.Text = "渠道：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 21;
            this.label3.Text = "婚期：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 20;
            this.label2.Text = "新娘联系方式：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 19;
            this.label1.Text = "新娘姓名：";
            // 
            // tbHisReason
            // 
            this.tbHisReason.Enabled = false;
            this.tbHisReason.Location = new System.Drawing.Point(517, 62);
            this.tbHisReason.Multiline = true;
            this.tbHisReason.Name = "tbHisReason";
            this.tbHisReason.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbHisReason.Size = new System.Drawing.Size(356, 457);
            this.tbHisReason.TabIndex = 36;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(422, 38);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 12);
            this.label9.TabIndex = 35;
            this.label9.Text = "历史原因记录：";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(134, 547);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 46);
            this.button1.TabIndex = 37;
            this.button1.Text = "预约成功";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(305, 547);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(84, 46);
            this.button2.TabIndex = 38;
            this.button2.Text = "未预约成功";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(485, 547);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(84, 46);
            this.button3.TabIndex = 39;
            this.button3.Text = "客户已流失";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(659, 547);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(84, 46);
            this.button4.TabIndex = 40;
            this.button4.Text = "返回";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // tbCustomerID
            // 
            this.tbCustomerID.Location = new System.Drawing.Point(134, 12);
            this.tbCustomerID.Name = "tbCustomerID";
            this.tbCustomerID.ReadOnly = true;
            this.tbCustomerID.Size = new System.Drawing.Size(219, 21);
            this.tbCustomerID.TabIndex = 42;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(24, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 41;
            this.label10.Text = "客户编号：";
            // 
            // tbReason
            // 
            this.tbReason.Location = new System.Drawing.Point(134, 402);
            this.tbReason.Multiline = true;
            this.tbReason.Name = "tbReason";
            this.tbReason.Size = new System.Drawing.Size(228, 117);
            this.tbReason.TabIndex = 44;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(24, 402);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 43;
            this.label11.Text = "原因：";
            // 
            // CMBTypeCustomerInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 614);
            this.Controls.Add(this.tbReason);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tbCustomerID);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbHisReason);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cbTryDress);
            this.Controls.Add(this.dtReserveTime);
            this.Controls.Add(this.dtReserveDate);
            this.Controls.Add(this.dtMarryDay);
            this.Controls.Add(this.tbMemo);
            this.Controls.Add(this.tbInfoChannel);
            this.Controls.Add(this.tbBrideContact);
            this.Controls.Add(this.tbBrideName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CMBTypeCustomerInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "B类客户信息";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbTryDress;
        private System.Windows.Forms.DateTimePicker dtReserveTime;
        private System.Windows.Forms.DateTimePicker dtReserveDate;
        private System.Windows.Forms.DateTimePicker dtMarryDay;
        private System.Windows.Forms.TextBox tbMemo;
        private System.Windows.Forms.TextBox tbInfoChannel;
        private System.Windows.Forms.TextBox tbBrideContact;
        private System.Windows.Forms.TextBox tbBrideName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbHisReason;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox tbCustomerID;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbReason;
        private System.Windows.Forms.Label label11;
    }
}