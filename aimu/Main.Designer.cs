namespace aimu
{
    partial class Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.buttonDressManagement = new System.Windows.Forms.Button();
            this.buttonOrderManagement = new System.Windows.Forms.Button();
            this.buttonCustomerManagement = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelVersion = new System.Windows.Forms.Label();
            this.labelOrderStatistic = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonDressManagement
            // 
            this.buttonDressManagement.Location = new System.Drawing.Point(626, 570);
            this.buttonDressManagement.Name = "buttonDressManagement";
            this.buttonDressManagement.Size = new System.Drawing.Size(100, 30);
            this.buttonDressManagement.TabIndex = 2;
            this.buttonDressManagement.Text = "商品管理";
            this.buttonDressManagement.UseVisualStyleBackColor = true;
            this.buttonDressManagement.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // buttonOrderManagement
            // 
            this.buttonOrderManagement.Location = new System.Drawing.Point(732, 570);
            this.buttonOrderManagement.Name = "buttonOrderManagement";
            this.buttonOrderManagement.Size = new System.Drawing.Size(100, 30);
            this.buttonOrderManagement.TabIndex = 3;
            this.buttonOrderManagement.Text = "订单管理";
            this.buttonOrderManagement.UseVisualStyleBackColor = true;
            this.buttonOrderManagement.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonCustomerManagement
            // 
            this.buttonCustomerManagement.Location = new System.Drawing.Point(520, 570);
            this.buttonCustomerManagement.Name = "buttonCustomerManagement";
            this.buttonCustomerManagement.Size = new System.Drawing.Size(100, 30);
            this.buttonCustomerManagement.TabIndex = 1;
            this.buttonCustomerManagement.Text = "客户管理";
            this.buttonCustomerManagement.UseVisualStyleBackColor = true;
            this.buttonCustomerManagement.Click += new System.EventHandler(this.button7_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(838, 570);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(100, 30);
            this.buttonExit.TabIndex = 4;
            this.buttonExit.Text = "退出";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.button6_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(984, 662);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.labelVersion);
            this.panel1.Controls.Add(this.labelOrderStatistic);
            this.panel1.Controls.Add(this.buttonCustomerManagement);
            this.panel1.Controls.Add(this.buttonOrderManagement);
            this.panel1.Controls.Add(this.buttonDressManagement);
            this.panel1.Controls.Add(this.buttonExit);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(984, 662);
            this.panel1.TabIndex = 5;
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Location = new System.Drawing.Point(12, 641);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(0, 12);
            this.labelVersion.TabIndex = 6;
            // 
            // labelOrderStatistic
            // 
            this.labelOrderStatistic.AutoSize = true;
            this.labelOrderStatistic.Location = new System.Drawing.Point(730, 630);
            this.labelOrderStatistic.Name = "labelOrderStatistic";
            this.labelOrderStatistic.Size = new System.Drawing.Size(0, 12);
            this.labelOrderStatistic.TabIndex = 5;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 662);
            this.Controls.Add(this.panel1);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "艾慕婚纱管理系统v1.0";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonOrderManagement;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonCustomerManagement;
        private System.Windows.Forms.Button buttonDressManagement;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelOrderStatistic;
        private System.Windows.Forms.Label labelVersion;
    }
}

